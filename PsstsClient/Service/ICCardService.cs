using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Entity;
using PsstsClient.Service.Parameter;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace PsstsClient.Service
{
    public class ICCardService : BaseBusinessService
    {
        const string businessType = "icCardService";
        //重试次数
        //private int recryCount;

        /// <summary>
        /// 卡表预购电查询验证
        /// </summary>
        /// <param name="p_CardQuery"></param>
        /// <param name="r_CardQuery"></param>
        /// <returns></returns>
        public bool CardAnlyseAndCheck(P_CardQueryCheck p_CardQuery, out string msg, out R_CardQueryCheck r_CardQuery)
        {
            msg = null;
            r_CardQuery = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "cardAnlyseAndCheck";

                businessData.AddParams(p_CardQuery);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("卡表预购电查询验证发送报文：" + sendJson);

                SendData(sendJson);

                //while (!SendData(sendJson))
                //{
                //    if (!isTimeOut || recryCount >= 3)
                //        break;

                //    recryCount++;
                //}

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("卡表预购电查询验证返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    r_CardQuery = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData?.ToString()).First?.ToObject<R_CardQueryCheck>();
                    result = true;
                }
                else
                {
                    msg = GetStatusMsg(recMessageEntity.status);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("卡表预购电查询验证异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 返回状态码对应内容
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private string GetStatusMsg(string status)
        {
            string msg = string.Empty;

            switch (status)
            {
                case "1208": msg = "购电卡为空卡，不能购电！"; break;
                case "1209": msg = "购电卡未插表，不能购电！"; break;
                case "1212": msg = "购电卡未插插表，需要限制购电！"; break;
                case "1213": msg = "该用户为定量用户，需要限制购电！"; break;
                case "1217": msg = "用户电价信息错误，需要限制购电！"; break;
            }

            return msg;
        }
    }
}
