namespace XlsxExporter
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this._btn_inputBrowse = new System.Windows.Forms.Button();
            this._tb_importDir = new System.Windows.Forms.TextBox();
            this._rb_tText = new System.Windows.Forms.RadioButton();
            this._rb_tBinary = new System.Windows.Forms.RadioButton();
            this._btn_outBrowse = new System.Windows.Forms.Button();
            this._tb_exportDir = new System.Windows.Forms.TextBox();
            this._btn_cancel = new System.Windows.Forms.Button();
            this._btn_save = new System.Windows.Forms.Button();
            this._cb_exportThCnt = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(33, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 12);
            label1.TabIndex = 0;
            label1.Text = "目录:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 26);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 12);
            label2.TabIndex = 0;
            label2.Text = "目录:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this._btn_inputBrowse);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(this._tb_importDir);
            groupBox1.Location = new System.Drawing.Point(16, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(501, 55);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "输入";
            // 
            // _btn_inputBrowse
            // 
            this._btn_inputBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btn_inputBrowse.Location = new System.Drawing.Point(410, 20);
            this._btn_inputBrowse.Name = "_btn_inputBrowse";
            this._btn_inputBrowse.Size = new System.Drawing.Size(57, 21);
            this._btn_inputBrowse.TabIndex = 2;
            this._btn_inputBrowse.Text = "浏览";
            this._btn_inputBrowse.UseVisualStyleBackColor = true;
            this._btn_inputBrowse.Click += new System.EventHandler(this.FolderBrowser);
            // 
            // _tb_importDir
            // 
            this._tb_importDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_importDir.Location = new System.Drawing.Point(74, 20);
            this._tb_importDir.Name = "_tb_importDir";
            this._tb_importDir.Size = new System.Drawing.Size(334, 21);
            this._tb_importDir.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(this._cb_exportThCnt);
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(this._btn_outBrowse);
            groupBox2.Controls.Add(this._tb_exportDir);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new System.Drawing.Point(16, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(501, 90);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "输出";
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            panel1.Controls.Add(this._rb_tText);
            panel1.Controls.Add(this._rb_tBinary);
            panel1.Location = new System.Drawing.Point(120, 54);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(132, 22);
            panel1.TabIndex = 3;
            // 
            // _rb_tText
            // 
            this._rb_tText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._rb_tText.AutoSize = true;
            this._rb_tText.Checked = true;
            this._rb_tText.Location = new System.Drawing.Point(3, 3);
            this._rb_tText.Name = "_rb_tText";
            this._rb_tText.Size = new System.Drawing.Size(47, 16);
            this._rb_tText.TabIndex = 1;
            this._rb_tText.TabStop = true;
            this._rb_tText.Text = "文本";
            this._rb_tText.UseVisualStyleBackColor = true;
            // 
            // _rb_tBinary
            // 
            this._rb_tBinary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._rb_tBinary.AutoSize = true;
            this._rb_tBinary.Location = new System.Drawing.Point(70, 3);
            this._rb_tBinary.Name = "_rb_tBinary";
            this._rb_tBinary.Size = new System.Drawing.Size(59, 16);
            this._rb_tBinary.TabIndex = 2;
            this._rb_tBinary.Text = "二进制";
            this._rb_tBinary.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(79, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 12);
            label3.TabIndex = 0;
            label3.Text = "类型:";
            // 
            // _btn_outBrowse
            // 
            this._btn_outBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btn_outBrowse.Location = new System.Drawing.Point(410, 22);
            this._btn_outBrowse.Name = "_btn_outBrowse";
            this._btn_outBrowse.Size = new System.Drawing.Size(57, 21);
            this._btn_outBrowse.TabIndex = 2;
            this._btn_outBrowse.Text = "浏览";
            this._btn_outBrowse.UseVisualStyleBackColor = true;
            this._btn_outBrowse.Click += new System.EventHandler(this.FolderBrowser);
            // 
            // _tb_exportDir
            // 
            this._tb_exportDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_exportDir.Location = new System.Drawing.Point(74, 22);
            this._tb_exportDir.Name = "_tb_exportDir";
            this._tb_exportDir.Size = new System.Drawing.Size(334, 21);
            this._tb_exportDir.TabIndex = 1;
            // 
            // _btn_cancel
            // 
            this._btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btn_cancel.Location = new System.Drawing.Point(133, 179);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 3;
            this._btn_cancel.Text = "取消";
            this._btn_cancel.UseVisualStyleBackColor = true;
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
            // 
            // _btn_save
            // 
            this._btn_save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btn_save.Location = new System.Drawing.Point(323, 179);
            this._btn_save.Name = "_btn_save";
            this._btn_save.Size = new System.Drawing.Size(75, 23);
            this._btn_save.TabIndex = 4;
            this._btn_save.Text = "保存";
            this._btn_save.UseVisualStyleBackColor = true;
            this._btn_save.Click += new System.EventHandler(this._btn_save_Click);
            // 
            // _cb_exportThCnt
            // 
            this._cb_exportThCnt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._cb_exportThCnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cb_exportThCnt.FormattingEnabled = true;
            this._cb_exportThCnt.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this._cb_exportThCnt.Location = new System.Drawing.Point(335, 55);
            this._cb_exportThCnt.MaxDropDownItems = 10;
            this._cb_exportThCnt.Name = "_cb_exportThCnt";
            this._cb_exportThCnt.Size = new System.Drawing.Size(59, 20);
            this._cb_exportThCnt.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(286, 59);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 12);
            label4.TabIndex = 5;
            label4.Text = "线程数:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 211);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this._btn_save);
            this.Controls.Add(this._btn_cancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 250);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btn_inputBrowse;
        private System.Windows.Forms.TextBox _tb_importDir;
        private System.Windows.Forms.TextBox _tb_exportDir;
        private System.Windows.Forms.Button _btn_outBrowse;
        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.Button _btn_save;
        private System.Windows.Forms.RadioButton _rb_tText;
        private System.Windows.Forms.RadioButton _rb_tBinary;
        private System.Windows.Forms.ComboBox _cb_exportThCnt;
    }
}