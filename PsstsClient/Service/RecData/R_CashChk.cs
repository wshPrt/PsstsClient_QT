namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 解款服务返回数据实体
    /// </summary>
    public class R_CashChk
    {
        /// <summary>
        /// 解款账户标识
        /// </summary>
        public string cashchkId { get; set; }

        /// <summary>
        /// 操作日期
        /// </summary>
        public string batchNo { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string rcvAmtSum { get; set; }
    }
}
