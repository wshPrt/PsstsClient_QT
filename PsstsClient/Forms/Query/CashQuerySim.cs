using Newtonsoft.Json;
using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity;
using PsstsClient.Forms.Pay;
using PsstsClient.Service;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static PsstsClient.Driver.DicCRT310Reader;

namespace PsstsClient.Forms.Query
{
    public partial class CashQuerySim : Form
    {
        public object[] obj;
        CardInfoEntity cardInfoEntity;
        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();
        R_Fees rFees = new R_Fees();
        string userType = string.Empty;
        Main m;

        public CashQuerySim()
        {
            InitializeComponent();
        }

        public CashQuerySim(object[] rObj)
        {
            this.obj = rObj;
            customerInfo = (R_QueryCustomerInfo)this.obj[0];

            if (Client.FlowType == Client.icflow)
            {
                cardInfoEntity = (CardInfoEntity)rObj[2];
            }

            InitializeComponent();
        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashQuerySim_Load(object sender, EventArgs e)
        {
            m = (Main)Owner;

            try
            {
                TimerInit();

                lab_CustomerName.Text = customerInfo.consName;
                lab_CustomerNo.Text = customerInfo.consNo;
                lab_CustomerAddress.Text = customerInfo.elecAddr;
                lab_Balance.Text = customerInfo.prepayBal;

                PrepaidService prepaidService = new PrepaidService();
                PayService payService = new PayService();

                if (Client.FlowType == Client.icflow)
                {
                    P_WriteUP writeUP = new P_WriteUP();
                    writeUP.cardType = cardInfoEntity.cardType;
                    writeUP.cardRandom = cardInfoEntity.cardRandom;
                    writeUP.cardSnr = cardInfoEntity.cardSnr;
                    writeUP.dfFile81 = cardInfoEntity.dfFile81;
                    writeUP.dfFile82 = cardInfoEntity.dfFile82;
                    writeUP.dfFile83 = cardInfoEntity.dfFile83;
                    writeUP.dfFile84 = cardInfoEntity.dfFile84;
                    writeUP.dfFile85 = cardInfoEntity.dfFile85;
                    writeUP.dfFile86 = cardInfoEntity.dfFile86;
                    writeUP.dfFile87 = cardInfoEntity.dfFile87;
                    writeUP.dfFile88 = cardInfoEntity.dfFile88;
                    writeUP.mfFile82 = cardInfoEntity.mfFile82;
                    writeUP.orgNo = customerInfo.orgNo;

                    R_WriteUP r_WriteUP = new R_WriteUP();

                    //查询用户是否有补电
                    if (prepaidService.WriteUP(writeUP, out r_WriteUP))
                    {
                        string promptTitle = string.Empty;
                        R_PrepaidServicePayBill payBill = new R_PrepaidServicePayBill();
                        //通过凭条服务查询写卡金额
                        if (prepaidService.PayBill(r_WriteUP.serialNo, out payBill))
                        {
                            promptTitle = "系统检测到您上次购电未写卡写卡金额：" + payBill.chargeFee + "，请进行补写操作，未写卡不能继续交易！";
                        }
                        else
                        {
                            promptTitle = "系统检测到您上次购电未写卡，请进行补写操作，未写卡不能继续交易！";
                        }

                        //进行补电写卡
                        pb_pay_cash.Visible = false;
                        pb_Pay_WeiXin.Visible = false;
                        Common.HideWaiting();

                        ShowCommit sc = new ShowCommit(promptTitle, "是否进行补写，是（补写）、否（返回首页）？");
                        sc.ShowDialog();
                        if (sc.DialogResult == DialogResult.Yes)
                        {
                            lpstruWriteCardData writeCardData = new lpstruWriteCardData();
                            writeCardData.cardType = cardInfoEntity.cardType;
                            writeCardData.dfFile81 = r_WriteUP.dfFile81;
                            writeCardData.dfFile81Mac = r_WriteUP.dfFile81Mac;
                            writeCardData.dfFile82Mac = r_WriteUP.dfFile82Mac;
                            writeCardData.dfFile83 = r_WriteUP.dfFile83;
                            writeCardData.dfFile83Mac = r_WriteUP.dfFile83Mac;
                            writeCardData.dfFile84 = r_WriteUP.dfFile84;
                            writeCardData.dfFile84Mac = r_WriteUP.dfFile84Mac;
                            writeCardData.dfFile86 = r_WriteUP.dfFile86;
                            writeCardData.dfFile86Mac = r_WriteUP.dfFile86Mac;
                            writeCardData.dfFile88 = r_WriteUP.dfFile88;
                            writeCardData.dfFile88Mac = r_WriteUP.dfFile88Mac;
                            writeCardData.k1 = r_WriteUP.k1;
                            writeCardData.k2 = r_WriteUP.k2;
                            writeCardData.k3 = r_WriteUP.k3;
                            writeCardData.k4 = r_WriteUP.k4;
                            writeCardData.mfFile82 = r_WriteUP.mfFile82;
                            writeCardData.mfFile82Mac = r_WriteUP.mfFile82Mac;
                            writeCardData.tRandom = r_WriteUP.tRandom;

                            if (cardInfoEntity.cardType == "ST")
                            {
                                writeCardData.dfFile82 = "1|00000000000000000000000000000000000000";
                            }
                            else
                            {
                                writeCardData.dfFile82 = r_WriteUP.dfFile82;
                                writeCardData.dfFile85 = "1|00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                                writeCardData.dfFile85Mac = r_WriteUP.dfFile85Mac;
                            }

                            bool wCardResult = B_Common.WriteCardFun(customerInfo.consNo, r_WriteUP.serialNo, writeCardData, false);

                            if (wCardResult)
                            {
                                ShowErroeMsg("操作成功", "补写卡成功，点击确认后返回首页");
                                Common.ShowWaiting(m, "正在跳转到首页...");
                                GoHome();
                            }
                            else
                            {
                                ShowErroeMsg("操作失败", "写卡失败，请移步至柜台处理");
                                Common.ShowWaiting(m, "正在跳转到首页...");
                                GoHome();
                            }
                        }
                        else
                        {
                            Common.ShowWaiting(m, "正在跳转到首页...");
                            //返回首页
                            GoHome();
                        }
                    }
                    else
                    {
                        Log4NetHelper.Instance.Debug("查询补电失败");
                    }

                    List<R_PurchaseInfo> purchaseInfos = new List<R_PurchaseInfo>();
                    if (payService.PowerPurchaseInfo(customerInfo.consNo, customerInfo.orgNo, out purchaseInfos) && purchaseInfos != null && purchaseInfos.Count > 0)
                    {
                        R_PurchaseInfo purchaseInfo = purchaseInfos.First();
                        lab_LastPayTime.Text = purchaseInfo.chargeDate;
                        lab_LastPayMoney.Visible = false;
                        label2.Visible = false;
                    }
                }
                else
                {
                    List<R_Fees> feesList = new List<R_Fees>();

                    if (payService.Fees(customerInfo.consNo, customerInfo.orgNo, out feesList) && feesList != null && feesList.Count > 0)
                    {
                        rFees = feesList.First();
                        lab_LastPayTime.Text = rFees.chargeDate;
                        lab_LastPayMoney.Text = rFees.rcvAmt.ToString("0.00");
                    }
                }

                //读取配置文件，获取交易方式，
                //1代表仅允许微信，0代表仅允许现金，其他代表所有
                string buymode = Common.ReadIniStr("ClientParam.ini", "Software", "buymode");

                switch (buymode)
                {
                    case "0":
                        this.pb_Pay_WeiXin.Visible = false;
                        break;
                    case "1":
                        this.pb_pay_cash.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易中间界面加载异常", ex);
            }
        }

        /// <summary>
        /// 返回首页
        /// </summary>
        private void GoHome()
        {
            try
            {
                new BusinessBindService().UnBind();

                DriverCommon.ICReaderDriver.OutCard(true);

                this.pb_back_top.Enabled = false;
                this.pb_returnprevious.Enabled = false;
                this.pb_pay_cash.Enabled = false;

                this.Hide();
                m.nowformname = this.Name;
                this.TopMost = false;
                this.Close();
                m.JmpFrom("MainFormSim");
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("返回首页异常", ex);
            }
        }

        #region 按钮事件
        /// <summary>
        /// 时间到超时返回上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            timer_returnmain.Enabled = false;
            this.pb_back_top_Click(sender, e);
        }

        private void pb_returnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                new BusinessBindService().UnBind();

                //返回上一页
                this.pb_returnprevious.Enabled = false;
                this.pb_pay_cash.Enabled = false;
                this.pb_back_top.Enabled = false;
                this.Hide();
                m.nowformname = this.Name;
                this.TopMost = false;
                this.pb_returnprevious.Enabled = true;
                this.Close();
                if (Client.FlowType == Client.nflow)
                {
                    m.JmpFrom("IputCustomeridSim");
                }
                else
                {
                    m.JmpFrom("InputIcCardSim");
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("返回上一页异常", ex);
            }
        }

