using PsstsClient.Driver;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Hardware
{
    public partial class CardReaderTest : Form
    {
        public CardReaderTest()
        {
            InitializeComponent();
        }
        private HardwareTest ht = null;

        private void CardReaderTest_Load(object sender, EventArgs e)
        {
            this.cb_port.SelectedIndex = Common.ReadIniInt("ClientParam.ini", "CardReader", "port");
            this.cb_baud.Text = Common.ReadIniStr("ClientParam.ini", "CardReader", "baud");
            if (DriverCommon.CardReader)
            {
                this.btn_openport.Enabled = false;
                this.btn_closeport.Enabled = true;
                this.btn_disenableinsert.Enabled = true;
                this.btn_ejectcard.Enabled = true;
                this.btn_enableinsert.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_readcaard.Enabled = true;
                this.btn_reset.Enabled = true;
                this.btn_swallow.Enabled = true;
            }
            else
            {
                this.btn_openport.Enabled = true;
                this.btn_closeport.Enabled = false;
                this.btn_disenableinsert.Enabled = false;
                this.btn_ejectcard.Enabled = false;
                this.btn_enableinsert.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_readcaard.Enabled = false;
                this.btn_reset.Enabled = false;
                this.btn_swallow.Enabled = false;
            }
            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null, "CRT310磁条卡读卡器");
        }
        //打开串口
        private void btn_openport_Click(object sender, EventArgs e)
        {
            DriverCommon.CardReaderDriver = new CardReaderDriver(this.cb_port.SelectedIndex, long.Parse(this.cb_baud.Text));
            if (DriverCommon.CardReader)
            {
                this.btn_openport.Enabled = false;
                this.btn_closeport.Enabled = true;
                this.btn_disenableinsert.Enabled = true;
                this.btn_ejectcard.Enabled = true;
                this.btn_enableinsert.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_readcaard.Enabled = true;
                this.btn_reset.Enabled = true;
                this.btn_swallow.Enabled = true;
                ht.ShowMsg("打开串口", "成功");
                return;
            }
            ht.ShowMsg("打开串口", "失败");
        }

        //设备复位
        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.DICReset())
            {
                ht.ShowMsg("设备复位", "成功");
                return;
            }
            ht.ShowMsg("设备复位", "失败");
        }

        //获取状态
        private void btn_getstatus_Click(object sender, EventArgs e)
        {
            ht.ShowMsg("获取状态", DriverCommon.CardReaderDriver.DICGetErrorMsg(DriverCommon.CardReaderDriver.DICGetStatus()));
        }

        //关闭串口
        private void btn_closeport_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.DICClose())
            {
                this.btn_openport.Enabled = true;
                this.btn_closeport.Enabled = false;
                this.btn_disenableinsert.Enabled = false;
                this.btn_ejectcard.Enabled = false;
                this.btn_enableinsert.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_readcaard.Enabled = false;
                this.btn_reset.Enabled = false;
                this.btn_swallow.Enabled = false;
                ht.ShowMsg("关闭串口", "成功");
                return;
            }
            ht.ShowMsg("关闭串口", "失败");
        }

        //允许插卡
        private void btn_enableinsert_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.EnableInsert())
            {
                ht.ShowMsg("允许插卡", "成功");
                return;
            }
            ht.ShowMsg("允许插卡", "失败");
        }

        //禁止插卡
        private void btn_disenableinsert_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.DisEnableInsert())
            {
                ht.ShowMsg("禁止插卡", "成功");
                return;
            }
            ht.ShowMsg("禁止插卡", "失败");

        }

        //读卡
        private void btn_readcaard_Click(object sender, EventArgs e)
        {
            String mag1 = "", mag2 = "", mag3 = "";
            if (DriverCommon.CardReaderDriver.ReadCard(ref mag1, ref mag2, ref mag3)) 
            {
                ht.ShowMsg("读卡", "成功");
                ht.ShowMsg("磁道一", mag1);
                ht.ShowMsg("磁道二", mag2);
                ht.ShowMsg("磁道三", mag3);
                return;
            }
            ht.ShowMsg("读卡", "失败");
        }

        //吐卡
        private void btn_ejectcard_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.EjectCard())
            {
                ht.ShowMsg("吐卡", "成功");
                return;
            }
            ht.ShowMsg("吐卡", "失败");
        }

        //吞卡
        private void btn_swallow_Click(object sender, EventArgs e)
        {
            if (DriverCommon.CardReaderDriver.SwallowCard())
            {
                ht.ShowMsg("吞卡", "成功");
                return;
            }
            ht.ShowMsg("吞卡", "失败");

        }

        private void btn_cardtype_Click(object sender, EventArgs e)
        {

        }

    }
}
