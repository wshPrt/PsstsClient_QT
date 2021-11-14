namespace PsstsClient.Forms.Hardware
{
    partial class UPHardwareCom
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
            this.but_Save = new System.Windows.Forms.Button();
            this.comb_MetalKeyboard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comb_ICRead = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comb_CardRead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comb_CashCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comb_ThermalPrinter = new System.Windows.Forms.ComboBox();
            this.but_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_Save
            // 
            this.but_Save.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Save.Location = new System.Drawing.Point(37, 317);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(111, 43);
            this.but_Save.TabIndex = 0;
            this.but_Save.Text = "保存修改";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // comb_MetalKeyboard
            // 
            this.comb_MetalKeyboard.FormattingEnabled = true;
            this.comb_MetalKeyboard.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comb_MetalKeyboard.Location = new System.Drawing.Point(181, 91);
            this.comb_MetalKeyboard.Name = "comb_MetalKeyboard";
            this.comb_MetalKeyboard.Size = new System.Drawing.Size(77, 20);
            this.comb_MetalKeyboard.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(82, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "密码键盘：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(82, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "IC读卡器：";
            // 
            // comb_ICRead
            // 
            this.comb_ICRead.FormattingEnabled = true;
            this.comb_ICRead.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comb_ICRead.Location = new System.Drawing.Point(181, 141);
            this.comb_ICRead.Name = "comb_ICRead";
            this.comb_ICRead.Size = new System.Drawing.Size(77, 20);
            this.comb_ICRead.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(48, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "银行卡读卡器：";
            // 
            // comb_CardRead
            // 
            this.comb_CardRead.FormattingEnabled = true;
            this.comb_CardRead.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comb_CardRead.Location = new System.Drawing.Point(181, 191);
            this.comb_CardRead.Name = "comb_CardRead";
            this.comb_CardRead.Size = new System.Drawing.Size(77, 20);
            this.comb_CardRead.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(65, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "纸币识别器：";
            // 
            // comb_CashCode
            // 
            this.comb_CashCode.FormattingEnabled = true;
            this.comb_CashCode.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comb_CashCode.Location = new System.Drawing.Point(181, 242);
            this.comb_CashCode.Name = "comb_CashCode";
            this.comb_CashCode.Size = new System.Drawing.Size(77, 20);
            this.comb_CashCode.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(65, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "凭条打印机：";
            // 
            // comb_ThermalPrinter
            // 
            this.comb_ThermalPrinter.FormattingEnabled = true;
            this.comb_ThermalPrinter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comb_ThermalPrinter.Location = new System.Drawing.Point(181, 50);
            this.comb_ThermalPrinter.Name = "comb_ThermalPrinter";
            this.comb_ThermalPrinter.Size = new System.Drawing.Size(77, 20);
            this.comb_ThermalPrinter.TabIndex = 9;
            // 
            // but_Back
            // 
            this.but_Back.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Back.Location = new System.Drawing.Point(185, 317);
            this.but_Back.Name = "but_Back";
            this.but_Back.Size = new System.Drawing.Size(111, 43);
            this.but_Back.TabIndex = 11;
            this.but_Back.Text = "返    回";
            this.but_Back.UseVisualStyleBackColor = true;
            this.but_Back.Click += new System.EventHandler(this.but_Back_Click);
            // 
            // UPHardwareCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 418);
            this.ControlBox = false;
            this.Controls.Add(this.but_Back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comb_ThermalPrinter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comb_CashCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comb_CardRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comb_ICRead);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comb_MetalKeyboard);
            this.Controls.Add(this.but_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UPHardwareCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UPHardwareCom";
            this.Load += new System.EventHandler(this.UPHardwareCom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Save;
        private System.Windows.Forms.ComboBox comb_MetalKeyboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comb_ICRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comb_CardRead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comb_CashCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comb_ThermalPrinter;
        private System.Windows.Forms.Button but_Back;
    }
}