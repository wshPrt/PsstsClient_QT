namespace PsstsClient.Forms.Pay
{
    partial class InputCashSim
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
            this.lb_billMoney = new System.Windows.Forms.Label();
            this.lb_InputMoney = new System.Windows.Forms.Label();
            this.lb_error = new System.Windows.Forms.Label();
            this.labelytke = new System.Windows.Forms.Label();
            this.labelqfje = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_paymoney = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer_returnMain = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pb_ok = new System.Windows.Forms.PictureBox();
            this.lab_consNo = new System.Windows.Forms.Label();
            this.lab_consName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lab_MZ = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_billMoney
            // 
            this.lb_billMoney.BackColor = System.Drawing.Color.Transparent;
            this.lb_billMoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_billMoney.ForeColor = System.Drawing.Color.Red;
            this.lb_billMoney.Location = new System.Drawing.Point(821, 248);
            this.lb_billMoney.Name = "lb_billMoney";
            this.lb_billMoney.Size = new System.Drawing.Size(92, 38);
            this.lb_billMoney.TabIndex = 4;
            this.lb_billMoney.Text = "0.0";
            this.lb_billMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_InputMoney
            // 
            this.lb_InputMoney.BackColor = System.Drawing.Color.Transparent;
            this.lb_InputMoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_InputMoney.ForeColor = System.Drawing.Color.Red;
            this.lb_InputMoney.Location = new System.Drawing.Point(826, 285);
            this.lb_InputMoney.Name = "lb_InputMoney";
            this.lb_InputMoney.Size = new System.Drawing.Size(87, 38);
            this.lb_InputMoney.TabIndex = 7;
            this.lb_InputMoney.Text = "0.0";
            this.lb_InputMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.lb_error.BackColor = System.Drawing.Color.Transparent;
            this.lb_error.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(437, 511);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(0, 25);
            this.lb_error.TabIndex = 9;
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelytke
            // 
            this.labelytke.BackColor = System.Drawing.Color.Transparent;
            this.labelytke.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelytke.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelytke.Location = new System.Drawing.Point(692, 285);
            this.labelytke.Name = "labelytke";
            this.labelytke.Size = new System.Drawing.Size(109, 38);
            this.labelytke.TabIndex = 21;
            this.labelytke.Text = "已投金额：";
            this.labelytke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelqfje
            // 
            this.labelqfje.BackColor = System.Drawing.Color.Transparent;
            this.labelqfje.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelqfje.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelqfje.Location = new System.Drawing.Point(692, 248);
            this.labelqfje.Name = "labelqfje";
            this.labelqfje.Size = new System.Drawing.Size(110, 38);
            this.labelqfje.TabIndex = 22;
            this.labelqfje.Text = "应收金额：";
            this.labelqfje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(919, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 38);
            this.label3.TabIndex = 23;
            this.label3.Text = "元";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(919, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 38);
            this.label4.TabIndex = 24;
            this.label4.Text = "元";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_1
            // 
            this.label_1.BackColor = System.Drawing.Color.Transparent;
            this.label_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_1.Location = new System.Drawing.Point(532, 145);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(113, 28);
            this.label_1.TabIndex = 25;
            this.label_1.Text = "客户编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(527, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 132);
            this.label1.TabIndex = 26;
            this.label1.Text = "1、请在指示灯变绿后平整插入纸币\r\n2、如需投入多张纸币，请一张一张平铺插入纸币\r\n3、投币结束后，请按“确定”按钮完成缴费\r\n4、缴费结束后，请取走打印出来的相" +
    "关凭条\r\n5、本机不找零，余额转预收电费\r\n6、投币过程指示灯变红且无法投币，表示钞箱已满。";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(919, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 38);
            this.label2.TabIndex = 28;
            this.label2.Text = "元";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_paymoney
            // 
            this.lb_paymoney.BackColor = System.Drawing.Color.Transparent;
            this.lb_paymoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_paymoney.ForeColor = System.Drawing.Color.Red;
            this.lb_paymoney.Location = new System.Drawing.Point(821, 325);
            this.lb_paymoney.Name = "lb_paymoney";
            this.lb_paymoney.Size = new System.Drawing.Size(92, 38);
            this.lb_paymoney.TabIndex = 29;
            this.lb_paymoney.Text = "0.0";
            this.lb_paymoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(691, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 38);
            this.label5.TabIndex = 30;
            this.label5.Text = "预收金额：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer_returnMain
            // 
            this.timer_returnMain.Tick += new System.EventHandler(this.timer_returnMain_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pb_ok
            // 
            this.pb_ok.BackColor = System.Drawing.Color.Transparent;
            this.pb_ok.BackgroundImage = global::PsstsClient.Properties.Resources.pb_ok01;
            this.pb_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_ok.InitialImage = global::PsstsClient.Properties.Resources.pb_ok01;
            this.pb_ok.Location = new System.Drawing.Point(597, 547);
            this.pb_ok.Name = "pb_ok";
            this.pb_ok.Size = new System.Drawing.Size(136, 47);
            this.pb_ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ok.TabIndex = 31;
            this.pb_ok.TabStop = false;
            this.pb_ok.Click += new System.EventHandler(this.pb_ok_Click);
            // 
            // lab_consNo
            // 
            this.lab_consNo.BackColor = System.Drawing.Color.Transparent;
            this.lab_consNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_consNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_consNo.Location = new System.Drawing.Point(624, 145);
            this.lab_consNo.Name = "lab_consNo";
            this.lab_consNo.Size = new System.Drawing.Size(210, 28);
            this.lab_consNo.TabIndex = 33;
            this.lab_consNo.Text = "-";
            // 
            // lab_consName
            // 
            this.lab_consName.BackColor = System.Drawing.Color.Transparent;
            this.lab_consName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_consName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_consName.Location = new System.Drawing.Point(624, 174);
            this.lab_consName.Name = "lab_consName";
            this.lab_consName.Size = new System.Drawing.Size(210, 28);
            this.lab_consName.TabIndex = 35;
            this.lab_consName.Text = "-";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(532, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 28);
            this.label8.TabIndex = 34;
            this.label8.Text = "客户名称：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(474, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 24);
            this.label7.TabIndex = 64;
            this.label7.Text = "现金支付";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PsstsClient.Properties.Resources.bg_money;
            this.pictureBox1.Location = new System.Drawing.Point(394, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::PsstsClient.Properties.Resources.qtb_s;
            this.pictureBox2.Location = new System.Drawing.Point(362, 372);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // lab_MZ
            // 
            this.lab_MZ.AutoSize = true;
            this.lab_MZ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_MZ.ForeColor = System.Drawing.Color.Red;
            this.lab_MZ.Location = new System.Drawing.Point(528, 522);
            this.lab_MZ.Name = "lab_MZ";
            this.lab_MZ.Size = new System.Drawing.Size(297, 14);
            this.lab_MZ.TabIndex = 66;
            this.lab_MZ.Text = "请投入面值为：100、50、20、10 元的纸币";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(404, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 37);
            this.button1.TabIndex = 67;
            this.button1.Text = "+10";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputCashSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_bgcash031;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lab_MZ);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab_consName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lab_consNo);
            this.Controls.Add(this.pb_ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_paymoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_InputMoney);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_billMoney);
            this.Controls.Add(this.labelytke);
            this.Controls.Add(this.labelqfje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.lb_error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputCashSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.InputCashSim_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InputCashSim_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_billMoney;
        private System.Windows.Forms.Label lb_InputMoney;
        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.Label labelytke;
        private System.Windows.Forms.Label labelqfje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_paymoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer_returnMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pb_ok;
        private System.Windows.Forms.Label lab_consNo;
        private System.Windows.Forms.Label lab_consName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lab_MZ;
        private System.Windows.Forms.Button button1;
    }
}