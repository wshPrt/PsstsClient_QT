using System;
using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class CardReaderAPI
    {
        const string CRT_310_DLL_Path = @"ImportDLL\CRT_310.dll";

        /// <summary>
        /// 打开串口
        /// </summary>
        [DllImport(CRT_310_DLL_Path)]
        public static extern IntPtr CommOpen(string Port);

        /// <summary>
        /// 打开串口
        /// </summary>
        [DllImport(CRT_310_DLL_Path)]
        public static extern IntPtr CommOpenWithBaut(string Port, int Baud);

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int CommClose(IntPtr ComHandle);


        [DllImport(CRT_310_DLL_Path)]
        public static extern int CommSetting(IntPtr ComHandle, string ComSeting);

        /// <summary>
        /// 设备复位
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Eject"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int CRT310_Reset(IntPtr ComHandle, byte _Eject);

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_atPosition"></param>
        /// <param name="_frontSetting"></param>
        /// <param name="_rearSetting"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int CRT310_GetStatus(IntPtr ComHandle, ref byte _atPosition, ref byte _frontSetting, ref byte _rearSetting);

        /// <summary>
        /// 允许插卡
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_CardIn"></param>
        /// <param name="_EnableBackIn"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int CRT310_CardSetting(IntPtr ComHandle, byte _CardIn, byte _EnableBackIn);

        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_mode"></param>
        /// <param name="_track"></param>
        /// <param name="_BlockData"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int MC_ReadTrack(IntPtr ComHandle, byte _mode, byte _track, byte[] _BlockData);

        /// <summary>
        /// 吐卡CT
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DLL_Path)]
        public static extern int CRT310_MovePosition(IntPtr ComHandle, byte Position);
    }
}
