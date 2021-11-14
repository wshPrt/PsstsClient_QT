using Newtonsoft.Json;
using PsstsClient.Entity;
using PsstsClient.Entity.LocalData;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsstsClient.Bll
{
    /// <summary>
    /// 清机对账业务处理类
    /// </summary>
    public class B_Reconciliation
    {
        int batchCode = 0;

        /// <summary>
        /// 生成对账文件名称
        /// </summary>
        /// <param name="payCode">缴费分类（01预付费、02后付费）</param>
        /// <returns></returns>
        public string GetRecFileName(string payCode, out string rBatch)
        {
            rBatch = null;
            string result = string.Empty;

            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string batch = date + GetBatchSeq();
                result = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}.txt", Global.ChanelNo, Global.ClientKey, payCode, Global.CashPay, Global.plOrgNo, date, batch);
                rBatch = batch;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("生成对账文件名异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 上传对账文件
        /// </summary>
        /// <param name="cashTrans">本地数据列表</param>
        /// <param name="icBatchno">返回参数，预付费对账批次号</param>
        /// <param name="payBatchno">返回参数，后付费对账批次号</param>
        /// <returns></returns>
        public bool UpRecFile(List<CashTranRecord> cashTrans, out string icBatchno, out string payBatchno)
        {
            icBatchno = null;
            payBatchno = null;
            bool result = false;

            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                StringBuilder icTranContext = new StringBuilder();
                StringBuilder billPayTranContext = new StringBuilder();

                foreach (CashTranRecord record in cashTrans)
                {
                    RecContext rec = new RecContext();
                    rec.machineid = record.machineid;
                    rec.flowno = record.flowno;
                    rec.batchno = record.batchno;
                    rec.paydate = date;
                    rec.trademoney = record.trademoney.ToString("0.00");
                    rec.settype = Global.CashPay;
                    rec.customerid = record.customerid;
                    rec.zhipiao = "";
                    rec.orgNo = Global.plOrgNo;

                    if (record.tradetype == Global.ICCardRecharge)
                    {
                        rec.tradetype = Global.TerminalChargeCode;
                        rec.paytype = Global.ICCardFlag;
                        icTranContext.AppendLine(rec.GenerateRecStr());
                    }
                    else
                    {
                        rec.tradetype = Global.TerminalCardCode;
                        rec.paytype = Global.PayCost;
                        billPayTranContext.AppendLine(rec.GenerateRecStr());
                    }
                }

                string icRecFileName = GetRecFileName(Global.ICCardFlag, out icBatchno);
                string payRecFileName = GetRecFileName(Global.PayCost, out payBatchno);
                string checkDir = Client.AppPath + Global.CheckFileDir + "\\";

                FileHelper.Instance.ExistsDir(checkDir, true);
                result = FileHelper.Instance.WriteFile(icTranContext.ToString(), checkDir + icRecFileName);
                result = FileHelper.Instance.WriteFile(billPayTranContext.ToString(), checkDir + payRecFileName);

                string upYffDir = string.Format("/EPMP-UPF-PAY/DK_IN/{0}/ds/dz/yff/", Global.ChanelNo);
                string upHffDir = string.Format("/EPMP-UPF-PAY/DK_IN/{0}/ds/dz/hff/", Global.ChanelNo);

                Log4NetHelper.Instance.Debug("Yff目录：" + upYffDir);
                Log4NetHelper.Instance.Debug("Hff目录：" + upHffDir);

                string ftpIcFileName = upYffDir + icRecFileName;
                string ftpPayFileName = upHffDir + payRecFileName;

                Log4NetHelper.Instance.Debug("预付费路径："+ ftpIcFileName);
                Log4NetHelper.Instance.Debug("后付费路径："+ ftpPayFileName);

                //上传对账文件
                FTPUtil ftp = new FTPUtil(Global.FtpIP, Global.FtpPort, Global.FtpUser, Global.FtpPwd);
                ftp.DirectoryExists(upYffDir);
                ftp.DirectoryExists(upHffDir);
                ftp.UPLoadFile(checkDir + icRecFileName, ftpIcFileName);
                ftp.UPLoadFile(checkDir + payRecFileName, ftpPayFileName);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("生成对账文件异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 获取批次序列
        /// </summary>
        /// <returns></returns>
        private string GetBatchSeq()
        {
            string batchSeq = string.Empty;
            batchCode++;

            if (batchCode < 10)
            {
                batchSeq = "0" + batchCode.ToString();
                Log4NetHelper.Instance.Debug("序列：" + batchSeq);
            }
            else
            {
                batchSeq = batchCode.ToString();
            }

            return batchSeq;
        }
    }
}
