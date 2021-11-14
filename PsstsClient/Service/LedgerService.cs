using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Entity;
using PsstsClient.Service.Parameter;
using PsstsClient.Utility;
using System;
using System.Collections;

namespace PsstsClient.Service
{
    public class LedgerService : BaseBusinessService
    {
        const string businessType = "ledgerService";

        /// <summary>
        /// 代收对账
        /// </summary>
        /// <param name="check"></param>
        /// <param name="reCode"></param>
        /// <returns></returns>
        public bool Check(P_Check check, out string reCode)
        {
            reCode = null;
            bool result = false;

            if (check == null)
                return result;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "check";

                businessData.AddParams(check);

                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("对账请求发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("对账请求返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    //JArray dataJson = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData.ToString());

                    reCode = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData.ToString())?.First.Value<string>("reCode");
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("代收对账异常", ex);
            }

            return result;
        }
    }
}
