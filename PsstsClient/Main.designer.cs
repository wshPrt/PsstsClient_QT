namespace PsstsClient
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel_form = new System.Windows.Forms.Panel();
            this.lb_time = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lb_deverror = new System.Windows.Forms.Label();
            this.btn_exit3 = new System.Windows.Forms.Button();
            this.btn_exit2 = new System.Windows.Forms.Button();
            this.btn_exit1 = new System.Windows.Forms.Button();
            this.btn_exit4 = new System.Windows.Forms.Button();
            this.timer_Heartbeat = new System.Windows.Forms.Timer(this.components);
            this.timer_DicReconnect = new System.Windows.Forms.Timer(this.components);
            this.timer_DataReported = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel_form
            // 
            this.panel_form.Location = new System.Drawing.Point(1, 88);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(1023, 634);
            this.panel_form.TabIndex = 1;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.BackColor = System.Drawing.Color.Transparent;
            this.lb_time.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_time.ForeColor = System.Drawing.Color.Black;
            this.lb_time.Location = new System.Drawing.Point(317, 40);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(55, 27);
            this.lb_time.TabIndex = 16;
            this.lb_time.Text = "V1.0";
            this.lb_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lb_deverror
            // 
            this.lb_deverror.AutoSize = true;
            this.lb_deverror.BackColor = System.Drawing.Color.Transparent;
            this.lb_deverror.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_deverror.ForeColor = System.Drawing.Color.Red;
            this.lb_deverror.Location = new System.Drawing.Point(140, 733);
            this.lb_deverror.Name = "lb_deverror";
            this.lb_deverror.Size = new System.Drawing.Size(88, 26);
            this.lb_deverror.TabIndex = 23;
            this.lb_deverror.Text = "提示信息";
            // 
            // btn_exit3
            // 
            this.btn_exit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit3.AutoSize = true;
            this.btn_exit3.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatAppearance.BorderSize = 0;
            this.btn_exit3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit3.Location = new System.Drawing.Point(891, 728);
            this.btn_exit3.Name = "btn_exit3";
            this.btn_exit3.Size = new System.Drawing.Size(133, 40);
            this.btn_exit3.TabIndex = 22;
            this.btn_exit3.UseVisualStyleBackColor = false;
            this.btn_exit3.Click += new System.EventHandler(this.btn_exit3_Click);
            // 
            // btn_exit2
            // 
            this.btn_exit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit2.AutoSize = true;
            this.btn_exit2.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatAppearance.BorderSize = 0;
            this.btn_exit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit2.Location = new System.Drawing.Point(876, -14);
            this.btn_exit2.Name = "btn_exit2";
            this.btn_exit2.Size = new System.Drawing.Size(148, 96);
            this.btn_exit2.TabIndex = 21;
            this.btn_exit2.UseVisualStyleBackColor = false;
            this.btn_exit2.Click += new System.EventHandler(this.btn_exit2_Click);
            // 
            // btn_exit1
            // 
            this.btn_exit1.AutoSize = true;
            this.btn_exit1.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatAppearance.BorderSize = 0;
            this.btn_exit1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit1.Location = new System.Drawing.Point(1, -14);
            this.btn_exit1.Name = "btn_exit1";
            this.btn_exit1.Size = new System.Drawing.Size(154, 96);
            this.btn_exit1.TabIndex = 20;
            this.btn_exit1.UseVisualStyleBackColor = false;
            this.btn_exit1.Click += new System.EventHandler(this.btn_exit1_Click);
            // 
            // btn_exit4
            // 
            this.btn_exit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit4.AutoSize = true;
            this.btn_exit4.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatAppearance.BorderSize = 0;
            this.btn_exit4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit4.Location = new System.Drawing.Point(1, 728);
            this.btn_exit4.Name = "btn_exit4";
            this.btn_exit4.Size = new System.Drawing.Size(133, 40);
            this.btn_exit4.TabIndex = 24;
            this.btn_exit4.UseVisualStyleBackColor = false;
            this.btn_exit4.Click += new System.EventHandler(this.btn_exit4_Click);
            // 
            // timer_Heartbeat
            // 
            this.timer_Heartbeat.Interval = 10000;
            this.timer_Heartbeat.Tick += new System.EventHandler(this.timer_Heartbeat_Tick);
            // 
            // timer_DicReconnect
            // 
            this.timer_DicReconnect.Interval = 60000;
            this.timer_DicReconnect.Tick += new System.EventHandler(this.timer_DicReconnect_Tick);
            // 
            // timer_DataReported
            // 
            this.timer_DataReported.Interval = 3600000;
            this.timer_DataReported.Tick += new System.EventHandler(this.timer_DataReported_Tick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lb_deverror);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.btn_exit4);
            this.Controls.Add(this.btn_exit3);
            this.Controls.Add(this.btn_exit2);
            this.Controls.Add(this.btn_exit1);
            this.Controls.Add(this.panel_form);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lb_deverror;
        private System.Windows.Forms.Button btn_exit3;
        private System.Windows.Forms.Button btn_exit2;
        private System.Windows.Forms.Button btn_exit1;
        private System.Windows.Forms.Button btn_exit4;
        private System.Windows.Forms.Timer timer_Heartbeat;
        private System.Windows.Forms.Timer timer_DicReconnect;
        private System.Windows.Forms.Timer timer_DataReported;
    }
}

