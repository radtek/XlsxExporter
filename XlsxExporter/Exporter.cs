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
    public interface IProgresser
    {
        void OnProgress(string file, string status, string progress);
    }

    public class Exporter : IDisposable
    {
        /// <summary>
        /// Xlsx数据
        /// </summary>
        private Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>> _xlsxData = new Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>>();
        /// <summary>
        /// 进度视图
        /// </summary>
        public IProgresser View { get; private set; }

        public Exporter(IProgresser view)
        {
            View = view;
        }
        /// <summary>
        /// 加载
        /// </summary>
        public void Load()
        {
            Clear();
            var importDir = new DirectoryInfo(Config.ImportDir);
            if (importDir.Exists)
            {
                foreach (var fileInfo in importDir.GetFiles("*.xlsx"))
                {
                    _xlsxData.Add(fileInfo.FullName,  new Dictionary<string, List<List<XlsxTextCell>>>());
                    View.OnProgress(fileInfo.FullName, "就绪", "");
                }
            }
            View.OnProgress(null, "就绪", "0");
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export(Action onCompleted)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            read(() =>
            {
                _readThreads.Clear();
                new CsvConverter().Convert(_xlsxData, new Action(() =>
                {
                    onCompleted?.Invoke();
                    sw.Stop();
                    Console.WriteLine("读取完成！总共花费{0}ms.", sw.Elapsed.TotalMilliseconds);
                }), View);
            });
        }

        private List<Thread> _readThreads = new List<Thread>();
        private void read(Action onCompleted)
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

            ThreadStart readAsync = delegate
            {
                foreach (var xlsx in _xlsxData)
                {
                    string file = xlsx.Key;
                    Dictionary<string, List<List<XlsxTextCell>>> data = xlsx.Value;

                    if (xlsxStatus[file] == 0)
                    {
                        xlsxStatus[file] = 1;

                        View.OnProgress(null, "正在读取... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0 / xlsxStatus.Count + "");
                        View.OnProgress(file, "正在读取 ", "正在分析...");
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
                                        View.OnProgress(file, "正在读取", "文件进度：" + sheetCount + "/" + xlsxReader.SheetsCount + ", 表格：" + sheetReader.Name + ", 进度：" + (int)(cellCount * 100.0 / sheetReader.CellCount) + " %");
                                    }
                                    sheet.Add(row);
                                }
                                data.Add(sheetReader.Name, sheet);
                            }
                        }

                        xlsxStatus[file] = 2;
                        View.OnProgress(file, "读取完成", null);
                        View.OnProgress(null, "正在读取... ", xlsxStatus.ToArray().Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count + "");
                    }
                }
                if (xlsxStatus.ToArray().Count(e => e.Value == 2) == xlsxStatus.Count)
                {
                    View.OnProgress(null, "读取完成", null);
                    onCompleted?.Invoke();
                    onCompleted = null;
                }
            };

            _readThreads.Clear();
            for (int i = 0; i < Config.ExportThreadCount; ++i)
            {
                var thread = new Thread(readAsync);
                _readThreads.Add(thread);
                thread.Start();
            }
        }
        public void Clear()
        {
            foreach (var thread in _readThreads)
                thread.Abort();
            _readThreads.Clear();

            _xlsxData.Clear();
        }

        public void Dispose() => Clear();
    }
}
