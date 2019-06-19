using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace XlsxExporter
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 文件对应DataGridViewRow
        /// </summary>
        private readonly Dictionary<string, DataGridViewRow> _rows = new Dictionary<string, DataGridViewRow>();
        private readonly Exporter _exporter = new Exporter();

        public MainForm() => InitializeComponent();

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            _pb_progress.Visible = _lb_progressText.Visible = false;
            _tb_exportDir.Text = Config.ExportDir;

            _tm_updateUI.Tick += new EventHandler((_, _1) => UpdateUI());

            Reload();
        }

        private void OnBtnClick(object sender, EventArgs e)
        {
            if (sender == _btn_outBrowse)
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "选择输出文件夹：";
                    folderDialog.SelectedPath = Config.ExportDir;
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        _tb_exportDir.Text = folderDialog.SelectedPath;
                    }
                }
            }
            else if (sender == _btn_editConfig)
            {
                switch (new ConfigForm().ShowDialog(this))
                {
                    default:
                        _tb_exportDir.Text = Config.ExportDir;
                        Reload();
                        break;
                }
            }
            else if (sender == _btn_reloadConfig)
            {
                Reload();
            }
            else if (sender == _btn_export)
            {
                _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = false;
                _exporter.ExportAll(isOk => Invoke(new Action(() =>
                {
                    _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = true;
                    _tb_exportDir.Enabled = _btn_export.Enabled = isOk;
                })), OnStatus);
            }
        }

        private void Reload()
        {
            _rows.Clear();
            _dgv_task.Rows.Clear();
            foreach (var file in _exporter.Load(OnStatus))
            {
                var row = _dgv_task.Rows[_dgv_task.Rows.Add()];
                row.Cells[0].Value = Path.GetFileName(file);
                _rows.Add(file, row);
            }

            _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = true;
            _btn_export.Enabled = _rows.Count > 0;
        }

        private readonly Dictionary<string, string[/*6*/]> progressCache = new Dictionary<string, string[/*6*/]>();
        private void UpdateUI()
        {
            List<string[/*4*/]> updateData = new List<string[/*4*/]>();
            foreach (var cache in progressCache)
            {
                string status = cache.Value[0] != cache.Value[3] ? cache.Value[3] : null;
                string progress = cache.Value[1] != cache.Value[4] ? cache.Value[4] : null;
                string error = cache.Value[2] != cache.Value[5] ? cache.Value[5] : null;

                if (status != null || progress != null || error != null)
                    updateData.Add(new string[4] { cache.Key, status, progress, error });

                cache.Value[0] = cache.Value[3];
                cache.Value[1] = cache.Value[4];
                cache.Value[2] = cache.Value[5];
                cache.Value[3] = cache.Value[4] = cache.Value[5] = null;
            }

            foreach (var data in updateData)
            {
                string file = data[0], status = data[1], progress = data[2], error = data[3];
                if (file != "")
                {
                    if (_rows.TryGetValue(file, out DataGridViewRow row))
                    {
                        if (status != null) row.Cells[1].Value = status;
                        if (progress != null) row.Cells[2].Value = progress;
                        if (error == true.ToString()) row.DefaultCellStyle.ForeColor = Color.Red;
                        else if (error == false.ToString()) row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (status != null) _lb_status.Text = status;
                    if (progress != null)
                    {
                        if (float.TryParse(progress, out float percent))
                        {
                            _pb_progress.Visible = _lb_progressText.Visible = percent >= 0;
                            _pb_progress.Value = (int)(_pb_progress.Maximum * (percent < 0 ? 0 : percent > 1 ? 1 : percent));
                            _lb_progressText.Text = (int)(percent * 100) + "%";
                        }
                        else
                            _pb_progress.Visible = _lb_progressText.Visible = false;
                    }
                    if (error == true.ToString()) _lb_status.ForeColor = Color.Red;
                    else if (error == false.ToString()) _lb_status.ForeColor = Color.Black;
                }
            }
        }

        public void OnStatus(string file, string status, string progress, bool isError = false)
        {
            if (string.IsNullOrEmpty(file)) file = "";

            if (!progressCache.TryGetValue(file, out _))
            {
                var temp = new string[6] { "", "", null, null, null, null };
                progressCache.Add(file, temp);
            }
            if (status != null) progressCache[file][3] = status;
            if (progress != null) progressCache[file][4] = progress;
            progressCache[file][5] = isError.ToString();
        }
    }
}