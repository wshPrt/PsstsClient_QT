namespace PsstsClient.Forms.Query
{
    partial class QueryElecInfo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pb_returnprevious = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_OrgNo = new System.Windows.Forms.Label();
            this.lab_ConsNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_ConsName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_ElecAddr = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lab_RcvblAmt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lab_TPq = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lab_RcvblYm = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pb_back_top = new System.Windows.Forms.Button();
            this.lab_RcvblPenalty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_SettleFlag = new System.Windows.Forms.Label();
            this.lab_CtlMode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.but_Next = new System.Windows.Forms.Button();
            this.but_Prev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
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
            this.label7.Text = "电费信息";
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
            this.pb_returnprevious.TabIndex = 62;
            this.pb_returnprevious.Text = "返回上一页";
            this.pb_returnprevious.UseVisualStyleBackColor = false;
            this.pb_returnprevious.Click += new System.EventHandler(this.pb_returnprevious_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(697, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "供电单位：";
            // 
            // lab_OrgNo
            // 
            this.lab_OrgNo.AutoSize = true;
            this.lab_OrgNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_OrgNo.Location = new System.Drawing.Point(796, 199);
            this.lab_OrgNo.Name = "lab_OrgNo";
            this.lab_OrgNo.Size = new System.Drawing.Size(17, 16);
            this.lab_OrgNo.TabIndex = 64;
            this.lab_OrgNo.Text = "-";
            // 
            // lab_ConsNo
            // 
            this.lab_ConsNo.AutoSize = true;
            this.lab_ConsNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_ConsNo.Location = new System.Drawing.Point(489, 199);
            this.lab_ConsNo.Name = "lab_ConsNo";
            this.lab_ConsNo.Size = new System.Drawing.Size(17, 16);
            this.lab_ConsNo.TabIndex = 66;
            this.lab_ConsNo.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(390, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "用户编号：";
            // 
            // lab_ConsName
            // 
            this.lab_ConsName.AutoSize = true;
            this.lab_ConsName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_ConsName.Location = new System.Drawing.Point(489, 234);
            this.lab_ConsName.Name = "lab_ConsName";
            this.lab_ConsName.Size = new System.Drawing.Size(17, 16);
            this.lab_ConsName.TabIndex = 68;
            this.lab_ConsName.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(390, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "用户名称：";
            // 
            // lab_ElecAddr
            // 
            this.lab_ElecAddr.AutoSize = true;
            this.lab_ElecAddr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_ElecAddr.Location = new System.Drawing.Point(490, 271);
            this.lab_ElecAddr.Name = "lab_ElecAddr";
            this.lab_ElecAddr.Size = new System.Drawing.Size(17, 16);
            this.lab_ElecAddr.TabIndex = 72;
            this.lab_ElecAddr.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(391, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 71;
            this.label6.Text = "用电地址：";
            // 
            // lab_RcvblAmt
            // 
            this.lab_RcvblAmt.AutoSize = true;
            this.lab_RcvblAmt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_RcvblAmt.ForeColor = System.Drawing.Color.Red;
            this.lab_RcvblAmt.Location = new System.Drawing.Point(796, 309);
            this.lab_RcvblAmt.Name = "lab_RcvblAmt";
            this.lab_RcvblAmt.Size = new System.Drawing.Size(17, 16);
            this.lab_RcvblAmt.TabIndex = 80;
            this.lab_RcvblAmt.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(714, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 79;
            this.label11.Text = "总电费：";
            // 
            // lab_TPq
            // 
            this.lab_TPq.AutoSize = true;
            this.lab_TPq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_TPq.Location = new System.Drawing.Point(796, 271);
            this.lab_TPq.Name = "lab_TPq";
            this.lab_TPq.Size = new System.Drawing.Size(17, 16);
            this.lab_TPq.TabIndex = 78;
            this.lab_TPq.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(714, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 16);
            this.label13.TabIndex = 77;
            this.label13.Text = "总电量：";
            // 
            // lab_RcvblYm
            // 
            this.lab_RcvblYm.AutoSize = true;
            this.lab_RcvblYm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_RcvblYm.Location = new System.Drawing.Point(796, 234);
            this.lab_RcvblYm.Name = "lab_RcvblYm";
            this.lab_RcvblYm.Size = new System.Drawing.Size(17, 16);
            this.lab_RcvblYm.TabIndex = 76;
            this.lab_RcvblYm.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(697, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 16);
            this.label15.TabIndex = 75;
            this.label15.Text = "电费年月：";
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
            this.pb_back_top.TabIndex = 81;
            this.pb_back_top.TabStop = false;
            this.pb_back_top.Text = "返回首页";
            this.pb_back_top.UseVisualStyleBackColor = false;
            this.pb_back_top.Click += new System.EventHandler(this.pb_back_top_Click);
            // 
            // lab_RcvblPenalty
            // 
            this.lab_RcvblPenalty.AutoSize = true;
            this.lab_RcvblPenalty.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_RcvblPenalty.ForeColor = System.Drawing.Color.Red;
            this.lab_RcvblPenalty.Location = new System.Drawing.Point(796, 344);
            this.lab_RcvblPenalty.Name = "lab_RcvblPenalty";
            this.lab_RcvblPenalty.Size = new System.Drawing.Size(17, 16);
            this.lab_RcvblPenalty.TabIndex = 83;
            this.lab_RcvblPenalty.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(714, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 82;
            this.label8.Text = "违约金：";
            // 
            // lab_SettleFlag
            // 
            this.lab_SettleFlag.AutoSize = true;
            this.lab_SettleFlag.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_SettleFlag.Location = new System.Drawing.Point(489, 344);
            this.lab_SettleFlag.Name = "lab_SettleFlag";
            this.lab_SettleFlag.Size = new System.Drawing.Size(17, 16);
            this.lab_SettleFlag.TabIndex = 74;
            this.lab_SettleFlag.Text = "-";
            // 
            // lab_CtlMode
            // 
            this.lab_CtlMode.AutoSize = true;
            this.lab_CtlMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lab_CtlMode.Location = new System.Drawing.Point(490, 309);
            this.lab_CtlMode.Name = "lab_CtlMode";
            this.lab_CtlMode.Size = new System.Drawing.Size(17, 16);
            this.lab_CtlMode.TabIndex = 70;
            this.lab_CtlMode.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(391, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 69;
            this.label4.Text = "电费类别：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(390, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 73;
            this.label9.Text = "结清状态：";
            // 
            // but_Next
            // 
            this.but_Next.BackColor = System.Drawing.Color.Transparent;
            this.but_Next.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_next;
            this.but_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Next.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.but_Next.FlatAppearance.BorderSize = 0;
            this.but_Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Next.Location = new System.Drawing.Point(700, 416);
            this.but_Next.Name = "but_Next";
            this.but_Next.Size = new System.Drawing.Size(133, 48);
            this.but_Next.TabIndex = 103;
            this.but_Next.TabStop = false;
            this.but_Next.UseVisualStyleBackColor = false;
            this.but_Next.Visible = false;
            this.but_Next.Click += new System.EventHandler(this.but_Next_Click);
            // 
            // but_Prev
            // 
            this.but_Prev.BackColor = System.Drawing.Color.Transparent;
            this.but_Prev.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_prev;
            this.but_Prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Prev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.but_Prev.FlatAppearance.BorderSize = 0;
            this.but_Prev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_Prev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Prev.Location = new System.Drawing.Point(460, 416);
            this.but_Prev.Name = "but_Prev";
            this.but_Prev.Size = new System.Drawing.Size(133, 48);
            this.but_Prev.TabIndex = 102;
            this.but_Prev.TabStop = false;
            this.but_Prev.UseVisualStyleBackColor = false;
            this.but_Prev.Visible = false;
            this.but_Prev.Click += new System.EventHandler(this.but_Prev_Click);
            // 
            // QueryElecInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_bgquery_detailed;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.but_Next);
            this.Controls.Add(this.but_Prev);
            this.Controls.Add(this.lab_RcvblPenalty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pb_back_top);
            this.Controls.Add(this.lab_RcvblAmt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lab_TPq);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lab_RcvblYm);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lab_SettleFlag);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lab_ElecAddr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lab_CtlMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_ConsName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab_ConsNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_OrgNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_returnprevious);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryElecInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "main_query";
            this.Load += new System.EventHandler(this.QueryElecInfo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QueryElecInfo_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button pb_returnprevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_OrgNo;
        private System.Windows.Forms.Label lab_ConsNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_ConsName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_ElecAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lab_RcvblAmt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lab_TPq;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lab_RcvblYm;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button pb_back_top;
        private System.Windows.Forms.Label lab_RcvblPenalty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_SettleFlag;
        private System.Windows.Forms.Label lab_CtlMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button but_Next;
        private System.Windows.Forms.Button but_Prev;
    }
}