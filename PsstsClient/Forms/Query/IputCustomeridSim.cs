using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Service;
using PsstsClient.Utility;
using PsstsClient.Service.RecData;
using SantaiSocket.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PsstsClient.Forms.Pay;

namespace PsstsClient.Forms.Query
{
    public partial class IputCustomeridSim : Form
    {
        private TextBox focustb; //光标所在textbox
        private int cursorposition = 0;//光标所在位置
        private string showerror = "";
        private Dictionary<string, Control> pb_control = new Dictionary<string, Control>();
        public IputCustomeridSim()
        {
            InitializeComponent();
            pb_control.Add(pb_0.Name, pb_0);
            pb_control.Add(pb_1.Name, pb_1);
            pb_control.Add(pb_2.Name, pb_2);
            pb_control.Add(pb_3.Name, pb_3);
            pb_control.Add(pb_4.Name, pb_4);
            pb_control.Add(pb_5.Name, pb_5);
            pb_control.Add(pb_6.Name, pb_6);
            pb_control.Add(pb_7.Name, pb_7);
            pb_control.Add(pb_8.Name, pb_8);
            pb_control.Add(pb_9.Name, pb_9);
            pb_control.Add(pb_jh.Name, pb_jh);
            pb_control.Add(pb_xh.Name, pb_xh);
            pb_control.Add(pb_qk.Name, pb_qk);
            pb_control.Add(pb_ok.Name, pb_ok);
            pb_control.Add(pb_back.Name, pb_back);
            foreach (Button pb in pb_control.Values)
            {
                if (pb.Name != "pb_ok")
                {
                    pb.Click += new System.EventHandler(this.KeyboardEvent);
                    pb.DoubleClick += new System.EventHandler(this.KeyboardEvent);
                }
            }
            input_id1.Enter += new EventHandler(this.TextboxEnter);
            input_id1.Click += new EventHandler(this.TextboxClick);
        }

        /// <summary>
        /// 初始化金属键盘,检测是否打开，没有则打开，
        /// 用于给客户输入户号
        /// </summary>
        private void InitMetalKeyboard()
        {
            //如果金属键盘没开则打开
            if (DevInfo.MetalKeyboardEnable != DevStatic.devEnable)
            {
                showerror = "金属键盘未启用,请使用屏幕键盘输入户号,不会影响缴费!";
                return;
            }
            try
            {
                stpeInput = false;
                if (DevStatic.CheckMetalKeyBoardStatus().Equals("0"))
                {
                    //开启声音并启用
                    if (DriverCommon.MetalKeyboardDriver.KeyboardSwitch(3))
                    {
                        //监听按键
                        DriverCommon.MetalKeyboardDriver.StartKeyListen(this.GetKey);
                    }
                }
                else
                {
                    if (Client.FlowType == Client.icflow)
                    {
                        showerror = "打开金属键盘失败,银联缴费无法使用,详询95598!";
                        this.pb_ok.Enabled = false;
                    }
                    else if (Client.FlowType == Client.nflow)
                    {
                        showerror = "打开金属键盘失败,请使用屏幕键盘输入户号,不会影响缴费!";
                    }
                }
            }
            catch (Exception ex)
            {
                DriverCommon.MetalKeyboard = false;
                Common.WriteLogStr("Error", "QueryIputCustomerid中InitMetalKeyboard方法", "启动金属键盘失败" + ex);
            }
        }

