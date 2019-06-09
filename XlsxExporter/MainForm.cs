using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace XlsxExporter
{
    public partial class MainForm : Form
    {

        public DataGridViewRowCollection Rows => _dgv_task.Rows;
        public Exporter _exporter;

        public MainForm()
        {
            InitializeComponent();

            _exporter = new Exporter();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _pb_progress.Visible = _lb_progressText.Visible = false;
            _tb_exportDir.Text = Config.ExportDir;

            _tm_updateUI.Tick += new EventHandler((_, _1) => UpdateUI());
            _exporter.Load(OnStatus);
        }

        private void _btn_outBrowse_Click(object sender, EventArgs e)
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

        private void _btn_editConfig_Click(object sender, EventArgs e)
        {
            switch (new ConfigForm().ShowDialog(this))
            {
                default:
                    _tb_exportDir.Text = Config.ExportDir;
                    reload();
                    break;
            }
        }

        private void _btn_reloadConfig_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void _btn_export_Click(object sender, EventArgs e)
        {
            _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = false;
            _exporter.Export(isOk => Invoke(new Action(() => _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = true)), OnStatus);
        }

        private void reload()
        {
            Rows.Clear();
            _exporter.Load(OnStatus);
        }

        private Dictionary<string, string[/*6*/]> progressCache = new Dictionary<string, string[/*6*/]>();
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
                    string name = Path.GetFileName(file);
                    DataGridViewRow row = null;
                    foreach (DataGridViewRow r in Rows)
                    {
                        if ((string)r.Cells[0].Value == name)
                        {
                            row = r;
                            break;
                        }
                    }
                    if (row == null)
                    {
                        row = Rows[Rows.Add()];
                        row.Cells[0].Value = name;
                    }
                    if (status != null) row.Cells[1].Value = status;
                    if (progress != null) row.Cells[2].Value = progress;
                    if (error == true.ToString()) row.DefaultCellStyle.ForeColor = Color.Red;
                    else if (error == false.ToString()) row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    if (status != null) _lb_status.Text = status;
                    if (progress != null)
                    {
                        if (float.TryParse(progress, out float percent))
                        {
                            _pb_progress.Visible = _lb_progressText.Visible = percent > 0;
                            _pb_progress.Value = (int)(_pb_progress.Maximum * percent);
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