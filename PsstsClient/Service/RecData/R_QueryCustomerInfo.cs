namespace PsstsClient.Service.RecData
{
    public class R_QueryCustomerInfo
    {
        /// <summary>
        /// 供电单位编号(必填)
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称(必填)
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 用户编号(必填)
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名称(必填)
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 电话号码(选填)
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 用电地址(必填)
        /// </summary>
        public string elecAddr { get; set; }

        /// <summary>
        /// 用户类型(必填)
        /// </summary>
        public string consSortCode { get; set; }

        /// <summary>
        /// 用电类别(必填)
        /// </summary>
        public string elecTypeCode { get; set; }

        /// <summary>
        /// 电表编号(必填)
        /// </summary>
        public string madeNo { get; set; }

        /// <summary>
        /// 费控分类(选填)
        /// </summary>
        public string ctlMode { get; set; }

        /// <summary>
        /// 电表余额(选填)
        /// </summary>
        public string realBal { get; set; }

        /// <summary>
        /// 营销余额(必填)
        /// </summary>
        public string prepayBal { get; set; }

        /// <summary>
        /// 远程费控余额(选填)
        /// </summary>
        public string ctlBal { get; set; }
    }
}
