using Newtonsoft.Json;
using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity;
using PsstsClient.Service;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static PsstsClient.Driver.DicCRT310Reader;

namespace PsstsClient.Forms.Pay
{
    public partial class InputCashSim : Form
    {
        #region 全局成员
        private string printdata = "";
        private bool isAotoCommit = false;

        /// <summary>
        /// 账单金额
        /// </summary>
        double billMoney;

        /// <summary>
        /// 流水号
        /// </summary>
        private string serialno = string.Empty;
        /// <summary>
        /// 用户基本数据
        /// </summary>
        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

        /// <summary>
        /// 读卡数据
        /// </summary>
        CardInfoEntity CardInfoEntity;

        /// <summary>
        /// 
        /// </summary>
        CommonService commonService = new CommonService();

        /// <summary>
        /// 跳转窗体异步委托
        /// </summary>
        /// <param name="payResut"></param>
        /// <param name="showInfo"></param>
        /// <param name="printInfo"></param>
        delegate void GoResultAsyn(int payResut, string showInfo, string printInfo, string msg);

        /// <summary>
        /// 已投币金额
        /// </summary>
        decimal inputMoney = 0;

        Main m;
        #endregion

        public InputCashSim()
        {
            InitializeComponent();
            this.label_1.AutoSize = true;
            this.label_1.BackColor = System.Drawing.Color.Transparent;
            this.label_1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_1.Name = "labelCustomerInfo";
            this.label_1.TabIndex = 21;
        }

        public InputCashSim(object[] obj)
        {
            this.customerInfo = (R_QueryCustomerInfo)obj[0];
            serialno = (string)obj[1];

            if (Client.FlowType == Client.icflow)
            {
                CardInfoEntity = (CardInfoEntity)obj[2];
            }
            else
            {
                billMoney = Convert.ToDouble(obj[2]);
            }

            InitializeComponent();

            lab_MZ.Text = GetMZ();
        }

        #region 界面事件
        /// <summary>
        /// 界面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputCashSim_Load(object sender, EventArgs e)
        {
            m = (Main)this.Owner;

            isAotoCommit = false;
            TimerInit();
            bool canDo = false;
            lab_consNo.Text = customerInfo.consNo;
            lab_consName.Text = customerInfo.consName;

            if (Client.FlowType == Client.nflow)
            {
                lb_billMoney.Text = billMoney.ToString("0.00");
            }

            canDo = GetfileModel();

            if (!canDo)
            {
                Common.HideWaiting();
                TimerInit();
                ShowMsg sm = new ShowMsg("很抱歉，缴费凭条模板不存在，不支持当前支付方式缴费", "请选择其他支付方式或到柜台缴费");
                sm.ShowDialog();
                GoMainFormSim();
                return;
            }

            //正式使用请放开
            //纸币识别器启动           
            if (DriverCommon.CashCode)
            {
                if (!DriverCommon.CashCodeDriver.StartIdentify(Client.Billtype, this.CashEvent))
                {
                    Common.HideWaiting();
                    TimerInit();
                    ShowMsg sm = new ShowMsg("很抱歉，本机暂不支持现金缴费（开启验钞失败)", "请选择其他支付方式或到柜台缴费");
                    sm.ShowDialog();
                    // GoMainFormSim();
                    return;
                }
                else
                {
                    SoundUtil.SayInsertmoney();
                }
            }
            else
            {
                Common.HideWaiting();
                TimerInit();
                ShowMsg sm = new ShowMsg("很抱歉，本机暂不支持现金缴费", "请选择其他支付方式或到柜台缴费");
                sm.ShowDialog();
                // GoMainFormSim();
                //return;
            }

            Common.WriteLogStr("System", "现金缴费", "用户[" + customerInfo.consNo + "]进入现金投币界面");
        }

        /// <summary>
        /// 跳转到首页
        /// </summary>
        private void GoMainFormSim()
        {
            DriverCommon.ICReaderDriver.OutCard(true);

            this.timer_returnMain.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            m.obj = null;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }

        private void InputCashSim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }

        /// <summary>
        /// 跳转到交易结果界面
        /// </summary>
        /// <param name="payResut">交易结果</param>
        /// <param name="showInfo">显示信息</param>
        /// <param name="printInfo">凭条打印信息</param>
        private void GoToPayResult(int payResut, string showInfo, string printInfo, string msg)
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
        #endregion

        #region 设置金额
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

        private void CashEvent(int money, string error)
        {
            CashE(setMoney, money, error);
        }

