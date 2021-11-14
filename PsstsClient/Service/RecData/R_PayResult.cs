namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 交易结果返回数据实体
    /// </summary>
    public class R_PayResult
    {
        /// <summary>
        /// 1、扫码支付回调，值：payCallback,目前暂为一种，后续可能扩展
        /// </summary>
        public string messageType { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string serialNo { get; set; }

        /// <summary>
        /// 回调结果状态，0：缴费失败、1：缴费成功
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string errorMsg { get; set; }

        /// <summary>
        /// 16个字符随机数用于系统认证（预付费缴费时返回）
        /// </summary>
        public string tRandom { get; set; }

        /// <summary>
        /// 密文用于系统认证（预付费缴费时返回）
        /// </summary>
        public string k1 { get; set; }

        /// <summary>
        /// 密文用于外部认证（预付费缴费时返回）
        /// </summary>
        public string k2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string k3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string k4 { get; set; }

        /// <summary>
        /// 基本文件（预付费缴费时返回）
        /// </summary>
        public string mfFile82 { get; set; }

        /// <summary>
        /// 下行购电文件（预付费缴费时返回）
        /// </summary>
        public string dfFile81 { get; set; }

        /// <summary>
        /// 返写文件
        /// </summary>
        public string dfFile82 { get; set; }

        /// <summary>
        /// 钱包文件（预付费缴费时返回）
        /// </summary>
        public string dfFile83 { get; set; }

        /// <summary>
        /// 备用套电价文件，国网卡使用
        /// </summary>
        public string dfFile84 { get; set; }

        /// <summary>
        /// [水投]预留，[国网]返写文件
        /// </summary>
        public string dfFile85 { get; set; }

        /// <summary>
        /// 下行自定义回写文件
        /// </summary>
        public string dfFile86 { get; set; }

        /// <summary>
        /// 下行参数设置文件（预付费缴费时返回）
        /// </summary>
        public string dfFile88 { get; set; }

        /// <summary>
        /// 基本文件MAC（预付费缴费时返回）
        /// </summary>
        public string mfFile82Mac { get; set; }

        /// <summary>
        /// 下行购电文件MAC（预付费缴费时返回）
        /// </summary>
        public string dfFile81Mac { get; set; }

        /// <summary>
        /// 返写文件MAC（预付费缴费时返回）
        /// </summary>
        public string dfFile82Mac { get; set; }

        /// <summary>
        /// 钱包文件MAC（预付费缴费时返回）
        /// </summary>
        public string dfFile83Mac { get; set; }

        /// <summary>
        /// 备用套电价文件Mac
        /// </summary>
        public string dfFile84Mac { get; set; }

        /// <summary>
        /// [国网]返写文件mac
        /// </summary>
        public string dfFile85Mac { get; set; }

        /// <summary>
        /// 下行自定义回写文件MAC（预付费缴费时返回）
        /// </summary>
        public string dfFile86Mac { get; set; }

        /// <summary>
        /// 下行参数设置文件MAC（预付费缴费时返回）
        /// </summary>
        public string dfFile88Mac { get; set; }
    }
}
