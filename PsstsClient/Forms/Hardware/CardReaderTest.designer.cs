namespace PsstsClient.Forms.Hardware
{
    partial class CardReaderTest
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
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_getstatus = new System.Windows.Forms.Button();
            this.btn_closeport = new System.Windows.Forms.Button();
            this.btn_disenableinsert = new System.Windows.Forms.Button();
            this.btn_readcaard = new System.Windows.Forms.Button();
            this.btn_swallow = new System.Windows.Forms.Button();
            this.btn_ejectcard = new System.Windows.Forms.Button();
            this.btn_enableinsert = new System.Windows.Forms.Button();
            this.btn_cardtype = new System.Windows.Forms.Button();
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
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reset.Location = new System.Drawing.Point(136, 110);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(112, 46);
            this.btn_reset.TabIndex = 17;
            this.btn_reset.Text = "复      位";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_getstatus
            // 
            this.btn_getstatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getstatus.Location = new System.Drawing.Point(261, 110);
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
            this.btn_closeport.Location = new System.Drawing.Point(261, 239);
            this.btn_closeport.Name = "btn_closeport";
            this.btn_closeport.Size = new System.Drawing.Size(112, 46);
            this.btn_closeport.TabIndex = 19;
            this.btn_closeport.Text = "关闭串口";
            this.btn_closeport.UseVisualStyleBackColor = true;
            this.btn_closeport.Click += new System.EventHandler(this.btn_closeport_Click);
            // 
            // btn_disenableinsert
            // 
            this.btn_disenableinsert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_disenableinsert.Location = new System.Drawing.Point(138, 174);
            this.btn_disenableinsert.Name = "btn_disenableinsert";
            this.btn_disenableinsert.Size = new System.Drawing.Size(112, 46);
            this.btn_disenableinsert.TabIndex = 21;
            this.btn_disenableinsert.Text = "禁止插卡";
            this.btn_disenableinsert.UseVisualStyleBackColor = true;
            this.btn_disenableinsert.Click += new System.EventHandler(this.btn_disenableinsert_Click);
            // 
            // btn_readcaard
            // 
            this.btn_readcaard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_readcaard.Location = new System.Drawing.Point(261, 174);
            this.btn_readcaard.Name = "btn_readcaard";
            this.btn_readcaard.Size = new System.Drawing.Size(112, 46);
            this.btn_readcaard.TabIndex = 22;
            this.btn_readcaard.Text = "读      卡";
            this.btn_readcaard.UseVisualStyleBackColor = true;
            this.btn_readcaard.Click += new System.EventHandler(this.btn_readcaard_Click);
            // 
            // btn_swallow
            // 
            this.btn_swallow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_swallow.Location = new System.Drawing.Point(138, 239);
            this.btn_swallow.Name = "btn_swallow";
            this.btn_swallow.Size = new System.Drawing.Size(112, 46);
            this.btn_swallow.TabIndex = 25;
            this.btn_swallow.Text = "吞      卡";
            this.btn_swallow.UseVisualStyleBackColor = true;
            this.btn_swallow.Click += new System.EventHandler(this.btn_swallow_Click);
            // 
            // btn_ejectcard
            // 
            this.btn_ejectcard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ejectcard.Location = new System.Drawing.Point(10, 239);
            this.btn_ejectcard.Name = "btn_ejectcard";
            this.btn_ejectcard.Size = new System.Drawing.Size(112, 46);
            this.btn_ejectcard.TabIndex = 24;
            this.btn_ejectcard.Text = "吐      卡";
            this.btn_ejectcard.UseVisualStyleBackColor = true;
            this.btn_ejectcard.Click += new System.EventHandler(this.btn_ejectcard_Click);
            // 
            // btn_enableinsert
            // 
            this.btn_enableinsert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_enableinsert.Location = new System.Drawing.Point(10, 174);
            this.btn_enableinsert.Name = "btn_enableinsert";
            this.btn_enableinsert.Size = new System.Drawing.Size(112, 46);
            this.btn_enableinsert.TabIndex = 20;
            this.btn_enableinsert.Text = "允许插卡";
            this.btn_enableinsert.UseVisualStyleBackColor = true;
            this.btn_enableinsert.Click += new System.EventHandler(this.btn_enableinsert_Click);
            // 
            // btn_cardtype
            // 
            this.btn_cardtype.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cardtype.Location = new System.Drawing.Point(10, 291);
            this.btn_cardtype.Name = "btn_cardtype";
            this.btn_cardtype.Size = new System.Drawing.Size(112, 46);
            this.btn_cardtype.TabIndex = 26;
            this.btn_cardtype.Text = "卡类型";
            this.btn_cardtype.UseVisualStyleBackColor = true;
            this.btn_cardtype.Click += new System.EventHandler(this.btn_cardtype_Click);
            // 
            // CardReaderTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 419);
            this.Controls.Add(this.btn_cardtype);
            this.Controls.Add(this.btn_swallow);
            this.Controls.Add(this.btn_ejectcard);
            this.Controls.Add(this.btn_readcaard);
            this.Controls.Add(this.btn_disenableinsert);
            this.Controls.Add(this.btn_enableinsert);
            this.Controls.Add(this.btn_closeport);
            this.Controls.Add(this.btn_getstatus);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.gb_comset);
            this.Controls.Add(this.btn_openport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CardReaderTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "银行卡读卡器测试";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.CardReaderTest_Load);
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
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_getstatus;
        private System.Windows.Forms.Button btn_closeport;
        private System.Windows.Forms.Button btn_disenableinsert;
        private System.Windows.Forms.Button btn_readcaard;
        private System.Windows.Forms.Button btn_swallow;
        private System.Windows.Forms.Button btn_ejectcard;
        private System.Windows.Forms.Button btn_enableinsert;
        private System.Windows.Forms.Button btn_cardtype;

    }
}