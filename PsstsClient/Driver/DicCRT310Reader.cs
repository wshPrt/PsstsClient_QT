using System;
using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class DicCRT310Reader
    {
        const string DicCRT310DLLPath = @"ImportDLL\DicCRT310Reader.dll";

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, EntryPoint = "DICOpenPort", CallingConvention = CallingConvention.StdCall)]
#pragma warning disable CA1401 // P/Invokes should not be visible
        public static extern bool DICOpenPort(int port);
#pragma warning restore CA1401 // P/Invokes should not be visible

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool DICClose();

        /// <summary>
        /// 获取读卡器卡槽状态（-1=读卡器异常、1=机内无卡、2=在非持卡位置有卡或卡长度异常、3=机内有卡且IC触电已下落）
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int DICGetStatus();

        /// <summary>
        /// 允许插卡
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Entry();

        /// <summary>
        /// 不允许插卡
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool DisEntry();

        /// <summary>
        /// 移卡
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool MovePosition();

        /// <summary>
        /// 吞卡，成功TRUE，失败FALSE
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Swallow();

        /// <summary>
        /// 吐卡，成功TRUE，失败FALSE
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Eject();

        /// <summary>
        /// 复位读卡器，成功返回0，失败返回-1
        /// </summary>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool DICResetDev();

        /// <summary>
        /// 水投读卡
        /// </summary>
        /// <param name="rcData"></param>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        //public static extern bool DICReadCard(ref lpstruReadCardData rcData);
        public static extern bool DICReadCard(ref lpstruReadCardData rcData);

        /// <summary>
        /// 水投写卡
        /// </summary>
        /// <param name="wcData"></param>
        /// <returns></returns>
        [DllImport(DicCRT310DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern bool DICWriteCard(ref lpstruWriteCardData wcData);

        /// <summary>
        /// 写卡参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct lpstruWriteCardData
        {
            /// <summary>
            /// 表号
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
            public string ammt;

            /// <summary>
            /// 卡类型
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string cardType;

            /// <summary>
            /// 基本文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string mfFile82;

            /// <summary>
            /// 下行购电文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile81;

            /// <summary>
            /// 反写文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile82;

            /// <summary>
            /// 钱包文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile83;

            /// <summary>
            /// [国网]第二套费率文件，水投留空
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile84;

            /// <summary>
            /// [水投]预留，[国网]返写文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile85;

            /// <summary>
            /// 下行自定义文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile86;

            /// <summary>
            /// 下行参数设置文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile88;

            /// <summary>
            /// 16个字符随机数
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string tRandom;

            /// <summary>
            /// 密文用于系统认证
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string k1;

            /// <summary>
            /// 密文用于外部认证
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string k2;

            /// <summary>
            /// [国网]外部认证
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string k3;

            /// <summary>
            /// [国网]外部认证
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string k4;

            /// <summary>
            /// 基本文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string mfFile82Mac;

            /// <summary>
            /// 下行购电文件Mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile81Mac;

            /// <summary>
            /// 反写文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile82Mac;

            /// <summary>
            /// 钱包文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile83Mac;

            /// <summary>
            /// [国网]第二套费率文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile84Mac;

            /// <summary>
            /// [国网]返写文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile85Mac;

            /// <summary>
            /// 下行自定义反写文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile86Mac;

            /// <summary>
            /// 下行参数设置文件mac
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile88Mac;
        }

        /// <summary>
        /// 读卡请求参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct lpstruReadCardData
        {
            /// <summary>
            /// 用户卡随机数
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string cardRandom;

            /// <summary>
            /// IC卡类型，ST表示水投，GW表示国网
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string cardType;

            /// <summary>
            /// 卡序列号
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string cardSnr;

            /// <summary>
            /// 电表基本文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string mfFile82;

            /// <summary>
            /// 下行购电文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile81;

            /// <summary>
            /// 反写文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile82;

            /// <summary>
            /// 钱包文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile83;

            /// <summary>
            /// [国网]第二套费率文件，水投留空
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile84;

            /// <summary>
            /// 预留文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFIle85;

            /// <summary>
            /// 下行自定义回写文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile86;

            /// <summary>
            /// 自定义信息反写文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string dfFile87;

            /// <summary>
            /// 下行参数设置文件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
            public string dfFile88;
        }
    }
}
