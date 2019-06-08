using System;
using System.Windows.Forms;

namespace XlsxExporter
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            _tb_importDir.Text = Config.ImportDir;
            _tb_exportDir.Text = Config.ExportDir;
            _rb_tText.Checked = Config.ExportType == ExportType.Text;
            _rb_tBinary.Checked = Config.ExportType == ExportType.Binary;
            _cb_exportThCnt.SelectedIndex = Config.ExportThreadCount - 1;
        }

        private void FolderBrowser(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                var textbox = sender == _btn_inputBrowse ? _tb_importDir : sender == _btn_outBrowse ? _tb_exportDir : null;
                var desc = sender == _btn_inputBrowse ? "选择输入文件夹：" : sender == _btn_outBrowse ? "选择输出文件夹：" : null;
                var path = sender == _btn_inputBrowse ? Config.ImportDir : sender == _btn_outBrowse ? Config.ExportDir : null;
                if (textbox != null && textbox != null)
                {
                    folderDialog.Description = desc;
                    folderDialog.SelectedPath = path;
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        textbox.Text = folderDialog.SelectedPath;
                    }
                }
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tb_importDir.Text != Config.ImportDir || _tb_exportDir.Text != Config.ExportDir
                || (_rb_tText.Checked && Config.ExportType != ExportType.Text) || (_rb_tBinary.Checked && Config.ExportType != ExportType.Binary)
                || _cb_exportThCnt.Text != Config.ExportThreadCount + "")
            {
                switch (MessageBox.Show("配置已被修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                    {
                        SaveConfig();
                        break;
                    }
                    case DialogResult.Cancel:
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void _btn_cancel_Click(object sender, EventArgs e)
        {
            FormClosing -= new FormClosingEventHandler(this.ConfigForm_FormClosing);
            Close();
            FormClosing += new FormClosingEventHandler(this.ConfigForm_FormClosing);
        }

        private void _btn_save_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            Config.ImportDir = _tb_importDir.Text;
            Config.ExportDir = _tb_exportDir.Text;
            if (_rb_tText.Checked) Config.ExportType = ExportType.Text;
            else if (_rb_tBinary.Checked) Config.ExportType = ExportType.Binary;
            Config.ExportThreadCount = _cb_exportThCnt.SelectedIndex + 1;
            Config.Save();
        }
    }
}
