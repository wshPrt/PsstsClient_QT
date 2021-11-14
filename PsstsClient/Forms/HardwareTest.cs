using PsstsClient.Bll;
using PsstsClient.Forms.Hardware;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class HardwareTest : Form
    {
        public HardwareTest()
        {
            InitializeComponent();
        }

        private Form currentTest = null;

        private void HardwareTest_Load(object sender, EventArgs e)
        {
            this.lv_msg.Columns.Add("时间", 60, HorizontalAlignment.Left);
            this.lv_msg.Columns.Add("操作", 60, HorizontalAlignment.Left);
            this.lv_msg.Columns.Add("操作结果", 200, HorizontalAlignment.Left); 
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            SysMaintainSim sm = new SysMaintainSim();
            sm.MdiParent = this.MdiParent;
            sm.Width = ScreenInfo.ScreenWidth;
            sm.Height = ScreenInfo.ScreenHeight;
            this.Close();
            sm.Show();
        }

        private void btn_cashcode_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            CashCodeTest cct = new CashCodeTest();
            cct.TopLevel = false;
            cct.Parent = this.pn_devtest;
            cct.Show();
            currentTest = cct;
            lb_title.Text = ((Button)sender).Text + "检测";
        }

        private void btn_metalkeyboard_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            MetalKeyboardTest mkt = new MetalKeyboardTest();
            mkt.TopLevel = false;
            mkt.Parent = this.pn_devtest;
            mkt.Show();
            currentTest = mkt;
            lb_title.Text = ((Button)sender).Text + "检测";
        }

        private void btn_icreader_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            ICReaderTest irt = new ICReaderTest();
            irt.TopLevel = false;
            irt.Parent = this.pn_devtest;
            irt.Show();
            currentTest = irt;
            lb_title.Text = ((Button)sender).Text + "检测";
        }

        private void btn_cardreader_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            //CardReaderTest crt = new CardReaderTest();
            //ActA6Test crt = new ActA6Test();
            //crt.TopLevel = false;
            //crt.Parent = this.pn_devtest;
            //crt.Show();
            //currentTest = crt;
            lb_title.Text = ((Button)sender).Text + "检测";
        }

        private void btn_thermalprinter_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            ThermalPrinterTest tpt = new ThermalPrinterTest();
            tpt.TopLevel = false;
            tpt.Parent = this.pn_devtest;
            tpt.Show();
            currentTest = tpt;
            lb_title.Text = ((Button)sender).Text + "检测";
           
        }

        private void btn_nettest_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
                currentTest.Close();
            NetTest nt = new NetTest();
            nt.TopLevel = false;
            nt.Parent = this.pn_devtest;
            nt.Show();
            currentTest = nt;
            lb_title.Text = "网络连接测试";
        }

        public void ShowMsg(string caption, string msg){
            DateTime dt = DateTime.Now;
            String time = dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");
            ListViewItem lvi = new ListViewItem(new String[]{time,caption,msg});
            this.lv_msg.Items.Add(lvi);
            lv_msg.EnsureVisible(lv_msg.Items.Count - 1);
        }

        public void ClearMsg(){
            this.lv_msg.Items.Clear();
        }
    }
}
