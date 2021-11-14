using Newtonsoft.Json;
using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity;
using PsstsClient.Service;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PsstsClient.Driver.DicCRT310Reader;

namespace PsstsClient.Forms.Pay
{
    public partial class ScanCodePaySim : Form
    {
        #region 全局成员
        /// <summary>
        /// 交易结果操作后台线程
        /// </summary>
        private Task payResultTask;

        /// <summary>
        /// 倒计时提醒异步操作委托
        /// </summary>
        /// <param name="text"></param>
        delegate void SetLableAsyn(bool visible);

        /// <summary>
        /// 返回上一页按钮异步委托
        /// </summary>
        /// <param name="visible"></param>
        delegate void PreviousButtonAsyn(bool visible);

        /// <summary>
        /// 跳转窗体异步委托
        /// </summary>
        /// <param name="payResut"></param>
        /// <param name="showInfo"></param>
        /// <param name="printInfo"></param>
        delegate void GoResultAsyn(int payResut, string showInfo, string printInfo, string msg);

        /// <summary>
        /// 通用服务（获取流水号和二维码）
        /// </summary>
        CommonService commonService = new CommonService();

        /// <summary>
        /// 交易支付请求、获取交易二维码、读取交易结果参数
        /// </summary>
        P_Pay pay;

        public object[] obj;

        /// <summary>
        /// 用户基本数据
        /// </summary>
        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

        /// <summary>
        /// 用户读卡实体
        /// </summary>
        CardInfoEntity cardInfoEntity;

        /// <summary>
        /// 总欠费金额
        /// </summary>
        double totalArrears = 0.00;

        /// <summary>
        /// 交易流水号
        /// </summary>
        string serialno = string.Empty;

        /// <summary>
        /// 写卡数据
        /// </summary>
        lpstruWriteCardData writeCardData = new lpstruWriteCardData();

        //主窗体
        Main m;
        #endregion

        private ScanCodePaySim()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rObj"></param>
        public ScanCodePaySim(object[] rObj)
        {
            obj = rObj;
            customerInfo = (R_QueryCustomerInfo)this.obj[0];
            serialno = this.obj[2].ToString();

            if (Client.FlowType == Client.icflow)
            {
                cardInfoEntity = (CardInfoEntity)this.obj[1];
            }
            else
            {
                totalArrears = (double)this.obj[1];
            }

            InitializeComponent();
        }