        private void pb_back_top_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        /// <summary>
        /// 微信按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_Pay_Weixin_Click(object sender, EventArgs e)
        {
            pb_Pay_WeiXin.Enabled = false;
            this.timer_returnmain.Enabled = false;
            Common.ShowWaiting(m, "检测小票打印机,请稍候...");
            ShowWaiting.InitTimeout();
            DevStatic.DevCheck(DevStatic.ThermalPrinter, "1");
            if (!DriverCommon.Printer)
            {
                TimerInit();
                Common.HideWaiting();
                ShowCommit sc = new ShowCommit("很抱歉，" + DevStatic.ThermalPrinterStaticMsg + "不提供凭条和发票打印！", "是否继续进行缴纳电费？");
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.No)
                {
                    pb_Pay_WeiXin.Enabled = true;
                    return;
                }
                Common.ShowWaiting(this, "正在查询欠费信息,请稍候...");
            }

            ShowWaiting.showmsg = "正在查询欠费信息,请稍候...";
            ShowWaiting.InitTimeout();
            double totalArrears = 0;

            if (Client.FlowType == Client.nflow)
            {
                PostpaidService postpaidService = new PostpaidService();

                if (!postpaidService.Arrearage(customerInfo.consNo, customerInfo.orgNo, out totalArrears))
                {
                    ShowErroeMsg("很抱歉，后台异常", "请联系柜台处理");
                    return;
                }
            }

