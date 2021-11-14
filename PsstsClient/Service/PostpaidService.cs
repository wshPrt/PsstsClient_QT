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
    public class PostpaidService : BaseBusinessService
    {
        /// <summary>
        /// 后付费欠费查询
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="orgNo">机构编号</param>
        /// <param name="totalArrears">总欠费</param>
        /// <param name="bgnYm">查询开始月份</param>
        /// <param name="endYm">查询结束月份</param>
        /// <returns></returns>
        public bool Arrearage(string consNo, string orgNo, out double totalArrears, string bgnYm = "", string endYm = "")
        {
            totalArrears = 0;
            bool result = false;

            try
            {
                bgnYm = DateTime.Now.AddMonths(-6).ToString("yyyyMM");
                endYm = DateTime.Now.ToString("yyyyMM");

                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = "postpaidService";
                businessData.businessMethod = "arrearage";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("consNo", consNo);
                queryParam.Add("orgNo", orgNo);
                queryParam.Add("bgnYm", bgnYm);
                queryParam.Add("endYm", endYm);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("后付费欠费查询发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("后付费欠费查询返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    recData = recMessageEntity.jsonData.ToString();

                    List<R_Arrearage> arrearageInfoArray = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData.ToString())?.ToObject<List<R_Arrearage>>();

                    double tArrearsAmt = 0;

                    arrearageInfoArray.ForEach((item) =>
                    {
                        tArrearsAmt += Convert.ToDouble(item.arrearsAmt);
                    });

                    totalArrears = tArrearsAmt;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("查询电费信息异常", ex);
            }

            return result;
        }

        /*/// <summary>
        /// 查询用户欠费信息
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="orgNo">单位编号</param>
        /// <param name="bgnYm"></param>
        /// <param name="endYm"></param>
        /// <returns></returns>
        public bool Arrearage(string consNo, string orgNo, out List<R_Arrearage> rArrearages, string bgnYm = "", string endYm = "")
        {
            rArrearages = null;
            bool result = false;

            try
            {
                bgnYm = DateTime.Now.AddMonths(-6).ToString("yyyyMM");
                endYm = DateTime.Now.ToString("yyyyMM");

                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = "postpaidService";
                businessData.businessMethod = "arrearage";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("consNo", consNo);
                queryParam.Add("orgNo", orgNo);
                queryParam.Add("bgnYm", bgnYm);
                queryParam.Add("endYm", endYm);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);

                SendData(sendJson);

                string recData = GetRecString();

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    result = true;
                    recData = recMessageEntity.jsonData.ToString();

                    List<R_Arrearage> customeInfoArray = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData.ToString())?.ToObject<List<R_Arrearage>>();

                    rArrearages = customeInfoArray;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("查询电费信息异常", ex);
            }

            return result;
        }*/

        /// <summary>
        /// 后付费缴费票据打印
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        public bool PayBill(string consNo, string serialNo, out R_PayBill rPayBill)
        {
            rPayBill = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = "postpaidService";
                businessData.businessMethod = "payBill";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("consNo", consNo);
                queryParam.Add("serialNo", serialNo);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("后付费缴费票据打印发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("后付费缴费票据打印返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    recData = recMessageEntity.jsonData.ToString();

                    rPayBill = JsonConvert.DeserializeObject<JArray>(recData)?.ToObject<List<R_PayBill>>()[0];
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("后付费缴费票据打印异常", ex);
            }

            return result;
        }
    }
}
