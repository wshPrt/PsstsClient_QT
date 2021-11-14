namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 后付费查询返回数据实体
    /// </summary>
    public class R_Arrearage
    {
        /// <summary>
        /// 欠费金额(必填)
        /// </summary>
        public string arrearsAmt { get; set; }

        /// <summary>
        /// 供电单位编号(必填)
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称(必填)
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 总应收(必填)
        /// </summary>
        public double rcvblAmtTal { get; set; }

        /// <summary>
        /// 总实收(必填)
        /// </summary>
        public double rcvedAmtTal { get; set; }

        /// <summary>
        /// 电费年月(必填)
        /// </summary>
        public string rcvblYm { get; set; }

        /// <summary>
        /// 电费(必填)
        /// </summary>
        public int tPq { get; set; }

        /// <summary>
        /// 应收电费(必填)
        /// </summary>
        public double rcvblAmt { get; set; }

        /// <summary>
        /// 实收电费(必填)
        /// </summary>
        public double rcvedAmt { get; set; }

        /// <summary>
        /// 应收违约金(必填)
        /// </summary>
        public double rcvblPenalty { get; set; }

        /// <summary>
        /// 实收违约金(必填)
        /// </summary>
        public double rcvedPenalty { get; set; }

        /// <summary>
        /// 电费类别(必填)
        /// </summary>
        public string ctlMode { get; set; }
    }
}
