namespace PsstsClient.Service.RecData
{
    public class R_PurchaseInfo
    {
        /// <summary>
        /// 供电单位
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 购电时间
        /// </summary>
        public string chargeDate { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 缴费方式
        /// </summary>
        public string payMode { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 交易流水号
        /// 对于接口交易的缴费信息查询出相关的流水号，电力柜台交易的信息不用查询次信息
        /// </summary>
        public string serialNo { get; set; }
    }
}
