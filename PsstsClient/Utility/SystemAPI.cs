using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace PsstsClient.Utility
{
    public class SystemAPI
    {
        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string def, string filePath);

        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileInt(string section, string key, int def, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ChangeDisplaySettings([In]ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, int lparam);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        public static Point GetCursorPos()
        {
            Point point = new Point();
            GetCursorPos(ref point);
            return point;
        }
        /// <summary>
        /// 隐藏任务栏的操作
        /// </summary>
        /// <param name="isHide"></param>
        public static void HideTask(bool isHide)
        {
            try
            {
                IntPtr trayHwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
                IntPtr hStar = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Button", null);

                if (isHide)
                {
                    ShowWindow(trayHwnd, 0);
                    ShowWindow(hStar, 0);
                }
                else
                {
                    ShowWindow(trayHwnd, 1);
                    ShowWindow(hStar, 1);
                }
            }
            catch { }
        }

        //private const int SW_HIDE = 0;  //隐藏任务栏
        //private const int SW_RESTORE = 9;//显示任务栏
        //[DllImport("user32.dll")]
        //public static extern int ShowWindow(int hwnd, int nCmdShow);
        //[DllImport("user32.dll")]
        //public static extern int FindWindow(string lpClassName, string lpWindowName);
        ///// <summary>
        ///// 隐藏任务栏
        ///// </summary>
        //public static void hideTaskbar()
        //{
        //  ShowWindow(FindWindow("Shell_TrayWnd",null),SW_HIDE);

        //}
        ///// <summary>
        ///// 显示任务栏
        ///// </summary>
        //public static void showTaskbar()
        //{
        //    ShowWindow(FindWindow("Shell_TrayWnd", null), SW_RESTORE);

        //}
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SystemTime sysTime);
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SystemTime sysTime);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemTime sysTime);

        /// <summary>
        /// 设置系统时间，用于服务器时间与当前时间统一
        /// </summary>
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }
        //设置本地时间
        public static void SetLocalTimeByStr(string timestr)
        {
            SystemTime sysTime = new SystemTime();
            string SysTime = timestr.Trim();   //此步骤多余，为方便程序而用直接用timestr即可
            if (SysTime.Length < 14)
                return;
            sysTime.wYear = Convert.ToUInt16(SysTime.Substring(0, 4));
            sysTime.wMonth = Convert.ToUInt16(SysTime.Substring(4, 2));
            sysTime.wDay = Convert.ToUInt16(SysTime.Substring(6, 2));
            sysTime.wHour = Convert.ToUInt16(SysTime.Substring(8, 2));
            sysTime.wMinute = Convert.ToUInt16(SysTime.Substring(10, 2));
            sysTime.wSecond = Convert.ToUInt16(SysTime.Substring(12, 2));
            SetLocalTime(ref sysTime);
        }
    }
}
