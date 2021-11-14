namespace PsstsClient.Entity
{
    public class PrintData
    {
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
        /// 供电单位
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string serialNo { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string paymode { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string transcode { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        public string rcvAmt { get; set; }

        /// <summary>
        /// 缴费结果
        /// </summary>
        public string traderesult { get; set; }

        /// <summary>
        /// 输出信息
        /// </summary>
        public string msg { get; set; }
    }
}
