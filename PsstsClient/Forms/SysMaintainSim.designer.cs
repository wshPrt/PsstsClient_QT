namespace PsstsClient.Forms
{
    partial class SysMaintainSim
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
            this.components = new System.ComponentModel.Container();
            this.btn_shutdown = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btn_wh = new System.Windows.Forms.Button();
            this.btn_htest = new System.Windows.Forms.Button();
            this.btn_updateper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_shutdown.Location = new System.Drawing.Point(530, 234);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(183, 73);
            this.btn_shutdown.TabIndex = 1;
            this.btn_shutdown.Text = "关      机";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            this.btn_shutdown.Click += new System.EventHandler(this.btn_shutdown_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_restart.Location = new System.Drawing.Point(530, 128);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(183, 73);
            this.btn_restart.TabIndex = 2;
            this.btn_restart.Text = "重      启";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_return
            // 
            this.btn_return.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_return.Location = new System.Drawing.Point(295, 353);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(183, 73);
            this.btn_return.TabIndex = 3;
            this.btn_return.Text = "返回首页";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clear.Location = new System.Drawing.Point(295, 234);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(183, 73);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "清      机";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exit.Location = new System.Drawing.Point(530, 353);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(183, 73);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "关闭程序";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(60, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 73);
            this.button1.TabIndex = 8;
            this.button1.Text = "现金缴费查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_wh
            // 
            this.btn_wh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_wh.Location = new System.Drawing.Point(60, 353);
            this.btn_wh.Name = "btn_wh";
            this.btn_wh.Size = new System.Drawing.Size(183, 73);
            this.btn_wh.TabIndex = 10;
            this.btn_wh.Text = "维     护";
            this.btn_wh.UseVisualStyleBackColor = true;
            this.btn_wh.Click += new System.EventHandler(this.btn_wh_Click);
            // 
            // btn_htest
            // 
            this.btn_htest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_htest.Location = new System.Drawing.Point(60, 234);
            this.btn_htest.Name = "btn_htest";
            this.btn_htest.Size = new System.Drawing.Size(183, 73);
            this.btn_htest.TabIndex = 11;
            this.btn_htest.Text = "硬件检测";
            this.btn_htest.UseVisualStyleBackColor = true;
            this.btn_htest.Click += new System.EventHandler(this.btn_htest_Click);
            // 
            // btn_updateper
            // 
            this.btn_updateper.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_updateper.Location = new System.Drawing.Point(295, 128);
            this.btn_updateper.Name = "btn_updateper";
            this.btn_updateper.Size = new System.Drawing.Size(183, 73);
            this.btn_updateper.TabIndex = 13;
            this.btn_updateper.Text = "修改硬件端口";
            this.btn_updateper.UseVisualStyleBackColor = true;
            this.btn_updateper.Click += new System.EventHandler(this.button3_Click);
            // 
            // SysMaintainSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 596);
            this.Controls.Add(this.btn_updateper);
            this.Controls.Add(this.btn_htest);
            this.Controls.Add(this.btn_wh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.btn_shutdown);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SysMaintainSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "系统维护";
            this.Load += new System.EventHandler(this.SysMaintainSim_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_shutdown;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_wh;
        private System.Windows.Forms.Button btn_htest;
        private System.Windows.Forms.Button btn_updateper;
    }
}