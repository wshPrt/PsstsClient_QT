using Newtonsoft.Json;
using PsstsClient.Driver;
using PsstsClient.Entity;
using PsstsClient.Service;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Text;
using static PsstsClient.Driver.DicCRT310Reader;

namespace PsstsClient.Bll
{
    public class B_Common
    {
        /// <summary>
        /// 生成后付费打印和展示内容
        /// </summary>
        /// <param name="payBill">服务端返回凭条结果数据</param>
        /// <param name="serialNo">流水号</param>
        /// <param name="traderesult">交易结果</param>
        /// <param name="transcode">交易类型</param>
        /// <param name="paymode">支付方式</param>
        /// <param name="msg">显示消息</param>
        /// <param name="templateName">模板名称</param>
        /// <returns></returns>
        public static PrintInfoEntity GeneratePayingPrint(R_PayBill payBill, string serialNo, string paymode, string traderesult, string transcode, string msg, string templateName)
        {
            PrintInfoEntity result = new PrintInfoEntity();

            try
            {
                //构建打印信息
                string printInfo = FileHelper.Instance.ReadFileString(Client.AppPath + Client.TemplatePath + templateName);

                printInfo = printInfo.Replace("{consNo}", payBill.consNo);
                printInfo = printInfo.Replace("{consName}", payBill.consName);
                printInfo = printInfo.Replace("{elecAddr}", payBill.elecAddr);
                printInfo = printInfo.Replace("{orgName}", payBill.orgName);
                printInfo = printInfo.Replace("{serialNo}", serialNo);
                printInfo = printInfo.Replace("{transcode}", transcode);
                printInfo = printInfo.Replace("{paymode}", paymode);
                printInfo = printInfo.Replace("{totalOweMoney}", payBill.rcvblAmtTal.ToString("0.00"));
                printInfo = printInfo.Replace("{rcvAmt}", payBill.rcvAmt.ToString("0.00"));
                printInfo = printInfo.Replace("{prepayAmt}", payBill.prepayAmt.ToString("0.00"));
                printInfo = printInfo.Replace("{traderesult}", traderesult);
                printInfo = printInfo.Replace("{msg}", msg);
                printInfo = printInfo.Replace("{datetime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                printInfo = printInfo.Replace("{machinecode}", Global.ClientKey);
                result.PrintInfo = printInfo;

                //构建显示信息
                StringBuilder showInfo = new StringBuilder();
                showInfo.AppendLine("用户编号：" + payBill.consNo);
                showInfo.AppendLine("用户名称：" + payBill.consName);
                showInfo.AppendLine("用电地址：" + payBill.elecAddr);
                showInfo.AppendLine("缴费金额：" + payBill.rcvAmt.ToString("0.00"));
                result.ShowInfo = showInfo.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 生成通用模板凭条内容（获取远程凭条失败时使用）
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="consName">用户名称</param>
        /// <param name="elecAddr">用电地址</param>
        /// <param name="orgName">用电单位</param>
        /// <param name="serialNo">流水号</param>
        /// <param name="traderesult">交易结果</param>
        /// <param name="transcode">交易类型</param>
        /// <param name="paymode">支付方式</param>
        /// <param name="isCardRec">是否卡表交易</param>
        /// <param name="templateName">模板名称</param>
        /// <returns></returns>
        public static PrintInfoEntity GenerateCommonPrint(PrintData printData, bool isCardRec = false, string templateName = "comm.txt")
        {
            PrintInfoEntity result = new PrintInfoEntity();

            try
            {
                //构建打印信息
                string printInfo = FileHelper.Instance.ReadFileString(Client.AppPath + Client.TemplatePath + templateName);

                printInfo = printInfo.Replace("{consNo}", printData.consNo);
                printInfo = printInfo.Replace("{consName}", printData.consName);
                printInfo = printInfo.Replace("{orgName}", printData.orgName);
                printInfo = printInfo.Replace("{elecAddr}", printData.elecAddr);
                printInfo = printInfo.Replace("{serialNo}", printData.serialNo);
                printInfo = printInfo.Replace("{transcode}", printData.transcode);
                printInfo = printInfo.Replace("{paymode}", printData.paymode);
                printInfo = printInfo.Replace("{rcvAmt}", printData.rcvAmt);
                printInfo = printInfo.Replace("{traderesult}", printData.traderesult);
                printInfo = printInfo.Replace("{datetime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                printInfo = printInfo.Replace("{machinecode}", Global.ClientKey);
                printInfo = printInfo.Replace("{msg}", printData.msg);
                result.PrintInfo = printInfo;

                //构建显示信息
                StringBuilder showInfo = new StringBuilder();
                showInfo.AppendLine("用户编号：" + printData.consNo);
                showInfo.AppendLine("用户名称：" + printData.consName);
                showInfo.AppendLine("用电地址：" + printData.elecAddr);
                showInfo.AppendLine("缴费金额：" + printData.rcvAmt);
                result.ShowInfo = showInfo.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="serialno"></param>
        /// <param name="writeCardData"></param>
        /// <param name="isWriteLocal">是否写入本地记录</param>
        /// <returns></returns>
        public static bool WriteCardFun(string consNo, string serialno, lpstruWriteCardData writeCardData, bool isWriteLocal = true)
        { 
            bool result = false;

            try
            {
                //写卡
                DriverCommon.ICReaderDriver.OpenPort();
                result = DriverCommon.ICReaderDriver.WriteCard(writeCardData);
                DriverCommon.ICReaderDriver.DICClose();

                Log4NetHelper.Instance.Debug("写卡结果：" + result);

                int writeCardFlag = result == true ? 1 : 0;
                PrepaidService prepaidService = new PrepaidService();
                bool isWCCallbackSuccess = prepaidService.WriteCardCallback(consNo, serialno, writeCardFlag);
                if (isWriteLocal)
                    B_LocalData.Instance.WriteCatdRecord(consNo, serialno, result, isWCCallbackSuccess);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写卡异常", ex);
            }

            return result;
        }
    }
}
