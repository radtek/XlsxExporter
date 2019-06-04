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
            this._bt_editConfig = new System.Windows.Forms.Button();
            this._bt_reloadConfig = new System.Windows.Forms.Button();
            this._bt_export = new System.Windows.Forms.Button();
            this._tb_outPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._bn_outBrowse = new System.Windows.Forms.Button();
            this._lv_taskView = new System.Windows.Forms.ListView();
            this._lb_status = new System.Windows.Forms.Label();
            this._pb_progress = new System.Windows.Forms.ProgressBar();
            this._pb_progressText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _bt_editConfig
            // 
            this._bt_editConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bt_editConfig.Location = new System.Drawing.Point(414, 8);
            this._bt_editConfig.Name = "_bt_editConfig";
            this._bt_editConfig.Size = new System.Drawing.Size(75, 25);
            this._bt_editConfig.TabIndex = 3;
            this._bt_editConfig.Text = "修改配置";
            this._bt_editConfig.UseVisualStyleBackColor = true;
            this._bt_editConfig.Click += new System.EventHandler(this._btn_editConfig_Click);
            // 
            // _bt_reloadConfig
            // 
            this._bt_reloadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bt_reloadConfig.Location = new System.Drawing.Point(495, 8);
            this._bt_reloadConfig.Name = "_bt_reloadConfig";
            this._bt_reloadConfig.Size = new System.Drawing.Size(75, 25);
            this._bt_reloadConfig.TabIndex = 2;
            this._bt_reloadConfig.Text = "重新载入";
            this._bt_reloadConfig.UseVisualStyleBackColor = true;
            // 
            // _bt_export
            // 
            this._bt_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bt_export.Location = new System.Drawing.Point(586, 8);
            this._bt_export.Name = "_bt_export";
            this._bt_export.Size = new System.Drawing.Size(75, 25);
            this._bt_export.TabIndex = 1;
            this._bt_export.Text = "开始输出";
            this._bt_export.UseVisualStyleBackColor = true;
            // 
            // _tb_outPath
            // 
            this._tb_outPath.Location = new System.Drawing.Point(79, 10);
            this._tb_outPath.Name = "_tb_outPath";
            this._tb_outPath.Size = new System.Drawing.Size(214, 21);
            this._tb_outPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "输出路径:";
            // 
            // _bn_outBrowse
            // 
            this._bn_outBrowse.Location = new System.Drawing.Point(299, 10);
            this._bn_outBrowse.Name = "_bn_outBrowse";
            this._bn_outBrowse.Size = new System.Drawing.Size(57, 21);
            this._bn_outBrowse.TabIndex = 4;
            this._bn_outBrowse.Text = "浏览";
            this._bn_outBrowse.UseVisualStyleBackColor = true;
            // 
            // _lv_taskView
            // 
            this._lv_taskView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lv_taskView.BackColor = System.Drawing.SystemColors.Control;
            this._lv_taskView.Location = new System.Drawing.Point(0, 39);
            this._lv_taskView.Name = "_lv_taskView";
            this._lv_taskView.Size = new System.Drawing.Size(684, 377);
            this._lv_taskView.TabIndex = 9;
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
            this._lb_status.TabIndex = 10;
            this._lb_status.Text = "就绪";
            // 
            // _pb_progress
            // 
            this._pb_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pb_progress.Location = new System.Drawing.Point(504, 419);
            this._pb_progress.Name = "_pb_progress";
            this._pb_progress.Size = new System.Drawing.Size(150, 13);
            this._pb_progress.TabIndex = 11;
            // 
            // _pb_progressText
            // 
            this._pb_progressText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pb_progressText.AutoSize = true;
            this._pb_progressText.Location = new System.Drawing.Point(655, 419);
            this._pb_progressText.Name = "_pb_progressText";
            this._pb_progressText.Size = new System.Drawing.Size(29, 12);
            this._pb_progressText.TabIndex = 12;
            this._pb_progressText.Text = "100%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 435);
            this.Controls.Add(this._pb_progressText);
            this.Controls.Add(this._pb_progress);
            this.Controls.Add(this._lb_status);
            this.Controls.Add(this._lv_taskView);
            this.Controls.Add(this._bn_outBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tb_outPath);
            this.Controls.Add(this._bt_export);
            this.Controls.Add(this._bt_reloadConfig);
            this.Controls.Add(this._bt_editConfig);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Xlsx Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _bt_export;
        private System.Windows.Forms.Button _bt_reloadConfig;
        private System.Windows.Forms.Button _bt_editConfig;
        private System.Windows.Forms.Button _bn_outBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tb_outPath;
        private System.Windows.Forms.ListView _lv_taskView;
        private System.Windows.Forms.Label _lb_status;
        private System.Windows.Forms.ProgressBar _pb_progress;
        private System.Windows.Forms.Label _pb_progressText;
    }
}

