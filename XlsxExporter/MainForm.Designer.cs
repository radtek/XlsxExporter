namespace XlsxExporter
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this._btn_editConfig = new System.Windows.Forms.Button();
            this._btn_reloadConfig = new System.Windows.Forms.Button();
            this._btn_export = new System.Windows.Forms.Button();
            this._tb_outPath = new System.Windows.Forms.TextBox();
            this._btn_outBrowse = new System.Windows.Forms.Button();
            this._lv_taskView = new System.Windows.Forms.ListView();
            this._lb_status = new System.Windows.Forms.Label();
            this._pb_progress = new System.Windows.Forms.ProgressBar();
            this._lb_progressText = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 12);
            label1.TabIndex = 0;
            label1.Text = "输出目录:";
            // 
            // _btn_editConfig
            // 
            this._btn_editConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_editConfig.Location = new System.Drawing.Point(464, 7);
            this._btn_editConfig.Name = "_btn_editConfig";
            this._btn_editConfig.Size = new System.Drawing.Size(75, 25);
            this._btn_editConfig.TabIndex = 3;
            this._btn_editConfig.Text = "修改配置";
            this._btn_editConfig.UseVisualStyleBackColor = true;
            this._btn_editConfig.Click += new System.EventHandler(this._btn_editConfig_Click);
            // 
            // _btn_reloadConfig
            // 
            this._btn_reloadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_reloadConfig.Location = new System.Drawing.Point(545, 7);
            this._btn_reloadConfig.Name = "_btn_reloadConfig";
            this._btn_reloadConfig.Size = new System.Drawing.Size(75, 25);
            this._btn_reloadConfig.TabIndex = 4;
            this._btn_reloadConfig.Text = "重新载入";
            this._btn_reloadConfig.UseVisualStyleBackColor = true;
            this._btn_reloadConfig.Click += new System.EventHandler(this._bt_reloadConfig_Click);
            // 
            // _btn_export
            // 
            this._btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_export.Location = new System.Drawing.Point(636, 7);
            this._btn_export.Name = "_btn_export";
            this._btn_export.Size = new System.Drawing.Size(75, 25);
            this._btn_export.TabIndex = 5;
            this._btn_export.Text = "开始输出";
            this._btn_export.UseVisualStyleBackColor = true;
            this._btn_export.Click += new System.EventHandler(this._bt_export_Click);
            // 
            // _tb_outPath
            // 
            this._tb_outPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_outPath.Location = new System.Drawing.Point(79, 9);
            this._tb_outPath.Name = "_tb_outPath";
            this._tb_outPath.Size = new System.Drawing.Size(264, 21);
            this._tb_outPath.TabIndex = 1;
            // 
            // _btn_outBrowse
            // 
            this._btn_outBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_outBrowse.Location = new System.Drawing.Point(349, 9);
            this._btn_outBrowse.Name = "_btn_outBrowse";
            this._btn_outBrowse.Size = new System.Drawing.Size(57, 21);
            this._btn_outBrowse.TabIndex = 2;
            this._btn_outBrowse.Text = "浏览";
            this._btn_outBrowse.UseVisualStyleBackColor = true;
            this._btn_outBrowse.Click += new System.EventHandler(this._bn_outBrowse_Click);
            // 
            // _lv_taskView
            // 
            this._lv_taskView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lv_taskView.BackColor = System.Drawing.SystemColors.Control;
            this._lv_taskView.Location = new System.Drawing.Point(0, 39);
            this._lv_taskView.Name = "_lv_taskView";
            this._lv_taskView.Size = new System.Drawing.Size(734, 377);
            this._lv_taskView.TabIndex = 6;
            this._lv_taskView.UseCompatibleStateImageBehavior = false;
            // 
            // _lb_status
            // 
            this._lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lb_status.AutoSize = true;
            this._lb_status.Font = new System.Drawing.Font("宋体", 9F);
            this._lb_status.Location = new System.Drawing.Point(3, 419);
            this._lb_status.Name = "_lb_status";
            this._lb_status.Size = new System.Drawing.Size(29, 12);
            this._lb_status.TabIndex = 0;
            this._lb_status.Text = "就绪";
            // 
            // _pb_progress
            // 
            this._pb_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pb_progress.Location = new System.Drawing.Point(554, 419);
            this._pb_progress.Name = "_pb_progress";
            this._pb_progress.Size = new System.Drawing.Size(150, 13);
            this._pb_progress.TabIndex = 0;
            // 
            // _lb_progressText
            // 
            this._lb_progressText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lb_progressText.AutoSize = true;
            this._lb_progressText.Location = new System.Drawing.Point(705, 419);
            this._lb_progressText.Name = "_lb_progressText";
            this._lb_progressText.Size = new System.Drawing.Size(29, 12);
            this._lb_progressText.TabIndex = 0;
            this._lb_progressText.Text = "100%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 435);
            this.Controls.Add(this._lb_progressText);
            this.Controls.Add(this._pb_progress);
            this.Controls.Add(this._lb_status);
            this.Controls.Add(this._lv_taskView);
            this.Controls.Add(this._btn_outBrowse);
            this.Controls.Add(label1);
            this.Controls.Add(this._tb_outPath);
            this.Controls.Add(this._btn_export);
            this.Controls.Add(this._btn_reloadConfig);
            this.Controls.Add(this._btn_editConfig);
            this.MinimumSize = new System.Drawing.Size(750, 400);
            this.Name = "MainForm";
            this.Text = "Xlsx Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _btn_export;
        private System.Windows.Forms.Button _btn_reloadConfig;
        private System.Windows.Forms.Button _btn_editConfig;
        private System.Windows.Forms.Button _btn_outBrowse;
        private System.Windows.Forms.TextBox _tb_outPath;
        private System.Windows.Forms.ListView _lv_taskView;
        private System.Windows.Forms.Label _lb_status;
        private System.Windows.Forms.ProgressBar _pb_progress;
        private System.Windows.Forms.Label _lb_progressText;
    }
}

