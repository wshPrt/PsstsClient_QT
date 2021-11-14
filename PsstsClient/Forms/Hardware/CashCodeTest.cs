using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Hardware
{
    public partial class CashCodeTest : Form
    {

        private void CashE(CashEvent myDelegate, int money, string error)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(myDelegate, new object[] { money, error });
            }
            else
            {
                myDelegate(money, error);
            }
        }

        public CashCodeTest()
        {
            InitializeComponent();
        }

        private HardwareTest ht = null;

        private void CashCodeTest_Load(object sender, EventArgs e)
        {
            this.cb_port.SelectedIndex = Common.ReadIniInt("ClientParam.ini", "CashCode", "port");
            this.cb_baud.Text = Common.ReadIniStr("ClientParam.ini", "CashCode", "baud");
            if (DriverCommon.CashCode)
            {
                this.btn_closeport.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_openport.Enabled = false;
                this.btn_startcheck.Enabled = true;
                this.btn_endcheck.Enabled = true;
                this.btn_reset.Enabled = true;
            }
            else
            {
                this.btn_closeport.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_openport.Enabled = true;
                this.btn_startcheck.Enabled = false;
                this.btn_endcheck.Enabled = false;
                this.btn_reset.Enabled = false;
            }
            this.btn_closeport.Enabled = true;
            this.btn_getstatus.Enabled = true;          
            this.btn_startcheck.Enabled = true;
            this.btn_endcheck.Enabled = true;
            this.btn_reset.Enabled = true;
            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null, "纸币识别器测试");
        }
        //打开串口
        private void btn_openport_Click(object sender, EventArgs e)
        {
            try
            {
                DriverCommon.CashCodeDriver = new CashCodeDriver(this.cb_port.SelectedIndex, long.Parse(this.cb_baud.Text));
                if (DriverCommon.CashCode)
                {
                    this.btn_closeport.Enabled = true;
                    this.btn_getstatus.Enabled = true;
                    this.btn_openport.Enabled = false;
                    this.btn_startcheck.Enabled = true;
                    this.btn_endcheck.Enabled = false;
                    this.btn_reset.Enabled = true;

                    ht.ShowMsg("打开串口", "成功");
                }
                else
                {
                    ht.ShowMsg("打开串口","失败");
                }
            }
            catch (Exception ex)
            {
                ht.ShowMsg("打开串口", "异常["+ex.Message+"]");
            }
        }

        //复位
        private void btn_reset_Click(object sender, EventArgs e)
        {
            bool ret=false;
            try
            {
                ret = DriverCommon.CashCodeDriver.DICReset();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            if (ret)            
                ht.ShowMsg("复位设备", "成功");
            else
                ht.ShowMsg("复位设备", "失败");

        }

        //关闭串口
        private void btn_closeport_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CashCodeDriver.DICClose())
            {
                this.btn_closeport.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_openport.Enabled = true;
                this.btn_startcheck.Enabled = false;
                this.btn_endcheck.Enabled = false;
                this.btn_reset.Enabled = false;
                ht.ShowMsg("关闭串口", "成功");
            }
            else
                ht.ShowMsg("关闭串口", "失败");
        }
       

        //获取状态
        private void btn_getstatus_Click(object sender, EventArgs e)
        {
            long lret = -999;
            string msg = "打开失败";
            try
            {
                lret=DriverCommon.CashCodeDriver.DICGetStatus();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            try
            {
            msg=DriverCommon.CashCodeDriver.DICGetErrorMsg(lret);
            }
            catch(Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            ht.ShowMsg("获取状态" + lret, msg);
        }

        //开始验钞
        private void btn_startcheck_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CashCodeDriver.StartIdentify(Client.Billtype,this.GetMoney))
            {
                ht.ShowMsg("开始验钞", "成功，请投入纸币进行测试......");

                this.btn_closeport.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_openport.Enabled = false;
                this.btn_startcheck.Enabled = false;
                this.btn_endcheck.Enabled = true;
                this.btn_reset.Enabled = false;
            }
            else
                ht.ShowMsg("开始验钞", "失败");
        }


        //结束放钞
        private void btn_endcheck_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CashCodeDriver.StopIdentify())
            {
                ht.ShowMsg("结束验钞", "成功");
                this.btn_closeport.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_openport.Enabled = false;
                this.btn_startcheck.Enabled = true;
                this.btn_endcheck.Enabled = true;
                this.btn_reset.Enabled = true;
            }
            else
                ht.ShowMsg("结束验钞", "失败");
        }

        private void GetMoney(int money,String error)
        {
            CashE(setMoney, money, error);
        }

        private void setMoney(int money, String error)
        {

            if (this.lb_money.Text == "")
                lb_money.Text = money.ToString("0.00");
            lb_money.Text = (float.Parse(lb_money.Text) + money).ToString("0.00");
            this.lb_error.Text = error;
        }

  
    }
}
