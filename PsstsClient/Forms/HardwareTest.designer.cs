namespace PsstsClient.Forms
{
    partial class HardwareTest
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
            this.btn_cashcode = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_metalkeyboard = new System.Windows.Forms.Button();
            this.btn_icreader = new System.Windows.Forms.Button();
            this.btn_cardreader = new System.Windows.Forms.Button();
            this.btn_thermalprinter = new System.Windows.Forms.Button();
            this.btn_nettest = new System.Windows.Forms.Button();
            this.gb_description = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.pn_devtest = new System.Windows.Forms.Panel();
            this.lv_msg = new System.Windows.Forms.ListView();
            this.gb_description.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cashcode
            // 
            this.btn_cashcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cashcode.Location = new System.Drawing.Point(7, 30);
            this.btn_cashcode.Name = "btn_cashcode";
            this.btn_cashcode.Size = new System.Drawing.Size(120, 50);
            this.btn_cashcode.TabIndex = 7;
            this.btn_cashcode.Text = "纸币识别器";
            this.btn_cashcode.UseVisualStyleBackColor = true;
            this.btn_cashcode.Click += new System.EventHandler(this.btn_cashcode_Click);
            // 
            // btn_return
            // 
            this.btn_return.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_return.Location = new System.Drawing.Point(7, 516);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(120, 50);
            this.btn_return.TabIndex = 8;
            this.btn_return.Text = "返      回";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // btn_metalkeyboard
            // 
            this.btn_metalkeyboard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_metalkeyboard.Location = new System.Drawing.Point(7, 111);
            this.btn_metalkeyboard.Name = "btn_metalkeyboard";
            this.btn_metalkeyboard.Size = new System.Drawing.Size(120, 50);
            this.btn_metalkeyboard.TabIndex = 9;
            this.btn_metalkeyboard.Text = "密码键盘";
            this.btn_metalkeyboard.UseVisualStyleBackColor = true;
            this.btn_metalkeyboard.Click += new System.EventHandler(this.btn_metalkeyboard_Click);
            // 
            // btn_icreader
            // 
            this.btn_icreader.Enabled = false;
            this.btn_icreader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_icreader.Location = new System.Drawing.Point(7, 192);
            this.btn_icreader.Name = "btn_icreader";
            this.btn_icreader.Size = new System.Drawing.Size(120, 50);
            this.btn_icreader.TabIndex = 10;
            this.btn_icreader.Text = "IC卡读卡器";
            this.btn_icreader.UseVisualStyleBackColor = true;
            this.btn_icreader.Click += new System.EventHandler(this.btn_icreader_Click);
            // 
            // btn_cardreader
            // 
            this.btn_cardreader.Enabled = false;
            this.btn_cardreader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cardreader.Location = new System.Drawing.Point(7, 273);
            this.btn_cardreader.Name = "btn_cardreader";
            this.btn_cardreader.Size = new System.Drawing.Size(120, 50);
            this.btn_cardreader.TabIndex = 11;
            this.btn_cardreader.Text = "银行卡读卡器";
            this.btn_cardreader.UseVisualStyleBackColor = true;
            this.btn_cardreader.Click += new System.EventHandler(this.btn_cardreader_Click);
            // 
            // btn_thermalprinter
            // 
            this.btn_thermalprinter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_thermalprinter.Location = new System.Drawing.Point(7, 354);
            this.btn_thermalprinter.Name = "btn_thermalprinter";
            this.btn_thermalprinter.Size = new System.Drawing.Size(120, 50);
            this.btn_thermalprinter.TabIndex = 12;
            this.btn_thermalprinter.Text = "热敏打印机";
            this.btn_thermalprinter.UseVisualStyleBackColor = true;
            this.btn_thermalprinter.Click += new System.EventHandler(this.btn_thermalprinter_Click);
            // 
            // btn_nettest
            // 
            this.btn_nettest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nettest.Location = new System.Drawing.Point(7, 435);
            this.btn_nettest.Name = "btn_nettest";
            this.btn_nettest.Size = new System.Drawing.Size(120, 50);
            this.btn_nettest.TabIndex = 13;
            this.btn_nettest.Text = "网络测试";
            this.btn_nettest.UseVisualStyleBackColor = true;
            this.btn_nettest.Click += new System.EventHandler(this.btn_nettest_Click);
            // 
            // gb_description
            // 
            this.gb_description.BackColor = System.Drawing.Color.Transparent;
            this.gb_description.Controls.Add(this.label5);
            this.gb_description.Controls.Add(this.label4);
            this.gb_description.Controls.Add(this.label3);
            this.gb_description.Controls.Add(this.label2);
            this.gb_description.Controls.Add(this.label1);
            this.gb_description.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_description.Location = new System.Drawing.Point(148, 55);
            this.gb_description.Name = "gb_description";
            this.gb_description.Size = new System.Drawing.Size(363, 157);
            this.gb_description.TabIndex = 15;
            this.gb_description.TabStop = false;
            this.gb_description.Text = "操作说明";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "1、选择要测试的功能模块;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "5、关闭串口。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "4、设备功能测试；";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "3、打开串口；";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "2、选择对应的串口和波特率；";
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.BackColor = System.Drawing.Color.Transparent;
            this.lb_title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.Location = new System.Drawing.Point(337, 24);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(222, 28);
            this.lb_title.TabIndex = 14;
            this.lb_title.Text = "自助服务终端设备检测";
            // 
            // pn_devtest
            // 
            this.pn_devtest.Location = new System.Drawing.Point(138, 218);
            this.pn_devtest.Name = "pn_devtest";
            this.pn_devtest.Size = new System.Drawing.Size(384, 364);
            this.pn_devtest.TabIndex = 16;
            // 
            // lv_msg
            // 
            this.lv_msg.BackColor = System.Drawing.SystemColors.Window;
            this.lv_msg.HideSelection = false;
            this.lv_msg.Location = new System.Drawing.Point(522, 66);
            this.lv_msg.Name = "lv_msg";
            this.lv_msg.Size = new System.Drawing.Size(375, 516);
            this.lv_msg.TabIndex = 17;
            this.lv_msg.UseCompatibleStateImageBehavior = false;
            this.lv_msg.View = System.Windows.Forms.View.Details;
            // 
            // HardwareTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(909, 594);
            this.Controls.Add(this.gb_description);
            this.Controls.Add(this.lv_msg);
            this.Controls.Add(this.pn_devtest);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.btn_nettest);
            this.Controls.Add(this.btn_thermalprinter);
            this.Controls.Add(this.btn_cardreader);
            this.Controls.Add(this.btn_icreader);
            this.Controls.Add(this.btn_metalkeyboard);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_cashcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HardwareTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "自助服务终端硬件测试";
            this.Load += new System.EventHandler(this.HardwareTest_Load);
            this.gb_description.ResumeLayout(false);
            this.gb_description.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cashcode;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_metalkeyboard;
        private System.Windows.Forms.Button btn_icreader;
        private System.Windows.Forms.Button btn_cardreader;
        private System.Windows.Forms.Button btn_thermalprinter;
        private System.Windows.Forms.Button btn_nettest;
        private System.Windows.Forms.GroupBox gb_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pn_devtest;
        private System.Windows.Forms.ListView lv_msg;
    }
}