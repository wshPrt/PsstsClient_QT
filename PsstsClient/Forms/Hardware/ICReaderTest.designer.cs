namespace PsstsClient.Forms.Hardware
{
    partial class ICReaderTest
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
            this.btn_openport = new System.Windows.Forms.Button();
            this.gb_comset = new System.Windows.Forms.GroupBox();
            this.cb_baud = new System.Windows.Forms.ComboBox();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.lb_baud = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.btn_getstatus = new System.Windows.Forms.Button();
            this.btn_closeport = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.gb_comset.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_openport
            // 
            this.btn_openport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openport.Location = new System.Drawing.Point(10, 110);
            this.btn_openport.Name = "btn_openport";
            this.btn_openport.Size = new System.Drawing.Size(112, 46);
            this.btn_openport.TabIndex = 0;
            this.btn_openport.Text = "打开串口";
            this.btn_openport.UseVisualStyleBackColor = true;
            this.btn_openport.Click += new System.EventHandler(this.btn_openport_Click);
            // 
            // gb_comset
            // 
            this.gb_comset.BackColor = System.Drawing.Color.Transparent;
            this.gb_comset.Controls.Add(this.cb_baud);
            this.gb_comset.Controls.Add(this.cb_port);
            this.gb_comset.Controls.Add(this.lb_baud);
            this.gb_comset.Controls.Add(this.lb_port);
            this.gb_comset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_comset.Location = new System.Drawing.Point(10, 12);
            this.gb_comset.Name = "gb_comset";
            this.gb_comset.Size = new System.Drawing.Size(363, 83);
            this.gb_comset.TabIndex = 16;
            this.gb_comset.TabStop = false;
            this.gb_comset.Text = "配置";
            // 
            // cb_baud
            // 
            this.cb_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_baud.FormattingEnabled = true;
            this.cb_baud.Items.AddRange(new object[] {
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cb_baud.Location = new System.Drawing.Point(250, 35);
            this.cb_baud.Name = "cb_baud";
            this.cb_baud.Size = new System.Drawing.Size(105, 29);
            this.cb_baud.TabIndex = 5;
            // 
            // cb_port
            // 
            this.cb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Items.AddRange(new object[] {
            "USB",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12"});
            this.cb_port.Location = new System.Drawing.Point(58, 35);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(105, 29);
            this.cb_port.TabIndex = 4;
            this.cb_port.SelectedIndexChanged += new System.EventHandler(this.cb_port_SelectedIndexChanged);
            // 
            // lb_baud
            // 
            this.lb_baud.AutoSize = true;
            this.lb_baud.Location = new System.Drawing.Point(180, 38);
            this.lb_baud.Name = "lb_baud";
            this.lb_baud.Size = new System.Drawing.Size(74, 21);
            this.lb_baud.TabIndex = 3;
            this.lb_baud.Text = "波特率：";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(6, 38);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(46, 21);
            this.lb_port.TabIndex = 2;
            this.lb_port.Text = "串口:";
            // 
            // btn_getstatus
            // 
            this.btn_getstatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getstatus.Location = new System.Drawing.Point(136, 110);
            this.btn_getstatus.Name = "btn_getstatus";
            this.btn_getstatus.Size = new System.Drawing.Size(112, 46);
            this.btn_getstatus.TabIndex = 18;
            this.btn_getstatus.Text = "获取状态";
            this.btn_getstatus.UseVisualStyleBackColor = true;
            this.btn_getstatus.Click += new System.EventHandler(this.btn_getstatus_Click);
            // 
            // btn_closeport
            // 
            this.btn_closeport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_closeport.Location = new System.Drawing.Point(10, 174);
            this.btn_closeport.Name = "btn_closeport";
            this.btn_closeport.Size = new System.Drawing.Size(112, 46);
            this.btn_closeport.TabIndex = 19;
            this.btn_closeport.Text = "关闭串口";
            this.btn_closeport.UseVisualStyleBackColor = true;
            this.btn_closeport.Click += new System.EventHandler(this.btn_closeport_Click);
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_test.Location = new System.Drawing.Point(261, 110);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(112, 46);
            this.btn_test.TabIndex = 21;
            this.btn_test.Text = "测      试";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // ICReaderTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 364);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_closeport);
            this.Controls.Add(this.btn_getstatus);
            this.Controls.Add(this.gb_comset);
            this.Controls.Add(this.btn_openport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ICReaderTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IC卡读卡器测试";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.ICReaderTest_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ICReaderTest_FormClosing);
            this.gb_comset.ResumeLayout(false);
            this.gb_comset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_openport;
        private System.Windows.Forms.GroupBox gb_comset;
        private System.Windows.Forms.Label lb_baud;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.ComboBox cb_baud;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.Button btn_getstatus;
        private System.Windows.Forms.Button btn_closeport;
        private System.Windows.Forms.Button btn_test;

    }
}