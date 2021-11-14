namespace PsstsClient.Forms.Pay
{
    partial class ScanCodePaySim
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
            this.label1 = new System.Windows.Forms.Label();
            this.lab_CustomerNo = new System.Windows.Forms.Label();
            this.lab_CustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_Balance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pic_WenXinQrCode = new System.Windows.Forms.PictureBox();
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_Countdown = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.time_Countdown = new System.Windows.Forms.Timer(this.components);
            this.lab_Prompt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_WenXinQrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(495, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户编号：";
            // 
            // lab_CustomerNo
            // 
            this.lab_CustomerNo.AutoSize = true;
            this.lab_CustomerNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CustomerNo.Location = new System.Drawing.Point(594, 168);
            this.lab_CustomerNo.Name = "lab_CustomerNo";
            this.lab_CustomerNo.Size = new System.Drawing.Size(17, 16);
            this.lab_CustomerNo.TabIndex = 1;
            this.lab_CustomerNo.Text = "-";
            // 
            // lab_CustomerName
            // 
            this.lab_CustomerName.AutoSize = true;
            this.lab_CustomerName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CustomerName.Location = new System.Drawing.Point(594, 198);
            this.lab_CustomerName.Name = "lab_CustomerName";
            this.lab_CustomerName.Size = new System.Drawing.Size(17, 16);
            this.lab_CustomerName.TabIndex = 3;
            this.lab_CustomerName.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(495, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "客户名称：";
            // 
            // lab_Balance
            // 
            this.lab_Balance.AutoSize = true;
            this.lab_Balance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Balance.ForeColor = System.Drawing.Color.Red;
            this.lab_Balance.Location = new System.Drawing.Point(594, 228);
            this.lab_Balance.Name = "lab_Balance";
            this.lab_Balance.Size = new System.Drawing.Size(44, 16);
            this.lab_Balance.TabIndex = 5;
            this.lab_Balance.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(495, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "当前欠费：";
            // 
            // pic_WenXinQrCode
            // 
            this.pic_WenXinQrCode.Image = global::PsstsClient.Properties.Resources.loading;
            this.pic_WenXinQrCode.Location = new System.Drawing.Point(563, 299);
            this.pic_WenXinQrCode.Name = "pic_WenXinQrCode";
            this.pic_WenXinQrCode.Size = new System.Drawing.Size(170, 170);
            this.pic_WenXinQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_WenXinQrCode.TabIndex = 6;
            this.pic_WenXinQrCode.TabStop = false;
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PsstsClient.Properties.Resources.bg_money;
            this.pictureBox1.Location = new System.Drawing.Point(394, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(474, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 24);
            this.label7.TabIndex = 62;
            this.label7.Text = "微信支付";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(544, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 63;
            this.label2.Text = "请在";
            // 
            // lab_Countdown
            // 
            this.lab_Countdown.AutoSize = true;
            this.lab_Countdown.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Countdown.ForeColor = System.Drawing.Color.Red;
            this.lab_Countdown.Location = new System.Drawing.Point(589, 492);
            this.lab_Countdown.Name = "lab_Countdown";
            this.lab_Countdown.Size = new System.Drawing.Size(31, 19);
            this.lab_Countdown.TabIndex = 64;
            this.lab_Countdown.Text = "90";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(620, 492);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 19);
            this.label8.TabIndex = 65;
            this.label8.Text = "秒内扫码支付";
            // 
            // time_Countdown
            // 
            this.time_Countdown.Interval = 1000;
            this.time_Countdown.Tick += new System.EventHandler(this.time_Countdown_Tick);
            // 
            // lab_Prompt
            // 
            this.lab_Prompt.AutoSize = true;
            this.lab_Prompt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lab_Prompt.ForeColor = System.Drawing.Color.Red;
            this.lab_Prompt.Location = new System.Drawing.Point(515, 511);
            this.lab_Prompt.Name = "lab_Prompt";
            this.lab_Prompt.Size = new System.Drawing.Size(262, 19);
            this.lab_Prompt.TabIndex = 66;
            this.lab_Prompt.Text = "正在读取后台数据请稍后...";
            this.lab_Prompt.Visible = false;
            // 
            // ScanCodePaySim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_scanpay;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.lab_Prompt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lab_Countdown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pic_WenXinQrCode);
            this.Controls.Add(this.lab_Balance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab_CustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_CustomerNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScanCodePaySim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanCodePaySim_FormClosing);
            this.Load += new System.EventHandler(this.ScanCodePaySim_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScanCodePaySim_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pic_WenXinQrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_CustomerNo;
        private System.Windows.Forms.Label lab_CustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_Balance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pic_WenXinQrCode;
        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_Countdown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer time_Countdown;
        private System.Windows.Forms.Label lab_Prompt;
    }
}