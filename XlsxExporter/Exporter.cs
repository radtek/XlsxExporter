using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XlsxText;

namespace XlsxExporter
{
    public interface IExporterView
    {
        /// <summary>
        /// 任务视图
        /// </summary>
        DataGridView TaskView { get; }
        /// <summary>
        /// 状态
        /// </summary>
        string Status { set; }
        /// <summary>
        /// 进度(百分比)
        /// </summary>
        float Progress { set; }
    }
    public class Exporter : IDisposable
    {
        /// <summary>
        /// 任务数据
        /// </summary>
        private DataTable _taskViewData;

        public IExporterView View { get; private set; }
        public Exporter(IExporterView view)
        {
            View = view;
            View.TaskView.DataSource = _taskViewData = new DataTable();
            _taskViewData.Columns.Add("名 称");
            _taskViewData.Columns.Add("状 态");
            _taskViewData.Columns.Add("进 度");
            View.TaskView.Columns[0].MinimumWidth = 100;
            View.TaskView.Columns[0].FillWeight = 20;
            View.TaskView.Columns[1].MinimumWidth = 50;
            View.TaskView.Columns[1].FillWeight = 10;
            View.TaskView.Columns[2].FillWeight = 70;
        }

        /// <summary>
        /// 加载
        /// </summary>
        public void Load()
        {
            _taskViewData.Rows.Clear();
            _xlsxSheets.Clear();
            var importDir = new DirectoryInfo(Config.ImportDir);
            if (importDir.Exists)
            {
                foreach (var fileInfo in importDir.GetFiles("*.xlsx"))
                {
                    _taskViewData.Rows.Add(new string[] { fileInfo.Name, "就绪", "" });
                }
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export(Action onCompleted)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _updateUITimer = new System.Timers.Timer(100);
            _updateUITimer.Elapsed += new System.Timers.ElapsedEventHandler((object source, System.Timers.ElapsedEventArgs e) => UpdateUI());
            _updateUITimer.AutoReset = true;
            _updateUITimer.Enabled = true;

            read(() =>
            {
                _updateUITimer.Dispose();
                _readThreads.Clear();
                UpdateUI();
                onCompleted?.Invoke();
                sw.Stop();
                Console.WriteLine("读取完成！总共花费{0}ms.", sw.Elapsed.TotalMilliseconds);
            });
        }

        private List<Thread> _readThreads = new List<Thread>();
        private System.Timers.Timer _updateUITimer;

        private Dictionary<DataRow, Dictionary<string, List<List<XlsxTextCell>>>> _xlsxSheets = new Dictionary<DataRow, Dictionary<string, List<List<XlsxTextCell>>>>();
        private void read(Action onCompleted)
        {
            _onProgress[0] = "";
            _onProgress[1] = 0f;
            _onItemProgress.Clear();
            _onProgressCache[0] = "";
            _onProgressCache[1] = 0f;
            _onItemProgressCache.Clear();
            _xlsxSheets.Clear();

            /**
             * 文件的读取状态，0 未读，1 在读，2 读完
             */
            Dictionary<DataRow, int> xlsxStatus = new Dictionary<DataRow, int>();
            foreach (DataRow row in _taskViewData.Rows)
            {
                xlsxStatus.Add(row, 0);
                _xlsxSheets.Add(row, new Dictionary<string, List<List<XlsxTextCell>>>());
            }

            ThreadStart readAsync = delegate
            {
                foreach (var xlsx in _xlsxSheets)
                {
                    DataRow row = xlsx.Key;
                    bool isCanRead = false;
                    lock (xlsxStatus)
                    {
                        if (xlsxStatus[row] == 0)
                        {
                            isCanRead = true;
                            xlsxStatus[row] = 1;
                            _onItemProgress.Add(row, new string[2] { "", "" });
                            _onProgress[0] = "读取中... ";
                            _onProgress[1] = xlsxStatus.Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count;
                        }
                    }
                    if (isCanRead)
                    {
                        Dictionary<string, List<List<XlsxTextCell>>> sheets = xlsx.Value;
                        _onItemProgress[row][0] = "读取中";
                        using (XlsxTextReader xlsxReader = XlsxTextReader.Create(Config.ImportDir + "/" + row[0]))
                        {
                            int sheetCount = 0;
                            while (xlsxReader.Read())
                            {
                                ++sheetCount;
                                long cellCount = 0;

                                List<List<XlsxTextCell>> sheet = new List<List<XlsxTextCell>>();
                                XlsxTextSheetReader sheetReader = xlsxReader.SheetReader;
                                while (sheetReader.Read())
                                {
                                    List<XlsxTextCell> sheetRow = new List<XlsxTextCell>();
                                    foreach (var cell in sheetReader.Row)
                                    {
                                        sheetRow.Add(cell);
                                        ++cellCount;
                                        _onItemProgress[row][0] = "读取中";
                                        _onItemProgress[row][1] = "文件进度：" + sheetCount + "/" + xlsxReader.SheetsCount + ", 表格进度：" + (int)(cellCount * 1.0 / sheetReader.CellCount * 100) + "%";
                                    }
                                    sheet.Add(sheetRow);
                                }

                                sheets.Add(sheetReader.Name, sheet);
                            }
                        }
                        _onItemProgress[row][0] = "读取完成";

                        xlsxStatus[row] = 2;
                        _onProgress[0] = "读取中... ";
                        _onProgress[1] = xlsxStatus.Count(e => e.Value == 2) * 1.0f / xlsxStatus.Count;
                    }
                }
                if (xlsxStatus.Count(e => e.Value == 2) == xlsxStatus.Count)
                {
                    _onProgress[0] = "读取完成";
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

        private object[] _onProgress = new object[2] { "", 0f };
        private object[] _onProgressCache = new object[2] { "", 0f };
        private Dictionary<DataRow, string[]> _onItemProgress = new Dictionary<DataRow, string[]>();
        private Dictionary<DataRow, string[]> _onItemProgressCache = new Dictionary<DataRow, string[]>();
        public void UpdateUI()
        {
            if (_onProgress[0] != _onProgressCache[0])
            {
                _onProgressCache[0] = _onProgress[0];
                View.Status = (string)_onProgress[0];
            }
            if (_onProgress[1] != _onProgressCache[1])
            {
                _onProgressCache[1] = _onProgress[1];
                View.Progress = (float)_onProgress[1];
            }
            foreach (var item in _onItemProgress)
            {
                if (_onItemProgressCache.TryGetValue(item.Key, out string[] values))
                {
                    if (item.Value[0] != values[0])
                    {
                        values[0] = item.Value[0];
                        item.Key[1] = item.Value[0];
                    }
                    if (item.Value[1] != values[1])
                    {
                        values[1] = item.Value[1];
                        item.Key[2] = item.Value[1];
                    }
                }
                else
                {
                    item.Key[1] = item.Value[0];
                    item.Key[2] = item.Value[1];
                    _onItemProgressCache.Add(item.Key, new string[2] { item.Value[0], item.Value[1] });
                }
            }
        }
        public void Clear()
        {
            foreach (var thread in _readThreads)
                thread.Abort();
            _readThreads.Clear();
            _updateUITimer?.Dispose();

            _onProgress[0] = "";
            _onProgress[1] = 0f;
            _onItemProgress.Clear();
            _onProgressCache[0] = "";
            _onProgressCache[1] = 0f;
            _onItemProgressCache.Clear();

            _taskViewData.Clear();
            _xlsxSheets.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
