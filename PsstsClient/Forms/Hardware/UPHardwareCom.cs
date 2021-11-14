using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Hardware
{
    public partial class UPHardwareCom : Form
    {
        const string configFileName = "ClientParam.ini";
        public UPHardwareCom()
        {
            InitializeComponent();
        }

        private void UPHardwareCom_Load(object sender, EventArgs e)
        {
            comb_ThermalPrinter.SelectedText = DevInfo.PrinterPort.ToString();
            comb_MetalKeyboard.SelectedText = DevInfo.MetalKeyboardPort.ToString();
            comb_CardRead.SelectedText = DevInfo.CardReaderPort.ToString();
            comb_ICRead.SelectedText = DevInfo.ICReaderPort.ToString();
            comb_CashCode.SelectedText = DevInfo.CashcodePort.ToString();
        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Common.WriteIniStr(configFileName, "ThermalPrinter", "port", comb_ThermalPrinter.Text);
                Common.WriteIniStr(configFileName, "MetalKeyboard", "port", comb_MetalKeyboard.Text);
                Common.WriteIniStr(configFileName, "ICReaderPort", "port", comb_ICRead.Text);
                Common.WriteIniStr(configFileName, "CardReader", "port", comb_CardRead.Text);
                Common.WriteIniStr(configFileName, "CashCode", "port", comb_CashCode.Text);

                DevInfo.PrinterPort = Convert.ToInt32(comb_ThermalPrinter.Text);
                DevInfo.MetalKeyboardPort = Convert.ToInt32(comb_MetalKeyboard.Text);
                DevInfo.ICReaderPort = Convert.ToInt32(comb_ICRead.Text);
                DevInfo.CardReaderPort = Convert.ToInt32(comb_CardRead.Text);
                DevInfo.CashcodePort = Convert.ToInt32(comb_CashCode.Text);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("保存硬件Com端口异常", ex);
            }
        }

        private void but_Back_Click(object sender, EventArgs e)
        {
            SysMaintainSim fm = new SysMaintainSim();
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.WindowState = FormWindowState.Normal;
            fm.Width = ScreenInfo.ScreenWidth;
            fm.Height = ScreenInfo.ScreenHeight;
            fm.Owner = Main.allower;
            fm.TopMost = true;
            fm.Show();
            this.Close();
        }
    }
}
