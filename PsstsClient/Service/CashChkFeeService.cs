using Newtonsoft.Json;
using PsstsClient.Entity;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections;

namespace PsstsClient.Service
{
    public class CashChkFeeService : BaseBusinessService
    {
        const string businessType = "cashChkFeeService";

        /// <summary>
        /// 解款预查询
        /// </summary>
        /// <param name="batchNo">批次号</param>
        /// <param name="rcvAmtSum">缴费金额</param>
        /// <param name="recordNum">缴费总笔数</param>
        /// <param name="cashChkFeeDetial">返回数据</param>
        /// <returns></returns>
        public bool QueryCashChkFeeDetial(string batchNo, decimal rcvAmtSum, string recordNum, out R_QueryCashChkFee cashChkFeeDetial)
        {
            cashChkFeeDetial = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "queryCashChkFeeDetial";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("batchNo", batchNo);
                queryParam.Add("orgNo", Global.plOrgNo);
                queryParam.Add("rcvAmtSum", rcvAmtSum);
                queryParam.Add("recordNum", recordNum);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("解款预查询发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("解款预查询返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                { 
                    
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("解款预查询异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 解款
        /// </summary>
        /// <param name="chargeEmpNo">操作员编号</param>
        /// <param name="cashchkId">解款标识号</param>
        /// <param name="cashChk">返回的数据</param>
        /// <returns></returns>
        public bool CashChk(string chargeEmpNo, string cashchkId, out R_CashChk cashChk)
        {
            cashChk = null;
            bool result = false;

            try
            {
                BusinessDataEntity businessData = new BusinessDataEntity();

                businessData.requestId = GetRequestID();
                businessData.businessType = businessType;
                businessData.businessMethod = "cashChk";

                Hashtable queryParam = new Hashtable();
                queryParam.Add("chargeEmpNo", chargeEmpNo);
                queryParam.Add("cashchkId", cashchkId);

                businessData.AddJsonData(queryParam);
                string sendJson = JsonConvert.SerializeObject(businessData);
                Log4NetHelper.Instance.Debug("解款发送报文：" + sendJson);

                SendData(sendJson);

                string recData = GetRecString();
                Log4NetHelper.Instance.Debug("解款返回结果：" + recData);

                RecMessageEntity recMessageEntity = JsonConvert.DeserializeObject<RecMessageEntity>(recData);

                if (recMessageEntity.requestId == businessData.requestId && recMessageEntity.status == Global.Successful)
                {

                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("解款异常", ex);
            }

            return result;
        }
    }
}
