namespace PsstsClient.Service.RecData
{
    public class R_ElectricInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 供电单位
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
        /// 用电地址
        /// </summary>
        public string elecAddr { get; set; }

        /// <summary>
        /// 电费年月
        /// yyyymm。按月份、电费类别Ctlmode进行汇总
        /// </summary>
        public string rcvblYm { get; set; }

        /// <summary>
        /// 总电量
        /// </summary>
        public string tPq { get; set; }

        /// <summary>
        /// 总电费
        /// </summary>
        public string rcvblAmt { get; set; }

        /// <summary>
        /// 总应收违约金
        /// </summary>
        public string rcvblPenalty { get; set; }

        /// <summary>
        /// 结清状态
        /// 根据总欠费金额与总金额比对：欠费、部分欠费、结清
        /// </summary>
        public string settleFlag { get; set; }

        /// <summary>
        /// 电费类别
        /// 后付费、费控，按此分类
        /// </summary>
        public string ctlMode { get; set; }
    }
}