            ShowWaiting.showmsg = "正在生成流水号,请稍候...";
            ShowWaiting.InitTimeout();
            string serialno = GetSerialno();

            if (string.IsNullOrEmpty(serialno))
            {
                ShowErroeMsg("很抱歉，获取流水号失败", "请联系柜台处理");
                return;
            }

            Common.HideWaiting();

            //设置结算方式和购电标记
            Global.SettleMode = Global.WenXinPay;

            if (Client.FlowType == Client.icflow)
            {
                m.obj = new object[] { customerInfo, cardInfoEntity, serialno };
            }
            else
            {
                m.obj = new object[] { customerInfo, totalArrears, serialno };
            }

            this.Hide();
            m.nowformname = this.Name;
            this.pb_returnprevious.Enabled = true;
            this.Close();
            m.JmpFrom("ScanCodePaySim");
        }

        /// <summary>
        /// 现金支付按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_pay_cash_Click(object sender, EventArgs e)
        {
            this.timer_returnmain.Enabled = false;
            Common.ShowWaiting((Main)this.Owner, "检测纸币识别器,请稍候...");
            DevStatic.DevCheck(DevStatic.CashCode, "1");
            //正式使用请放开
            if (!DriverCommon.CashCode)
            {
                TimerInit();
                Common.HideWaiting();
                TimerInit();
                ShowMsg sm = new ShowMsg("很抱歉，" + DevStatic.CashCodeStaticMsg + "暂不支持现金缴费", "请选择其他支付方式或到柜台缴费");
                sm.ShowDialog();
                return;
            }
            ShowWaiting.showmsg = "检测小票打印机,请稍等...";
            ShowWaiting.InitTimeout();
            DevStatic.DevCheck(DevStatic.ThermalPrinter, "1");
            if (!DriverCommon.Printer)
            {
                TimerInit();
                Common.HideWaiting();
                ShowCommit sc = new ShowCommit("很抱歉，" + DevStatic.ThermalPrinterStaticMsg + "不提供凭条和发票打印！", "是否继续进行缴纳电费？");
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.No)
                {
                    return;
                }
                Common.ShowWaiting(this, "正在获取流水号,请稍候...");
            }

            TimerInit();
            ShowWaiting.showmsg = "与生成流水号,请稍候...";
            ShowWaiting.InitTimeout();
            string serialno = GetSerialno();

            if (string.IsNullOrEmpty(serialno))
            {
                ShowErroeMsg("很抱歉，获取流水号失败", "请联系柜台处理");
                return;
            }

            //设置结算方式和购电标记
            Global.SettleMode = Global.CashPay;

            if (Client.FlowType == Client.icflow)
            {
                m.obj = new object[] { customerInfo, serialno, this.obj[2] };
            }
            else
            {
                ShowWaiting.showmsg = "正在查询欠费信息,请稍候...";
                ShowWaiting.InitTimeout();
                double totalArrears = 0;

                if (Client.FlowType == Client.nflow)
                {
                    TimerInit();
                    PostpaidService postpaidService = new PostpaidService();

                    if (!postpaidService.Arrearage(customerInfo.consNo, customerInfo.orgNo, out totalArrears))
                    {
                        ShowErroeMsg("很抱歉，后台异常", "请联系柜台处理");
                        return;
                    }
                }

                m.obj = new object[] { customerInfo, serialno, totalArrears };
            }

            this.Hide();
            m.nowformname = this.Name;
            this.pb_returnprevious.Enabled = true;
            this.Close();
            m.JmpFrom("InputCashSim");
        }

        private string GetSerialno()
        {
            string _serialno = string.Empty;

            CommonService commonService = new CommonService();
            commonService.Serialno(out _serialno);

            return _serialno;
        }

        /// <summary>
        /// 弹出异常提示并充值按钮状态
        /// </summary>
        /// <param name="msg1"></param>
        /// <param name="msg2"></param>
        private void ShowErroeMsg(string msg1, string msg2)
        {
            TimerInit();
            Common.HideWaiting();
            ShowMsg sm = new ShowMsg(msg1, msg2);
            sm.ShowDialog();
            this.timer_returnmain.Enabled = true;
            pb_Pay_WeiXin.Enabled = true;
        }
        #endregion

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void CashQuerySim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
    }
}
