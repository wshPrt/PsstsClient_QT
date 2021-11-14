using PsstsClient.Utility;
using System;

namespace PsstsClient.Driver
{
    public class ThermalPrinterDriver
    {
        public ThermalPrinterDriver(string data)
        {

        }

        public ThermalPrinterDriver(int port, long baud)
        {
            DICOpenPort(port, baud);
        }

        public string DICGetErrorMsg(int ErrorCode)
        {
            string strResult = "";
            switch (ErrorCode)
            {
                case 0:
                    strResult = "执行成功";
                    break;
                case 1:
                    strResult = "执行失败";
                    break;
                case 2:
                    strResult = "端口被其他设备打开";
                    break;
                case 3:
                    strResult = "设备没有被初始化";
                    break;
                case 4:
                    strResult = "设备缺纸";
                    break;
                case 5:
                    strResult = "设备忙";
                    break;
                case 6:
                    strResult = "设备忙";
                    break;
                default:
                    strResult = "未知返回码[" + ErrorCode + "]";
                    break;
            }

            return strResult;
        }

        //打开串口 
        public bool DICOpenPort(int port, long baud)
        {
            try
            {
                int iret = PrintAPI.GFS_CMD_OPEN(port, baud);
                if (iret != 0)
                {
                    DriverCommon.Printer = false;
                    Common.WriteLogStr("ThermalPrinter", "打开串口", "失败");
                    return false;
                }
                iret = PrintAPI.GFS_CMD_SCPPTR_INIT(0);
                if (iret != 0)
                {
                    DriverCommon.Printer = false;
                    Common.WriteLogStr("ThermalPrinter", "打开串口", "设备初始化失败");
                    PrintAPI.GFS_CMD_SCPPTR_CLOSE();
                    return false;
                }
                iret = PrintAPI.GFS_INF_SCPPTR_STATUS();
                if (iret == 0 || iret == 4)
                {

                    DriverCommon.Printer = true;
                    Common.WriteLogStr("ThermalPrinter", "打开串口", "成功");
                    return true;

                }
                //MessageBox.Show("凭条打印机："+iret);
                DriverCommon.Printer = false;
                Common.WriteLogStr("ThermalPrinter", "打开串口", "设备初始化失败");
                return false;
            }
            catch (Exception ex)
            {
                DriverCommon.Printer = false;
                Common.WriteLogStr("ThermalPrinter", "打开串口", "异常[" + ex.Message + "]");
                return false;
            }
        }

        //复位
        public bool DICReset()
        {
            try
            {
                int iret = PrintAPI.GFS_CMD_SCPPTR_INIT(0);
                if (iret == 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "设备复位", "成功");
                    return true;
                }
                else
                {
                    Common.WriteLogStr("ThermalPrinter", "设备复位", "失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "设备复位", "异常[" + ex.Message + "]");
                return false;
            }
        }


        /// <summary>
        /// 获取状态
        /// </summary>
        public int DICGetStatus()
        {
            try
            {
                int iret = PrintAPI.GFS_INF_SCPPTR_STATUS();
                Common.WriteLogStr("ThermalPrinter", "获取状态", DICGetErrorMsg(iret));
                return iret;

            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "获取状态", "异常[" + ex.Message + "]");
                return 1;
            }

        }

        //关闭串口
        public bool DICClose()
        {
            try
            {
                int iret = PrintAPI.GFS_CMD_SCPPTR_CLOSE();
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "关闭串口", "关闭串口失败");
                    return false;
                }
                Common.WriteLogStr("ThermalPrinter", "关闭串口", "关闭串口成功");
                DriverCommon.Printer = false;
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "关闭串口", "关闭串口异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 打印并走纸7行切纸
        /// </summary>
        /// <param name="printdate"></param>
        public bool PrintAndCutpaper(string PrintData)
        {
            try
            {
                int iret = PrintAPI.GFS_INF_SCPPTR_STATUS();
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "打印切纸", "获取状态异常[" + DICGetErrorMsg(iret) + "]");
                    return false;
                }
                iret = PrintAPI.GFS_CMD_SCPPTR_PRINT(2, PrintData);
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "打印切纸", "打印数据失败");
                    return false;
                }

                iret = PrintAPI.GFS_CMD_SCPPTR_PRINT(2, "\n\n\n\n\n\n\n");
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "打印切纸", "走纸7行失败");
                    return false;
                }

                iret = PrintAPI.GFS_CMD_SCPPTR_ENDDOC(0, 4);
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "打印切纸", "切纸失败");
                    return false;
                }

                Common.WriteLogStr("ThermalPrinter", "打印切纸", "打印完成");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "打印切纸", "打印异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="printdate"></param>
        public bool PrintNotCutpaper(string PrintData)
        {
            try
            {
                int iret = PrintAPI.GFS_CMD_SCPPTR_PRINT(2, PrintData);
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "打    印", "打印数据失败");
                    return false;
                }

                Common.WriteLogStr("ThermalPrinter", "打    印", "打印完成");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "打    印", "打印异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 切纸
        /// </summary>
        /// <returns></returns>
        public bool CutPaper()
        {
            try
            {
                int iret = PrintAPI.GFS_CMD_SCPPTR_ENDDOC(0, 4);
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "切    纸", "切纸失败");
                    return false;
                }

                Common.WriteLogStr("ThermalPrinter", "切    纸", "切纸成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "切    纸", "切纸异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 走纸N行
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool FeednLine(int n)
        {
            string printdata = "";
            for (int i = 0; i < n; i++)
                printdata += "\n";
            try
            {
                int iret = PrintAPI.GFS_CMD_SCPPTR_PRINT(2, printdata);
                if (iret != 0)
                {
                    Common.WriteLogStr("ThermalPrinter", "走    纸", "走纸" + n.ToString() + "行失败");
                    return false;
                }
                Common.WriteLogStr("ThermalPrinter", "走    纸", "走纸" + n.ToString() + "行成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("ThermalPrinter", "走    纸", "走纸" + n.ToString() + "行异常[" + ex.Message + "]");
                return false;
            }
        }
    }
}
