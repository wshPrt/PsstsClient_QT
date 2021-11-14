namespace PsstsClient.Forms.Query
{
    partial class QueryBankPayLogSim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>1
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
            this.tb_queryWhere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_num0 = new System.Windows.Forms.Button();
            this.btn_num9 = new System.Windows.Forms.Button();
            this.btn_num8 = new System.Windows.Forms.Button();
            this.btn_num7 = new System.Windows.Forms.Button();
            this.btn_num6 = new System.Windows.Forms.Button();
            this.btn_num5 = new System.Windows.Forms.Button();
            this.btn_num4 = new System.Windows.Forms.Button();
            this.btn_num3 = new System.Windows.Forms.Button();
            this.btn_num2 = new System.Windows.Forms.Button();
            this.btn_num1 = new System.Windows.Forms.Button();
            this.timer_returnmain = new System.Windows.Forms.Timer(this.components);
            this.btn_Clear = new System.Windows.Forms.Button();
            this.dgv_detail = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_repay = new System.Windows.Forms.Button();
            this.btn_record = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_queryWhere
            // 
            this.tb_queryWhere.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_queryWhere.Location = new System.Drawing.Point(215, 50);
            this.tb_queryWhere.MaxLength = 30;
            this.tb_queryWhere.Name = "tb_queryWhere";
            this.tb_queryWhere.Size = new System.Drawing.Size(230, 30);
            this.tb_queryWhere.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(41, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入户号/凭证号：";
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(661, 46);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(85, 43);
            this.btn_ok.TabIndex = 115;
            this.btn_ok.TabStop = false;
            this.btn_ok.Text = "确认查询";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancle.Location = new System.Drawing.Point(591, 102);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(62, 43);
            this.btn_cancle.TabIndex = 116;
            this.btn_cancle.TabStop = false;
            this.btn_cancle.Text = "返回";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_del.Location = new System.Drawing.Point(463, 46);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(71, 43);
            this.btn_del.TabIndex = 130;
            this.btn_del.TabStop = false;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // btn_num0
            // 
            this.btn_num0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num0.Location = new System.Drawing.Point(479, 102);
            this.btn_num0.Name = "btn_num0";
            this.btn_num0.Size = new System.Drawing.Size(43, 43);
            this.btn_num0.TabIndex = 127;
            this.btn_num0.TabStop = false;
            this.btn_num0.Text = "0";
            this.btn_num0.UseVisualStyleBackColor = true;
            // 
            // btn_num9
            // 
            this.btn_num9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num9.Location = new System.Drawing.Point(431, 102);
            this.btn_num9.Name = "btn_num9";
            this.btn_num9.Size = new System.Drawing.Size(43, 43);
            this.btn_num9.TabIndex = 126;
            this.btn_num9.TabStop = false;
            this.btn_num9.Text = "9";
            this.btn_num9.UseVisualStyleBackColor = true;
            // 
            // btn_num8
            // 
            this.btn_num8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num8.Location = new System.Drawing.Point(383, 102);
            this.btn_num8.Name = "btn_num8";
            this.btn_num8.Size = new System.Drawing.Size(43, 43);
            this.btn_num8.TabIndex = 125;
            this.btn_num8.TabStop = false;
            this.btn_num8.Text = "8";
            this.btn_num8.UseVisualStyleBackColor = true;
            // 
            // btn_num7
            // 
            this.btn_num7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num7.Location = new System.Drawing.Point(335, 102);
            this.btn_num7.Name = "btn_num7";
            this.btn_num7.Size = new System.Drawing.Size(43, 43);
            this.btn_num7.TabIndex = 124;
            this.btn_num7.TabStop = false;
            this.btn_num7.Text = "7";
            this.btn_num7.UseVisualStyleBackColor = true;
            // 
            // btn_num6
            // 
            this.btn_num6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num6.Location = new System.Drawing.Point(287, 102);
            this.btn_num6.Name = "btn_num6";
            this.btn_num6.Size = new System.Drawing.Size(43, 43);
            this.btn_num6.TabIndex = 123;
            this.btn_num6.TabStop = false;
            this.btn_num6.Text = "6";
            this.btn_num6.UseVisualStyleBackColor = true;
            // 
            // btn_num5
            // 
            this.btn_num5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num5.Location = new System.Drawing.Point(239, 102);
            this.btn_num5.Name = "btn_num5";
            this.btn_num5.Size = new System.Drawing.Size(43, 43);
            this.btn_num5.TabIndex = 122;
            this.btn_num5.TabStop = false;
            this.btn_num5.Text = "5";
            this.btn_num5.UseVisualStyleBackColor = true;
            // 
            // btn_num4
            // 
            this.btn_num4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num4.Location = new System.Drawing.Point(191, 102);
            this.btn_num4.Name = "btn_num4";
            this.btn_num4.Size = new System.Drawing.Size(43, 43);
            this.btn_num4.TabIndex = 121;
            this.btn_num4.TabStop = false;
            this.btn_num4.Text = "4";
            this.btn_num4.UseVisualStyleBackColor = true;
            // 
            // btn_num3
            // 
            this.btn_num3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num3.Location = new System.Drawing.Point(143, 102);
            this.btn_num3.Name = "btn_num3";
            this.btn_num3.Size = new System.Drawing.Size(43, 43);
            this.btn_num3.TabIndex = 120;
            this.btn_num3.TabStop = false;
            this.btn_num3.Text = "3";
            this.btn_num3.UseVisualStyleBackColor = true;
            // 
            // btn_num2
            // 
            this.btn_num2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num2.Location = new System.Drawing.Point(95, 102);
            this.btn_num2.Name = "btn_num2";
            this.btn_num2.Size = new System.Drawing.Size(43, 43);
            this.btn_num2.TabIndex = 119;
            this.btn_num2.TabStop = false;
            this.btn_num2.Text = "2";
            this.btn_num2.UseVisualStyleBackColor = true;
            // 
            // btn_num1
            // 
            this.btn_num1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num1.Location = new System.Drawing.Point(47, 102);
            this.btn_num1.Name = "btn_num1";
            this.btn_num1.Size = new System.Drawing.Size(43, 43);
            this.btn_num1.TabIndex = 118;
            this.btn_num1.TabStop = false;
            this.btn_num1.Text = "1";
            this.btn_num1.UseVisualStyleBackColor = true;
            // 
            // timer_returnmain
            // 
            this.timer_returnmain.Interval = 120000;
            this.timer_returnmain.Tick += new System.EventHandler(this.timer_returnmain_Tick);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clear.Location = new System.Drawing.Point(552, 46);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(92, 43);
            this.btn_Clear.TabIndex = 157;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // dgv_detail
            // 
            this.dgv_detail.AllowUserToAddRows = false;
            this.dgv_detail.AllowUserToDeleteRows = false;
            this.dgv_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_detail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_detail.Location = new System.Drawing.Point(47, 173);
            this.dgv_detail.Name = "dgv_detail";
            this.dgv_detail.ReadOnly = true;
            this.dgv_detail.RowTemplate.Height = 23;
            this.dgv_detail.Size = new System.Drawing.Size(675, 402);
            this.dgv_detail.TabIndex = 158;
            this.dgv_detail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_detail_CellMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(48, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 161;
            this.label3.Text = "交易记录";
            // 
            // btn_repay
            // 
            this.btn_repay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_repay.Location = new System.Drawing.Point(528, 102);
            this.btn_repay.Name = "btn_repay";
            this.btn_repay.Size = new System.Drawing.Size(57, 43);
            this.btn_repay.TabIndex = 162;
            this.btn_repay.TabStop = false;
            this.btn_repay.Text = "冲正";
            this.btn_repay.UseVisualStyleBackColor = true;
            this.btn_repay.Click += new System.EventHandler(this.btn_repay_Click);
            // 
            // btn_record
            // 
            this.btn_record.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_record.Location = new System.Drawing.Point(661, 102);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(85, 43);
            this.btn_record.TabIndex = 163;
            this.btn_record.TabStop = false;
            this.btn_record.Text = "历史记录";
            this.btn_record.UseVisualStyleBackColor = true;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // QueryBankPayLogSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.flashbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 596);
            this.Controls.Add(this.btn_record);
            this.Controls.Add(this.btn_repay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_detail);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_num0);
            this.Controls.Add(this.btn_num9);
            this.Controls.Add(this.btn_num8);
            this.Controls.Add(this.btn_num7);
            this.Controls.Add(this.btn_num6);
            this.Controls.Add(this.btn_num5);
            this.Controls.Add(this.btn_num4);
            this.Controls.Add(this.btn_num3);
            this.Controls.Add(this.btn_num2);
            this.Controls.Add(this.btn_num1);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_queryWhere);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryBankPayLogSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.QueryBankPayLogSim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_queryWhere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_num0;
        private System.Windows.Forms.Button btn_num9;
        private System.Windows.Forms.Button btn_num8;
        private System.Windows.Forms.Button btn_num7;
        private System.Windows.Forms.Button btn_num6;
        private System.Windows.Forms.Button btn_num5;
        private System.Windows.Forms.Button btn_num4;
        private System.Windows.Forms.Button btn_num3;
        private System.Windows.Forms.Button btn_num2;
        private System.Windows.Forms.Button btn_num1;
        private System.Windows.Forms.Timer timer_returnmain;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.DataGridView dgv_detail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_repay;
        private System.Windows.Forms.Button btn_record;

    }
}