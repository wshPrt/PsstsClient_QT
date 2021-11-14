using Newtonsoft.Json;
using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity.LocalData;
using PsstsClient.Forms;
using PsstsClient.Forms.Pay;
using PsstsClient.Forms.Query;
using PsstsClient.Service;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PsstsClient
{
    public partial class Main : Form
    {
        public static object objLock = new object();
        public string nowformname;
        public static Form allower;
        //窗体参数
        public object[] obj = null;
        BaseBusinessService baseBusinessService = new BaseBusinessService();
        PrepaidService prepaidService = new PrepaidService();

        public Main()
        {
            InitializeComponent();

            Log4NetHelper.Instance.Info("程序启动了");

            this.Width = ScreenInfo.ScreenWidth;
            this.Height = ScreenInfo.ScreenHeight;
        }

        //完美解决窗口闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        Color[] errorColor = new Color[] { Color.White, Color.Orange, Color.GreenYellow, Color.Red };
        Random random = new Random();
        int colori = 0;

        /// <summary>
        /// 监测设备结果显示
        /// </summary>
        private void CheckDev()
        {
            this.lb_deverror.Text = "";
            colori++;
            if (colori == errorColor.Length)
            {
                colori = 0;
            }
            lb_deverror.ForeColor = errorColor[colori];
            if (!DriverCommon.CashCode && DevInfo.CashcodeEnable == DevStatic.devEnable)
            {
                lb_deverror.Text += " " + DevStatic.CashCodeStaticMsg;
            }
            if (!DriverCommon.Printer && DevInfo.PrinterEnable == DevStatic.devEnable)
            {
                lb_deverror.Text += " " + DevStatic.ThermalPrinterStaticMsg;
            }
            if (!DriverCommon.MetalKeyboard && DevInfo.MetalKeyboardEnable == DevStatic.devEnable)
            {
                lb_deverror.Text += " " + DevStatic.MetalKeyboardStaticMsg;
            }
            if (!DriverCommon.ICReader && DevInfo.ICReaderEnable == DevStatic.devEnable)
            {
                Common.WriteLogStr("ICReader", "监测设备", "设备状态：" + DevInfo.ICReaderEnable);
                lb_deverror.Text += " " + DevStatic.ICReaderStaticMsg;
            }
        }

        /// <summary>
        /// 内部面板显示界面的跳转处理
        /// </summary>
        /// <param name="formname"></param>
        public void JmpFrom(string formname)
        {
            nowformname = formname;
            Form mf = null;

            try
            {
                ShowWaiting.showmsg = "载入中,请稍候...";
                //Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
                HideBtn1234();

                switch (formname)
                {
                    case "MainFormSim":
                        mf = new MainFormSim();
                        ShowBtn1234();
                        break;
                    case "IputCustomeridSim":
                        mf = new IputCustomeridSim();
                        break;
                    case "InputICCardSim":
                        mf = new InputIcCardSim();
                        break;
                    case "CashQuerySim":
                        mf = new CashQuerySim(obj);
                        break;
                    case "InputCashSim":
                        mf = new InputCashSim(obj);
                        break;
                    case "PayResultSim":
                        mf = new PayResultSim((int)obj[0], (string)obj[1], (int)obj[2], (string)obj[3], (string)obj[4]);        //交易结果，打印凭条         
                        break;
                    case "ScanCodePaySim":
                        mf = new ScanCodePaySim(obj);
                        break;
                    case "QueryIndex":
                        mf = new QueryIndex(obj);
                        break;
                    case "QueryBasicInfo":
                        mf = new QueryBasicInfo(obj);
                        break;
                    case "QueryElecInfo":
                        mf = new QueryElecInfo(obj);
                        break;
                    case "QueryFeesInfo":
                        mf = new QueryFeesInfo(obj);
                        break;
                    case "QueryPowerPurchaseInfo":
                        mf = new QueryPowerPurchaseInfo(obj);
                        break;
                    default:
                        mf = new MainFormSim();
                        ShowBtn1234();
                        break;
                }
                mf.Owner = this;
                mf.TopLevel = false; // 不是最顶层窗体
                mf.FormBorderStyle = FormBorderStyle.None;
                mf.WindowState = FormWindowState.Normal;
                this.panel_form.Controls.Add(mf);
                mf.Show();
                Common.HideWaiting();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("窗口跳转异常", ex);
            }
        }

        #region 窗体事件
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                string pwd = EncryDecrypt.MD5Encrypt(Common.GetMoAddress());

                if (string.IsNullOrEmpty(Global.RegPwd) || pwd != Global.RegPwd)
                {
                    ShowMsg sm = new ShowMsg("启动失败", "终端未注册，请联系终端厂家授权。");
                    sm.ShowDialog();
                    return;
                }

                allower = this;
                exittime = 1;

                //页面加载时注册终端
                if (baseBusinessService.BindClient(Global.ClientKey))
                {
                    timer_Heartbeat.Interval = Global.HeartbeatTime;
                    StartHeartbeat();

                    timer_DataReported.Interval = Global.DataReported;
                    StartDataReported();
                }
                else
                {
                    ShowMsg sm = new ShowMsg("通讯异常", "连接服务器绑定客户端异常。");
                    sm.ShowDialog();
                    return;
                }

                Common.ShowWaiting(this, "正在初次检测设备，请稍后...");

                ShowWaiting.showmsg = "正在检测纸币识别器...";
                DevStatic.DevCheck(DevStatic.CashCode, "1");
                ShowWaiting.InitTimeout();
                ShowWaiting.showmsg = "正在检测凭条打印机...";
                DevStatic.DevCheck(DevStatic.ThermalPrinter, "1");
                ShowWaiting.InitTimeout();
                ShowWaiting.showmsg = "正在检测金属键盘...";
                DevStatic.DevCheck(DevStatic.MetalKeyboard, "1");
                ShowWaiting.InitTimeout();
                ShowWaiting.showmsg = "正在检测IC读卡器...";
                DevStatic.DevCheck(DevStatic.ICReader, "1");
                ShowWaiting.InitTimeout();

                CheckDev();

                JmpFrom("MainFormSim");                
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("硬件检测异常", ex);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDataReported();
            StoptHeartbeat();
            SocketHelper.Instance.Close();
            SystemAPI.HideTask(false);
            DriverCommon.DriverClose();
        }
        #endregion

        #region 管理界面操作
        private void HideBtn1234()
        {
            this.btn_exit1.Visible = false;
            this.btn_exit2.Visible = false;
            this.btn_exit3.Visible = false;
            this.btn_exit4.Visible = false;
            exittime = 9999999;
        }

        private void ShowBtn1234()
        {
            this.btn_exit1.Visible = true;
            this.btn_exit2.Visible = true;
            this.btn_exit3.Visible = true;
            this.btn_exit4.Visible = true;
            btn_exit1.BringToFront();
            btn_exit2.BringToFront();
            btn_exit3.BringToFront();
            btn_exit4.BringToFront();
            exittime = 3;
        }

        private int exittime = -1;
        private string exitcode = "";
        private void btn_exit1_Click(object sender, EventArgs e)
        {
            exitcode += "1";
            exittime = 20;
        }

        private void btn_exit2_Click(object sender, EventArgs e)
        {
            exitcode += "2";
            exittime = 20;
        }

        private void btn_exit3_Click(object sender, EventArgs e)
        {
            exitcode += "3";
            exittime = 20;
        }

        private void btn_exit4_Click(object sender, EventArgs e)
        {
            if (exitcode == "123")
            {
                ExitPwdSim fm = new ExitPwdSim();
                DevStatic.AutoCheck = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.WindowState = FormWindowState.Normal;
                fm.Width = ScreenInfo.ScreenWidth;
                fm.Height = ScreenInfo.ScreenHeight;
                fm.Owner = allower;
                fm.Show();
                exittime = 999999;
                exitcode = "";
                this.Hide();
            }
            else
            {
                exitcode = "";
            }
        }
        #endregion

        #region 定时器
        /// <summary>
        /// 时间日期更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //显示日期时间               
                DateTime dt = DateTime.Now;
                string week = "";
                switch (dt.DayOfWeek.ToString())
                {
                    case "Monday":
                        week = "星期一";
                        break;
                    case "Tuesday":
                        week = "星期二";
                        break;
                    case "Wednesday":
                        week = "星期三";
                        break;
                    case "Thursday":
                        week = "星期四";
                        break;
                    case "Friday":
                        week = "星期五";
                        break;
                    case "Saturday":
                        week = "星期六";
                        break;
                    case "Sunday":
                        week = "星期日";
                        break;
                    default:
                        break;
                }
                lb_time.Text = dt.ToString("yyyy年MM月dd日 HH:mm:ss") + " " + week + "  V" + Client.thisVersion;

            }
            catch (Exception ex)
            {
                Common.WriteLogStr("Error", "MainForm中timer_Tick方法出错", ex.ToString());
            }

            if (exittime >= 0)
            {
                exittime--;
            }
            else
            {
                exitcode = "";
                exittime = -1;
                //this.TopMost = true;
                Common.HideWaiting();
            }
        }

        /// <summary>
        /// 断线重连定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_DicReconnect_Tick(object sender, EventArgs e)
        {
            try
            {
                //先断开再连接
                SocketHelper.Instance.Close();
                SocketHelper.Instance.Connect();

                //重新注册终端获取Key
                if (baseBusinessService.BindClient(Global.ClientKey))
                {
                    StartHeartbeat();
                    StopDisReconnectTimer();
                }
            }
            catch (SocketException sEx)
            {
                Log4NetHelper.Instance.Error("断线重连异常", sEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("断线重连异常", ex);
            }
        }

        /// <summary>
        /// 服务端心跳定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Heartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                SocketHelper.Instance.SendHeartbeat();
            }
            catch (SocketException sEx)
            {
                Log4NetHelper.Instance.Error("心跳异常", sEx);
                Log4NetHelper.Instance.Debug("心跳连接错误码：" + sEx.SocketErrorCode);

                if (sEx.SocketErrorCode == SocketError.ConnectionAborted || sEx.SocketErrorCode == SocketError.ConnectionReset)
                {
                    StoptHeartbeat();
                    StartDisReconnectTimer();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("发送心跳异常", ex);
            }
        }

        /// <summary>
        /// 数据上报（每个小时执行一次，查询本地是否有写卡成功上报数据失败数据，有则继续上报）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_DataReported_Tick(object sender, EventArgs e)
        {
            try
            {
                List<WriteCardrRcord> list = B_LocalData.Instance.QueryWriteCatdRecord();

                foreach (WriteCardrRcord rcord in list)
                {
                    if (prepaidService.WriteCardCallback(rcord.customerid, rcord.flowno, 1))
                    {
                        B_LocalData.Instance.UpWriteCatdRecord(rcord.customerid, rcord.flowno);
                    }
                }

                Log4NetHelper.Instance.Debug("读取到的上报记录：" + JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("数据上报异常", ex);
            }
        }

        /// <summary>
        /// 启动心跳
        /// </summary>
        public void StartHeartbeat()
        {
            timer_Heartbeat.Enabled = true;
            timer_Heartbeat.Start();
        }

        /// <summary>
        /// 停止心跳
        /// </summary>
        public void StoptHeartbeat()
        {
            timer_Heartbeat.Stop();
            timer_Heartbeat.Enabled = false;
        }

        /// <summary>
        /// 启动断线重连定时器
        /// </summary>
        private void StartDisReconnectTimer()
        {
            //timer_DicReconnect.Enabled = true;
            //timer_DicReconnect.Start();
        }

        /// <summary>
        /// 停止断线重连定时器
        /// </summary>
        private void StopDisReconnectTimer()
        {
            //timer_DicReconnect.Enabled = false;
            //timer_DicReconnect.Stop();
        }

        /// <summary>
        /// 启动数据上报
        /// </summary>
        private void StartDataReported()
        {
            timer_DataReported.Enabled = true;
            timer_DataReported.Start();
        }

        /// <summary>
        /// 停止数据上报
        /// </summary>
        private void StopDataReported()
        {
            timer_DataReported.Enabled = false;
            timer_DataReported.Stop();
        }
        #endregion
    }
}
