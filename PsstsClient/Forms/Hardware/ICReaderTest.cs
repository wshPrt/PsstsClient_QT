using PsstsClient.Driver;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PsstsClient.Forms.Hardware
{
    public partial class ICReaderTest : Form
    {
        private int devhandle = -1;
        HardwareTest ht = null;
        private String devType = "1";

        public ICReaderTest()
        {
            InitializeComponent();
        }

        private void ICReaderTest_Load(object sender, EventArgs e)
        {
            this.cb_port.SelectedIndex = Common.ReadIniInt("ClientParam.ini", "ICReader", "port");
            this.cb_baud.Text = Common.ReadIniStr("ClientParam.ini", "ICReader", "baud");
            devType = Common.ReadIniStr("ClientParam.ini", "ICReader", "devType");
            this.btn_closeport.Enabled = false;
            this.btn_getstatus.Enabled = false;
            this.btn_openport.Enabled = true;
            this.btn_test.Enabled = false;

            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null,"IC卡读卡器测试");
            
        }

        private void btn_openport_Click(object sender, EventArgs e)
        {
            try
            {
                devhandle = ICReaderAPI.ic_init(this.cb_port.SelectedIndex - 1, long.Parse(cb_baud.Text));
                if (devhandle > 0)
                {
                    ht.ShowMsg("打开串口","成功");
                    this.btn_test.Enabled = true;
                    this.btn_openport.Enabled = false;
                    this.btn_getstatus.Enabled = true;
                    this.btn_closeport.Enabled = true;
                    return;
                }
                ht.ShowMsg("打开串口","失败");
            }
            catch(Exception ex){
                MessageBox.Show("系统异常！\n异常原因[" + ex.Message + "]", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_closeport_Click(object sender, EventArgs e)
        {
            try
            {
                int iRet = ICReaderAPI.ic_exit(devhandle);
                if (iRet != 0)
                {
                    ht.ShowMsg("串口关闭","失败");
                    return;
                }
                ht.ShowMsg("串口关闭","成功");
                this.btn_closeport.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_openport.Enabled = true;
                this.btn_test.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统异常！\n异常原因[" + ex.Message + "]", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_getstatus_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] status = new byte[5];
                int iRet = ICReaderAPI.get_status(devhandle, status);
                if (iRet != 0)
                {
                    ht.ShowMsg("获取状态","失败");
                    return;
                }
                switch (status[0])
                {
                    case 0:
                        ht.ShowMsg("测试", "读卡器未插卡");
                        break;
                    case 1:
                        ht.ShowMsg("测试", "读卡器插有卡");
                        break;
                    default:
                        ht.ShowMsg("测试", "未知设备状态[" + status[0] + "]");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统异常！\n异常原因[" + ex.Message + "]","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ICReaderTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.btn_closeport.Enabled == true)
                this.btn_closeport_Click(null, null);
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] status = new byte[5];
                int iRet = ICReaderAPI.get_status(devhandle, status);
                if (iRet != 0)
                {
                    ht.ShowMsg("测试","获取设备状态失败");
                    return;
                }
                if (status[0] != 1)
                {
                    MessageBox.Show("请插卡后再进行测试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统异常！\n异常原因[" + ex.Message + "]", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cb_port_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
