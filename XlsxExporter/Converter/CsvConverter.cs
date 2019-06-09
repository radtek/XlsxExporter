using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using XlsxText;

namespace XlsxExporter.Converter
{
    class CsvConverter : Converter
    {
        private Dictionary<string, Dictionary<string, string>> _csvData = new Dictionary<string, Dictionary<string, string>>();
        public override void Convert(Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>> xlsxData, OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
            _csvData.Clear();
            if (xlsxData == null) return;

            /**
             * 文件的读取状态，0 未转，1 在转，2 转完
             */
            Dictionary<string, int> xlsxStatus = new Dictionary<string, int>();
            foreach (var xlsx in xlsxData)
            {
                xlsxStatus.Add(xlsx.Key, 0);
                _csvData.Add(xlsx.Key, new Dictionary<string, string>());
            }

            bool isOnCompletedCalled = false;
            ThreadStart convertAsync = delegate
            {
                foreach (var xlsx in xlsxData)
                {
                    string file = xlsx.Key;
                    Dictionary<string, List<List<XlsxTextCell>>> data = xlsx.Value;

                    if (xlsxStatus[file] == 0)
                    {
                        xlsxStatus[file] = 1;

                        onStatus?.Invoke(null, "正在转换CSV... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0 / xlsxStatus.Count + "");
                        int sheetCount = 0;
                        foreach (var sheet in data)
                        {
                            ++sheetCount;
                            int cellCount = 0, sheetCellCount = 0;
                            foreach (var row in sheet.Value)
                                sheetCellCount += row.Count;

                            StringBuilder expr = new StringBuilder();
                            foreach (var row in sheet.Value)
                            {
                                bool isFirstCell = true;
                                foreach (var cell in row)
                                {
                                    StringBuilder value = new StringBuilder(cell.Value);
                                    //字段中若包含回车换行符、双引号或者逗号，该字段需要用双引号括起来。
                                    if (cell.Value.IndexOf(',') != -1 || cell.Value.IndexOf('"') != -1 || cell.Value.IndexOf('\r') != -1 || cell.Value.IndexOf('\n') != -1)
                                    {
                                        value.Replace("\"", "\"\"");
                                        value.Insert(0, '"');
                                        value.Append('"');
                                    }

                                    if (!isFirstCell) expr.Append(',');
                                    else isFirstCell = false;
                                    expr.Append(value.ToString());

                                    ++cellCount;
                                    onStatus?.Invoke(file, "正在转换CSV", "文件进度：" + sheetCount + "/" + data.Count + ", 表格：" + sheet.Key + ", 进度：" + (int)(cellCount * 100.0 / sheetCellCount) + " %");
                                }
                                expr.Append('\n');
                            }
                            if (expr.Length > 0)
                                _csvData[file].Add(sheet.Key, expr.ToString());
                        }

                        xlsxStatus[file] = 2;
                        onStatus?.Invoke(file, "转换CSV完成", null);
                        onStatus?.Invoke(null, "正在转换CSV... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count + "");
                    }
                }
                if (xlsxStatus.ToArray().Count(e => e.Value == 2) == xlsxStatus.Count && !isOnCompletedCalled)
                {
                    isOnCompletedCalled = true;
                    Save(onCompleted, onStatus);
                    onStatus?.Invoke(null, "转换CSV完成", null);
                }
            };

            for (int i = 0; i < Math.Min(Config.ExportThreadCount, xlsxStatus.Keys.Count); ++i)
            {
                var thread = new Thread(convertAsync);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        protected override void Save(OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
            /**
             * 文件的读取状态，0 未保存，1 在保存，2 已保存
             */
            Dictionary<string, int> xlsxStatus = new Dictionary<string, int>();
            foreach (var xlsx in _csvData)
                xlsxStatus.Add(xlsx.Key, 0);

            string error = null;
            List<Thread> saveThreads = new List<Thread>();
            ThreadStart saveAsync = delegate
            {
                foreach (var xlsx in _csvData)
                {
                    if (error != null) return;

                    string file = xlsx.Key;
                    if (xlsxStatus[file] == 0)
                    {
                        xlsxStatus[file] = 1;

                        onStatus?.Invoke(null, "正在保存CSV... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0 / xlsxStatus.Count + "");
                        int sheetCount = 0;
                        foreach (var sheet in xlsx.Value)
                        {
                            ++sheetCount;
                            onStatus?.Invoke(file, "正在保存CSV", "文件进度：" + sheetCount + "/" + xlsx.Value.Count + ", 表格：" + sheet.Key + ", 进度：正在保存...");

                            if (error != null)
                            {
                                onStatus?.Invoke(file, "保存CSV中断", null);
                                return;
                            }

                            try
                            {
                                using (StreamWriter writer = new StreamWriter(Config.ExportDir + "/" + sheet.Key + ".csv"))
                                {
                                    writer.Write(sheet.Value);
                                }
                            }
                            catch (Exception e)
                            {
                                if (error != null)
                                {
                                    onStatus?.Invoke(file, "保存CSV中断", null);
                                    return;
                                }

                                error = e.Message;
                                onStatus?.Invoke(file, "保存CSV出错", "文件进度：" + sheetCount + "/" + xlsx.Value.Count + ", 表格：" + sheet.Key + "保存失败: " + e.Message, true);
                                onStatus?.Invoke(null, "保存CSV出错。文件进度：" + sheetCount + "/" + xlsx.Value.Count + ", 表格：" + sheet.Key + "保存失败: " + e.Message, null, true);

                                Debug.Print("保存CSV中断, 等待线程结束，剩余线程个数：" + saveThreads.Count(thread => thread.IsAlive));
                                while (saveThreads.Count(thread => thread.IsAlive) > 1) /** 等待其他线程结束 */;

                                onCompleted?.Invoke(false);
                                onCompleted = null;
                                return;
                            }
                            onStatus?.Invoke(file, "正在保存CSV", "文件进度：" + sheetCount + "/" + xlsx.Value.Count + ", 表格：" + sheet.Key + ", 进度：保存完成");
                        }

                        xlsxStatus[file] = 2;
                        onStatus?.Invoke(file, "保存CSV完成", null);
                        onStatus?.Invoke(null, "正在保存CSV... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count + "");
                    }
                }
                if (xlsxStatus.ToArray().Count(e => e.Value == 2) == xlsxStatus.Count)
                {
                    Debug.Print("保存CSV完成, 剩余线程个数：" + saveThreads.Count(thread => thread.IsAlive));
                    onStatus?.Invoke(null, "保存CSV完成", null);

                    onCompleted?.Invoke(true);
                    onCompleted = null;
                }
            };

            for (int i = 0; i < Math.Min(Config.ExportThreadCount, xlsxStatus.Keys.Count); ++i)
            {
                var thread = new Thread(saveAsync);
                thread.IsBackground = true;
                saveThreads.Add(thread);
                thread.Start();
            }
        }
    }
}
