using PsstsClient.Utility;

namespace PsstsClient.Entity
{
    public class RecContext
    {
        /// <summary>
        /// 终端编号
        /// </summary>
        public string machineid { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string flowno { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string batchno { get; set; }

        /// <summary>
        /// 缴费分类
        /// </summary>
        public string paytype { get; set; }

        /// <summary>
        /// 账务日期
        /// </summary>
        public string paydate { get; set; }

        /// <summary>
        /// 缴费总金额
        /// </summary>
        public string trademoney { get; set; }

        /// <summary>
        /// 缴费方式
        /// </summary>
        public string tradetype { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string settype { get; set; }

        /// <summary>
        /// 支票号码
        /// </summary>
        public string zhipiao { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string customerid { get; set; }

        /// <summary>
        /// 单位代码
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 生成对账内容
        /// </summary>
        /// <returns></returns>
        public string GenerateRecStr()
        {
            string result = string.Empty;

            machineid = machineid.PadLeft(8, ' ');
            flowno = flowno.PadLeft(20, ' ');
            batchno = batchno.PadLeft(10, ' ');
            paytype = paytype.PadLeft(2, ' ');
            paydate = paydate.PadLeft(10, ' ');
            trademoney = trademoney.PadLeft(15, ' ');
            tradetype = tradetype.PadLeft(6, ' ');
            settype = settype.PadLeft(2, ' ');
            zhipiao = zhipiao.PadLeft(12, ' ');
            customerid = customerid.PadLeft(12, ' ');
            orgNo = orgNo.PadLeft(7, ' ');

            /*machineid = StringUtil.StrCompletion(8, " ", machineid);
            flowno = StringUtil.StrCompletion(20, "\t", flowno);
            batchno = StringUtil.StrCompletion(10, "\t", batchno);
            paytype = StringUtil.StrCompletion(2, "\t", paytype);
            paydate = StringUtil.StrCompletion(10, "\t", paydate);
            trademoney = StringUtil.StrCompletion(15, "\t", trademoney);
            tradetype = StringUtil.StrCompletion(6, "\t", tradetype);
            settype = StringUtil.StrCompletion(2, "\t", settype);
            zhipiao = StringUtil.StrCompletion(12, "\t", zhipiao);
            customerid = StringUtil.StrCompletion(12, "\t", customerid);
            orgNo = StringUtil.StrCompletion(7, "\t", orgNo);*/

            result = machineid + flowno + batchno + paytype + paydate + trademoney + tradetype + settype + zhipiao + customerid + orgNo;

            return result;
        }
    }
}