namespace PsstsClient.Forms.Query
{
    partial class QueryIndex
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
            this.pb_back_top = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.but_BasicInfo = new System.Windows.Forms.Button();
            this.but_ElectricChargeInfo = new System.Windows.Forms.Button();
            this.but_FeesInfo = new System.Windows.Forms.Button();
            this.but_PowerPurchaseInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
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
            this.label7.Text = "查询信息";
            // 
            // but_BasicInfo
            // 
            this.but_BasicInfo.BackColor = System.Drawing.Color.Transparent;
            this.but_BasicInfo.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_basicinfo;
            this.but_BasicInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_BasicInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.but_BasicInfo.FlatAppearance.BorderSize = 0;
            this.but_BasicInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_BasicInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_BasicInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_BasicInfo.Location = new System.Drawing.Point(394, 203);
            this.but_BasicInfo.Name = "but_BasicInfo";
            this.but_BasicInfo.Size = new System.Drawing.Size(236, 90);
            this.but_BasicInfo.TabIndex = 62;
            this.but_BasicInfo.TabStop = false;
            this.but_BasicInfo.UseVisualStyleBackColor = false;
            this.but_BasicInfo.Click += new System.EventHandler(this.but_BasicInfo_Click);
            // 
            // but_ElectricChargeInfo
            // 
            this.but_ElectricChargeInfo.BackColor = System.Drawing.Color.Transparent;
            this.but_ElectricChargeInfo.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_electricchargeinfo;
            this.but_ElectricChargeInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_ElectricChargeInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.but_ElectricChargeInfo.FlatAppearance.BorderSize = 0;
            this.but_ElectricChargeInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_ElectricChargeInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_ElectricChargeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ElectricChargeInfo.Location = new System.Drawing.Point(673, 203);
            this.but_ElectricChargeInfo.Name = "but_ElectricChargeInfo";
            this.but_ElectricChargeInfo.Size = new System.Drawing.Size(236, 90);
            this.but_ElectricChargeInfo.TabIndex = 63;
            this.but_ElectricChargeInfo.TabStop = false;
            this.but_ElectricChargeInfo.UseVisualStyleBackColor = false;
            this.but_ElectricChargeInfo.Click += new System.EventHandler(this.but_ElectricChargeInfo_Click);
            // 
            // but_FeesInfo
            // 
            this.but_FeesInfo.BackColor = System.Drawing.Color.Transparent;
            this.but_FeesInfo.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_feesinfo;
            this.but_FeesInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_FeesInfo.FlatAppearance.BorderSize = 0;
            this.but_FeesInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_FeesInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_FeesInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_FeesInfo.Location = new System.Drawing.Point(673, 366);
            this.but_FeesInfo.Name = "but_FeesInfo";
            this.but_FeesInfo.Size = new System.Drawing.Size(236, 90);
            this.but_FeesInfo.TabIndex = 65;
            this.but_FeesInfo.TabStop = false;
            this.but_FeesInfo.UseVisualStyleBackColor = false;
            this.but_FeesInfo.Click += new System.EventHandler(this.but_FeesInfo_Click);
            // 
            // but_PowerPurchaseInfo
            // 
            this.but_PowerPurchaseInfo.BackColor = System.Drawing.Color.Transparent;
            this.but_PowerPurchaseInfo.BackgroundImage = global::PsstsClient.Properties.Resources.pb_query_powerpurchaseinfo;
            this.but_PowerPurchaseInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_PowerPurchaseInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.but_PowerPurchaseInfo.FlatAppearance.BorderSize = 0;
            this.but_PowerPurchaseInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.but_PowerPurchaseInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.but_PowerPurchaseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_PowerPurchaseInfo.Location = new System.Drawing.Point(394, 366);
            this.but_PowerPurchaseInfo.Name = "but_PowerPurchaseInfo";
            this.but_PowerPurchaseInfo.Size = new System.Drawing.Size(236, 90);
            this.but_PowerPurchaseInfo.TabIndex = 64;
            this.but_PowerPurchaseInfo.TabStop = false;
            this.but_PowerPurchaseInfo.UseVisualStyleBackColor = false;
            this.but_PowerPurchaseInfo.Click += new System.EventHandler(this.but_PowerPurchaseInfo_Click);
            // 
            // QueryIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_bgquery01;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.but_FeesInfo);
            this.Controls.Add(this.but_PowerPurchaseInfo);
            this.Controls.Add(this.but_ElectricChargeInfo);
            this.Controls.Add(this.but_BasicInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_back_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "main_query";
            this.Load += new System.EventHandler(this.QueryIndex_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QueryIndex_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.Button pb_back_top;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button but_BasicInfo;
        private System.Windows.Forms.Button but_ElectricChargeInfo;
        private System.Windows.Forms.Button but_FeesInfo;
        private System.Windows.Forms.Button but_PowerPurchaseInfo;
    }
}