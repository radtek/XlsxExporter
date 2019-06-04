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
            this._bn_inputBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tb_inputPath = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._btn_cancel = new System.Windows.Forms.Button();
            this._btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _bn_inputBrowse
            // 
            this._bn_inputBrowse.Location = new System.Drawing.Point(307, 27);
            this._bn_inputBrowse.Name = "_bn_inputBrowse";
            this._bn_inputBrowse.Size = new System.Drawing.Size(57, 21);
            this._bn_inputBrowse.TabIndex = 7;
            this._bn_inputBrowse.Text = "浏览";
            this._bn_inputBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "输入路径:";
            // 
            // _tb_inputPath
            // 
            this._tb_inputPath.Location = new System.Drawing.Point(87, 27);
            this._tb_inputPath.Name = "_tb_inputPath";
            this._tb_inputPath.Size = new System.Drawing.Size(214, 21);
            this._tb_inputPath.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 21);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "输出路径:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _btn_cancel
            // 
            this._btn_cancel.Location = new System.Drawing.Point(94, 132);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 10;
            this._btn_cancel.Text = "取消";
            this._btn_cancel.UseVisualStyleBackColor = true;
            // 
            // _btn_save
            // 
            this._btn_save.Location = new System.Drawing.Point(218, 132);
            this._btn_save.Name = "_btn_save";
            this._btn_save.Size = new System.Drawing.Size(75, 23);
            this._btn_save.TabIndex = 11;
            this._btn_save.Text = "保存";
            this._btn_save.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 170);
            this.Controls.Add(this._btn_save);
            this.Controls.Add(this._btn_cancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._bn_inputBrowse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tb_inputPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _bn_inputBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tb_inputPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.Button _btn_save;
    }
}