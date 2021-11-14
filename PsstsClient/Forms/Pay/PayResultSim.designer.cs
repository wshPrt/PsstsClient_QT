namespace PsstsClient.Forms.Pay
{
    partial class PayResultSim
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
            this.lb_showResul = new System.Windows.Forms.Label();
            this.timer_returnMain = new System.Windows.Forms.Timer(this.components);
            this.lb_showTitle = new System.Windows.Forms.Label();
            this.pb_back_top = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_showResul
            // 
            this.lb_showResul.BackColor = System.Drawing.Color.Transparent;
            this.lb_showResul.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_showResul.Location = new System.Drawing.Point(420, 209);
            this.lb_showResul.Name = "lb_showResul";
            this.lb_showResul.Size = new System.Drawing.Size(434, 240);
            this.lb_showResul.TabIndex = 11;
            this.lb_showResul.Text = "1111";
            // 
            // timer_returnMain
            // 
            this.timer_returnMain.Tick += new System.EventHandler(this.timer_returnMain_Tick);
            // 
            // lb_showTitle
            // 
            this.lb_showTitle.AutoSize = true;
            this.lb_showTitle.BackColor = System.Drawing.Color.Transparent;
            this.lb_showTitle.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_showTitle.ForeColor = System.Drawing.Color.Red;
            this.lb_showTitle.Location = new System.Drawing.Point(497, 157);
            this.lb_showTitle.Name = "lb_showTitle";
            this.lb_showTitle.Size = new System.Drawing.Size(294, 36);
            this.lb_showTitle.TabIndex = 25;
            this.lb_showTitle.Text = "交易成功，请取走凭条!";
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
            this.pb_back_top.Location = new System.Drawing.Point(874, 518);
            this.pb_back_top.Name = "pb_back_top";
            this.pb_back_top.Size = new System.Drawing.Size(82, 71);
            this.pb_back_top.TabIndex = 42;
            this.pb_back_top.Text = "返回首页";
            this.pb_back_top.UseVisualStyleBackColor = false;
            this.pb_back_top.Click += new System.EventHandler(this.pb_back_top_Click);
            // 
            // PayResultSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.sub_bgcash032;
            this.ClientSize = new System.Drawing.Size(1023, 634);
            this.Controls.Add(this.pb_back_top);
            this.Controls.Add(this.lb_showTitle);
            this.Controls.Add(this.lb_showResul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PayResultSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PayResultSim";
            this.Load += new System.EventHandler(this.PayResultSim_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PayResultSim_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_showResul;
        private System.Windows.Forms.Timer timer_returnMain;
        private System.Windows.Forms.Label lb_showTitle;
        private System.Windows.Forms.Button pb_back_top;
    }
}