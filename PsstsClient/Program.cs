using PsstsClient.Bll;
using PsstsClient.Driver;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsstsClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("程序已经运行在运行，该程序只允许有一个实例", "程序启动失败");
                return;
            }

            Rectangle rect = Screen.PrimaryScreen.Bounds;
            ScreenInfo.ScreenWidth = rect.Width;//屏幕宽
            ScreenInfo.ScreenHeight = rect.Height;//屏幕高 
            //设置分辨率，正式使用注释下面两句
            ScreenInfo.ScreenWidth = 1024;//屏幕宽
            ScreenInfo.ScreenHeight = 768;//屏幕高
            //////设置屏幕分辨率 
            SystemAPI.DEVMODE dm = new SystemAPI.DEVMODE();
            SystemAPI.EnumDisplaySettings(null, 0, ref dm);
            dm.dmSize = (short)Marshal.SizeOf(typeof(SystemAPI.DEVMODE));
            dm.dmPelsWidth = ScreenInfo.ScreenWidth;//屏幕宽
            dm.dmPelsHeight = ScreenInfo.ScreenHeight;//屏幕高
            dm.dmBitsPerPel = 32;//颜色象素
                                 //设置桌面分辨率，不使用
                                 // int RetVal = SystemAPI.ChangeDisplaySettings(ref dm, 0);
                                 // ScreenInfo.ScreenWidth = ScreenInfo.ScreenWidth - 2;//屏幕宽
                                 //ScreenInfo.ScreenHeight = ScreenInfo.ScreenHeight - 2;//屏幕高
                                 //加载读取配置
            Global.LoadConfig();

            Common.WriteLogStr("System", "系统启动", "IP[" + DevInfo.LocalIP + "]MAC[" + DevInfo.LocalMac + "]");

            //设备初始化
            DriverCommon.DriverInit();
            //DriverCommon.DriverCreate();

            //SystemAPI.HideTask(true);

            try
            {
                //处理未捕获的异常  
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常  
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常  
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
                
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("未处理异常", ex);
                //frmBug f = new frmBug(str);//友好提示界面
                //f.ShowDialog();
                MessageBox.Show("发生致命错误，请联系柜台处理！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception as Exception;

            Log4NetHelper.Instance.Error("未处理异常", error);
            MessageBox.Show("发生致命错误，请联系柜台处理！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            Log4NetHelper.Instance.Error("未处理异常", error);
            MessageBox.Show("发生致命错误，请联系柜台处理！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
