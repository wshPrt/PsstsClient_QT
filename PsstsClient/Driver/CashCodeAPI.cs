using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class CashCodeAPI
    {
        const string CashCodeDll_DLL = @"ImportDLL\CashCodeDll.dll";

        public static byte CASH_ADDR = 3;

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="iPortNumber">串口</param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL, CharSet = CharSet.Auto)]
        public static extern bool OpenPort(int iPortNumber);

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <param name="iPortNumber">端口号</param>
        /// <param name="iTo">时间超时值</param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL, CharSet = CharSet.Auto)]
        public static extern bool InitPort(int iPortNumber, int iTo);

        /// <summary>
        /// 重新初始化设备
        /// </summary>
        /// <param name="addr">设备句柄</param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL, CharSet = CharSet.Auto)]
        public static extern int ResetCMD(byte addr);

        /// <summary>
        /// 激活设备
        /// </summary>
        /// <param name="addr">设备句柄</param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL, CharSet = CharSet.Auto)]
        public static extern int PollCMD(byte addr, ref byte z1, ref byte z2);

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL, CharSet = CharSet.Auto)]
        public static extern void ClosePort();

        /// <summary>
        /// 纸币类型
        /// </summary>
        /// <param name="enBill"></param>
        /// <param name="escBill"></param>
        /// <param name="Addr"></param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL)]
        public static extern int CmdBillType(int enBill, int escBill, byte Addr);

        /// <summary>
        /// 设置安全等级
        /// </summary>
        /// <param name="wS">0</param>
        /// <param name="Addr">3</param>
        /// <returns></returns>
        [DllImport(CashCodeDll_DLL)]
        public static extern int CmdSetSecurity(int wS, byte Addr);

        public struct g_BillTable
        {

            public int iCashValue;//存储纸币面值
            public string sCountryCode;//存储国家名称
        }

        public struct _Cassete
        {
            public byte BillNumber;       //面值
            public byte BillType;         //币种
            public byte bEscrow;          //是否存在于暂存箱标志
            public byte Status;           //设备状态

        }

        /// <summary>
        /// 获得返回值
        /// </summary>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static string GetReturnMsg(int returnValue)
        {
            string Msg = "";
            switch (returnValue)
            {
                case 0:
                    Msg = "操作成功";
                    break;
                case -1:
                    Msg = "通讯超时";
                    break;
                case -2:
                    Msg = "SYN信号错误";
                    break;
                case -3:
                    Msg = "接收数据失败";
                    break;
                case -4:
                    Msg = "CRC错误";
                    break;
                case -5:
                    Msg = "设备无回应";
                    break;
                case -6:
                    Msg = "无效命令";
                    break;
                case -7:
                    Msg = "执行错误回应";
                    break;
                case -8:
                    Msg = "设备回应状态无效";
                    break;
                default:
                    Msg = "未知返回码[" + returnValue + "]";
                    break;
            }

            return Msg;
        }
    }
}
