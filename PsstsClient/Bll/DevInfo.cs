using System;

namespace PsstsClient.Bll
{
    public class DevInfo
    {
        /// <summary>
        /// 获取或设置终端IP
        /// </summary>
        public static string LocalIP { get; set; }

        /// <summary>
        /// 获取或终端MAC地址
        /// </summary>
        public static string LocalMac { get; set; }

        /// <summary>
        /// 打印机串口
        /// </summary>
        public static int PrinterPort { get; set; }

        /// <summary>
        /// 打印机波特率
        /// </summary>
        public static long PrinterBaud { get; set; }

        /// <summary>
        /// cashcodePort
        /// </summary>
        public static int CashcodePort { get; set; }

        /// <summary>
        /// 纸币识别器波特率
        /// </summary>
        public static long CashcodeBaud { get; set; }

        /// <summary>
        /// 银行卡读卡器串口
        /// </summary>
        public static int CardReaderPort { get; set; }

        /// <summary>
        /// 银行卡读卡器波特率
        /// </summary>
        public static long CardReaderBaud { get; set; }

        /// <summary>
        /// 金属加密键盘串口
        /// </summary>
        public static int MetalKeyboardPort { get; set; }

        /// <summary>
        /// 金属加密键盘波特率
        /// </summary>
        public static int MetalKeyboardBaud { get; set; }

        /// <summary>
        /// IC读卡器串口
        /// </summary>
        public static int ICReaderPort { get; set; }

        /// <summary>
        /// IC读卡器波特率
        /// </summary>
        public static int ICReaderBaud { get; set; }

        /// <summary>
        /// IC卡读卡器厂商
        /// </summary>
        public static string ICDevVendor { get; set; }

        public static int IcReaderPsam { get; set; }

        /// <summary>
        /// 打印机是否启动 0启动 其他不启动
        /// </summary>
        public static int PrinterEnable { get; set; }

        /// <summary>
        /// 纸币识别器是否启动 0启动 其他不启动
        /// </summary>
        public static int CashcodeEnable { get; set; }

        /// <summary>
        /// 银行卡读卡器是否启动 0启动 其他不启动
        /// </summary>
        public static int CardReaderEnable { get; set; }

        /// <summary>
        /// IC卡读卡器是否启动 0启动 其他不启动
        /// </summary>
        public static int ICReaderEnable { get; set; }

        /// <summary>
        /// 密码键盘是否启动 0启动 其他不启动
        /// </summary>
        public static int MetalKeyboardEnable { get; set; }

        /// <summary>
        /// socket通讯包头中的szVerify 验证信息
        /// </summary>
        public static string szVerify { get; set; }

        /// <summary>
        /// socket通讯包头中的szBossCode验证信息
        /// </summary>
        public static string szBossCode { get; set; }

        /// <summary>
        /// 超时返回时间
        /// </summary>
        public static int returntime { get; set; }
    }
}