        private void setMoney(int money, string error)
        {
            TimerInit();
            if (this.lb_InputMoney.Text == "")
                this.lb_InputMoney.Text = money.ToString("0.00");
            this.lb_InputMoney.Text = (float.Parse(this.lb_InputMoney.Text) + money).ToString("0.00");
            this.lb_paymoney.Text = (float.Parse(this.lb_InputMoney.Text) - float.Parse(this.lb_billMoney.Text)).ToString("0.00");
            //this.lb_error.Text = error;
            if (money != 0) //记录纸币识别器日志在数据库
            {
                Common.WriteLogStr("System", "现金缴费", "用户[" + customerInfo.consNo + "]投币[" + money.ToString("0.00") + "]元");

                B_LocalData.Instance.InsertCashRecord(customerInfo.consNo, serialno, money);
            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //正式使用请放开
            try
            {
                DriverCommon.CashCodeDriver.StopIdentify();
            }
            catch (Exception ex)
            {
                this.pb_ok.Enabled = true;
                Common.WriteLogStr("Errors", "确定结束投币", "停止验钞[" + ex + "]");
            }

            decimal arrear = decimal.Parse(this.lb_billMoney.Text);
            inputMoney = decimal.Parse(this.lb_InputMoney.Text);
            ShowCommit sc;
            //无投币           
            if (inputMoney == 0)
            {
                //如果是超时自动返回
                if (isAotoCommit)
                {
                    GoMainFormSim();
                    return;
                }
                Common.HideWaiting();
                sc = new ShowCommit("没有投币，是否退出缴费？", "是：退出并返回主界面\r\n否：继续缴费");
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.Yes)
                {
                    GoMainFormSim();
                    return;
                }
                else
                {
                    isPaying = false;
                    TimerInit();
                    DriverCommon.CashCodeDriver.StartIdentify(Client.Billtype, this.CashEvent);
                    this.pb_ok.Enabled = true;
                    return;
                }
            }

            if ((arrear - inputMoney) > 0)
            {
                if (isAotoCommit)
                {

                }
                else
                {
                    Common.HideWaiting();
                    sc = new ShowCommit("投币金额不足以缴清欠费，是否继续投币？", "是：继续投币\r\n否：结束投币进行缴费");
                    sc.ShowDialog();
                    if (sc.DialogResult == DialogResult.Yes)
                    {
                        TimerInit();
                        DriverCommon.CashCodeDriver.StartIdentify(Client.Billtype, this.CashEvent);
                        this.pb_ok.Enabled = true;
                        isPaying = false;
                        return;
                    }
                    else
                    {
                        Common.ShowWaiting((Main)this.Owner, "正在发起交易,请稍后...");
                    }
                }
            }

            Common.HideWaiting();
            sc = new ShowCommit("信息确认", string.Format("确认充值：{0} 元\r\n是：确认充值，否：继续缴费", inputMoney));
            DialogResult result = sc.ShowDialog();

            if (sc.DialogResult == DialogResult.Yes)
            {
                Common.ShowWaiting((Main)this.Owner, "正在发起交易,请稍后...");

                TranProcessing();
            }
            else
            {
                TimerInit();
                DriverCommon.CashCodeDriver.StartIdentify(Client.Billtype, this.CashEvent);
                this.pb_ok.Enabled = true;
                isPaying = false;
                return;
            }
        }

