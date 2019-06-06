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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            _pb_progress.Visible = _lb_progressText.Visible = false;
        }

        private void _bn_outBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "选择输出文件夹：";
                folderDialog.SelectedPath = Application.StartupPath;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _tb_outPath.Text = folderDialog.SelectedPath;
                }
            }
        }
  
        private void _btn_editConfig_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }

        private void _bt_reloadConfig_Click(object sender, EventArgs e)
        {

        }

        private void _bt_export_Click(object sender, EventArgs e)
        {

        }
    }
}
