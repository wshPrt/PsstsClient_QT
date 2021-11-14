using System;
using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class ICReaderAPI
    {
        const string Mwic_32_DLL_Path = @"ImportDLL\Mwic_32.dll";
        const string DicICReader_DLL_Path = @"ImportDLL\DicICReader.dll";

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <param name="port">串口</param>
        /// <param name="baud">波特率</param>
        /// <returns></returns>
        [DllImport(Mwic_32_DLL_Path)]
        public static extern int ic_init(int port, long baud);

        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="hDev">设备句柄</param>
        /// <param name="status">设备状态(返参)</param>
        /// <returns></returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "get_status", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern short get_status(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] state);

        /// <summary>
        /// 卡机进卡控制设置
        /// </summary>
        /// <param name="icdev">串口句柄</param>
        /// <param name="_CardIn">前端进卡设置：</param>
        /// =0x31 不允许；
		///	=0x32 磁卡方式（磁信号+开关同时有效）进卡使能, 只允许磁卡从前端开闸门进卡；
		///	=0x33 开关信号方式进卡使能，允许磁卡，IC 卡，M1 射频卡，双界面卡从前端开闸门进卡。
		///	=0x34 磁信号方式进卡使能, 针对薄磁卡等一些纸卡进卡；
        /// <param name="_EnableBackIn">是否允许后端进卡。 0x30=允许；0x31=不允许</param>
        /// <returns>成功返回0，失败返回-1</returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "crt_card_setting", CallingConvention = CallingConvention.StdCall)]
        public static extern int crt_card_setting(int icdev, byte _CardIn, byte _EnableBackIn);

        /// <summary>
        /// 走卡位置设置
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="_position">=0x2E 将卡重新走位到卡机内位置,操作成功后可进行 M1 射频卡操作。
		///		=0x2F 将卡重新走位到卡机内位置，并将 IC 卡触点落下，操作成功后可进行接触式 IC 卡操作。
		///		=0x30 将卡重新走位到前端位置，不持卡。
		///		=0x31 将卡重新走位到前端位置，并持卡。
		///		=0x32 将卡重新走位到后端位置，并持卡。
		///		=0x33 将卡重新走位后端位置，不持卡。
		///		=0x34 将异常长度卡（短卡，长卡）清出卡机内，将卡向后端弹卡，对于短卡还需人工在卡口插正常卡辅助操作.
		///		=0x37 启动清洁卡操作</param>
        /// <returns>成功返回0，失败返回-1</returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "crt_moveposition", CallingConvention = CallingConvention.StdCall)]
        public static extern int crt_moveposition(int icdev, byte _position);

        /// <summary>
        /// 应用程序在操作接触式 IC 卡之前，需调用此函数给卡片上电
        /// </summary>
        /// <param name="icdev">串口句柄</param>
        /// <returns>成功返回0，失败返回-1</returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "crt_cardopen", CallingConvention = CallingConvention.StdCall)]
        public static extern int crt_cardopen(int icdev);

        /// <summary>
        /// 应用程序在操作完接触式 IC 后，在用户拔出卡片之前，需调用此函数以给卡片下电
        /// </summary>
        /// <param name="icdev">串口句柄</param>
        /// <returns>成功返回0，失败返回-1</returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "crt_cardclose", CallingConvention = CallingConvention.StdCall)]
        public static extern int crt_cardclose(int icdev);

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="hDev">设备句柄</param>
        /// <returns></returns>
        [DllImport(Mwic_32_DLL_Path)]
        public static extern int ic_exit(int hDev);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>

        [DllImport(Mwic_32_DLL_Path, CallingConvention = CallingConvention.StdCall)]
        public static extern int srd_24c02(int icdev, int offset, int len, IntPtr buffer);


        /// <summary>
        /// IC卡复位
        /// </summary>
        /// <param name="hDev">设备句柄</param>
        /// <param name="data_buffer">卡序列号</param>
        /// <returns></returns>
        [DllImport(Mwic_32_DLL_Path)]
        public static extern int cpu_reset(int hDev, ref string data_buffer);

        /// <summary>
        /// 检测卡片类型
        /// </summary>
        /// <param name="hDev">设备句柄</param>
        /// <returns>卡片类型</returns>
        [DllImport(Mwic_32_DLL_Path, EntryPoint = "chk_card", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern short chk_card(int icdev);

        /// <summary>
        /// 卡类型威胜国网自管户
        /// </summary>
        public const int cardtype_ws = 991;


        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <param name="port">串口</param>
        /// <param name="baud">波特率</param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path, EntryPoint = "DICOpenPort", CallingConvention = CallingConvention.StdCall)]
        public static extern int DICOpenPort(int port, int baud);

        /// <summary>
        /// 获取卡类型，是cpu卡则返回99，否则看具体
        /// </summary>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path, EntryPoint = "CheckCard", CallingConvention = CallingConvention.StdCall)]
        public static extern int CheckCard();

        /// <summary>
        /// 金属键盘打开串口
        /// </summary>
        /// <param name="port">串口</param>
        /// <param name="baud">波特率</param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern bool MKBOpenPort(int Port, int BaudRate);

        /// <summary>
        /// 关闭金属键盘
        /// </summary>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern bool MKBClosePort();

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern bool DICClose();
        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern int DICGetStatus();
        /// <summary>
        /// 读卡方法1为威胜国网自管户的卡，2直接读取24出卡信息
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern bool ReadCard(int ct);

        /// <summary>
        /// 获取卡数据
        /// </summary>
        /// <param name="Index">序号0~8</param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern IntPtr GetCardData(int Index);

        /// <summary>
        /// 获取AT24C02卡数据2016818
        /// </summary>     
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern IntPtr AT24C02ReadFile();

        /// <summary>
        /// 获取卡类型，正泰还是威胜的国网自管户
        /// </summary>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern IntPtr DICGetCardType();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="ErrorCode">错误代码</param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern IntPtr DICGetErrorMsg(long ErrorCode);


        /// <summary>
        /// 明华卡机带psam 的写卡方法，自助终端屏蔽不用
        /// </summary>
        /// <param name="psamsite">卡机psam座</param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="f4"></param>
        /// <param name="f5"></param>
        /// <param name="f6"></param>
        /// <param name="f7"></param>
        /// <returns></returns>
        //[DllImport(DicICReader_DLL_Path)]
        //public static extern bool WSWriteCard(int psamsite, string f1, string f2, string f3, string f4, string f5, string f6, string f7);

        /// <summary>
        /// 自助终端写卡方法,要提前打开金属键盘串口，用完要关闭金属键盘
        /// </summary>
        /// <param name="psamsite">金属加密键盘里面放psam 的卡座</param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="f4"></param>
        /// <param name="f5"></param>
        /// <param name="f6"></param>
        /// <param name="f7"></param>
        /// <returns></returns>
        [DllImport(DicICReader_DLL_Path)]
        public static extern bool CWSWriteCard(int psamsite, string f1, string f2, string f3, string f4, string f5, string f6, string f7);
        /// <summary>
        /// 正泰写卡，其实只是写24c02卡，现在直接调用明华读卡器的驱动，所以屏蔽
        /// </summary>
        /// <param name="f1"></param>
        /// <returns></returns>
        //[DllImport(DicICReader_DLL_Path)]
        //public static extern bool ZTWriteCard(string f1);

        [DllImport(DicICReader_DLL_Path)]
        public static extern int ICSetType(int ISeat,byte UcType);

        [DllImport(DicICReader_DLL_Path)]
        public static extern int ICPowerOn(byte[] UcReData);


        /// <summary>
        /// 正泰的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        //public static string Crc24C02(string s)
        //{
        //    int i, j, CRC1, CRC2, Count, DataLen, XorVal;
        //    int[] arrdata;
        //    string tmpStr;
        //    DataLen = s.Length / 2;
        //    arrdata = new int[DataLen];
        //    for (i = 0; i < DataLen; i++)
        //    {
        //        arrdata[i] = Convert.ToInt32(s.Substring(2 * i, 2), 16);
        //    }
        //    Count = DataLen / 16;
        //    for (j = 0; j < Count; j++)
        //    {
        //        XorVal = arrdata[0x0C + j * 16] ^ arrdata[0x0D + j * 16];
        //        for (i = 0 + j * 16; i < 0x0B + j * 16; i++)
        //        {
        //            arrdata[i] = arrdata[i] ^ XorVal;
        //        }
        //        CRC1 = 0;
        //        CRC2 = 0;
        //        for (i = 0 + j * 16; i < 0x0D + j * 16; i++)
        //        {
        //            CRC1 = CRC1 ^ arrdata[i];
        //            CRC2 = CRC2 + arrdata[i];
        //        }
        //        arrdata[0x0E + j * 16] = CRC1;
        //        CRC2 = (CRC2 + CRC1) % 256;
        //        arrdata[0x0F + j * 16] = CRC2;
        //    }

        //    tmpStr = "";
        //    for (i = 0; i < DataLen; i++)
        //    {
        //        tmpStr = tmpStr + Convert.ToString(arrdata[i], 16);
        //    }

        //    return tmpStr;
        //}
    }
}
