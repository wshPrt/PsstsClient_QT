using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class PrintAPI
    {
        const string SCPPRINT_DLL_Path = @"ImportDLL\SCPPRINT.dll";

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="PortNo"></param>
        /// <param name="lpPrintData"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SCPPTR_OPEN(int PortNo, ref char lpPrintData);

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="PortNo"></param>
        /// <param name="bBaudRate"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto,CallingConvention = CallingConvention.ThisCall)]
        public static extern int GFS_CMD_OPEN(int PortNo, long bBaudRate);

        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SCPPTR_INIT(long n);

        /// <summary>
        /// 关闭打印机
        /// </summary>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SCPPTR_CLOSE();

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_INF_SCPPTR_STATUS();

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="ContentType"></param>
        /// <param name="lpPrintData"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path)]
        public static extern int GFS_CMD_SCPPTR_PRINT(int ContentType, string lpPrintData);

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="cbFontSize"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SET_FONTSIZE(int cbFontSize);

        /// <summary>
        /// 设置字体名称
        /// </summary>
        /// <param name="lpFontName"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SET_FONTNAME(string lpFontName);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SET_CHARSET(string lpCharSet);

        /// <summary>
        /// 切纸
        /// </summary>
        /// <param name="cbCutMode"></param>
        /// <param name="cbLines"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SCPPTR_ENDDOC(byte cbCutMode, byte cbLines);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_INF_SCPPTR_GETVER(string VersionInfo);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_PRINTER_NVBMP(long dwBmpIndex, long dwSize);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int SetBarCodeHeight(byte cbHeight);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern long SetBarCodeWidth(byte cbWidth);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int SetPrintPositionOfHRIChars(byte cbPos);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int SelectHRICharsFont(byte cbFont);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int PrintBarCode(byte cbBarCodeSystem, byte cbDataLength, ref byte cbCode);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_GOTOBLACKMARK();

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SETROWSPACE(long IRow);

        /// <summary>
        /// 设置边距
        /// </summary>
        /// <param name="nL"></param>
        /// <param name="nH"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SETLEFTSPACE(long nL, long nH);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SETEMPHASIZE(long n);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_SETFONTSPACE(long n);

        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_DOWNLOADBMP(ref char address);

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="address"></param>
        /// <param name="dwSize"></param>
        /// <returns></returns>
        [DllImport(SCPPRINT_DLL_Path, CharSet = CharSet.Auto)]
        public static extern int GFS_CMD_PRINTBMP(string address, long dwSize);



        //public static Boolean AutoPrint(String PrintData) 
        //{
        //    try
        //    {
        //        int iret = (int)PrintAPI.GFS_CMD_OPEN(Common.ReadIniInt("ClientParam.ini", "ThermalPrinter", "port"), long.Parse(Common.ReadIniStr("ClientParam.ini", "ThermalPrinter", "baud")));
        //        if (iret != 0)
        //        {
        //            return false;
        //        }

        //        iret = (int)PrintAPI.GFS_CMD_SCPPTR_INIT(0);
        //        if (iret != 0)
        //        {
        //            PrintAPI.GFS_CMD_SCPPTR_CLOSE();
        //            return false;
        //        }
        //        iret = (int)PrintAPI.GFS_CMD_SCPPTR_PRINT(2, PrintData);
        //        if (iret != 0)
        //        {
        //            PrintAPI.GFS_CMD_SCPPTR_CLOSE();
        //            return false;
        //        }

        //        iret = (int)PrintAPI.GFS_CMD_SCPPTR_PRINT(2, "\n\n\n\n");
        //        if (iret != 0)
        //        {
        //            PrintAPI.GFS_CMD_SCPPTR_CLOSE();
        //            return false;
        //        }

        //        PrintAPI.GFS_CMD_SCPPTR_ENDDOC(0,4);
        //        PrintAPI.GFS_CMD_SCPPTR_CLOSE();
        //        return true;
        //    }
        //    catch (Exception ex) 
        //    {
        //        return false;
        //    }
        //}
    }
}
