namespace PsstsClient.Service.RecData
{
    public class R_PrepaidServicePayBill
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string consAddr { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        public string chargeFee { get; set; }

        /// <summary>
        /// 收款时间
        /// </summary>
        public string chargeTime { get; set; }

        /// <summary>
        /// 购电次数
        /// </summary>
        public string meterPurchaseNum { get; set; }

        /// <summary>
        /// 缴费方式
        /// </summary>
        public string payType { get; set; }

        /// <summary>
        /// 退补金额
        /// </summary>
        public string returnFee { get; set; }

        /// <summary>
        /// 划转金额
        /// </summary>
        public string transferFee { get; set; }

        /// <summary>
        /// 写卡金额
        /// </summary>
        public string writeCardFee { get; set; }

        /// <summary>
        /// 大写金额
        /// </summary>
        public string amountWords { get; set; }
    }
}
