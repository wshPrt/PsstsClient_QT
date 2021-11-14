using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Entity;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PsstsClient.Service
{
    public class PayService : BaseBusinessService
    {
        const string businessType = "payService";

        /// <summary>
        /// 缴费信息查询
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="orgNo">供电单位编号</param>
        /// <param name="bgnYm">yyyy-mm，查询该年月区间的缴费记录</param>
        /// <param name="endYm">yyyy-mm，查询该年月区间的缴费记录</param>
        /// <returns></returns>
        public bool Fees(string consNo, string orgNo, out List<R_Fees> reesList)
        {
            reesList = null;
            bool result = false;

            try
            {
                string bgnYm = DateTime.Now.AddMonths(-6).ToString("yyyyMM");
                string endYm = DateTime.Now.ToString("yyyyMM");

                string jsonData = SendRequest("fees", consNo, orgNo, bgnYm, endYm);

                if (!string.IsNullOrEmpty(jsonData))
                {
                    Log4NetHelper.Instance.Debug("缴费信息：" + jsonData);
                    reesList = JsonConvert.DeserializeObject<JArray>(jsonData)?.ToObject<List<R_Fees>>();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("缴费信息查询异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 电费信息查询
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="orgNo"></param>
        /// <param name="eInfoList"></param>
        /// <returns></returns>
        public bool ElectricChargeInfos(string consNo, string orgNo,out List<R_ElectricInfo> eInfoList)
        {
            eInfoList = null;
            bool result = false;

            try
            {
                string bgnYm = DateTime.Now.AddMonths(-6).ToString("yyyyMM");
                string endYm = DateTime.Now.ToString("yyyyMM");

                string jsonData = SendRequest("electricchargeinfos", consNo, orgNo, bgnYm, endYm);

                if (!string.IsNullOrEmpty(jsonData))
                {
                    Log4NetHelper.Instance.Debug("电费信息："+ jsonData);
                    eInfoList = JsonConvert.DeserializeObject<JArray>(jsonData)?.ToObject<List<R_ElectricInfo>>();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("电费信息查询异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 购电信息查询
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="orgNo"></param>
        /// <param name="r_PurchaseInfo"></param>
        /// <returns></returns>
        public bool PowerPurchaseInfo(string consNo, string orgNo,out List<R_PurchaseInfo> r_PurchaseInfo)
        {
            r_PurchaseInfo = null;
            bool result = false;

            try
            {
                string bgnYm = DateTime.Now.AddMonths(-6).ToString("yyyyMM");
                string endYm = DateTime.Now.ToString("yyyyMM");

                string jsonData = SendRequest("powerPurchaseInfo", consNo, orgNo, bgnYm, endYm);

                if (!string.IsNullOrEmpty(jsonData))
                {
                    Log4NetHelper.Instance.Debug("购电信息：" + jsonData);
                    JArray powArray = JsonConvert.DeserializeObject<JArray>(jsonData);

                    if (powArray != null && powArray.Count > 0)
                    {
                        r_PurchaseInfo = powArray.ToObject<List<R_PurchaseInfo>>();
                        result = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("购电信息查询异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 发送查询请求
        /// </summary>
        /// <param name="businessMethod"></param>
        /// <param name="consNo"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgnYm"></param>
        /// <param name="endYm"></param>
        /// <returns></returns>
        private string SendRequest(string businessMethod, string consNo, string orgNo, string bgnYm, string endYm)
        {
            string recJsonStr = string.Empty;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();
                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = businessMethod;

                Hashtable queryParam = new Hashtable();
                queryParam.Add("consNo", consNo);
                queryParam.Add("orgNo", orgNo);
                queryParam.Add("bgnYm", bgnYm);
                queryParam.Add("endYm", endYm);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    recJsonStr = recMessageEntity.jsonData.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return recJsonStr;
        }
    }
}
