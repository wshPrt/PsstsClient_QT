namespace PsstsClient.Service.RecData
{
    public class R_Fees
    {
        /// <summary>
        /// 序号(必填)
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 供电单位(必填)
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称(必填)
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 缴费时间(必填)
        /// </summary>
        public string chargeDate { get; set; }

        /// <summary>
        /// 用户编号(必填)
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名称(必填)
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 缴费金额(必填)
        /// </summary>
        public double rcvAmt { get; set; }

        /// <summary>
        /// 缴费方式(必填)
        /// </summary>
        public string payMode { get; set; }

        /// <summary>
        /// 结算方式(必填)
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 收费员(必填)
        /// </summary>
        public string chargeEpmNo { get; set; }

        /// <summary>
        /// 交易流水号(必填)
        /// </summary>
        public string serialNo { get; set; }
    }
}
