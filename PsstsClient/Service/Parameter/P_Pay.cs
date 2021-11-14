namespace PsstsClient.Service.Parameter
{
    /// <summary>
    /// 交易服务参数实体
    /// </summary>
    public class P_Pay
    {
        /// <summary>
        /// 用户编号(必填)
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 供电单位(必填)
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 流水号(必填)
        /// </summary>
        public string serialNo { get; set; }

        /// <summary>
        /// 批次号(必填)
        /// </summary>
        public string batchNo { get; set; }

        /// <summary>
        /// 缴费方式(必填)
        /// </summary>
        public string payMode { get; set; }

        /// <summary>
        /// 结算方式(必填)
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 业务类型(必填，01：卡表售电。02：缴费)
        /// </summary>
        public string cardFlag { get; set; }

        /// <summary>
        /// 银行日期(必填)
        /// </summary>
        public string bankDate { get; set; }

        /// <summary>
        /// 交易金额(必填)
        /// </summary>
        public string rcvAmt { get; set; }

        /// <summary>
        /// 付款码标识，否：0,是:1。
        /// 注：标识为是，则手机扫码是直接进行支付操作；标识为否，则手机扫码后显示输入金额后再进行支付
        /// </summary>
        public int payCodeFlag { get; set; }

        /// <summary>
        /// 否：0，是：1；注：二维码扫码支付必须传递0
        /// </summary>
        public int paySuccessFlag { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardType { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string cardSnr { get; set; }

        /// <summary>
        /// 基本文件
        /// </summary>
        public string mfFile82 { get; set; }

        /// <summary>
        /// 下行购电文件
        /// </summary>
        public string dfFile81 { get; set; }

        /// <summary>
        /// 返写文件
        /// </summary>
        public string dfFile82 { get; set; }

        /// <summary>
        /// 钱包文件
        /// </summary>
        public string dfFile83 { get; set; }

        /// <summary>
        /// 备用套电价文件(国网卡使用，水投为空)
        /// </summary>
        public string dfFile84 { get; set; }

        /// <summary>
        /// 预留
        /// </summary>
        public string dfFile85 { get; set; }

        /// <summary>
        /// 下行自定义回写文件
        /// </summary>
        public string dfFile86 { get; set; }

        /// <summary>
        /// 自定义信息返写文件
        /// </summary>
        public string dfFile87 { get; set; }

        /// <summary>
        /// 下行参数设置文件
        /// </summary>
        public string dfFile88 { get; set; }

        /// <summary>
        /// 8字节随机数
        /// </summary>
        public string cardRandom { get; set; }
    }
}
