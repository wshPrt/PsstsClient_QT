namespace PsstsClient.Forms
{
    partial class MainFormSim
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
            this.lb_time = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_pay_bank = new System.Windows.Forms.Button();
            this.btn_pay_cash = new System.Windows.Forms.Button();
            this.btn_pay_ic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.BackColor = System.Drawing.Color.Transparent;
            this.lb_time.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_time.ForeColor = System.Drawing.Color.White;
            this.lb_time.Location = new System.Drawing.Point(152, 723);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(55, 26);
            this.lb_time.TabIndex = 15;
            this.lb_time.Text = "V1.0";
            this.lb_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btn_pay_bank
            // 
            this.btn_pay_bank.BackColor = System.Drawing.Color.Transparent;
            this.btn_pay_bank.FlatAppearance.BorderSize = 0;
            this.btn_pay_bank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_bank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_bank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay_bank.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pay_bank.Image = global::PsstsClient.Properties.Resources.pb_pay_ic;
            this.btn_pay_bank.Location = new System.Drawing.Point(395, 50);
            this.btn_pay_bank.Name = "btn_pay_bank";
            this.btn_pay_bank.Size = new System.Drawing.Size(151, 118);
            this.btn_pay_bank.TabIndex = 8;
            this.btn_pay_bank.TabStop = false;
            this.btn_pay_bank.Text = "信息查询";
            this.btn_pay_bank.UseVisualStyleBackColor = false;
            this.btn_pay_bank.Click += new System.EventHandler(this.btn_pay_bank_Click);
            // 
            // btn_pay_cash
            // 
            this.btn_pay_cash.BackColor = System.Drawing.Color.Transparent;
            this.btn_pay_cash.FlatAppearance.BorderSize = 0;
            this.btn_pay_cash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_cash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_cash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay_cash.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pay_cash.Image = global::PsstsClient.Properties.Resources.pb_pay_cash_01;
            this.btn_pay_cash.Location = new System.Drawing.Point(597, 308);
            this.btn_pay_cash.Name = "btn_pay_cash";
            this.btn_pay_cash.Size = new System.Drawing.Size(277, 218);
            this.btn_pay_cash.TabIndex = 7;
            this.btn_pay_cash.TabStop = false;
            this.btn_pay_cash.Text = "卡表购电";
            this.btn_pay_cash.UseVisualStyleBackColor = false;
            this.btn_pay_cash.Click += new System.EventHandler(this.btn_pay_cash_Click);
            // 
            // btn_pay_ic
            // 
            this.btn_pay_ic.BackColor = System.Drawing.Color.Transparent;
            this.btn_pay_ic.FlatAppearance.BorderSize = 0;
            this.btn_pay_ic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_ic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_pay_ic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay_ic.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pay_ic.Image = global::PsstsClient.Properties.Resources.pb_pay_bank_01;
            this.btn_pay_ic.Location = new System.Drawing.Point(539, 138);
            this.btn_pay_ic.Name = "btn_pay_ic";
            this.btn_pay_ic.Size = new System.Drawing.Size(212, 138);
            this.btn_pay_ic.TabIndex = 16;
            this.btn_pay_ic.TabStop = false;
            this.btn_pay_ic.Text = "电费缴纳";
            this.btn_pay_ic.UseVisualStyleBackColor = false;
            this.btn_pay_ic.Click += new System.EventHandler(this.btn_pay_ic_Click);
            // 
            // MainFormSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.bg_mainsim;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.btn_pay_ic);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.btn_pay_bank);
            this.Controls.Add(this.btn_pay_cash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFormSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainFormSim";
            this.Load += new System.EventHandler(this.MainFormSim_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormSim_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pay_cash;
        private System.Windows.Forms.Button btn_pay_bank;
        private System.Windows.Forms.Label lb_time;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_pay_ic;
        //private AxABC_POS_OCXLib.AxABC_POS_OCX axABC_POS_OCX1;
    }
}