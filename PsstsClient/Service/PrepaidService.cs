using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Entity;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace PsstsClient.Service
{
    public class PrepaidService : BaseBusinessService
    {
        private const string businessType = "prepaidService";
        //重试次数
        //int recryCount = 1;

        /// <summary>
        /// 写卡结果回调
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="serialNo">交易时候使用的流水号</param>
        /// <param name="writeCardFlag">0：失败，1：成功</param>
        /// <returns></returns>
        public bool WriteCardCallback(string consNo, string serialNo, int writeCardFlag)
        {
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "writeCardCallback";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("consNo", consNo);
                queryParam.Add("serialNo", serialNo);
                queryParam.Add("writeCardFlag", writeCardFlag);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("写卡结果回调发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("写卡结果回调返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写卡回调异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 卡表购电票据打印
        /// </summary>
        /// <param name="serialNo">交易流水号</param>
        /// <returns></returns>
        public bool PayBill(string serialNo, out R_PrepaidServicePayBill servicePayBill)
        {
            servicePayBill = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "payBill";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("serialNo", serialNo);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("卡表购电票据打印发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("卡表购电票据打印返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    recData = recMessageEntity.jsonData.ToString();
                    servicePayBill = JsonConvert.DeserializeObject<JArray>(recData)?.ToObject<List<R_PrepaidServicePayBill>>()[0];

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写卡回调异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 购电补写
        /// </summary>
        /// <param name="pWriteUP">购电补写参数</param>
        /// <param name="rWriteUP">购电补写返回数据</param>
        /// <returns></returns>
        public bool WriteUP(P_WriteUP pWriteUP, out R_WriteUP rWriteUP)
        {
            rWriteUP = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "writeUp";

                businessData.AddParams(pWriteUP);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("购电补写发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("购电补写返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    recData = recMessageEntity.jsonData.ToString();
                    rWriteUP = JsonConvert.DeserializeObject<R_WriteUP>(recData);

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("购电补写异常", ex);
            }

            return result;
        }
    }
}
