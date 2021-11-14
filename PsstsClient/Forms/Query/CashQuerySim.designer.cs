namespace PsstsClient.Forms.Query
{
    partial class CashQuerySim
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
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            this.pb_returnprevious = new System.Windows.Forms.Button();
            this.pb_back_top = new System.Windows.Forms.Button();
            this.pb_pay_cash = new System.Windows.Forms.Button();
            this.pb_Pay_WeiXin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lab_CustomerName = new System.Windows.Forms.Label();
            this.lab_CustomerNo = new System.Windows.Forms.Label();
            this.lab_CustomerAddress = new System.Windows.Forms.Label();
            this.lab_Balance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_LastPayTime = new System.Windows.Forms.Label();
            this.lab_LastPayMoney = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
            // 
            // pb_returnprevious
            // 
            this.pb_returnprevious.BackColor = System.Drawing.Color.Transparent;
            this.pb_returnprevious.FlatAppearance.BorderSize = 0;
            this.pb_returnprevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pb_returnprevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pb_returnprevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pb_returnprevious.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pb_returnprevious.Image = global::PsstsClient.Properties.Resources.btn_back2;
            this.pb_returnprevious.Location = new System.Drawing.Point(807, 521);
            this.pb_returnprevious.Name = "pb_returnprevious";
            this.pb_returnprevious.Size = new System.Drawing.Size(82, 71);
            this.pb_returnprevious.TabIndex = 40;
            this.pb_returnprevious.TabStop = false;
            this.pb_returnprevious.Text = "返回上一页";
            this.pb_returnprevious.UseVisualStyleBackColor = false;
            this.pb_returnprevious.Visible = false;
            this.pb_returnprevious.Click += new System.EventHandler(this.pb_returnprevious_Click);
            // 
            // pb_back_top
            // 
            this.pb_back_top.BackColor = System.Drawing.Color.Transparent;
            this.pb_back_top.FlatAppearance.BorderSize = 0;
            this.pb_back_top.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pb_back_top.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pb_back_top.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pb_back_top.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pb_back_top.Image = global::PsstsClient.Properties.Resources.pb_back_top01;
            this.pb_back_top.Location = new System.Drawing.Point(895, 521);
            this.pb_back_top.Name = "pb_back_top";
            this.pb_back_top.Size = new System.Drawing.Size(82, 71);
            this.pb_back_top.TabIndex = 41;
            this.pb_back_top.TabStop = false;
            this.pb_back_top.Text = "返回首页";
            this.pb_back_top.UseVisualStyleBackColor = false;
            this.pb_back_top.Click += new System.EventHandler(this.pb_back_top_Click);
            // 
            // pb_pay_cash
            // 
            this.pb_pay_cash.BackColor = System.Drawing.Color.Transparent;
            this.pb_pay_cash.FlatAppearance.BorderSize = 0;
            this.pb_pay_cash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pb_pay_cash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pb_pay_cash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pb_pay_cash.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pb_pay_cash.Image = global::PsstsClient.Properties.Resources.pb_pay_cash011;
            this.pb_pay_cash.Location = new System.Drawing.Point(480, 431);
            this.pb_pay_cash.Name = "pb_pay_cash";
            this.pb_pay_cash.Size = new System.Drawing.Size(133, 65);
            this.pb_pay_cash.TabIndex = 42;
            this.pb_pay_cash.TabStop = false;
            this.pb_pay_cash.UseVisualStyleBackColor = false;
            this.pb_pay_cash.Click += new System.EventHandler(this.pb_pay_cash_Click);
            // 
            // pb_Pay_WeiXin
            // 
            this.pb_Pay_WeiXin.BackColor = System.Drawing.Color.Transparent;
            this.pb_Pay_WeiXin.FlatAppearance.BorderSize = 0;
            this.pb_Pay_WeiXin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pb_Pay_WeiXin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pb_Pay_WeiXin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pb_Pay_WeiXin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pb_Pay_WeiXin.Image = global::PsstsClient.Properties.Resources.pb_pay_weixin;
            this.pb_Pay_WeiXin.Location = new System.Drawing.Point(658, 431);
            this.pb_Pay_WeiXin.Name = "pb_Pay_WeiXin";
            this.pb_Pay_WeiXin.Size = new System.Drawing.Size(133, 65);
            this.pb_Pay_WeiXin.TabIndex = 43;
            this.pb_Pay_WeiXin.TabStop = false;
            this.pb_Pay_WeiXin.UseVisualStyleBackColor = false;
            this.pb_Pay_WeiXin.Click += new System.EventHandler(this.pb_Pay_Weixin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(553, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "客户名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(552, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "客户编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(537, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "账户余额：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(552, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "用电地址：";
            // 
            // lab_CustomerName
            // 
            this.lab_CustomerName.AutoSize = true;
            this.lab_CustomerName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CustomerName.Location = new System.Drawing.Point(665, 181);
            this.lab_CustomerName.Name = "lab_CustomerName";
            this.lab_CustomerName.Size = new System.Drawing.Size(42, 16);
            this.lab_CustomerName.TabIndex = 52;
            this.lab_CustomerName.Text = "张三";
            // 
            // lab_CustomerNo
            // 
            this.lab_CustomerNo.AutoSize = true;
            this.lab_CustomerNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CustomerNo.Location = new System.Drawing.Point(665, 148);
            this.lab_CustomerNo.Name = "lab_CustomerNo";
            this.lab_CustomerNo.Size = new System.Drawing.Size(53, 16);
            this.lab_CustomerNo.TabIndex = 53;
            this.lab_CustomerNo.Text = "10000";
            // 
            // lab_CustomerAddress
            // 
            this.lab_CustomerAddress.AutoSize = true;
            this.lab_CustomerAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CustomerAddress.Location = new System.Drawing.Point(665, 217);
            this.lab_CustomerAddress.Name = "lab_CustomerAddress";
            this.lab_CustomerAddress.Size = new System.Drawing.Size(44, 16);
            this.lab_CustomerAddress.TabIndex = 54;
            this.lab_CustomerAddress.Text = "Test";
            // 
            // lab_Balance
            // 
            this.lab_Balance.AutoSize = true;
            this.lab_Balance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Balance.ForeColor = System.Drawing.Color.Red;
            this.lab_Balance.Location = new System.Drawing.Point(664, 258);
            this.lab_Balance.Name = "lab_Balance";
            this.lab_Balance.Size = new System.Drawing.Size(20, 19);
            this.lab_Balance.TabIndex = 55;
            this.lab_Balance.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(518, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "上次充值时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(518, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "上次充值金额：";
            // 
            // lab_LastPayTime
            // 
            this.lab_LastPayTime.AutoSize = true;
            this.lab_LastPayTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_LastPayTime.Location = new System.Drawing.Point(665, 325);
            this.lab_LastPayTime.Name = "lab_LastPayTime";
            this.lab_LastPayTime.Size = new System.Drawing.Size(17, 16);
            this.lab_LastPayTime.TabIndex = 58;
            this.lab_LastPayTime.Text = "-";
            // 
            // lab_LastPayMoney
            // 
            this.lab_LastPayMoney.AutoSize = true;
            this.lab_LastPayMoney.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_LastPayMoney.Location = new System.Drawing.Point(665, 369);
            this.lab_LastPayMoney.Name = "lab_LastPayMoney";
            this.lab_LastPayMoney.Size = new System.Drawing.Size(17, 16);
            this.lab_LastPayMoney.TabIndex = 59;
            this.lab_LastPayMoney.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PsstsClient.Properties.Resources.bg_userinfo;
            this.pictureBox1.Location = new System.Drawing.Point(394, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.TabIndex = 60;
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
            this.label7.TabIndex = 61;
            this.label7.Text = "用户信息";
            // 
            // CashQuerySim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_bgcash021;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab_LastPayMoney);
            this.Controls.Add(this.lab_LastPayTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_Balance);
            this.Controls.Add(this.lab_CustomerAddress);
            this.Controls.Add(this.lab_CustomerNo);
            this.Controls.Add(this.lab_CustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pb_Pay_WeiXin);
            this.Controls.Add(this.pb_pay_cash);
            this.Controls.Add(this.pb_back_top);
            this.Controls.Add(this.pb_returnprevious);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashQuerySim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "main_query";
            this.Load += new System.EventHandler(this.CashQuerySim_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CashQuerySim_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.Button pb_returnprevious;
        private System.Windows.Forms.Button pb_back_top;
        private System.Windows.Forms.Button pb_pay_cash;
        private System.Windows.Forms.Button pb_Pay_WeiXin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lab_CustomerName;
        private System.Windows.Forms.Label lab_CustomerNo;
        private System.Windows.Forms.Label lab_CustomerAddress;
        private System.Windows.Forms.Label lab_Balance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_LastPayTime;
        private System.Windows.Forms.Label lab_LastPayMoney;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}