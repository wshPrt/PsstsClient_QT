namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 
    /// </summary>
    public class R_QueryCashChkFee
    {
        /// <summary>
        /// 解款标识号
        /// </summary>
        public string cashchkId { get; set; }

        /// <summary>
        /// 缴费批次号
        /// </summary>
        public string batchNo { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 解款总笔数
        /// </summary>
        public string thisRecordNum { get; set; }

        /// <summary>
        /// 解款总金额
        /// </summary>
        public string thisAmtSum { get; set; }

        /// <summary>
        /// 解款的单位编码
        /// </summary>
        public string orgNo { get; set; }
    }
}