        /// <summary>
        /// 停止金属键盘
        /// </summary>
        private void StopMetalKeyboard()
        {

            try
            {
                if (DriverCommon.MetalKeyboard && MetalKeyDriver.IsRunning)
                {
                    //停止监听
                    DriverCommon.MetalKeyboardDriver.StopKeyListen();
                    //停止声音
                    DriverCommon.MetalKeyboardDriver.KeyboardSwitch(0);

                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }

        //pictureBox点击事件
        private void KeyboardEvent(object sender, EventArgs e)
        {
            this.focustb.Focus();
            ((Button)sender).Enabled = false;
            String key = ((Button)sender).Name;//获取按钮文本
            String[] temps = key.Split('_');
            TimerInit();
            if (null != temps && 1 < temps.Length)
            {
                this.timer_returnmain.Interval = DevInfo.returntime;
                key = temps[1];
                switch (key)
                {

                    case "back":
                        if (this.focustb.SelectionStart > 0)
                        {
                            try
                            {
                                cursorposition = this.focustb.SelectionStart;
                                this.focustb.Text = this.focustb.Text.Substring(0, cursorposition - 1) + this.focustb.Text.Substring(cursorposition, this.focustb.Text.Length - cursorposition);
                                cursorposition = cursorposition - 1;
                            }
                            catch (Exception ex)
                            {
                                Log4NetHelper.Instance.Error(ex.Message, ex);
                            }
                        }
                        this.focustb.Focus();
                        break;
                    case "qk":
                        if (this.focustb.SelectionStart > 0)
                        {
                            try
                            {
                                this.input_id1.Text = "";
                                this.input_id1.Focus();
                                cursorposition = 0;
                            }
                            catch (Exception ex)
                            {
                                Log4NetHelper.Instance.Error(ex.Message, ex);
                            }
                        }
                        break;
                    default:
                        if (this.focustb.Text.Length < MemberCommon.C_ID_LENGTH)
                        {

                            if (key == "xh")
                            {
                                //key = "*";
                                key = "";
                            }
                            else if (key == "jh")
                            {
                                //key = "#";
                                key = "";
                            }
                            cursorposition = this.focustb.SelectionStart;
                            this.focustb.Text = this.focustb.Text.Substring(0, cursorposition)
                                              + key
                                              + this.focustb.Text.Substring(cursorposition, focustb.Text.Length - cursorposition);
                            cursorposition += key.Length;

                        }
                        this.focustb.Focus();
                        break;
                }
            }
            ((Button)sender).Enabled = true;
            this.focustb.SelectionStart = cursorposition;
        }

        //建立个委托
        private delegate void returnStrDelegate(object sender, EventArgs e);
        private void KeyPressE(MetalKeyBoardEvent myDelegate, byte key, String error)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(myDelegate, new Object[] { key, error });
            }
            else
            {
                myDelegate(key, error);
            }
        }
        private void MetalKeyPress(returnStrDelegate myDelegate, object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(myDelegate, new Object[] { sender, e });
            }
            else
            {
                myDelegate(sender, e);
            }
        }

        private void GetKey(byte key, String error)
        {
            KeyPressE(MetalKeyPress, key, error);
        }

        private void MetalKeyPress(byte key, String Error)
        {
            if (stpeInput)
            {
                return;
            }
            switch (key)
            {
                case 0x00:
                    break;
                case 0x30:
                    MetalKeyPress(KeyboardEvent, this.pb_0, null);
                    break;
                case 0x31:
                    MetalKeyPress(KeyboardEvent, this.pb_1, null);
                    break;
                case 0x32:
                    MetalKeyPress(KeyboardEvent, this.pb_2, null);
                    break;
                case 0x33:
                    MetalKeyPress(KeyboardEvent, this.pb_3, null);
                    break;
                case 0x34:
                    MetalKeyPress(KeyboardEvent, this.pb_4, null);
                    break;
                case 0x35:
                    MetalKeyPress(KeyboardEvent, this.pb_5, null);
                    break;
                case 0x36:
                    MetalKeyPress(KeyboardEvent, this.pb_6, null);
                    break;
                case 0x37:
                    MetalKeyPress(KeyboardEvent, this.pb_7, null);
                    break;
                case 0x38:
                    MetalKeyPress(KeyboardEvent, this.pb_8, null);
                    break;
                case 0x39:
                    MetalKeyPress(KeyboardEvent, this.pb_9, null);
                    break;
                case 0x0D:  //回车键
                    MetalKeyPress(pb_ok_Click, this.pb_ok, null);
                    // this.pb_ok_Click(this.pb_ok, null);
                    break;
                case 0x1B:  //退出键
                    MetalKeyPress(pb_returnprevious_Click, null, null);
                    break;
                case 0x08:  //删除键

                    MetalKeyPress(KeyboardEvent, this.pb_back, null);
                    break;
                case 0x02:
                    //Msg = "检测到上翻键";
                    break;
                case 0x03:
                    //Msg = "检测到下翻键";
                    break;
                case 0x2E:
                    //Msg = "检测到小数点键";
                    break;
                case 0x2A:
                    //Msg = "检测到其他按键";
                    break;
            }
        }

