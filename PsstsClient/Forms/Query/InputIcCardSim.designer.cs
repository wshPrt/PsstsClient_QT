namespace PsstsClient.Forms.Query
{
    partial class InputIcCardSim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputIcCardSim));
            this.lb_error = new System.Windows.Forms.Label();
            this.labelCustomerInfo = new System.Windows.Forms.Label();
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            this.pb_ok = new System.Windows.Forms.PictureBox();
            this.pb_returnprevious = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.lb_error.BackColor = System.Drawing.Color.Transparent;
            this.lb_error.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(453, 559);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(0, 25);
            this.lb_error.TabIndex = 9;
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCustomerInfo
            // 
            this.labelCustomerInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelCustomerInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCustomerInfo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCustomerInfo.Location = new System.Drawing.Point(408, 60);
            this.labelCustomerInfo.Name = "labelCustomerInfo";
            this.labelCustomerInfo.Size = new System.Drawing.Size(487, 524);
            this.labelCustomerInfo.TabIndex = 25;
            this.labelCustomerInfo.Text = "请芯片朝上插入电卡";
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnMain_Tick);
            // 
            // pb_ok
            // 
            this.pb_ok.BackColor = System.Drawing.Color.Transparent;
            this.pb_ok.BackgroundImage = global::PsstsClient.Properties.Resources.pb_ok01;
            this.pb_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_ok.InitialImage = global::PsstsClient.Properties.Resources.pb_ok01;
            this.pb_ok.Location = new System.Drawing.Point(595, 491);
            this.pb_ok.Name = "pb_ok";
            this.pb_ok.Size = new System.Drawing.Size(141, 59);
            this.pb_ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ok.TabIndex = 32;
            this.pb_ok.TabStop = false;
            this.pb_ok.Click += new System.EventHandler(this.pb_ok_Click);
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
            this.pb_returnprevious.Location = new System.Drawing.Point(898, 539);
            this.pb_returnprevious.Name = "pb_returnprevious";
            this.pb_returnprevious.Size = new System.Drawing.Size(82, 71);
            this.pb_returnprevious.TabIndex = 40;
            this.pb_returnprevious.Text = "返回上一页";
            this.pb_returnprevious.UseVisualStyleBackColor = false;
            this.pb_returnprevious.Click += new System.EventHandler(this.pb_returnprevious_Click);
            // 
            // InputIcCardSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.pb_returnprevious);
            this.Controls.Add(this.pb_ok);
            this.Controls.Add(this.labelCustomerInfo);
            this.Controls.Add(this.lb_error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputIcCardSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputIcCardSim_FormClosing);
            this.Load += new System.EventHandler(this.InputICCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.Label labelCustomerInfo;
        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.PictureBox pb_ok;
        private System.Windows.Forms.Button pb_returnprevious;
    }
}