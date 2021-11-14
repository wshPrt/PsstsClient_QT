namespace PsstsClient.Entity
{
    /// <summary>
    /// 读写卡数据实体
    /// </summary>
    public class CardInfoEntity
    {
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
        /// [国网]第二套费率文件，水投留空
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
