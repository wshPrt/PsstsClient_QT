using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Entity.LocalData;
using PsstsClient.Forms.Hardware;
using PsstsClient.Forms.Pay;
using PsstsClient.Forms.Query;
using PsstsClient.Service;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class SysMaintainSim : Form
    {
        DbOperate dboperate = new DbOperate();//实例化一个数据库操作对象,以便对下面数据进行相关的数据库操作
        readonly string startupPath = Application.StartupPath;

        public SysMaintainSim()
        {
            InitializeComponent();
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即将关闭终端，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //MessageBox.Show("关机啦啦啦啦啦啦啦啦！！！！！！！！！！！");
                SystemAPI.HideTask(false);
                Process.Start("shutdown.exe", " -s -t 0");
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即将重启终端，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //MessageBox.Show("重启啦啦啦啦啦啦啦啦！！！！！！！！！！！");
                SystemAPI.HideTask(false);
                Process.Start("shutdown.exe", " -r -t 0");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即将退出自助服务终端程序，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExitApp();
                //this.MdiParent.Dispose();
            }
        }

        private void ExitApp()
        {
            try
            {
                SystemAPI.HideTask(false);
                SocketHelper.Instance.Close();
                DriverCommon.DriverClose();
                Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }
            catch (System.Security.SecurityException sEx)
            {
                Log4NetHelper.Instance.Error("关闭程序异常", sEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("关闭程序异常", ex);
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Global.OpEmpNo = "";
            this.TopMost = false;
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();
        }

        private void runApp()
        {
            //关闭本程序，启动客户端主程序
            String mainExe = startupPath + "\\" + Client.Updatesoftname + ".exe";
            if (!File.Exists(mainExe))
            {
                mainExe = startupPath + "\\ClientUpdate.exe";
                if (!File.Exists(mainExe))
                {
                    MessageBox.Show("自助终端更新程序丢失，请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            SystemAPI.HideTask(false);
            System.Diagnostics.Process.Start(mainExe);
            this.Close();
        }

        private string GetPayList()
        {
            string result = string.Empty;

            try
            {
                DbOperate dboperate = new DbOperate();//实例化一个数据库操作对象,以便对下面数据进行相关的数据库操作
                string sql = "select customerid,trademoney,traderesult,tradetime from cashpayrecord where  clearflag='否' order by tradetime desc";
                DataTable dt = dboperate.GetDataTable(sql);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    stringBuilder.AppendLine(string.Format("{0} {1} {2} {3}", row["customerid"], row["trademoney"], row["traderesult"], row["tradetime"]));
                }

                result = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }

            return result;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            TimerInit();
            //成功总数
            int successCount = 0;
            //失败总数
            int failCount = 0;
            //总笔数
            int totalCount = 0;
            //成功金额
            double successMoney = 0;
            //失败金额
            double failMoney = 0;
            //总金额
            double totalMoney = 0;

            try
            {
                if (!DriverCommon.Printer)
                {
                    ShowMsg sm = new ShowMsg("打印机异常", "打印机异常，无法打印小票。");
                    sm.ShowDialog();
                    return;
                }

                //读取清机小票
                string slipStr = FileHelper.Instance.ReadFileString(startupPath + "/PrintModel/clean.txt");

                //备份现有数据库
                //string backupDbName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".mdb";
                // FileHelper.Instance.CopyFileTo(startupPath + "/PsstsClient.mdb", startupPath + "/backupDB/", backupDbName);

                //读取本地记录
                List<CashTranRecord> tranRecordList = B_LocalData.Instance.QueryCashRecord();
                totalCount = tranRecordList.Count;

                int icSuccessCount = 0;
                double icSuccessMoney = 0;

                //统计数量
                tranRecordList.ForEach((rec) =>
                {
                    if (rec.traderesult == "成功")
                    {
                        successCount += 1;
                        successMoney += rec.trademoney;

                        if (rec.tradetype == Global.ICCardRecharge)
                        {
                            icSuccessCount += 1;
                            icSuccessMoney += rec.trademoney;
                        }
                    }
                    else
                    {
                        failCount += 1;
                        failMoney += rec.trademoney;
                    }

                    totalMoney += rec.trademoney;
                });

                //生成对账文件并上传至服务器
                string icBatchno, payBatchno;
                B_Reconciliation reconciliation = new B_Reconciliation();
                reconciliation.UpRecFile(tranRecordList, out icBatchno, out payBatchno);

                //发起对账请求
                P_Check icCheck = new P_Check();
                icCheck.cardFlag = Global.ICCardFlag;
                icCheck.settleMode = Global.CashPay;
                icCheck.acctDate = DateTime.Now.ToString("yyyy-MM-dd");
                icCheck.cashchkEmpNo = Global.OpEmpNo;
                icCheck.orgNo = Global.plOrgNo;
                icCheck.batchNo = icBatchno;
                icCheck.rcvAmtSum = icSuccessMoney.ToString("0.00");
                icCheck.recordNum = icSuccessCount.ToString();

                string reCode = string.Empty;
                LedgerService ledgerService = new LedgerService();
                if (ledgerService.Check(icCheck, out reCode))
                {
                    ShowMsg sm = new ShowMsg("对账异常", "错误码：" + reCode);
                    sm.ShowDialog();
                    return;
                }

                R_QueryCashChkFee cashChkFeeDetial = new R_QueryCashChkFee();
                //发起解款请求
                CashChkFeeService chkFeeService = new CashChkFeeService();
                chkFeeService.QueryCashChkFeeDetial(icCheck.batchNo, Convert.ToDecimal(icCheck.rcvAmtSum), icCheck.recordNum, out cashChkFeeDetial);
                return;

                StringBuilder tranList = new StringBuilder();

                foreach (CashTranRecord cashTran in tranRecordList)
                {
                    tranList.AppendLine(string.Format("{0}  {1}  {2} {3}", cashTran.customerid, cashTran.tradetime, cashTran.trademoney.ToString("0.##"), cashTran.traderesult));
                }

                slipStr = slipStr.Replace("{successNum}", successCount.ToString());
                slipStr = slipStr.Replace("{successMon}", successMoney.ToString());
                slipStr = slipStr.Replace("{failNum}", failCount.ToString());
                slipStr = slipStr.Replace("{failMon}", failMoney.ToString());
                slipStr = slipStr.Replace("{allNum}", totalCount.ToString());
                slipStr = slipStr.Replace("{allMon}", totalMoney.ToString());
                slipStr = slipStr.Replace("{machinecode}", Client.MachineCode);
                slipStr = slipStr.Replace("{exchangelisting}", tranList.ToString());
                slipStr = slipStr.Replace("{cleartime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                Log4NetHelper.Instance.Debug(slipStr);

                //删除本地记录
                B_LocalData.Instance.DeleteCashRecord();

                //打印小票
                if (DevInfo.PrinterEnable == DevStatic.devEnable && DriverCommon.Printer)
                {
                    DriverCommon.PrinterDriver.PrintAndCutpaper(slipStr);
                    SoundUtil.SayOverprintslip();
                }

                SuspendedFormSim fm = new SuspendedFormSim();
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.WindowState = FormWindowState.Normal;
                fm.Width = ScreenInfo.ScreenWidth;
                fm.Height = ScreenInfo.ScreenHeight;
                fm.Owner = Main.allower;
                fm.TopMost = true;
                fm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMsg sm = new ShowMsg("提示", "清机失败，请联系维护人员处理。");
                sm.ShowDialog();
                Log4NetHelper.Instance.Error("清机异常", ex);
            }
        }

        private string GetLocalFlowNo()
        {
            string sql = "select Top 1 clearflowno from cashpayrecord where  clearflag = \"否\"";
            return dboperate.ExcuteStrScrSql(sql);
        }

        /// <summary>
        /// 获取清机总数
        /// </summary>
        /// <returns></returns>
        private double GetClearNum()
        {
            string sql = "select count(*) from cashpayrecord where  clearflag = \"否\"";
            return double.Parse(dboperate.ExcuteStrScrSql(sql));
        }

        /// <summary>
        /// 获取要清机总金额
        /// </summary>
        /// <returns></returns>
        private double GetClearMoney()
        {
            string sql = "select IIF(sum(trademoney) is null,0,sum(trademoney)) from cashpayrecord where clearflag = \"否\"";
            return double.Parse(dboperate.ExcuteStrScrSql(sql));
        }

        private void SysMaintainSim_Load(object sender, EventArgs e)
        {
            TimerInit();
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            timer_returnmain.Enabled = false;
            this.TopMost = false;
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();
        }

        private void LocalClearMachine()
        {
            ShowMsg sm;
            try
            {
                string printdata = "";
                bool printbool = true;
                string filemodel = startupPath + "\\printmodel\\0001.txt";
                if (!File.Exists(filemodel))
                {
                    sm = new ShowMsg("提示", "清机凭条模板不存在,将采用原始打印");
                    sm.ShowDialog();
                    printbool = false; ;
                }
                StreamReader sr = null;
                string line = "";
                //读取收费凭条内容
                if (printbool == true)
                {
                    sr = new StreamReader(filemodel, System.Text.Encoding.Default);

                    while ((line = sr.ReadLine()) != null)
                    {
                        printdata += line + "\r\n";

                    }
                }

                //总金额
                string sql = "select IIF(sum(trademoney) is null,0,sum(trademoney)) from cashpayrecord where clearflag = \"否\"";
                double totalmoney = double.Parse(dboperate.ExcuteStrScrSql(sql));

                //总笔数
                sql = "select count(*) from cashpayrecord where clearflag = \"否\"";
                string totalMoneyNum = dboperate.ExcuteStrScrSql(sql).ToString();

                //成功金额
                sql = "select IIF(sum(trademoney) is null,0,sum(trademoney)) from cashpayrecord where clearflag = \"否\" and traderesult = \"成功\"";
                double suMoney = double.Parse(dboperate.ExcuteStrScrSql(sql));

                //成功笔数
                sql = "select count(*) from cashpayrecord where clearflag = \"否\" and traderesult = \"成功\"";
                string suMoneyNum = dboperate.ExcuteStrScrSql(sql).ToString();

                //失败金额
                printdata = printdata.Replace("{successNum}", suMoneyNum.ToString());
                printdata = printdata.Replace("{successMon}", suMoney.ToString("0.00"));
                printdata = printdata.Replace("{failNum}", (decimal.Parse(totalMoneyNum) - decimal.Parse(suMoneyNum)).ToString());
                printdata = printdata.Replace("{failMon}", (totalmoney - suMoney).ToString("0.00"));
                printdata = printdata.Replace("{allMon}", totalmoney.ToString("0.00"));
                printdata = printdata.Replace("{machinecode}", Client.MachineCode);
                printdata = printdata.Replace("{cleartime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                printdata = printdata.Replace("{password}", Common.ReadIniStr("register.ini", "machine", "password"));
                DriverCommon.PrinterDriver.PrintAndCutpaper(printdata);

                DialogResult dia = MessageBox.Show(this, "是否打印本机记录的失败详单", "打印详单", MessageBoxButtons.YesNo);
                if (dia == DialogResult.Yes)
                {
                    printdata = "\n终端本机失败记录\n失败总笔数：" + (decimal.Parse(totalMoneyNum) - decimal.Parse(suMoneyNum)).ToString() + "\t失败总金额：" + (totalmoney - suMoney).ToString() + "\n户号              缴费日期    缴费金额\n";
                    sql = "SELECT t.customerid, format(t.tradetime,\"yyyymmdd\"), t.trademoney FROM cashpayrecord AS t WHERE t.traderesult = \"失败\" and t.clearflag = \"否\" order by t.tradetime desc ";
                    DataTable dt = dboperate.GetDataTable(sql);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        printdata += dt.Rows[i][0] + "        " + dt.Rows[i][1] + "    " + dt.Rows[i][2] + "\n";
                    }

                    DriverCommon.PrinterDriver.PrintAndCutpaper(printdata);
                }

                //更新数据记录
                sql = "update cashpayrecord t set t.clearflag = \"是\" where t.clearflag = \"否\"";
                int updatenum = dboperate.ExcuteIntSql(sql);
                return;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting(Main.allower, "正在同步交易数据，请稍后...");
            QueryCashPayLogSim fm = new QueryCashPayLogSim();
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.WindowState = FormWindowState.Normal;
            fm.Width = ScreenInfo.ScreenWidth;
            fm.Height = ScreenInfo.ScreenHeight;
            //fm.TopMost = true;
            Common.HideWaiting();
            fm.Show();
            this.Close();
        }

        private void btn_wh_Click(object sender, EventArgs e)
        {
            this.timer_returnmain.Enabled = false;
            SuspendedFormSim fm = new SuspendedFormSim();
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.WindowState = FormWindowState.Normal;
            fm.Width = ScreenInfo.ScreenWidth;
            fm.Height = ScreenInfo.ScreenHeight;
            fm.Owner = Main.allower;
            fm.TopMost = true;
            fm.Show();
            this.Close();
        }

        private void btn_htest_Click(object sender, EventArgs e)
        {
            HardwareTest ht = new HardwareTest();
            ht.MdiParent = this.MdiParent;
            this.Close();
            ht.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimerInit();

            UPHardwareCom fm = new UPHardwareCom();
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.WindowState = FormWindowState.Normal;
            fm.Width = ScreenInfo.ScreenWidth;
            fm.Height = ScreenInfo.ScreenHeight;
            Common.HideWaiting();
            fm.Show();
            this.Close();
        }

        private void CheckRecover()
        {
            Common.WriteIniStr("ClientParam.ini", "Software", "softcanupdate", "1");
            Common.WriteIniStr("ClientParam.ini", "Software", "modifyflag", "0");
            Common.HideWaiting();
            this.TopMost = false;
            ShowCommit sc = new ShowCommit("请确认是否恢复?", "是:自动恢复!否:暂不恢复!");
            sc.ShowDialog();
            if (sc.DialogResult == DialogResult.Yes)
            {
                runApp();
            }
            else
            {
                this.TopMost = true;
            }
        }
    }
}