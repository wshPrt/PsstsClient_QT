using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Hardware
{
    public partial class MetalKeyboardTest : Form
    {
        private void KeyPressE(MetalKeyBoardEvent myDelegate, byte key, string error)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(myDelegate, new object[] { key, error });
            }
            else
            {
                myDelegate(key, error);
            }
        }

        public MetalKeyboardTest()
        {
            InitializeComponent();
        }

       // private delegate void ListenDelegte();
        private HardwareTest ht = null;

        //建立个委托
        private delegate void returnStrDelegate(string title, string content);
        private void ShowMessage(returnStrDelegate myDelegate, string title, string content)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(myDelegate, new Object[] { title, content });
            }
            else
            {
                myDelegate(title, content);
            }
        }


        private void MetalKeyboardTest_Load(object sender, EventArgs e)
        {
            this.cb_port.SelectedIndex = Common.ReadIniInt("ClientParam.ini", "MetalKeyboard", "port");
            this.cb_baud.Text = Common.ReadIniStr("ClientParam.ini", "MetalKeyboard", "baud");
            if (DriverCommon.MetalKeyboard)
            {
                this.btn_openport.Enabled = false;
                this.btn_closeport.Enabled = true;
                this.btn_getstatus.Enabled = true;
                this.btn_reset.Enabled = true;
                this.btn_stoptest.Enabled = true;
                this.btn_test1.Enabled = true;
            }
            else
            {
                this.btn_openport.Enabled = true;
                this.btn_closeport.Enabled = false;
                this.btn_getstatus.Enabled = false;
                this.btn_reset.Enabled = false;
                this.btn_stoptest.Enabled = false;
                this.btn_test1.Enabled = false;
            }
            this.btn_closeport.Enabled = true;
            this.btn_getstatus.Enabled = true;
            this.btn_reset.Enabled = true;
            this.btn_stoptest.Enabled = true;
            this.btn_test1.Enabled = true;
            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null, "加密键盘测试");
        }

        private void btn_openport_Click(object sender, EventArgs e)
        {

            int port,baud;
            port = this.cb_port.SelectedIndex;
            baud = int.Parse(this.cb_baud.Text);
            DriverCommon.MetalKeyboardDriver = new MetalKeyDriver(DevInfo.MetalKeyboardPort, DevInfo.MetalKeyboardBaud);        
            if (!DriverCommon.MetalKeyboard)
            {
                ht.ShowMsg("打开串口", "失败");
                return;
            }
            ht.ShowMsg("打开串口", "成功");
            this.btn_openport.Enabled = false;
            this.btn_closeport.Enabled = true;
            this.btn_getstatus.Enabled = true;
            this.btn_reset.Enabled = true;
            this.btn_stoptest.Enabled = true;
            this.btn_test1.Enabled = true;
            
        }
       

        private void btn_closeport_Click(object sender, EventArgs e)
        {
            if ( !DriverCommon.MetalKeyboardDriver.DICClose())
            {
                ht.ShowMsg("关闭串口", "失败");
                return;
            }
            ht.ShowMsg("关闭串口", "成功");
            this.btn_openport.Enabled = true;
            this.btn_closeport.Enabled = false;
            this.btn_getstatus.Enabled = false;
            this.btn_reset.Enabled = false;
            this.btn_stoptest.Enabled = false;
            this.btn_test1.Enabled = false;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            int iret =DriverCommon.MetalKeyboardDriver.DICReset();
            ht.ShowMsg("设备复位", DriverCommon.MetalKeyboardDriver.DICGetErrorMsg(iret));
        }

        private void btn_getstatus_Click(object sender, EventArgs e)
        {

            int lret = -999;
            String msg = "打开失败";
            try
            {
                lret = DriverCommon.MetalKeyboardDriver.DICGetStatus();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            try
            {
                msg = DriverCommon.MetalKeyboardDriver.DICGetErrorMsg(lret);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
            ht.ShowMsg("获取状态" + lret, msg);            
        }


        //明文测试
        private void btn_test1_Click(object sender, EventArgs e)
        {
            //打开键盘
            testType = 0;
            if(!DriverCommon.MetalKeyboardDriver.KeyboardSwitch(3))
            {
                ht.ShowMsg("明文测试", "打开键盘失败");
                return;
            }
            DriverCommon.MetalKeyboardDriver.StartKeyListen(this.GetKey);
            ht.ShowMsg("键盘监测","开始，请在键盘上按键测试");
            this.btn_stoptest.Enabled = true;
            this.btn_testX.Enabled = false; ;
            this.btn_test1.Enabled = false;;
        }

        private void GetKey(byte key, String error)
        {
            KeyPressE(MetalKeyPress, key, error);
        }

        int testType = 0;
        private void MetalKeyPress(byte key, String Error)
        {
            switch(key)
            {
                case 0x00:
                    break;
                case 0x30:
                    ht.ShowMsg("按键监测" , "检测到数字键0");
                    break;
                case 0x31:
                    ht.ShowMsg("按键监测", "检测到数字键1");
                    break;
                case 0x32:
                    ht.ShowMsg("按键监测", "检测到数字键2");
                    break;
                case 0x33:
                    ht.ShowMsg("按键监测", "检测到数字键3");
                    break;
                case 0x34:
                    ht.ShowMsg("按键监测", "检测到数字键4");
                    break;
                case 0x35:
                    ht.ShowMsg("按键监测", "检测到数字键5");
                    break;
                case 0x36:
                    ht.ShowMsg("按键监测", "检测到数字键6");
                    break;
                case 0x37:
                    ht.ShowMsg("按键监测", "检测到数字键7");
                    break;
                case 0x38:
                    ht.ShowMsg("按键监测", "检测到数字键8");
                    break;
                case 0x39:
                    ht.ShowMsg("按键监测", "检测到数字键9");
                    break;
                case 0x0D:
                    ht.ShowMsg("按键监测", "检测到确认键");
                    if (testType == 1)
                    {
                        GetPindate();
                    }
                    break;
                case 0x1B:
                    ht.ShowMsg("按键监测", "检测到退出键");
                    break;
                case 0x08:
                    ht.ShowMsg("按键监测", "检测到清除键");
                    break;
                case 0x23:
                    ht.ShowMsg("按键监测", "检测到上翻键");
                    break;
                case 0x2A:
                    ht.ShowMsg("按键监测", "检测到下翻键");
                    break;
                case 0x2E:
                    ht.ShowMsg("按键监测", "检测到小数点键");
                    break;
                //case 0x2A:
                //    ht.ShowMsg("按键监测", "检测到其他键");
                //    break;
            }
        }

        private void GetPindate()
        {
            ht.ShowMsg("获取密文", "获取密文");
            btn_stoptest_Click(null,null);
            //读Pin密文
            String pin = "";
            //bool  bre = DriverCommon.MetalKeyboardDriver.SetPara(0x04, 10);
           //
            Boolean reBool = DriverCommon.MetalKeyboardDriver.ReadPinBlock(ref pin);          
            ht.ShowMsg("获取密文", "获取密文" + pin);
        }
        private void btn_testX_Click(object sender, EventArgs e)
        {
            try
            {
                testType = 1;
                if (DriverCommon.MetalKeyboardDriver.DICReset() != 0)
                {
                    return;
                }
                 DriverCommon.MetalKeyboardDriver.ActivateWorkkey(BankInfo.MainKeyNo, BankInfo.PinKeyNo);
                if (!DriverCommon.MetalKeyboardDriver.KeyboardSwitch(2))
                {
                    return;
                }
                if (!DriverCommon.MetalKeyboardDriver.PinStart(6,1,40))
                {

                    DriverCommon.MetalKeyboardDriver.KeyboardSwitch(0);
                    return;
                }
                //MetalKeyboardAPI.ZT_EPP_PinStartAdd(6, 1, 1, 0, 40);
                DriverCommon.MetalKeyboardDriver.StartKeyListen(this.GetKey);
                ht.ShowMsg("开始输入", "");

            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                return;
            }
        }
        private void btn_stoptest_Click(object sender, EventArgs e)
        {
            DriverCommon.MetalKeyboardDriver.StopKeyListen();
            DriverCommon.MetalKeyboardDriver.KeyboardSwitch(0);
            this.btn_test1.Enabled = true;
            this.btn_stoptest.Enabled = false;
            this.btn_testX.Enabled = true; ;
        }
        string pinkey = "";
        string pkdec = "";
        string mackdec = "";
        string mackey = "";
        string pinkcv = "";
        string mackcy = "";
        /// <summary>
        /// 设置工作密钥
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            bool loadpin = DriverCommon.MetalKeyboardDriver.LoadWorkkey(BankInfo.MainKeyNo, BankInfo.PinKeyNo, pkdec, pinkcv);
            if(loadpin)
                ht.ShowMsg("设置pin工作密钥" + pinkcv, "成功");
            else
                ht.ShowMsg("设置pin工作密钥" + pinkcv, "失败");
            loadpin = DriverCommon.MetalKeyboardDriver.LoadWorkkey(BankInfo.MainKeyNo, BankInfo.MacKeyNo, mackdec, mackcy);
            if (loadpin)
                ht.ShowMsg("设置mac工作密钥" + mackcy, "成功");
            else
                ht.ShowMsg("设置mac工作密钥" + mackcy, "失败");
        }
        /// <summary>
        /// 设置主密钥
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setMainkey_Click(object sender, EventArgs e)
        {
            string outStr = "";
            bool loadpin = DriverCommon.MetalKeyboardDriver.LoadMainkey(2, BankInfo.MainKeyNo, "1FF8BC2F0E3DE3DC547F49A18F49D57A", ref outStr);
            if (loadpin)
                ht.ShowMsg("设置主密钥1FF8BC2F0E3DE3DC547F49A18F49D57A", "成功");
            else
                ht.ShowMsg("设置主密钥1FF8BC2F0E3DE3DC547F49A18F49D57A", "失败");

           
        }

        private void btn_dec_Click(object sender, EventArgs e)
        {   //密钥密文
            string keydec = "BA6A072F512285C64A2E28FFAD0E8B1C51240D45B317AFEF20B900E61F48F432";
             pkdec = keydec.Substring(0,32);
             pinkcv = keydec.Substring(32, 8);
             mackdec = keydec.Substring(40,16);
             mackcy = keydec.Substring(56, 8);
            string outStr = "";
            bool loadpin = DriverCommon.MetalKeyboardDriver.MainkeyDec(5, 0, pkdec, ref outStr);
            if (loadpin)
            {
                ht.ShowMsg("解PINKEY密" + outStr, "成功" + pinkcv);
                pinkey = outStr.TrimEnd('\0'); 
            }
            else
                ht.ShowMsg("解PINKEY密" + outStr, "失败");
            loadpin = DriverCommon.MetalKeyboardDriver.MainkeyDec(5, 0, mackdec, ref outStr);
            if (loadpin)
            {
                ht.ShowMsg("解MACKEY密" + outStr, "成功" + mackcy);
                mackey = outStr.TrimEnd('\0'); 
            }
            else
                ht.ShowMsg("解MACKEY密" + outStr, "失败");
        }
    }
}