        /// <summary>
        /// 交易处理函数
        /// </summary>
        /// <returns></returns>
        private bool TranProcessing()
        {
            bool result = false;

            try
            {
                P_Pay pay = new P_Pay();
                R_Pay r_Pay = new R_Pay();
                string traderesult = string.Empty;
                bool isPaySuccess = false;
                string batchNo = commonService.GetBatchNo();

                if (Client.FlowType == Client.icflow)
                {
                    bool isWriteSucess = false;

                    B_LocalData.Instance.InsertTradingRecord(customerInfo.consNo, serialno, batchNo, Global.ICCardRecharge, decimal.Parse(lb_InputMoney.Text).ToString("0.00"));

                    pay.consNo = customerInfo.consNo;
                    pay.orgNo = customerInfo.orgNo;
                    pay.serialNo = serialno;
                    pay.batchNo = batchNo;
                    pay.payMode = Global.TerminalCardCode;
                    pay.settleMode = Global.CashPay;
                    pay.cardFlag = Global.ICCardFlag;
                    pay.bankDate = DateTime.Now.ToString("yyyyMMdd");
                    pay.rcvAmt = inputMoney.ToString("0.00");
                    pay.paySuccessFlag = 1;
                    pay.payCodeFlag = 0;
                    pay.cardType = CardInfoEntity.cardType;
                    pay.cardSnr = CardInfoEntity.cardSnr;
                    pay.mfFile82 = CardInfoEntity.mfFile82;
                    pay.dfFile81 = CardInfoEntity.dfFile81;
                    pay.dfFile82 = CardInfoEntity.dfFile82;
                    pay.dfFile83 = CardInfoEntity.dfFile83;
                    pay.dfFile84 = CardInfoEntity.dfFile84;
                    pay.dfFile85 = CardInfoEntity.dfFile85;
                    pay.dfFile86 = CardInfoEntity.dfFile86;
                    pay.dfFile87 = CardInfoEntity.dfFile87;
                    pay.dfFile88 = CardInfoEntity.dfFile88;
                    pay.cardRandom = CardInfoEntity.cardRandom;

                    if (commonService.Pay(pay, out r_Pay))
                    {
                        isPaySuccess = true;
                        ShowWaiting.showmsg = "交易成功，正在进行写卡操作...";
                        //交易成功修改本地数据
                        B_LocalData.Instance.UpTradingRecord(serialno);

                        isWriteSucess = WriteCard(r_Pay);

                        string payResult = string.Empty;

                        if (isWriteSucess)
                        {
                            traderesult = Global.PayConstSuccess;
                        }
                        else
                        {
                            traderesult = Global.PayConstFailure;
                        }
                    }
                    else
                    {
                        traderesult = Global.ChargeOffsFailure;
                    }

                    PayResultHandle(isPaySuccess, pay, traderesult, isWriteSucess);
                }
                else
                {
                    B_LocalData.Instance.InsertTradingRecord(customerInfo.consNo, serialno, batchNo, Global.BillPay, decimal.Parse(lb_InputMoney.Text).ToString("0.00"));

                    pay.consNo = customerInfo.consNo;
                    pay.orgNo = customerInfo.orgNo;
                    pay.serialNo = serialno;
                    pay.batchNo = batchNo;
                    pay.payMode = Global.TerminalChargeCode;
                    pay.settleMode = Global.CashPay;
                    pay.cardFlag = Global.PayCost;
                    pay.bankDate = DateTime.Now.ToString("yyyyMMdd");
                    pay.rcvAmt = inputMoney.ToString("0.00");
                    pay.paySuccessFlag = 1;
                    pay.payCodeFlag = 0;

                    if (commonService.Pay(pay, out r_Pay))
                    {
                        //交易成功
                        B_LocalData.Instance.UpTradingRecord(serialno);
                        traderesult = Global.PayConstSuccess;
                        isPaySuccess = true;
                    }
                    else
                    {
                        traderesult = Global.ChargeOffsFailure;
                    }

                    PayResultHandle(isPaySuccess, pay, traderesult);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易处理异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 交易结果处理
        /// </summary>
        /// <param name="isPaySucess"></param>
        /// <param name="pay"></param>
        /// <param name="payResult"></param>
        /// <param name="writeCardSucc">写卡成功？(true=成功、false=失败)</param>
        private void PayResultHandle(bool isPaySucess, P_Pay pay, string payResult, bool writeCardSucc = false)
        {
            PrintInfoEntity printInfo;
            string payMode = string.Empty;
            string msg = string.Empty;
            int payCode = -1;

            try
            {
                if (Client.FlowType == Client.icflow)
                {
                    payMode = Global.ICCardRecharge;

                    if (isPaySucess && writeCardSucc)
                    {
                        payCode = 0;
                        msg = "交易成功，请保留此凭条。";
                    }
                    else if (isPaySucess && !writeCardSucc)
                    {
                        msg = "支付成功写卡失败，请凭此凭条移步到柜台处理。";
                    }
                    else
                    {
                        msg = "缴费失败，系统销账异常，请凭此凭条移步到柜台处理。";
                    }
                }
                else
                {
                    if (isPaySucess)
                    {
                        payCode = 0;
                        msg = "交易成功，请保留此凭条。";
                    }
                    else
                    {
                        msg = "缴费失败，系统销账异常，请凭此凭条移步到柜台处理。";
                    }

                    payMode = Global.BillPay;
                }

                PrintData printData = new PrintData();
                printData.consNo = customerInfo.consNo;
                printData.consName = customerInfo.consName;
                printData.orgName = customerInfo.orgName;
                printData.elecAddr = customerInfo.elecAddr;
                printData.serialNo = serialno;
                printData.paymode = payMode;
                printData.rcvAmt = pay.rcvAmt;
                printData.traderesult = payResult;
                printData.transcode = Global.CashPayMode;
                printData.msg = msg;


                printInfo = B_Common.GenerateCommonPrint(printData);

                GoToPayResult(payCode, printInfo.ShowInfo, printInfo.PrintInfo, payResult);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易结果处理异常", ex);
            }
        }

        /// <summary>
        /// 写卡
        /// </summary>
        /// <returns></returns>
        private bool WriteCard(R_Pay r_Pay)
        {
            bool result = false;

            try
            {
                ICCardEncipheredData cardEncipheredData = JsonConvert.DeserializeObject<ICCardEncipheredData>(r_Pay.icCardEncipheredData);
                lpstruWriteCardData writeCardData = new lpstruWriteCardData();

                writeCardData.cardType = CardInfoEntity.cardType;
                writeCardData.dfFile81 = cardEncipheredData.dfFile81;
                writeCardData.dfFile81Mac = cardEncipheredData.dfFile81Mac;
                writeCardData.dfFile82Mac = cardEncipheredData.dfFile82Mac;
                writeCardData.dfFile83 = cardEncipheredData.dfFile83;
                writeCardData.dfFile83Mac = cardEncipheredData.dfFile83Mac;
                writeCardData.dfFile84 = cardEncipheredData.dfFile84;
                writeCardData.dfFile84Mac = cardEncipheredData.dfFile84Mac;
                writeCardData.dfFile85 = cardEncipheredData.dfFile85;
                writeCardData.dfFile85Mac = cardEncipheredData.dfFile85Mac;
                writeCardData.dfFile86 = cardEncipheredData.dfFile86;
                writeCardData.dfFile86Mac = cardEncipheredData.dfFile86Mac;
                writeCardData.dfFile88 = cardEncipheredData.dfFile88;
                writeCardData.dfFile88Mac = cardEncipheredData.dfFile88Mac;
                writeCardData.k1 = cardEncipheredData.k1;
                writeCardData.k2 = cardEncipheredData.k2;
                writeCardData.k3 = cardEncipheredData.k3;
                writeCardData.k4 = cardEncipheredData.k4;
                writeCardData.mfFile82 = cardEncipheredData.mfFile82;
                writeCardData.mfFile82Mac = cardEncipheredData.mfFile82Mac;
                writeCardData.tRandom = cardEncipheredData.tRandom;

                if (CardInfoEntity.cardType == "ST")
                {
                    writeCardData.dfFile82 = "1|00000000000000000000000000000000000000";
                }
                else
                {
                    writeCardData.dfFile82 = cardEncipheredData.dfFile82;
                    writeCardData.dfFile85 = "1|00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                    writeCardData.dfFile85Mac = cardEncipheredData.dfFile85Mac;
                }

                result = B_Common.WriteCardFun(customerInfo.consNo, serialno, writeCardData);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("现金购电写卡异常", ex);
            }

            return result;
        }

        bool isPaying = false;

        #region 控件事件
        private void pb_ok_Click(object sender, EventArgs e)
        {
            if (isPaying)
            {
                return;
            }

            isPaying = true;
            this.pb_ok.Enabled = false;
            this.timer_returnMain.Enabled = false;

            Common.ShowWaiting((Main)this.Owner, "正在识别纸币,请不要再放钞...");

            try
            {
                DriverCommon.CashCodeDriver.StopIdentify();
            }
            catch (Exception ex)
            {
                this.pb_ok.Enabled = true;
                Common.WriteLogStr("Errors", "确定结束投币", "停止验钞[" + ex + "]");
            }

            SoundUtil.SayDobusiness();

            if (backgroundWorker1.IsBusy)
            {
                this.pb_ok.Enabled = true;
                return;
            }

            //正式使用请放开
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void TimerInit()
        {
            this.timer_returnMain.Enabled = false;
            this.timer_returnMain.Interval = DevInfo.returntime;
            this.timer_returnMain.Enabled = true;
        }

        /// <summary>
        /// 超时定时器执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_returnMain_Tick(object sender, EventArgs e)
        {
            isAotoCommit = true;
            this.pb_ok_Click(sender, e);
            this.timer_returnMain.Enabled = false;

        }
        #endregion

        /// <summary>
        /// 读取凭条模板
        /// </summary>
        /// <returns></returns>
        private bool GetfileModel()
        {
            //检查凭条模板是否存在
            string filemodel = Client.AppPath + "\\PrintModel\\cardpay.txt";
            if (!File.Exists(filemodel))
            {
                return false;
            }

            //读取收费凭条内容
            StreamReader sr = new StreamReader(filemodel, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                printdata += line + "\r\n";
            }

            return true;
        }

        /// <summary>
        /// 获取面值输出提示
        /// </summary>
        /// <returns></returns>
        private string GetMZ()
        {
            int[] billType = new int[7] { 1, 2, 4, 8, 16, 32, 64 };
            string[] mz = new string[7] { "1", "2", "5", "10", "20", "50", "100", };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 7; i++)
            {
                if ((Client.Billtype & billType[i]) == billType[i])
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("、" + mz[i]);
                    }
                    else
                    {
                        sb.Append(mz[i]);
                    }
                }
            }

            sb.Append(" 元的纸币");

            return "请投入面值为：" + sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setMoney(10, "");
        }
    }
}