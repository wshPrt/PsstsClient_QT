namespace PsstsClient.Forms
{
    partial class ShowWaiting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowWaiting));
            this.label1 = new System.Windows.Forms.Label();
            this.pb_waiting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_waiting)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(41, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在处理中，请稍后...";
            // 
            // pb_waiting
            // 
            this.pb_waiting.BackColor = System.Drawing.Color.Transparent;
            this.pb_waiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_waiting.Image = ((System.Drawing.Image)(resources.GetObject("pb_waiting.Image")));
            this.pb_waiting.Location = new System.Drawing.Point(0, 0);
            this.pb_waiting.Name = "pb_waiting";
            this.pb_waiting.Size = new System.Drawing.Size(284, 262);
            this.pb_waiting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_waiting.TabIndex = 0;
            this.pb_waiting.TabStop = false;
            // 
            // ShowWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_waiting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowWaiting";
            this.Opacity = 0.7;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShowWaiting_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowWaiting_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pb_waiting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_waiting;
    }
}