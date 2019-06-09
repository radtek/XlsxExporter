using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XlsxExporter
{
    public partial class MainForm : Form, IProgresser
    {

        public DataGridViewRowCollection Rows => _dgv_task.Rows;
        public Exporter _exporter;

        public MainForm()
        {
            InitializeComponent();

            _exporter = new Exporter(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _pb_progress.Visible = _lb_progressText.Visible = false;
            _tb_exportDir.Text = Config.ExportDir;

            _tm_updateUI.Tick += new EventHandler((_, _1) => UpdateUI());
            _exporter.Load();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _exporter.Dispose();
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
            _exporter.Export(() => Invoke(new Action(() => _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = true)));
        }

        private void reload()
        {
            Rows.Clear();
            _exporter.Load();
        }

        private Dictionary<string, string[/*4*/]> progressCache = new Dictionary<string, string[/*4*/]>();
        private void UpdateUI()
        {
            List<string[]> updateData = new List<string[]>();
            foreach (var cache in progressCache)
            {
                string status = cache.Value[0] != cache.Value[2] ? cache.Value[2] : null;
                string progress = cache.Value[1] != cache.Value[3] ? cache.Value[3] : null;

                if (status != null || progress != null)
                    updateData.Add(new string[] { cache.Key, status, progress });

                cache.Value[0] = cache.Value[2];
                cache.Value[1] = cache.Value[3];
                cache.Value[2] = cache.Value[3] = null;
            }

            foreach (var data in updateData)
            {
                string file = data[0], status = data[1], progress = data[2];
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
                }
            }
        }

        public void OnProgress(string file, string status, string progress)
        {
            if (string.IsNullOrEmpty(file)) file = "";

            if (!progressCache.TryGetValue(file, out _))
            {
                var temp = new string[4] { "", "", null, null };
                progressCache.Add(file, temp);
            }
            if (status != null) progressCache[file][2] = status;
            if (progress != null) progressCache[file][3] = progress;
        }
    }
}