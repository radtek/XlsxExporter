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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void FolderBrowser(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                var textbox = sender == _btn_inputBrowse ? _tb_inputPath : sender == _btn_outBrowse ? _tb_outPath : null;
                var desc = sender == _btn_inputBrowse ? "选择输入文件夹：" : sender == _btn_outBrowse ? "选择输出文件夹：" : null;
                if (textbox != null && textbox != null)
                {
                    folderDialog.Description = desc;
                    folderDialog.SelectedPath = Application.StartupPath;
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        textbox.Text = folderDialog.SelectedPath;
                    }
                }
            }
        }
    }
}
