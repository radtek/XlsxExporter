using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using XlsxExporter.Converter;
using XlsxText;

namespace XlsxExporter
{
    /**
     * bool   ==> bool
     * uint8  ==> byte,   int8    ==> sbyte
     * uint16 ==> ushort, int16   ==> short
     * uint32 ==> uint,   int32   ==> int
     * uint64 ==> ulong,  int64   ==> long
     * float  ==> float,  float64 ==> double
     * string ==> string,
     */
    //using bool = System.Boolean;
    using uint8 = System.Byte;
    using int8 = System.SByte;
    using uint16 = System.UInt16;
    using int16 = System.Int16;
    using uint32 = System.UInt32;
    using int32 = System.Int32;
    using uint64 = System.UInt64;
    using int64 = System.Int64;
    //using float = System.Single;
    using float64 = System.Double;

    public delegate void OnCompletedHandler(bool isOk);
    public delegate void OnStatusHandler(string file, string status, string progress, bool isError = false);

    public class Exporter
    {
        /// <summary>
        /// Xlsx文件路径
        /// </summary>
        private List<string> _paths = new List<string>();
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="onStatus">状态回调</param>
        /// <returns></returns>
        public List<string> Load(OnStatusHandler onStatus)
        {
            _paths.Clear();
            var importDir = new DirectoryInfo(Config.ImportDir);
            if (importDir.Exists)
            {
                foreach (var fileInfo in importDir.GetFiles("*.xlsx"))
                {
                    _paths.Add(fileInfo.FullName);
                    onStatus?.Invoke(fileInfo.FullName, "就绪", "");
                }
            }
            onStatus?.Invoke(null, "载入完成  一共" + _paths.Count + "个文件", "-1");

            return _paths;
        }

        /// <summary>
        /// 全部导出
        /// </summary>
        /// <param name="onCompleted">完成回调</param>
        /// <param name="onStatus">状态</param>
        public void ExportAll(OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
            // 文件的状态，0 未处理，1 处理中，2 处理完
            Dictionary<string, int> status = _paths.ToDictionary(path => path, _ => 0);
            for (int i = 0; i < Math.Min(Config.ExportThreadCount, status.Count); ++i)
            {
                bool isBreak = false;
                int threadCount = 0;
                var thread = new Thread(() =>
                {
                    ++threadCount;

                    foreach (var path in status.Keys.ToArray())
                    {
                        if (isBreak) break;
                        if (status[path] == 0)
                        {
                            status[path] = 1;
                            onStatus?.Invoke(null, "正在处理...", status.Values.ToArray().Count(e => e == 2) * 1.0 / status.Count + "");
                            Export(path, isOk =>
                            {
                                isBreak = !isOk;
                                if (isOk)
                                {
                                    status[path] = 2;
                                    onStatus?.Invoke(null, "正在处理...", status.Values.ToArray().Count(e => e == 2) * 1.0 / status.Count + "");
                                }
                            }, onStatus);
                        }
                    }

                    --threadCount;
                    if (threadCount == 0)
                    {
                        onStatus?.Invoke(null, isBreak ? "中断" : "完成", null, isBreak);
                        onCompleted?.Invoke(!isBreak);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="path">xlsx文件路径</param>
        /// <param name="onCompleted">完成回调</param>
        /// <param name="onStatus">状态</param>
        public void Export(string path, OnCompletedHandler onCompleted, OnStatusHandler onStatus)
        {
            onStatus?.Invoke(path, "正在处理", "正在分析...");
            using (Workbook workbook = new Workbook(path))
            {
                int sheetIndex = 0;
                while (workbook.Read(out var worksheet))
                {
                    ++sheetIndex;

                    List<List<object>> sheet = new List<List<object>>();

                    /** 读取校验 */
                    int rowIndex = 0;
                    onStatus?.Invoke(path, "正在处理", string.Format("表({0}/{1}), 正在读取, 表: {2}, 行({3}/{4})", sheetIndex, workbook.WorksheetCount, worksheet.Name, rowIndex, worksheet.RowCount));
                    while (worksheet.Read(out var row))
                    {
                        ++rowIndex;
                        List<object> sheetRow = new List<object>();
                        foreach (var cell in row)
                        {
                            /** 校验单元格数据 */
                            //

                            sheetRow.Add(cell.Value);
                        }
                        if (sheetRow.Count > 0) sheet.Add(sheetRow);

                        onStatus?.Invoke(path, "正在处理", string.Format("表({0}/{1}), 正在读取, 表: {2}, 行({3}/{4})", sheetIndex, workbook.WorksheetCount, worksheet.Name, rowIndex, worksheet.RowCount));
                    }

                    /** 转换 */
                    if (new CsvConverter(path, worksheet.Name, string.Format("表({0}/{1}), 正在转换CSV, 表: {2}, ", sheetIndex, workbook.WorksheetCount, worksheet.Name) + "{0}").Convert(sheet, out string csvData, onStatus))
                    {
                        using (var stream = new FileStream(Config.ExportDir + "/" + worksheet.Name + ".csv", FileMode.Create))
                        {
                            var writer = new StreamWriter(stream, new System.Text.UTF8Encoding(false));
                            writer.Write(csvData);
                            writer.Flush();
                            writer.Close();
                        }
                    }
                }

                onStatus?.Invoke(path, "完成", null);
                onCompleted?.Invoke(true);
            }
        }
    }
}
