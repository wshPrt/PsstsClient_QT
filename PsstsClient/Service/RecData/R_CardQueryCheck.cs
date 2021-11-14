namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 卡表预购电查询验证返回数据实体
    /// </summary>
    public class R_CardQueryCheck
    {
        /// <summary>
        /// 资金编号(同操作员登录接口的批次号)
        /// </summary>
        public string batchNo { get; set; }

        /// <summary>
        /// 供电单位编码
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 综合电价
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// 尖电价
        /// </summary>
        public string jPrice { get; set; }

        /// <summary>
        /// 峰电价
        /// </summary>
        public string fPrice { get; set; }

        /// <summary>
        /// 平电价
        /// </summary>
        public string pPrice { get; set; }

        /// <summary>
        /// 谷电价
        /// </summary>
        public string gPrice { get; set; }

        /// <summary>
        /// 卡表类型
        /// </summary>
        public string meterType { get; set; }

        /// <summary>
        /// 预置金额
        /// </summary>
        public string prePq { get; set; }

        /// <summary>
        /// 购电金额上限
        /// </summary>
        public string downBuyPq { get; set; }

        /// <summary>
        /// 购电金额下限
        /// </summary>
        public string upBuyPq { get; set; }

        /// <summary>
        /// 购电次数
        /// </summary>
        public string buyNum { get; set; }

        /// <summary>
        /// 调尾金额(网省特殊)
        /// </summary>
        public string prepayBal { get; set; }

        /// <summary>
        /// 电能表标识
        /// </summary>
        public string meterId { get; set; }

        /// <summary>
        /// 是否插表
        /// </summary>
        public string ifMeter { get; set; }

        /// <summary>
        /// 核算单位
        /// </summary>
        public string acctOrgNo { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string elecAddr { get; set; }

        /// <summary>
        /// 是否允许购电标识
        /// </summary>
        public int buyPowerFlag { get; set; }
    }
}
