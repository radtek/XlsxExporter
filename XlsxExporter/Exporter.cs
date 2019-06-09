using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using XlsxExporter.Converter;
using XlsxText;

namespace XlsxExporter
{
    public delegate void OnCompletedHandler(bool isOk);
    public delegate void OnStatusHandler(string file, string status, string progress, bool isError = false);

    public class Exporter
    {
        /// <summary>
        /// Xlsx数据
        /// </summary>
        private Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>> _xlsxData = new Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>>();
        /// <summary>
        /// 进度视图
        /// </summary>
        /// <summary>
        /// 加载
        /// </summary>
        public void Load(OnStatusHandler onStatus)
        {
            _xlsxData.Clear();
            var importDir = new DirectoryInfo(Config.ImportDir);
            if (importDir.Exists)
            {
                foreach (var fileInfo in importDir.GetFiles("*.xlsx"))
                {
                    _xlsxData.Add(fileInfo.FullName, new Dictionary<string, List<List<XlsxTextCell>>>());
                    onStatus?.Invoke(fileInfo.FullName, "就绪", "");
                }
            }
            onStatus?.Invoke(null, "就绪", "0");
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export(OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            Read(isOk1 =>
            {
                if (isOk1)
                {
                    new CsvConverter().Convert(_xlsxData, isOk2 =>
                    {
                        onCompleted?.Invoke(isOk2);
#if DEBUG
                        sw.Stop();
                        Debug.Print("读取完成！总共花费" + sw.Elapsed.TotalMilliseconds + "ms");
#endif
                    }, onStatus);
                }
            }, onStatus);
        }

        public void Read(OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
            /**
             * 文件的读取状态，0 未读，1 在读，2 读完
             */
            Dictionary<string, int> xlsxStatus = new Dictionary<string, int>();
            foreach (var xlsx in _xlsxData)
            {
                xlsxStatus.Add(xlsx.Key, 0);
                xlsx.Value.Clear();
            }

            string error = null;
            List<Thread> readThreads = new List<Thread>();
            ThreadStart readAsync = delegate
            {
                foreach (var xlsx in _xlsxData)
                {
                    if (error != null) return;

                    string file = xlsx.Key;
                    Dictionary<string, List<List<XlsxTextCell>>> data = xlsx.Value;
                    if (xlsxStatus[file] == 0)
                    {
                        xlsxStatus[file] = 1;
                        onStatus?.Invoke(null, "正在读取... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0 / xlsxStatus.Count + "");
                        onStatus?.Invoke(file, "正在读取 ", "正在分析...");

                        try
                        {
                            using (XlsxTextReader xlsxReader = XlsxTextReader.Create(file))
                            {
                                int sheetCount = 0;
                                while (xlsxReader.Read())
                                {
                                    ++sheetCount;
                                    List<List<XlsxTextCell>> sheet = new List<List<XlsxTextCell>>();
                                    long cellCount = 0;
                                    XlsxTextSheetReader sheetReader = xlsxReader.SheetReader;
                                    while (sheetReader.Read())
                                    {
                                        List<XlsxTextCell> row = new List<XlsxTextCell>();
                                        foreach (var cell in sheetReader.Row)
                                        {
                                            row.Add(cell);
                                            ++cellCount;
                                            onStatus?.Invoke(file, "正在读取", "文件进度：" + sheetCount + "/" + xlsxReader.SheetsCount + ", 表格：" + sheetReader.Name + ", 进度：" + (int)(cellCount * 100.0 / sheetReader.CellCount) + " %");

                                            if (error != null)
                                            {
                                                onStatus?.Invoke(file, "读取中断", null);
                                                return;
                                            }
                                        }
                                        sheet.Add(row);
                                    }
                                    data.Add(sheetReader.Name, sheet);
                                }
                            }
                        }
                        catch (Exception e)
                        {  
                            if (error != null)
                            {
                                onStatus?.Invoke(file, "读取中断", null);
                                return;
                            }

                            error = e.Message;
                            onStatus?.Invoke(file, "读取出错", error, true);
                            onStatus?.Invoke(null, "读取出错。" + error, null, true);

                            Debug.Print("读取中断, 等待线程结束，剩余线程个数：" + readThreads.Count(thread => thread.IsAlive));
                            while (readThreads.Count(thread => thread.IsAlive) > 1) /** 等待其他线程结束 */;

                            onCompleted?.Invoke(false);
                            onCompleted = null; 
                            return;
                        }

                        xlsxStatus[file] = 2;
                        onStatus?.Invoke(file, "读取完成", null);
                        onStatus?.Invoke(null, "正在读取... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count + "");
                    }
                }
                if (xlsxStatus.ToArray().Count(e => e.Value == 2) == xlsxStatus.Count)
                {
                    Debug.Print("读取完成, 剩余线程个数：" + readThreads.Count(thread => thread.IsAlive));
                    onStatus?.Invoke(null, "读取完成", null);

                    onCompleted?.Invoke(true);
                    onCompleted = null;
                }
            };

            for (int i = 0; i < Config.ExportThreadCount; ++i)
            {
                var thread = new Thread(readAsync);
                thread.IsBackground = true;
                readThreads.Add(thread);
                thread.Start();
            }
        }
    }
}
