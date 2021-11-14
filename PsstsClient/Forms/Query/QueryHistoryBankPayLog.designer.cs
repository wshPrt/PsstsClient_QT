using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PsstsClient.Forms.Query
{
    partial class QueryHistoryBankPayLog
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
            this.tb_query = new System.Windows.Forms.TextBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clear_detail = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_entry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_query
            // 
            this.tb_query.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_query.Location = new System.Drawing.Point(426, 24);
            this.tb_query.MaxLength = 25;
            this.tb_query.Name = "tb_query";
            this.tb_query.Size = new System.Drawing.Size(230, 30);
            this.tb_query.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(265, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输户号/流水号：";
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(818, 22);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 36);
            this.btn_ok.TabIndex = 115;
            this.btn_ok.TabStop = false;
            this.btn_ok.Text = "确认查询";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancle.Location = new System.Drawing.Point(769, 93);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(82, 43);
            this.btn_cancle.TabIndex = 116;
            this.btn_cancle.TabStop = false;
            this.btn_cancle.Text = "返回";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_del.Location = new System.Drawing.Point(672, 23);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(67, 35);
            this.btn_del.TabIndex = 130;
            this.btn_del.TabStop = false;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // btn_num0
            // 
            this.btn_num0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_num0.Location = new System.Drawing.Point(711, 93);
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
            this.btn_num9.Location = new System.Drawing.Point(662, 93);
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
            this.btn_num8.Location = new System.Drawing.Point(613, 93);
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
            this.btn_num7.Location = new System.Drawing.Point(564, 93);
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
            this.btn_num6.Location = new System.Drawing.Point(515, 93);
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
            this.btn_num5.Location = new System.Drawing.Point(466, 93);
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
            this.btn_num4.Location = new System.Drawing.Point(417, 93);
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
            this.btn_num3.Location = new System.Drawing.Point(368, 93);
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
            this.btn_num2.Location = new System.Drawing.Point(319, 93);
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
            this.btn_num1.Location = new System.Drawing.Point(270, 93);
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
            this.btn_Clear.Location = new System.Drawing.Point(745, 22);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(67, 36);
            this.btn_Clear.TabIndex = 157;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // dgv_detail
            // 
            this.dgv_detail.AllowUserToAddRows = false;
            this.dgv_detail.AllowUserToDeleteRows = false;
            this.dgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_detail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_detail.Location = new System.Drawing.Point(215, 176);
            this.dgv_detail.Name = "dgv_detail";
            this.dgv_detail.ReadOnly = true;
            this.dgv_detail.RowTemplate.Height = 23;
            this.dgv_detail.Size = new System.Drawing.Size(743, 408);
            this.dgv_detail.TabIndex = 158;
            //this.dgv_detail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_detail_CellMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(210, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 160;
            this.label2.Text = "交易记录";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 162;
            this.label4.Text = "清机记录";
            // 
            // clear_detail
            // 
            this.clear_detail.AllowUserToAddRows = false;
            this.clear_detail.AllowUserToDeleteRows = false;
            this.clear_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clear_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.clear_detail.BackgroundColor = System.Drawing.Color.White;
            this.clear_detail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.clear_detail.Location = new System.Drawing.Point(11, 176);
            this.clear_detail.Name = "clear_detail";
            this.clear_detail.ReadOnly = true;
            this.clear_detail.RowTemplate.Height = 23;
            this.clear_detail.Size = new System.Drawing.Size(198, 408);
            this.clear_detail.TabIndex = 163;
            this.clear_detail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.clear_detail_CellMouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(22, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 165;
            this.label5.Text = "请选择日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(32, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 25);
            this.label7.TabIndex = 167;
            this.label7.Text = "至";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 21);
            this.dateTimePicker1.TabIndex = 164;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(27, 102);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 21);
            this.dateTimePicker2.TabIndex = 168;
            // 
            // btn_entry
            // 
            this.btn_entry.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_entry.Location = new System.Drawing.Point(162, 67);
            this.btn_entry.Name = "btn_entry";
            this.btn_entry.Size = new System.Drawing.Size(82, 43);
            this.btn_entry.TabIndex = 169;
            this.btn_entry.TabStop = false;
            this.btn_entry.Text = "确  定";
            this.btn_entry.UseVisualStyleBackColor = true;
            this.btn_entry.Click += new System.EventHandler(this.btn_entry_Click);
            // 
            // QueryHistoryBankPayLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsstsClient.Properties.Resources.flashbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(971, 596);
            this.Controls.Add(this.btn_entry);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.clear_detail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.tb_query);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryHistoryBankPayLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.QueryHistoryCashPayLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_query;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView clear_detail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_entry;

    }
}