        #region 交易业务处理
        /// <summary>
        /// 启动监听交易结果
        /// </summary>
        private void StartListeningPayResult()
        {
            R_PayResult payResult = new R_PayResult();
            PayResultService payResultService = new PayResultService();
            TimerInit();

            try
            {
                bool writeCardSucc = false;
                string traderesult = string.Empty;
                string msg = string.Empty;
                bool isTimeOut = false;
                bool isPaySuccess = payResultService.PayResultListening(out isTimeOut, out payResult);
                m.StartHeartbeat();

                if (isTimeOut)
                {
                    TimerInit();
                    //监听超时，主动查询交易结果
                    bool payRus = InitiativeGetPayResult(out writeCardSucc);

                    SetLableVisible(false);
                    CountdownAction(false);

                    if (payRus && writeCardSucc)
                    {
                        traderesult = Global.PayConstSuccess;
                        msg = "交易成功，请保留此凭条。";
                    }
                    if (payRus && !writeCardSucc)
                    {
                        traderesult = Global.PayConstFailure;
                        msg = "支付成功写卡失败，请凭此凭条移步到柜台处理。";
                    }
                    else
                    {
                        msg = "缴费失败，系统销账异常，请凭此凭条移步到柜台处理。";
                        traderesult = Global.ChargeOffsFailure;
                    }

                    PayResultHandle(payRus, traderesult, msg, writeCardSucc);
                }
                else
                {
                    if (isPaySuccess)
                    {
                        if (Client.FlowType == Client.icflow)
                        {
                            writeCardData.cardType = cardInfoEntity.cardType;
                            writeCardData.dfFile81 = payResult.dfFile81;
                            writeCardData.dfFile81Mac = payResult.dfFile81Mac;
                            writeCardData.dfFile82Mac = payResult.dfFile82Mac;
                            writeCardData.dfFile83 = payResult.dfFile83;
                            writeCardData.dfFile83Mac = payResult.dfFile83Mac;
                            writeCardData.dfFile84 = payResult.dfFile84;
                            writeCardData.dfFile84Mac = payResult.dfFile84Mac;
                            writeCardData.dfFile85 = payResult.dfFile85;
                            writeCardData.dfFile85Mac = payResult.dfFile85Mac;
                            writeCardData.dfFile86 = payResult.dfFile86;
                            writeCardData.dfFile86Mac = payResult.dfFile86Mac;
                            writeCardData.dfFile88 = payResult.dfFile88;
                            writeCardData.dfFile88Mac = payResult.dfFile88Mac;
                            writeCardData.k1 = payResult.k1;
                            writeCardData.k2 = payResult.k2;
                            writeCardData.k3 = payResult.k3;
                            writeCardData.k4 = payResult.k4;
                            writeCardData.mfFile82 = payResult.mfFile82;
                            writeCardData.mfFile82Mac = payResult.mfFile82Mac;
                            writeCardData.tRandom = payResult.tRandom;

                            if (cardInfoEntity.cardType == "ST")
                            {
                                writeCardData.dfFile82 = "1|00000000000000000000000000000000000000";
                            }
                            else
                            {
                                writeCardData.dfFile82 = payResult.dfFile82;
                                writeCardData.dfFile85 = "1|00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                                writeCardData.dfFile85Mac = payResult.dfFile85Mac;
                            }

                            writeCardSucc = B_Common.WriteCardFun(customerInfo.consNo, serialno, writeCardData);

                            if (writeCardSucc)
                            {
                                traderesult = Global.PayConstSuccess;
                                msg = "交易成功，请保留此凭条。";
                            }
                            else
                            {
                                msg = "支付成功写卡失败，请凭此凭条移步到柜台处理。";
                                traderesult = Global.PayConstFailure;
                            }
                        }

                        //缴费成功，跳转到结果页面
                        SetLableVisible(false);
                        CountdownAction(false);
                        PayResultHandle(isPaySuccess, traderesult, msg, writeCardSucc);
                    }
                    else
                    {
                        msg = "缴费失败，系统销账异常，请凭此凭条移步到柜台处理。";
                        traderesult = Global.ChargeOffsFailure;
                        //缴费失败，跳转到结果页面
                        SetLableVisible(false);
                        CountdownAction(false);
                        PayResultHandle(isPaySuccess, traderesult, msg, writeCardSucc);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("监听交易结果消息异常", ex);
            }
        }

        /// <summary>
        /// 主动读取交易结果
        /// </summary>
        /// <param name="writeCardSucc">写卡结果</param>
        /// <returns></returns>
        private bool InitiativeGetPayResult(out bool writeCardSucc)
        {
            writeCardSucc = false;
            bool result = false;

            try
            {
                R_Pay rPay = commonService.GetPayResult(pay);

                result = rPay?.status == "1";

                if (result && Client.FlowType == Client.icflow)
                {
                    ICCardEncipheredData iCCard = JsonConvert.DeserializeObject<ICCardEncipheredData>(rPay.icCardEncipheredData);

                    writeCardData.cardType = cardInfoEntity.cardType;
                    writeCardData.dfFile81 = iCCard.dfFile81;
                    writeCardData.dfFile81Mac = iCCard.dfFile81Mac;
                    writeCardData.dfFile82Mac = iCCard.dfFile82Mac;
                    writeCardData.dfFile83 = iCCard.dfFile83;
                    writeCardData.dfFile83Mac = iCCard.dfFile83Mac;
                    writeCardData.dfFile84 = iCCard.dfFile84;
                    writeCardData.dfFile84Mac = iCCard.dfFile84Mac;
                    writeCardData.dfFile85 = iCCard.dfFile85;
                    writeCardData.dfFile85Mac = iCCard.dfFile85Mac;
                    writeCardData.dfFile86 = iCCard.dfFile86;
                    writeCardData.dfFile86Mac = iCCard.dfFile86Mac;
                    writeCardData.dfFile88 = iCCard.dfFile88;
                    writeCardData.dfFile88Mac = iCCard.dfFile88Mac;
                    writeCardData.k1 = iCCard.k1;
                    writeCardData.k2 = iCCard.k2;
                    writeCardData.k3 = iCCard.k3;
                    writeCardData.k4 = iCCard.k4;
                    writeCardData.mfFile82 = iCCard.mfFile82;
                    writeCardData.mfFile82Mac = iCCard.mfFile82Mac;
                    writeCardData.tRandom = iCCard.tRandom;

                    if (cardInfoEntity.cardType == "ST")
                    {
                        writeCardData.dfFile82 = "1|00000000000000000000000000000000000000";
                    }
                    else
                    {
                        writeCardData.dfFile82 = iCCard.dfFile82;
                        writeCardData.dfFile85 = "1|00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                        writeCardData.dfFile85Mac = iCCard.dfFile85Mac;
                    }

                    writeCardSucc = B_Common.WriteCardFun(customerInfo.consNo, serialno, writeCardData);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("主动读取交易结果异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 支付结果处理，远程获取打印凭条数据，如获取失败则打印通用凭条
        /// </summary>
        /// <param name="isPaySucess">交易支付结果</param>
        /// <param name="payResult">缴费结果</param>
        /// <param name="msg">写卡结果</param>
        private void PayResultHandle(bool isPaySucess, string payResult, string msg, bool isWriteCard)
        {

            try
            {
                string payMode = string.Empty;
                PrintData printData = new PrintData();
                printData.consNo = customerInfo.consNo;
                printData.consName = customerInfo.consName;
                printData.elecAddr = customerInfo.elecAddr;
                printData.orgName = customerInfo.orgName;
                printData.serialNo = serialno;
                printData.transcode = Global.WeiXinPayMode;
                printData.traderesult = payResult;
                printData.msg = msg;

                if (isPaySucess && Client.FlowType == Client.icflow)
                {
                    printData.paymode = Global.ICCardRecharge;
                    PrepaidService prepaidService = new PrepaidService();
                    R_PrepaidServicePayBill pPayBill = new R_PrepaidServicePayBill();

                    if (prepaidService.PayBill(serialno, out pPayBill))
                    {
                        printData.rcvAmt = pPayBill.chargeFee.Replace("￥", "");
                        B_LocalData.Instance.UpScanCodePayRecord(serialno, Convert.ToDecimal(printData.rcvAmt));
                    }
                    else
                    {
                        printData.rcvAmt = "0.00";
                        printData.msg = "缴费成功，获取小票数据失败，请移步到柜台补打小票。";
                    }

                    //读取凭条和输出结果信息
                    PrintInfoEntity printInfo = B_Common.GenerateCommonPrint(printData);

                    GoToPayResult(isPaySucess == isWriteCard ? 0 : -1, printInfo.ShowInfo, printInfo.PrintInfo);
                }
                else if (isPaySucess && Client.FlowType == Client.nflow)
                {
                    payMode = Global.BillPay;
                    PostpaidService postpaidService = new PostpaidService();
                    R_PayBill payBill = new R_PayBill();

                    //交易成功读取交易成功打印凭据
                    if (postpaidService.PayBill(customerInfo.consNo, serialno, out payBill))
                    {
                        B_LocalData.Instance.UpScanCodePayRecord(serialno, Convert.ToDecimal(payBill.rcvAmt));
                        PrintInfoEntity printInfo = B_Common.GeneratePayingPrint(payBill, serialno, payMode, "支付成功", Global.WeiXinPayMode, "交易成功，请保留凭条。", Client.PayingTemplateName);
                        //进入打印页面
                        GoToPayResult(0, printInfo.ShowInfo, printInfo.PrintInfo);
                    }
                    else
                    {
                        printData.rcvAmt = "0.00";
                        printData.msg = "缴费成功，获取小票数据失败，请移步到柜台补打小票。";
                        Log4NetHelper.Instance.Debug("获取后付费用户打印凭据失败，流水号：" + serialno);

                        PrintInfoEntity printInfo = B_Common.GenerateCommonPrint(printData);
                        //进入打印页面
                        GoToPayResult(0, printInfo.ShowInfo, printInfo.PrintInfo);
                    }
                }
                else
                {
                    Log4NetHelper.Instance.Debug("微信支付失败，流水号：" + serialno);

                    printData.rcvAmt = "0.00";
                    PrintInfoEntity printInfo = B_Common.GenerateCommonPrint(printData);
                    //进入打印页面
                    GoToPayResult(-1, printInfo.ShowInfo, printInfo.PrintInfo);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易结果处理异常", ex);
            }
        }
        #endregion

        #region 页面操作
        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanCodePaySim_Load(object sender, System.EventArgs e)
        {
            m = (Main)this.Owner;

            lab_CustomerNo.Text = customerInfo.consNo;
            lab_CustomerName.Text = customerInfo.consName;
            lab_Balance.Text = totalArrears.ToString("0.00");

            TimerInit();

            //开始提交交易请求生成二维码
            pay = new P_Pay();
            pay.consNo = customerInfo.consNo;
            pay.orgNo = customerInfo.orgNo;
            pay.serialNo = serialno;
            pay.batchNo = commonService.GetBatchNo();
            pay.payMode = Global.TerminalChargeCode;
            pay.settleMode = Global.SettleMode;
            pay.bankDate = DateTime.Now.ToString("yyyyMMdd");
            pay.paySuccessFlag = 1;

            if (totalArrears <= 0)
            {
                pay.rcvAmt = (0.01).ToString();
                pay.payCodeFlag = 0;
            }
            else
            {
                pay.rcvAmt = totalArrears.ToString("0.00");
                pay.payCodeFlag = 1;
            }

            if (Client.FlowType == Client.icflow)
            {
                pay.cardFlag = Global.ICCardFlag;

                pay.cardType = cardInfoEntity.cardType;
                pay.cardSnr = cardInfoEntity.cardSnr;
                pay.mfFile82 = cardInfoEntity.mfFile82;
                pay.dfFile81 = cardInfoEntity.dfFile81;
                pay.dfFile82 = cardInfoEntity.dfFile82;
                pay.dfFile83 = cardInfoEntity.dfFile83;
                pay.dfFile84 = cardInfoEntity.dfFile84;
                pay.dfFile85 = cardInfoEntity.dfFile85;
                pay.dfFile86 = cardInfoEntity.dfFile86;
                pay.dfFile87 = cardInfoEntity.dfFile87;
                pay.dfFile88 = cardInfoEntity.dfFile88;
                pay.cardRandom = cardInfoEntity.cardRandom;
            }
            else
            {
                pay.cardFlag = Global.PayCost;
            }

            R_Pay rPay = new R_Pay();

            if (commonService.Pay(pay, out rPay) && rPay.serialNo == serialno)
            {
                Bitmap qrCodeImage = QRCodeUtil.CreateCode(rPay.qrCode, 3);
                pic_WenXinQrCode.Image = qrCodeImage;

                SetLableVisible(true);
                CountdownAction(true);

                //发送一次心跳数据给服务端避免连接断开，停止主窗体的心跳发送避免交易回调数据误收
                SocketHelper.Instance.SendHeartbeat();
                m.StoptHeartbeat();

                //启动交易消息监听
                payResultTask = new Task(StartListeningPayResult);
                payResultTask.Start();
            }
            else
            {
                SetLableVisible(false);
                //获取二维码失败弹出提示
                ShowMsg sm = new ShowMsg("交易异常", "无法获取二维码，请选择其他支付方式进行交易，点击确定返回重新选择支付方式");
                sm.ShowDialog();
                GoHome();
                return;
            }

            string buyMode = string.Empty;

            if (Client.FlowType == Client.icflow)
            {
                buyMode = "卡表购电";
            }
            else
            {
                buyMode = "充值缴费";
            }

            B_LocalData.Instance.InsertScanCodePayRecord(customerInfo.consNo, serialno, buyMode);
        }

        /// <summary>
        /// 跳转到交易结果界面
        /// </summary>
        /// <param name="payResut">交易结果</param>
        /// <param name="showInfo">显示信息</param>
        /// <param name="printInfo">凭条打印信息</param>
        private void GoToPayResult(int payResut, string showInfo, string printInfo, string msg = "")
        {
            if (this.InvokeRequired)
            {
                GoResultAsyn goResult = new GoResultAsyn(GoToPayResult);
                Invoke(goResult, payResut, showInfo, printInfo, msg);
            }
            else
            {
                this.Hide();
                m.nowformname = this.Name;
                m.obj = new object[] { payResut, showInfo, 0, printInfo, msg };
                this.TopMost = false;
                this.Close();
                m.JmpFrom("PayResultSim");
            }
        }

        private delegate void GoToHome();

        /// <summary>
        /// 返回首页
        /// </summary>
        private void GoHome()
        {
            if (this.InvokeRequired)
            {
                GoToHome toHome = new GoToHome(GoHome);
                Invoke(toHome);
            }
            else
            {
                if (Client.FlowType == Client.icflow)
                {
                    DriverCommon.ICReaderDriver.OutCard(true);
                    DriverCommon.ICReaderDriver.DICClose();
                }

                this.Hide();
                m.nowformname = this.Name;
                this.TopMost = false;
                this.Close();
                m.JmpFrom("MainFormSim");
            }
        }

        /// <summary>
        /// 关闭窗体事件（停止定时器）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanCodePaySim_FormClosing(object sender, FormClosingEventArgs e)
        {
            CountdownAction(false);

            if (payResultTask.Status == TaskStatus.RanToCompletion)
            {
                payResultTask.Dispose();
            }

            time_Countdown.Dispose();
            timer_returnmain.Stop();
            timer_returnmain.Dispose();
        }

        private void ScanCodePaySim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
        #endregion

        #region 页面控件操作
        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = 120 * 1000;
            this.timer_returnmain.Enabled = true;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            Log4NetHelper.Instance.Debug("进入到超时定时器函数");
            Common.ShowWaiting(m, "支付超时，正在跳转到首页。");

            GoHome();
        }

        /// <summary>
        /// 倒数定时器操作(启动、停止)
        /// </summary>
        /// <param name="action"></param>
        private void CountdownAction(bool action)
        {
            time_Countdown.Enabled = action;

            if (action)
            {
                time_Countdown.Start();
            }
            else
            {
                time_Countdown.Stop();
            }
        }

        /// <summary>
        /// 倒计时定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Countdown_Tick(object sender, EventArgs e)
        {
            int countDown = Convert.ToInt32(lab_Countdown.Text);

            if (countDown == 1)
            {
                lab_Countdown.Text = "0";
                pic_WenXinQrCode.Image = PsstsClient.Properties.Resources.loading;
                time_Countdown.Stop();
                time_Countdown.Enabled = false;

                SetLableVisible(false);

                //输出提示读取后台数据
                lab_Prompt.Visible = true;
            }
            else
            {
                lab_Countdown.Text = (Convert.ToInt32(lab_Countdown.Text) - 1).ToString();
            }
        }

        /// <summary>
        /// 设置定时器提示是否显示
        /// </summary>
        /// <param name="visible"></param>
        void SetLableVisible(bool visible)
        {
            if (this.label2.InvokeRequired)
            {
                SetLableAsyn stcb = new SetLableAsyn(SetLableVisible);
                Invoke(stcb, visible);
            }
            else
            {
                label2.Visible = visible;
                lab_Countdown.Visible = visible;
                label8.Visible = visible;
            }
        }
        #endregion
    }
}
