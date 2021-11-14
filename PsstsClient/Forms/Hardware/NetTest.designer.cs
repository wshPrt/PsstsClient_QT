namespace PsstsClient.Forms.Hardware
{
    partial class NetTest
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
            this.btn_nettest = new System.Windows.Forms.Button();
            this.gb_comset = new System.Windows.Forms.GroupBox();
            this.tb_serverport = new System.Windows.Forms.TextBox();
            this.tb_serverip = new System.Windows.Forms.TextBox();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_serverip = new System.Windows.Forms.Label();
            this.gb_comset.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_nettest
            // 
            this.btn_nettest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nettest.Location = new System.Drawing.Point(10, 110);
            this.btn_nettest.Name = "btn_nettest";
            this.btn_nettest.Size = new System.Drawing.Size(112, 46);
            this.btn_nettest.TabIndex = 0;
            this.btn_nettest.Text = "网络测试";
            this.btn_nettest.UseVisualStyleBackColor = true;
            this.btn_nettest.Click += new System.EventHandler(this.btn_nettest_Click);
            // 
            // gb_comset
            // 
            this.gb_comset.BackColor = System.Drawing.Color.Transparent;
            this.gb_comset.Controls.Add(this.tb_serverport);
            this.gb_comset.Controls.Add(this.tb_serverip);
            this.gb_comset.Controls.Add(this.lb_port);
            this.gb_comset.Controls.Add(this.lb_serverip);
            this.gb_comset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_comset.Location = new System.Drawing.Point(10, 12);
            this.gb_comset.Name = "gb_comset";
            this.gb_comset.Size = new System.Drawing.Size(363, 83);
            this.gb_comset.TabIndex = 16;
            this.gb_comset.TabStop = false;
            this.gb_comset.Text = "配置";
            // 
            // tb_serverport
            // 
            this.tb_serverport.Location = new System.Drawing.Point(289, 35);
            this.tb_serverport.Name = "tb_serverport";
            this.tb_serverport.Size = new System.Drawing.Size(68, 29);
            this.tb_serverport.TabIndex = 5;
            // 
            // tb_serverip
            // 
            this.tb_serverip.Location = new System.Drawing.Point(81, 35);
            this.tb_serverip.Name = "tb_serverip";
            this.tb_serverip.Size = new System.Drawing.Size(152, 29);
            this.tb_serverip.TabIndex = 4;
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(238, 38);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(58, 21);
            this.lb_port.TabIndex = 3;
            this.lb_port.Text = "端口：";
            // 
            // lb_serverip
            // 
            this.lb_serverip.AutoSize = true;
            this.lb_serverip.Location = new System.Drawing.Point(6, 38);
            this.lb_serverip.Name = "lb_serverip";
            this.lb_serverip.Size = new System.Drawing.Size(77, 21);
            this.lb_serverip.TabIndex = 2;
            this.lb_serverip.Text = "服务器IP:";
            // 
            // NetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 364);
            this.Controls.Add(this.gb_comset);
            this.Controls.Add(this.btn_nettest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NetTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "网络连接测试";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.NetTest_Load);
            this.gb_comset.ResumeLayout(false);
            this.gb_comset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_nettest;
        private System.Windows.Forms.GroupBox gb_comset;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_serverip;
        private System.Windows.Forms.TextBox tb_serverport;
        private System.Windows.Forms.TextBox tb_serverip;

    }
}