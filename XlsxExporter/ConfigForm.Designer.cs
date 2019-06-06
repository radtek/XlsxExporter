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
            this._btn_inputBrowse = new System.Windows.Forms.Button();
            this._tb_inputPath = new System.Windows.Forms.TextBox();
            this._rb_typeText = new System.Windows.Forms.RadioButton();
            this._rb_typeBin = new System.Windows.Forms.RadioButton();
            this._btn_outBrowse = new System.Windows.Forms.Button();
            this._tb_outPath = new System.Windows.Forms.TextBox();
            this._btn_cancel = new System.Windows.Forms.Button();
            this._btn_save = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
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
            groupBox1.Controls.Add(this._tb_inputPath);
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
            // _tb_inputPath
            // 
            this._tb_inputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_inputPath.Location = new System.Drawing.Point(74, 20);
            this._tb_inputPath.Name = "_tb_inputPath";
            this._tb_inputPath.Size = new System.Drawing.Size(334, 21);
            this._tb_inputPath.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(this._btn_outBrowse);
            groupBox2.Controls.Add(this._tb_outPath);
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
            panel1.Controls.Add(this._rb_typeText);
            panel1.Controls.Add(this._rb_typeBin);
            panel1.Location = new System.Drawing.Point(189, 54);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(132, 22);
            panel1.TabIndex = 3;
            // 
            // _rb_typeText
            // 
            this._rb_typeText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._rb_typeText.AutoSize = true;
            this._rb_typeText.Checked = true;
            this._rb_typeText.Location = new System.Drawing.Point(3, 3);
            this._rb_typeText.Name = "_rb_typeText";
            this._rb_typeText.Size = new System.Drawing.Size(47, 16);
            this._rb_typeText.TabIndex = 1;
            this._rb_typeText.TabStop = true;
            this._rb_typeText.Text = "文本";
            this._rb_typeText.UseVisualStyleBackColor = true;
            // 
            // _rb_typeBin
            // 
            this._rb_typeBin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._rb_typeBin.AutoSize = true;
            this._rb_typeBin.Location = new System.Drawing.Point(70, 3);
            this._rb_typeBin.Name = "_rb_typeBin";
            this._rb_typeBin.Size = new System.Drawing.Size(59, 16);
            this._rb_typeBin.TabIndex = 2;
            this._rb_typeBin.Text = "二进制";
            this._rb_typeBin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(148, 60);
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
            // _tb_outPath
            // 
            this._tb_outPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_outPath.Location = new System.Drawing.Point(74, 22);
            this._tb_outPath.Name = "_tb_outPath";
            this._tb_outPath.Size = new System.Drawing.Size(334, 21);
            this._tb_outPath.TabIndex = 1;
            // 
            // _btn_cancel
            // 
            this._btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btn_cancel.Location = new System.Drawing.Point(133, 179);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 3;
            this._btn_cancel.Text = "取消";
            this._btn_cancel.UseVisualStyleBackColor = true;
            // 
            // _btn_save
            // 
            this._btn_save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btn_save.Location = new System.Drawing.Point(323, 179);
            this._btn_save.Name = "_btn_save";
            this._btn_save.Size = new System.Drawing.Size(75, 23);
            this._btn_save.TabIndex = 4;
            this._btn_save.Text = "保存";
            this._btn_save.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this._btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btn_cancel;
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
        private System.Windows.Forms.TextBox _tb_inputPath;
        private System.Windows.Forms.TextBox _tb_outPath;
        private System.Windows.Forms.Button _btn_outBrowse;
        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.Button _btn_save;
        private System.Windows.Forms.RadioButton _rb_typeText;
        private System.Windows.Forms.RadioButton _rb_typeBin;
    }
}