using Newtonsoft.Json;
using PsstsClient.Entity;
using PsstsClient.Utility;
using System;
using System.Collections;

namespace PsstsClient.Service
{
    public class BusinessBindService : BaseBusinessService
    {
        /// <summary>
        /// 插卡绑定
        /// </summary>
        /// <param name="consNo"></param>
        /// <returns></returns>
        public bool Bind(string consNo)
        {
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = "businessBindService";
                businessData.businessMethod = "bind";
                businessData.jsonData = consNo;

                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("插卡绑定发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("插卡绑定返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("用户卡绑定异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 取消插卡绑定
        /// </summary>
        /// <returns></returns>
        public bool UnBind()
        {
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = "businessBindService";
                businessData.businessMethod = "unbind";

                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("取消插卡绑定发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("取消插卡绑定返回数据：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("用户卡绑定异常", ex);
            }

            return result;
        }
    }
}
