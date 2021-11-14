namespace PsstsClient.Service.Parameter
{
    /// <summary>
    /// 购电补写服务接口参数
    /// </summary>
    public class P_WriteUP
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string serialNo { get; set; }

        /// <summary>
        /// ST标识水投卡，GW表示国网卡
        /// </summary>
        public string cardType { get; set; }

        /// <summary>
        /// 8字节卡片序列号，终端读卡获取
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
        /// 自定义信息返写文件
        /// </summary>
        public string dfFile87 { get; set; }

        /// <summary>
        /// 下行参数设置文件
        /// </summary>
        public string dfFile88 { get; set; }

        /// <summary>
        /// 用户卡随机数(从卡内获取)
        /// </summary>
        public string cardRandom { get; set; }

        /// <summary>
        /// 供电单位编号（可以为空）
        /// </summary>
        public string orgNo { get; set; }
    }
}
