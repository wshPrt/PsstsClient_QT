namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 购电补写服务接口返回值
    /// </summary>
    public class R_WriteUP
    {
        /// <summary>
        /// 16个字符随机数用于系统认证
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
        /// 国网卡使用
        /// </summary>
        public string k3 { get; set; }

        /// <summary>
        /// 国网卡使用
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
        /// 
        /// </summary>
        public string dfFile82 { get; set; }

        /// <summary>
        /// 钱包文件
        /// </summary>
        public string dfFile83 { get; set; }

        /// <summary>
        /// [国网]第二套费率文件，水投留空
        /// </summary>
        public string dfFile84 { get; set; }

        /// <summary>
        /// 预留文件
        /// </summary>
        public string dfFile85 { get; set; }

        /// <summary>
        /// 下行自定义回写文件
        /// </summary>
        public string dfFile86 { get; set; }

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
        /// 备用套电价文件MAC
        /// </summary>
        public string dfFile84Mac { get; set; }

        public string dfFile85Mac { get; set; }

        /// <summary>
        /// 下行自定义回写文件MAC
        /// </summary>
        public string dfFile86Mac { get; set; }

        /// <summary>
        /// 下行参数设置文件MAC
        /// </summary>
        public string dfFile88Mac { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string serialNo { get; set; }
    }
}
