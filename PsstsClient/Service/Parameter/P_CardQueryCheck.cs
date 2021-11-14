namespace PsstsClient.Service.Parameter
{
    /// <summary>
    /// 卡表预购电查询验证参数实体
    /// </summary>
    public class P_CardQueryCheck
    {
        /// <summary>
        /// 用户卡随机数(从卡内获取，必填)
        /// </summary>
        public string cardRandom { get; set; }

        /// <summary>
        /// IC卡类型，ST表示水投，GW表示国网(必填)
        /// </summary>
        public string cardType { get; set; }

        /// <summary>
        /// 卡序列号(必填)
        /// </summary>
        public string cardSnr { get; set; }

        /// <summary>
        /// 电表基本文件(必填)
        /// </summary>
        public string mfFile82 { get; set; }

        /// <summary>
        /// 下行购电文件(必填)
        /// </summary>
        public string dfFile81 { get; set; }

        /// <summary>
        /// 返写文件(必填)
        /// </summary>
        public string dfFile82 { get; set; }

        /// <summary>
        /// 钱包文件(必填)
        /// </summary>
        public string dfFile83 { get; set; }

        /// <summary>
        /// 国网：备用套电价文件；水头为空即可
        /// </summary>
        public string dfFile84 { get; set; }

        /// <summary>
        /// 预留文件(必填)
        /// </summary>
        public string dfFile85 { get; set; }

        /// <summary>
        /// 下行自定义回写文件(必填)
        /// </summary>
        public string dfFile86 { get; set; }

        /// <summary>
        /// 自定义信息返写文件(必填)
        /// </summary>
        public string dfFile87 { get; set; }

        /// <summary>
        /// 下行参数设置文件(必填)
        /// </summary>
        public string dfFile88 { get; set; }
    }
}
