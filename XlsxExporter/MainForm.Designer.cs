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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._btn_editConfig = new System.Windows.Forms.Button();
            this._btn_reloadConfig = new System.Windows.Forms.Button();
            this._btn_export = new System.Windows.Forms.Button();
            this._tb_exportDir = new System.Windows.Forms.TextBox();
            this._btn_outBrowse = new System.Windows.Forms.Button();
            this._lb_status = new System.Windows.Forms.Label();
            this._pb_progress = new System.Windows.Forms.ProgressBar();
            this._lb_progressText = new System.Windows.Forms.Label();
            this._dgv_task = new System.Windows.Forms.DataGridView();
            this._tm_updateUI = new System.Windows.Forms.Timer(this.components);
            this._ch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ch_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ch_progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_task)).BeginInit();
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
            this._btn_reloadConfig.Click += new System.EventHandler(this._btn_reloadConfig_Click);
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
            this._btn_export.Click += new System.EventHandler(this._btn_export_Click);
            // 
            // _tb_exportDir
            // 
            this._tb_exportDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_exportDir.Location = new System.Drawing.Point(79, 9);
            this._tb_exportDir.Name = "_tb_exportDir";
            this._tb_exportDir.Size = new System.Drawing.Size(264, 21);
            this._tb_exportDir.TabIndex = 1;
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
            this._btn_outBrowse.Click += new System.EventHandler(this._btn_outBrowse_Click);
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
            this._pb_progress.Maximum = 100000;
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
            // _dgv_task
            // 
            this._dgv_task.AllowUserToAddRows = false;
            this._dgv_task.AllowUserToDeleteRows = false;
            this._dgv_task.AllowUserToResizeRows = false;
            this._dgv_task.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv_task.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv_task.BackgroundColor = System.Drawing.SystemColors.Control;
            this._dgv_task.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this._dgv_task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgv_task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ch_name,
            this._ch_status,
            this._ch_progress});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv_task.DefaultCellStyle = dataGridViewCellStyle1;
            this._dgv_task.GridColor = System.Drawing.SystemColors.Control;
            this._dgv_task.Location = new System.Drawing.Point(-1, 36);
            this._dgv_task.Name = "_dgv_task";
            this._dgv_task.ReadOnly = true;
            this._dgv_task.RowHeadersVisible = false;
            this._dgv_task.RowTemplate.Height = 23;
            this._dgv_task.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dgv_task.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv_task.Size = new System.Drawing.Size(735, 380);
            this._dgv_task.TabIndex = 7;
            // 
            // _tm_updateUI
            // 
            this._tm_updateUI.Enabled = true;
            // 
            // _ch_name
            // 
            this._ch_name.FillWeight = 25F;
            this._ch_name.HeaderText = "名 称";
            this._ch_name.Name = "_ch_name";
            this._ch_name.ReadOnly = true;
            // 
            // _ch_status
            // 
            this._ch_status.FillWeight = 15F;
            this._ch_status.HeaderText = "状 态";
            this._ch_status.Name = "_ch_status";
            this._ch_status.ReadOnly = true;
            // 
            // _ch_progress
            // 
            this._ch_progress.FillWeight = 60F;
            this._ch_progress.HeaderText = "进 度";
            this._ch_progress.Name = "_ch_progress";
            this._ch_progress.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 435);
            this.Controls.Add(this._dgv_task);
            this.Controls.Add(this._lb_progressText);
            this.Controls.Add(this._pb_progress);
            this.Controls.Add(this._lb_status);
            this.Controls.Add(this._btn_outBrowse);
            this.Controls.Add(label1);
            this.Controls.Add(this._tb_exportDir);
            this.Controls.Add(this._btn_export);
            this.Controls.Add(this._btn_reloadConfig);
            this.Controls.Add(this._btn_editConfig);
            this.MinimumSize = new System.Drawing.Size(750, 400);
            this.Name = "MainForm";
            this.Text = "Xlsx Exporter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgv_task)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _btn_export;
        private System.Windows.Forms.Button _btn_reloadConfig;
        private System.Windows.Forms.Button _btn_editConfig;
        private System.Windows.Forms.Button _btn_outBrowse;
        private System.Windows.Forms.TextBox _tb_exportDir;
        private System.Windows.Forms.Label _lb_status;
        private System.Windows.Forms.ProgressBar _pb_progress;
        private System.Windows.Forms.Label _lb_progressText;
        private System.Windows.Forms.DataGridView _dgv_task;
        private System.Windows.Forms.Timer _tm_updateUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ch_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ch_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ch_progress;
    }
}

