using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Bll;
using PsstsClient.Entity;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;
using System.Threading;

namespace PsstsClient.Service
{
    public class CommonService : BaseBusinessService
    {
        const string businessType = "commonService";

        public bool ChargeEmpLogin(string terminalNo, string username, string pwd, out string msg)
        {
            msg = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "chargeEmpLogin";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("terminalNo", terminalNo);
                queryParam.Add("username", username);
                queryParam.Add("pwd", pwd);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
              //  Log4NetHelper.Instance.Debug("操作员登录发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
               // Log4NetHelper.Instance.Debug("操作员登录返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    JObject jsonData = JsonConvert.DeserializeObject<JObject>(recMessageEntity.jsonData.ToString());

                    result = jsonData.Value<bool>("verify");

                    if (!result)
                    {
                        msg = jsonData.Value<string>("msg");
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("操作员登录接口调用异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public bool Serialno(out string serialno)
        {
            serialno = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "serialno";

                string sendJson = JsonConvert.SerializeObject(businessData);

                SendData(sendJson);

                string recData = GetRecString();

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    serialno = recMessageEntity.jsonData.ToString();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("获取流水号异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 交易支付请求
        /// </summary>
        /// <param name="pay">交易支付请求参数实体</param>
        /// <returns></returns>
        public bool Pay(P_Pay pay, out R_Pay rPay)
        {
            rPay = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "pay";

                pay.orgNo.Substring(0, 7);
                businessData.AddParams(pay);

                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("交易支付请求发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("交易支付请求返回结果：" + recData);

                if (string.IsNullOrEmpty(recData))
                {
                    return result;
                }

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {

                    rPay = JsonConvert.DeserializeObject<R_Pay>(recMessageEntity.jsonData.ToString());

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易支付接口异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 获取交易结果（没有监听到交易返回消息时使用主动获取交易结果）
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        public R_Pay GetPayResult(P_Pay pay)
        {
            R_Pay rPay = new R_Pay();
            bool isWait = true;

            if (pay == null)
            {
                Log4NetHelper.Instance.Debug("交易结果参数异常");
                return null;
            }

            try
            {
                while (isWait)
                {
                    Pay(pay, out rPay);

                    switch (rPay.status)
                    {
                        case "2":
                            Thread.Sleep(5000);
                            break;
                        default:
                            isWait = false;
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("读取交易结果异常", ex);
            }

            return rPay;
        }
    }
}
