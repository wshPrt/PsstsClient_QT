namespace PsstsClient.Service.RecData
{
    public class R_Pay
    {
        /// <summary>
        /// 二维码地址
        /// </summary>
        public string qrCode { get; set; }

        /// <summary>
        /// 写卡数据
        /// </summary>
        public string icCardEncipheredData { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string serialNo { get; set; }

        /// <summary>
        /// 0：失败 1：成功  2：处理中
        /// </summary>
        public string status { get; set; }
    }

    /// <summary>
    /// 写卡数据实体定义
    /// </summary>
    public class ICCardEncipheredData
    {
        /// <summary>
        /// 16个字符随机数用于系统认证(预付费缴费时返回)
        /// </summary>
        public string tRandom { get; set; }

        /// <summary>
        /// 密文用于系统认证
        /// </summary>
        public string k1 { get; set; }

        /// <summary>
        /// 密文用于外部认证
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
        /// 自定义信息返写文件
        /// </summary>
        public string dfFile87 { get; set; }

        /// <summary>
        /// 下行参数设置文件
        /// </summary>
        public string dfFile88 { get; set; }

        /// <summary>
        /// 基本文件MAC
        /// </summary>
        public string mfFile82Mac { get; set; }

        /// <summary>
        /// 下行购电文件MAC
        /// </summary>
        public string dfFile81Mac { get; set; }

        /// <summary>
        /// 返写文件MAC
        /// </summary>
        public string dfFile82Mac { get; set; }

        /// <summary>
        /// 钱包文件MAC
        /// </summary>
        public string dfFile83Mac { get; set; }

        /// <summary>
        /// 备用套电价文件MAC，国网卡使用
        /// </summary>
        public string dfFile84Mac { get; set; }

        /// <summary>
        /// [国网]返写文件mac
        /// </summary>
        public string dfFile85Mac { get; set; }

        /// <summary>
        /// 下行自定义回写文件MAC
        /// </summary>
        public string dfFile86Mac { get; set; }

        /// <summary>
        /// 下行参数设置文件MAC
        /// </summary>
        public string dfFile88Mac { get; set; }
    }
}
