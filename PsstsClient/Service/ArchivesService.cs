using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PsstsClient.Entity;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;

namespace PsstsClient.Service
{
    public class ArchivesService : BaseBusinessService
    {
        const string businessType = "archivesService";

        /// <summary>
        /// 客户基本信息查询
        /// </summary>
        /// <param name="queryNo">查询编号</param>
        /// <param name="queryType">1用户编号 2电表号码，优先用1</param>
        /// <returns></returns>
        public bool QueryCustomerInfo(string queryNo, out R_QueryCustomerInfo rCustomerInfo, string queryType = "1")
        {
            rCustomerInfo = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "queryCustomerInfo";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("queryNo", queryNo);
                queryParam.Add("queryType", queryType);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("客户基本信息查询发送报文："+ sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("客户基本信息查询返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    result = true;
                    recData = recMessageEntity.jsonData.ToString();

                    JArray customeInfoArray = JsonConvert.DeserializeObject<JArray>(recMessageEntity.jsonData.ToString());

                    rCustomerInfo = customeInfoArray?.First?.ToObject<R_QueryCustomerInfo>();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("客户基本信息查询异常", ex);
            }

            return result;
        }
    }
}
