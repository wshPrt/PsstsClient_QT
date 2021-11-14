using System;
using System.Windows.Forms;
using PsstsClient.Utility;
using PsstsClient.Driver;
using PsstsClient.Bll;

namespace PsstsClient.Forms.Hardware
{
    public partial class ThermalPrinterTest : Form
    {
        public ThermalPrinterTest()
        {
            InitializeComponent();
        }
        private HardwareTest ht;

        private void ThermalPrinterTest_Load(object sender, EventArgs e)
        {
            this.cb_port.SelectedIndex = Common.ReadIniInt("ClientParam.ini", "ThermalPrinter", "port");
            this.cb_baud.Text = Common.ReadIniStr("ClientParam.ini", "ThermalPrinter", "baud");
                
            if (DriverCommon.Printer)
            {
                this.btn_openport.Enabled = false;
                this.btn_reset.Enabled = true;
                this.btn_test.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_closeport.Enabled = true;
            }
            else
            {
                this.btn_openport.Enabled = true;
                this.btn_reset.Enabled = false;
                this.btn_test.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_closeport.Enabled = false;
            }
            this.btn_reset.Enabled = true;
            this.btn_test.Enabled = true;
            this.btn_getstatus.Enabled = true;
            this.btn_closeport.Enabled = true;
            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null, "热敏打印机测试");
        }

        //打开串口 热敏打印端口3 波特率9600
        private void btn_openport_Click(object sender, EventArgs e)
        {
            int port;
            long baud;
            port = this.cb_port.SelectedIndex;
            baud = long.Parse(this.cb_baud.Text);
            DriverCommon.PrinterDriver = new ThermalPrinterDriver(port, baud);
            if (DriverCommon.Printer)
            {
                this.btn_openport.Enabled = false;
                this.btn_reset.Enabled = true;
                this.btn_test.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_closeport.Enabled = true;
                ht.ShowMsg("打开串口", "成功");
            }
            else
                ht.ShowMsg("打开串口", "失败");
        }

        //复位
        private void btn_reset_Click(object sender, EventArgs e)
        {
            if(DriverCommon.PrinterDriver.DICReset())
                ht.ShowMsg("复位", "成功");
            else
                ht.ShowMsg("复位", "失败");
        }


        //获取状态
        private void btn_getstatus_Click(object sender, EventArgs e)
        {
            int lret = -999;
            String msg = "打开失败";
            try
            {
                lret = DriverCommon.PrinterDriver.DICGetStatus();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            try
            {
                msg = DriverCommon.PrinterDriver.DICGetErrorMsg(lret);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            ht.ShowMsg("获取状态" + lret, msg);         

        }

        //关闭串口
        private void btn_closeport_Click(object sender, EventArgs e)
        {
            if (DriverCommon.PrinterDriver.DICClose())
            {
                this.btn_openport.Enabled = true;
                this.btn_reset.Enabled = false;
                this.btn_test.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_closeport.Enabled = false;
                ht.ShowMsg("关闭串口", "成功");
            }
            else
                ht.ShowMsg("关闭串口", "失败");
        }

        //测试
        private void btn_test_Click(object sender, EventArgs e)
        {
            String printdata = "            海南电网海口供电公司\n"
                             + "            自助服务终端缴费凭条\n"
                             + "------------------------------------------------\n"
                             + "用户编号：8888888888\n"
                             + "用户名称：张三\n"
                             + "用户地址：海口市龙华区大同路34号\n"
                             + "------------------------------------------------\n"
                             + "自助流水号：000000132873\n"
                             + "交易类型：欠费缴纳\n"
                             + "交易状态：成功\n"
                             + "支付方式：现金\n"
                             + "------------------------------------------------\n"
                             + "上次余额：￥0.35\n"
                             + "欠费金额：￥123.74\n"
                             + "缴费金额：￥130.00\n"
                             + "账户余额：￥6.61\n"
                             + "------------------------------------------------\n"
                             + "缴费成功！\n"
                             + "\n"
                             + "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n"
                             + "终端编号：" + Client.MachineCode + "\n"
                             + "\n"
                             + "如有疑问请致电客户服务热线95598咨询！\n"
                             + "欢迎再次使用自助缴费终端！";


            DriverCommon.PrinterDriver.PrintAndCutpaper(printdata);
        }
    }
}
