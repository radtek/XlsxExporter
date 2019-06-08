using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XlsxExporter
{
    public partial class MainForm : Form, IExporterView
    {
        public DataGridView TaskView => _dgv_task;
        public string Status { set => Invoke(new Action(() => _lb_status.Text = value)); }
        public float Progress
        {
            set => Invoke(new Action(() =>
            {
                _pb_progress.Visible = _lb_progressText.Visible = value > 0;
                _pb_progress.Value = (int)(_pb_progress.Maximum * value);
                _lb_progressText.Text = (int)(value * 100) + "%";
            }));
        }

        public Exporter Exporter { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _pb_progress.Visible = _lb_progressText.Visible = false;
            _tb_exportDir.Text = Config.ExportDir;

            Exporter = new Exporter(this);
            Exporter.Load();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exporter.Dispose();
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
                    Exporter.Load();
                    break;
            }
        }

        private void _btn_reloadConfig_Click(object sender, EventArgs e)
        {
            Exporter.Load();
        }

        private void _btn_export_Click(object sender, EventArgs e)
        {
            _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = false;
            Exporter.Export(() => Invoke(new Action(() => _tb_exportDir.Enabled = _btn_outBrowse.Enabled = _btn_editConfig.Enabled = _btn_reloadConfig.Enabled = _btn_export.Enabled = true)));
        }
    }
}
