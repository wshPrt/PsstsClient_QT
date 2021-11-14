using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity;
using PsstsClient.Forms.Pay;
using PsstsClient.Service;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Query
{
    /// <summary>
    /// 卡表购电的业务逻辑一般：
    /// 步骤1、先从购电卡读取相关信息，发送给营销进行查询欠费，然后根据营销返回的欠费信息。
    /// 步骤2、进行投钱缴费，发送缴费信息给营销然后营销返回信息进行写卡。
    /// 步骤3、写卡成功则还要发送一个写卡结果确认给营销。
    /// 也有可能：
    /// 步骤1、先从购电卡读取相关信息，发送给营销进行查询欠费，然后根据营销返回的欠费信息。
    /// 步骤2、进行投钱缴费，并计算则装信息写卡，成功则发送缴费信息给营销然后营销。     
    /// </summary>
    public partial class InputIcCardSim : Form
    {
        Main m;

        public InputIcCardSim()
        {
            InitializeComponent();
        }

        #region 界面事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputICCard_Load(object sender, EventArgs e)
        {
            m = (Main)this.Owner;
            TimerInit();

            if (!DriverCommon.ICReaderDriver.OpenPort())
            {
                pb_ok.Enabled = false;
                ShowMsg sm = new ShowMsg("设备异常", "读卡器启动失败，请联系柜台处理。");
                sm.ShowDialog();
                return;
            }

            if (DriverCommon.ICReader)
            {
                //选择支付方式
                SoundUtil.SayInsertcard();

                if (DriverCommon.ICReaderDriver.AllowedCard())
                {
                    Log4NetHelper.Instance.Debug("允许插卡成功");
                }
                else
                {
                    Log4NetHelper.Instance.Debug("允许插卡失败");
                }
            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_ok_Click(object sender, EventArgs e)
        {
            CardInfoEntity cardInfoEntity = new CardInfoEntity();

            TimerInit();
            this.pb_ok.Enabled = false;
            this.timer_returnmain.Enabled = false;

            try
            {
                Common.ShowWaiting(m, "正在读卡请稍后");
                ShowWaiting.InitTimeout();
                if (!DriverCommon.ICReaderDriver.ReadCard(out cardInfoEntity))
                {
                    Common.HideWaiting();
                    ShowMsg sm = new ShowMsg("读卡异常", "读卡失败，请正确插入卡片或移步柜台处理。");
                    sm.ShowDialog();
                    this.pb_ok.Enabled = true;
                    this.timer_returnmain.Enabled = true;
                    return;
                }

                Log4NetHelper.Instance.Debug("读卡数据：" + Newtonsoft.Json.JsonConvert.SerializeObject(cardInfoEntity));
                //查询用户信息
                ICCardService cardService = new ICCardService();

                R_CardQueryCheck r_CardQuery = new R_CardQueryCheck();
                P_CardQueryCheck p_CardQuery = new P_CardQueryCheck();
                p_CardQuery.cardType = cardInfoEntity.cardType;
                p_CardQuery.cardRandom = cardInfoEntity.cardRandom;
                p_CardQuery.cardSnr = cardInfoEntity.cardSnr;
                p_CardQuery.mfFile82 = cardInfoEntity.mfFile82;
                p_CardQuery.dfFile81 = cardInfoEntity.dfFile81;
                p_CardQuery.dfFile82 = cardInfoEntity.dfFile82;
                p_CardQuery.dfFile83 = cardInfoEntity.dfFile83;
                p_CardQuery.dfFile84 = cardInfoEntity.dfFile84;
                p_CardQuery.dfFile85 = cardInfoEntity.dfFile85;
                p_CardQuery.dfFile86 = cardInfoEntity.dfFile86;
                p_CardQuery.dfFile87 = cardInfoEntity.dfFile87;
                p_CardQuery.dfFile88 = cardInfoEntity.dfFile88;

                //Common.HideWaiting();
                R_QueryCustomerInfo customerInfo;
                string msg = string.Empty;

                if (cardService.CardAnlyseAndCheck(p_CardQuery, out msg, out r_CardQuery))
                {
                    if (r_CardQuery.buyPowerFlag != 1)
                    {
                        Common.HideWaiting();
                        //不允许购电
                        ShowMsg sm = new ShowMsg("查询异常", "查询信息异常，不允许购电，请移步柜台处理。");
                        sm.ShowDialog();
                        this.pb_ok.Enabled = true;
                        this.timer_returnmain.Enabled = true;
                        return;
                    }

                    //绑定终端
                    BusinessBindService bindService = new BusinessBindService();
                    if (!bindService.Bind(r_CardQuery.consNo))
                    {
                        Common.HideWaiting();
                        //插卡绑定
                        ShowMsg sm = new ShowMsg("交易异常", "终端绑定失败，请移步柜台处理。");
                        sm.ShowDialog();
                        this.pb_ok.Enabled = true;
                        this.timer_returnmain.Enabled = true;
                        return;
                    }

                    Client.FlowType = Client.icflow;

                    //查询成功
                    customerInfo = new R_QueryCustomerInfo();
                    customerInfo.consNo = r_CardQuery.consNo;
                    customerInfo.consName = r_CardQuery.consName;
                    customerInfo.elecAddr = r_CardQuery.elecAddr;
                    customerInfo.prepayBal = r_CardQuery.prepayBal;
                    customerInfo.orgNo = r_CardQuery.orgNo;
                    customerInfo.orgName = r_CardQuery.orgName;
                    customerInfo.prepayBal = "0";

                    m.nowformname = this.Name;
                    m.obj = new object[] { customerInfo, p_CardQuery, cardInfoEntity };
                    this.TopMost = false;
                    this.Close();
                    m.JmpFrom("CashQuerySim");
                }
                else
                {
                    Log4NetHelper.Instance.Debug("msg:" + msg);
                    Common.HideWaiting();
                    ShowMsg sm;

                    if (!string.IsNullOrEmpty(msg))
                    {
                        sm = new ShowMsg("查询异常", msg);
                        sm.ShowDialog();
                        this.pb_ok.Enabled = true;
                        this.timer_returnmain.Enabled = true;
                        return;
                    }
                    else
                    {                        
                        sm = new ShowMsg("交易异常", "查询客户信息错误，请联系柜台处理。");
                        sm.ShowDialog();
                        this.pb_ok.Enabled = true;
                        this.timer_returnmain.Enabled = true;
                        return;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("卡表查询异常", ex);
            }
        }

        /// <summary>
        /// 返回上一页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_returnprevious_Click(object sender, EventArgs e)
        {
            GoToPrevPage();
        }
        #endregion

        /// <summary>
        /// 超时则返回主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_returnMain_Tick(object sender, EventArgs e)
        {
            GoToPrevPage();
        }

        /// <summary>
        /// 定时器初始化
        /// </summary>
        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        /// <summary>
        /// 返回上一页
        /// </summary>
        private void GoToPrevPage()
        {
            DriverCommon.ICReaderDriver.OutCard(true);
            DriverCommon.ICReaderDriver.DICClose();

            //返回上一页   
            this.pb_returnprevious.Enabled = false;
            this.timer_returnmain.Enabled = false;
            this.pb_ok.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }

        private void InputIcCardSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            DriverCommon.ICReaderDriver.DontAllowedCard();
            DriverCommon.ICReaderDriver.DICClose();
        }
    }
}