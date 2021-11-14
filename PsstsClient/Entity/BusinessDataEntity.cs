using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Collections;
using Newtonsoft.Json;
using System.Reflection;

namespace PsstsClient.Entity
{
    /// <summary>
    /// 业务参数实体
    /// </summary>
    public class BusinessDataEntity : BaseDataEntity
    {
        Hashtable jsonParams = new Hashtable();

        public BusinessDataEntity()
        {
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="paramObj"></param>
        public void AddParams(object paramObj)
        {
            //先添加公共参数
            jsonParams.Add("channelNo", Global.ChanelNo);
            jsonParams.Add("chargeEmpNo", "bbb");
            //jsonParams.Add("plOrgNo", Global.plOrgNo);
            jsonParams.Add("terminalNo", Global.ClientKey);
            jsonParams.Add("mac", DevInfo.LocalMac);

            PropertyInfo[] propertyArray = paramObj.GetType().GetProperties();

            foreach (PropertyInfo property in propertyArray)
            {
               object value = property.GetValue(paramObj, null);

                jsonParams.Add(property.Name, value);
            }

            base.jsonData = JsonConvert.SerializeObject(jsonParams);
        }

        /// <summary>
        /// 添加接口参数
        /// </summary>
        /// <param name="data"></param>
        public void AddJsonData(Hashtable data)
        {
            //先添加公共参数
            jsonParams.Add("channelNo", Global.ChanelNo);
            jsonParams.Add("chargeEmpNo", "bbb");
            //jsonParams.Add("plOrgNo", Global.plOrgNo);
            jsonParams.Add("terminalNo", Global.ClientKey);
            jsonParams.Add("mac", DevInfo.LocalMac);

            foreach (string key in data.Keys)
            {
                if (data[key]?.GetType() == typeof(int))
                {
                    jsonParams.Add(key, Convert.ToInt32(data[key]?.ToString()));
                }
                else
                {
                    jsonParams.Add(key, data[key]?.ToString());
                }
            }

            base.jsonData = JsonConvert.SerializeObject(jsonParams);
        }
    }
}