        /// <summary>
        /// 输入框焦点获取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxEnter(object sender, EventArgs e)
        {
            if (this.focustb != (TextBox)sender)
                cursorposition = ((TextBox)sender).Text.Length;
            this.focustb = (TextBox)sender;

        }

        /// <summary>
        /// 输入框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxClick(object sender, EventArgs e)
        {
            this.focustb = (TextBox)sender;
            cursorposition = ((TextBox)sender).SelectionStart;
        }

        /// <summary>
        /// 返回上一页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_returnprevious_Click(object sender, EventArgs e)
        {
            //返回上一页   
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
            StopMetalKeyboard();
            this.pb_returnprevious.Enabled = false;
            this.timer_returnmain.Enabled = false;
            this.pb_returnprevious.Enabled = false;
            foreach (Button pb in pb_control.Values)
            {
                pb.Enabled = false;
            }
            this.Hide();
            Main m = (Main)this.Owner;
            m.nowformname = this.Name;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }

        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            timer_returnmain.Enabled = false;
            this.pb_returnprevious_Click(sender, e);
        }

        private bool stpeInput = false;

        private void pb_ok_Click(object sender, EventArgs e)
        {
            try
            {
                timer_returnmain.Enabled = false;
                stpeInput = false;
                pb_ok.Enabled = false;
                //通过socket 通讯 查询客户欠费信息 
                Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

                QueryCustomerInfo();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                TimerInit();
                Common.HideWaiting();
            }
        }

        /// <summary>
        /// 查询客户信息
        /// </summary>
        public void QueryCustomerInfo()
        {
            SoundUtil.SayDobusiness();

            try
            {
                ArchivesService archivesService = new ArchivesService();
                R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

                if (!archivesService.QueryCustomerInfo(input_id1.Text.Trim(), out customerInfo))
                {
                    Common.HideWaiting();
                    ShowMsg sm = new ShowMsg("查询失败", "没有查询到用户信息");
                    sm.ShowDialog();
                    timer_returnmain.Enabled = true;
                    stpeInput = true;
                    pb_ok.Enabled = true;
                    return;
                }

                Main m = (Main)this.Owner;

                if (Client.FlowType == Client.nflow)
                {
                    //绑定终端
                    BusinessBindService bindService = new BusinessBindService();
                    if (!bindService.Bind(customerInfo.consNo))
                    {
                        Common.HideWaiting();
                        //插卡绑定
                        ShowMsg sm = new ShowMsg("交易异常", "终端绑定失败，请移步柜台处理。");
                        sm.ShowDialog();
                        stpeInput = true;
                        this.pb_ok.Enabled = true;
                        this.timer_returnmain.Enabled = true;
                        return;
                    }

                    m.nowformname = this.Name;
                    m.obj = new object[] { customerInfo };
                    this.TopMost = false;
                    this.Close();
                    m.JmpFrom("CashQuerySim");
                }
                else if (Client.FlowType == Client.queryflow)
                {
                    m.nowformname = this.Name;
                    m.obj = new object[] { customerInfo };
                    this.TopMost = false;
                    this.Close();
                    m.JmpFrom("QueryIndex");
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("查询客户信息异常", ex);
            }
            finally
            {
                StopMetalKeyboard();
            }
        }

        private void IputCustomeridSim_Load(object sender, EventArgs e)
        {
            TimerInit();
            cursorposition = 0;
            //请输入您的账号
            SoundUtil.SayInputcustomerid();
            InitMetalKeyboard();
            this.input_id1.Text = "";
            this.input_id1.Focus();
            this.focustb = this.input_id1;
            this.pb_ok.Enabled = true;
            if (showerror != "")
                this.lb_showerror.Text = showerror;
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void IputCustomeridSim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
    }
}
