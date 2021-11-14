namespace PsstsClient.Bll
{
    public class BankInfo
    {
        /// <summary>
        /// 银联签到是否成功
        /// </summary>
        public static bool IsBankSign { get; set; }

        /// <summary>
        /// 银联交易中分配的终端编号
        /// </summary>
        public static string ClientId { get; set; }

        /// <summary>
        /// 银联交易中商务号
        /// </summary>
        public static string MerchantNo { get; set; }

        /// <summary>
        /// 银联tpdu
        /// </summary>
        public static string Tpdu { get; set; }

        /// <summary>
        /// tpdu中的源地址
        /// </summary>
        public static string Tpdu_src { get; set; }

        /// <summary>
        /// tpdu中的目的地址
        /// </summary>
        public static string Tpdu_des { get; set; }

        /// <summary>
        /// 报文头
        /// </summary>
        public static string Pack_head { get; set; }

        /// <summary>
        /// 主密钥号
        /// </summary>
        public static int MainKeyNo { get; set; }

        /// <summary>
        /// Pin密钥号
        /// </summary>
        public static int PinKeyNo { get; set; }

        /// <summary>
        /// Mac密钥号
        /// </summary>
        public static int MacKeyNo { get; set; }

        /// <summary>
        /// 银联IP
        /// </summary>
        public static string Bankip { get; set; }

        /// <summary>
        /// 银联端口
        /// </summary>
        public static int Bankport { get; set; }

        /// <summary>
        /// 使用单位/商户名称
        /// </summary>
        public static string Deptname { get; set; }

        /// <summary>
        /// 是否银联测试环境 配置1为测试，其他为正式
        /// </summary>
        public static bool Istest { get; set; }

        /// <summary>
        /// 主密钥值，测试模式istest  配置1为测试，时生效
        /// </summary>
        public static string Mainkey { get; set; }

        /// <summary>
        /// 银联通讯超时
        /// </summary>
        public static int Timeout { get; set; }
    }
}