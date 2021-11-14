using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Service;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Pay
{
    public partial class PayResultSim : Form
    {
        private string showInfo;
        private string printInfo;
        private int payRes;
        private int ifprint;
        private string msg = string.Empty;
        ShowCommit sc;

        public PayResultSim()
        {
            InitializeComponent();
        }

        public PayResultSim(int _payRest, string _showInfo, int _ifprint, string _printInfo, string _msg)
        {
            this.printInfo = _printInfo;
            this.payRes = _payRest;
            this.ifprint = _ifprint;
            this.showInfo = _showInfo;
            this.msg = _msg;

            Log4NetHelper.Instance.Debug("输出内容：" + _showInfo);
            Log4NetHelper.Instance.Debug("凭条内容：" + _printInfo);
            InitializeComponent();
        }

        private void PayResultSim_Load(object sender, EventArgs e)
        {
            if (Client.FlowType == Client.icflow)
            {
                DriverCommon.ICReaderDriver.OpenPort();
                DriverCommon.ICReaderDriver.OutCard(true);
                DriverCommon.ICReaderDriver.DICClose();
            }

            //返回主页 
            TimerInit();
            if (showInfo != "")
            {
                this.lb_showResul.Text = showInfo;
            }
            if (this.payRes == 0)
                lb_showTitle.Text = "交易成功，请取走凭条!";
            else
                lb_showTitle.Text = "交易失败，请取凭条到柜台处理!";

            DriverCommon.ICReaderDriver.OutCard(true);

            if (ifprint == 0)
            {
                Common.HideWaiting();
                SoundUtil.SayPrintslip();
                sc = new ShowCommit("是否打印缴费凭条？", "是：打印\r\n否：不打印");
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (DevInfo.PrinterEnable == DevStatic.devEnable && DriverCommon.Printer)
                        {
                            DriverCommon.PrinterDriver.PrintAndCutpaper(this.printInfo);
                            SoundUtil.SayOverprintslip();
                        }
                        else
                        {
                            Common.HideWaiting();
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.WriteLogStr("Errors", "PayResultSim_Load", "打印异常异常[" + ex + "]");
                    }
                }
            }
        }

        private void TimerInit()
        {
            this.timer_returnMain.Enabled = false;
            this.timer_returnMain.Interval = DevInfo.returntime;
            this.timer_returnMain.Enabled = true;
        }

        private void timer_returnMain_Tick(object sender, EventArgs e)
        {
            GoMainFormSim();
        }

        private void GoMainFormSim()
        {
            try
            {
                new BusinessBindService().UnBind();

                this.Hide();
                Main m = (Main)this.Owner;
                m.nowformname = this.Name;
                this.TopMost = false;
                m.obj = null;
                this.Close();
                m.JmpFrom("MainFormSim");
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("返回首页异常", ex);
            }
        }

        private void pb_back_top_Click(object sender, EventArgs e)
        {
            GoMainFormSim();
        }

        private void PayResultSim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
    }
}
