namespace PsstsClient.Forms
{
    partial class SuspendedFormSim
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuspendedFormSim));
            this.btn_exit1 = new System.Windows.Forms.Button();
            this.btn_exit2 = new System.Windows.Forms.Button();
            this.btn_exit3 = new System.Windows.Forms.Button();
            this.btn_exit4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_exit1
            // 
            this.btn_exit1.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatAppearance.BorderSize = 0;
            this.btn_exit1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit1.Location = new System.Drawing.Point(0, 0);
            this.btn_exit1.Name = "btn_exit1";
            this.btn_exit1.Size = new System.Drawing.Size(120, 73);
            this.btn_exit1.TabIndex = 10;
            this.btn_exit1.UseVisualStyleBackColor = false;
            this.btn_exit1.Click += new System.EventHandler(this.btn_exit1_Click);
            // 
            // btn_exit2
            // 
            this.btn_exit2.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatAppearance.BorderSize = 0;
            this.btn_exit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit2.Location = new System.Drawing.Point(902, 0);
            this.btn_exit2.Name = "btn_exit2";
            this.btn_exit2.Size = new System.Drawing.Size(120, 73);
            this.btn_exit2.TabIndex = 11;
            this.btn_exit2.UseVisualStyleBackColor = false;
            this.btn_exit2.Click += new System.EventHandler(this.btn_exit2_Click);
            // 
            // btn_exit3
            // 
            this.btn_exit3.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatAppearance.BorderSize = 0;
            this.btn_exit3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit3.Location = new System.Drawing.Point(902, 694);
            this.btn_exit3.Name = "btn_exit3";
            this.btn_exit3.Size = new System.Drawing.Size(120, 73);
            this.btn_exit3.TabIndex = 12;
            this.btn_exit3.UseVisualStyleBackColor = false;
            this.btn_exit3.Click += new System.EventHandler(this.btn_exit3_Click);
            // 
            // btn_exit4
            // 
            this.btn_exit4.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatAppearance.BorderSize = 0;
            this.btn_exit4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit4.Location = new System.Drawing.Point(0, 694);
            this.btn_exit4.Name = "btn_exit4";
            this.btn_exit4.Size = new System.Drawing.Size(120, 73);
            this.btn_exit4.TabIndex = 13;
            this.btn_exit4.UseVisualStyleBackColor = false;
            this.btn_exit4.Click += new System.EventHandler(this.btn_exit4_Click);
            // 
            // SuspendedFormSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.suspended;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 767);
            this.ControlBox = false;
            this.Controls.Add(this.btn_exit4);
            this.Controls.Add(this.btn_exit3);
            this.Controls.Add(this.btn_exit2);
            this.Controls.Add(this.btn_exit1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuspendedFormSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "自助服务终端客户端";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SuspendedFormSim_Load);
            this.Shown += new System.EventHandler(this.SuspendedFormSim_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_exit1;
        private System.Windows.Forms.Button btn_exit2;
        private System.Windows.Forms.Button btn_exit3;
        private System.Windows.Forms.Button btn_exit4;

    }
}

