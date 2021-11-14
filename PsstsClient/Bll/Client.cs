using System.Windows.Forms;

namespace PsstsClient.Bll
{
    public class Client
    {
        public static string ClientServiceUri { get; set; }

        /// <summary>
        /// 非卡表购电业务
        /// </summary>
        public const string nflow = "pay_n";

        /// <summary>
        /// 卡表购电业务
        /// </summary>
        public const string icflow = "pay_ic";

        /// <summary>
        /// 查询信息业务
        /// </summary>
        public const string queryflow = "query_info";

        /// <summary>
        /// 获取或设置当前业务类型
        /// </summary>
        public static string FlowType { get; set; }

        /// <summary>
        /// 支付方式：银联或现金
        /// </summary>
        public static string Payment { get; set; }

        /// <summary>
        /// 获取或设置识别的纸币类型
        /// </summary>
        public static int Billtype { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        public static string MachineCode { get; set; }

        /// <summary>
        /// 终端程序启动目录
        /// </summary>
        public static string AppPath = Application.StartupPath;

        /// <summary>
        /// 打印模板路径
        /// </summary>
        public static string TemplatePath = "/PrintModel/";

        /// <summary>
        /// 后付费用户缴费模板
        /// </summary>
        public static string PayingTemplateName = "paying.txt";

        /// <summary>
        /// 管理登录密码
        /// </summary>
        public static string SystemPwd = "";

        /// <summary>
        /// 机构编码
        /// </summary>
        public static string JGBM { get; set; }

        public static int UpdateAppTime { get; set; }

        public static string Softversion { get; set; }

        public static bool SoftCanUpdate = true;

        public static string Updatesoftname { get; set; }

        public static string thisVersion = "1.0";

        public static string HttpServerUrl { get; set; }
    }
}
