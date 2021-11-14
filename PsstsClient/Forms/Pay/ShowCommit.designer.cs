namespace PsstsClient.Forms.Pay
{
    partial class ShowCommit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowCommit));
            this.lb_msg1 = new System.Windows.Forms.Label();
            this.lb_msg2 = new System.Windows.Forms.Label();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pb_background = new System.Windows.Forms.PictureBox();
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_background)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_msg1
            // 
            this.lb_msg1.BackColor = System.Drawing.Color.Transparent;
            this.lb_msg1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_msg1.Location = new System.Drawing.Point(10, 34);
            this.lb_msg1.Name = "lb_msg1";
            this.lb_msg1.Size = new System.Drawing.Size(448, 21);
            this.lb_msg1.TabIndex = 2;
            // 
            // lb_msg2
            // 
            this.lb_msg2.BackColor = System.Drawing.Color.Transparent;
            this.lb_msg2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_msg2.Location = new System.Drawing.Point(10, 63);
            this.lb_msg2.Name = "lb_msg2";
            this.lb_msg2.Size = new System.Drawing.Size(448, 65);
            this.lb_msg2.TabIndex = 3;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancle.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancle.Image")));
            this.btn_cancle.Location = new System.Drawing.Point(259, 131);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 32);
            this.btn_cancle.TabIndex = 4;
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.Image")));
            this.btn_ok.Location = new System.Drawing.Point(116, 131);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 32);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pb_background
            // 
            this.pb_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_background.Image = ((System.Drawing.Image)(resources.GetObject("pb_background.Image")));
            this.pb_background.Location = new System.Drawing.Point(0, 0);
            this.pb_background.Name = "pb_background";
            this.pb_background.Size = new System.Drawing.Size(470, 173);
            this.pb_background.TabIndex = 0;
            this.pb_background.TabStop = false;
         
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 5000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
            // 
            // ShowCommit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 173);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.lb_msg2);
            this.Controls.Add(this.lb_msg1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pb_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(165, 213);
            this.Name = "ShowCommit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowMsg";
            this.Load += new System.EventHandler(this.ShowCommit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_background;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lb_msg1;
        private System.Windows.Forms.Label lb_msg2;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Timer timer_returnmain;
    }
}