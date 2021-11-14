using PsstsClient.Bll;
using PsstsClient.Driver;
using System;
using System.Text;
using System.Threading;

namespace PsstsClient.Utility
{
    public class DevStatic
    {
        /// <summary>
        /// 标志着设备是启用的1
        /// </summary>
        public static int devEnable = 1;
        /// <summary>
        /// 是否自检设备状态，只有在主界面的时候才监测
        /// </summary>
        public static bool AutoCheck = false;
        /// <summary>
        /// 设状态XX 打开串口失败
        /// </summary>
        public static string DevStaticXX = "-1";
        /// <summary>
        ///纸币识别器代码
        /// </summary>
        public static string CashCode = "01";
        /// <summary>
        /// 纸币识别器正常状态00
        /// </summary>
        public static string CashCodeStatic00 = "00";
        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long CashCodeLastCheckTime = 0;
        /// <summary>
        /// 纸币识别状态显示信息
        /// </summary>
        public static string CashCodeStaticMsg = "";

        /// <summary>
        /// 凭条打印机代码
        /// </summary>
        public static string ThermalPrinter = "02";
        /// <summary>
        /// 凭条打印机正常状态代码
        /// </summary>
        public static string ThermalPrinterStatic00 = "00";
        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long ThermalPrinterLastCheckTime = 0;
        /// <summary>
        /// 凭条打印机状态信心
        /// </summary>
        public static string ThermalPrinterStaticMsg = "";

        /// <summary>
        /// 金属键盘代码
        /// </summary>
        public static string MetalKeyboard = "03";
        /// <summary>
        /// 金属键盘正常状态代码
        /// </summary>
        public static string MetalKeyboardStatic00 = "00";
        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long MetalKeyboardLastCheckTime = 0;
        /// <summary>
        /// 凭条打印机状态信心
        /// </summary>
        public static string MetalKeyboardStaticMsg = "";

        /// <summary>
        /// IC卡读卡器代码
        /// </summary>
        public static string ICReader = "04";
        /// <summary>
        /// IC卡读卡器正常状态代码
        /// </summary>
        public static string ICReaderStatic00 = "00";
        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long ICReaderLastCheckTime = 0;
        /// <summary>
        /// IC状态信心
        /// </summary>
        public static string ICReaderStaticMsg = "";

        /// <summary>
        /// 银行卡读卡器代码
        /// </summary>
        public static string CardReader = "05";
        /// <summary>
        /// 银行卡读卡器正常状态代码
        /// </summary>
        public static string CardReaderStatic00 = "00";
        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long CardReaderLastCheckTime = 0;
        /// <summary>
        /// 银行卡读卡器状态信心
        /// </summary>
        public static string CardReaderStaticMsg = "";

        /// <summary>
        /// 间隔5分钟检测一次
        /// </summary>
        public static int intervalMin = 1;

        /// <summary>
        /// 检测设备最后一次检测时间是否超过多少分钟
        /// </summary>
        /// <param name="devCode">设备代码</param>
        /// <returns></returns>
        ///      
        struct CheckDevinfo
        {
            public string devCode;
            public string checkType;
        }

        /// <summary>
        /// 自动检测设备状态类型0
        /// </summary>
        /// <param name="devCode">设备编码</param>
        /// <returns></returns>
        public static bool GetCheckIntervalMin(string devCode)
        {
            long newTime = DateTime.Now.Ticks;
            long intervalTime = newTime;
            if (CashCode.Equals(devCode))
            {   //纸币识别器
                intervalTime = (newTime - CashCodeLastCheckTime) / 600000000;
            }
            else if (ThermalPrinter.Equals(devCode))
            {
                //凭条打印机
                intervalTime = (newTime - ThermalPrinterLastCheckTime) / 600000000;
            }
            else if (MetalKeyboard.Equals(devCode))
            {
                //金属加密键盘
                intervalTime = (newTime - MetalKeyboardLastCheckTime) / 600000000;
            }
            else if (ICReader.Equals(devCode))
            {
                //IC卡读卡器
                intervalTime = (newTime - ICReaderLastCheckTime) / 600000000;
            }
            //else if (CardReader.Equals(devCode))
            //{
            //    //银行卡读卡器
            //    intervalTime = (newTime - CardReaderLastCheckTime) / 600000000;
            //}
            if (intervalTime >= intervalMin)
            {
                SetDevCheckTime(devCode);
                //用于程序在主界面空闲时定时监测设备
                CheckDevinfo cd = new CheckDevinfo();
                cd.devCode = devCode;
                cd.checkType = "0";
                DevCheck(cd);
                SetDevCheckTime(devCode);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 设置最后一次检测时间
        /// </summary>
        /// <param name="devCode">设备代码</param>
        private static void SetDevCheckTime(string devCode)
        {
            long newTime = DateTime.Now.Ticks;
            if (CashCode.Equals(devCode))
            {
                CashCodeLastCheckTime = newTime;
            }
            else if (ThermalPrinter.Equals(devCode))
            {
                ThermalPrinterLastCheckTime = newTime;
            }
            else if (MetalKeyboard.Equals(devCode))
            {
                MetalKeyboardLastCheckTime = newTime;
            }
            else if (ICReader.Equals(devCode))
            {
                ICReaderLastCheckTime = newTime;
            }
            else if (CardReader.Equals(devCode))
            {
                CardReaderLastCheckTime = newTime;
            }
        }

        /// <summary>
        /// 所有设备监测入口，监测设备状态并发送指令给服务器更新状态
        /// </summary>
        /// <param name="dv"></param>
        private static void DevCheck(object dv)
        {
            Thread.Sleep(1000);
            CheckDevinfo cd = (CheckDevinfo)dv;
            string devCode = cd.devCode;
            SetDevCheckTime(devCode);
            //string checkType = cd.checkType;
            string checkStatus = DevStaticXX;
            ////纸币识别器
            if (CashCode.Equals(devCode))
            {
                if (DevInfo.CashcodeEnable != devEnable)
                {
                    return;
                }
                checkStatus = CheckCashCodeStatus();

            }//凭条打印机
            else if (ThermalPrinter.Equals(devCode))
            {
                if (DevInfo.PrinterEnable != devEnable)
                {
                    return;
                }
                checkStatus = CheckPrinterStatus();

            }       ///////金属加密键盘
            else if (MetalKeyboard.Equals(devCode))
            {
                if (DevInfo.MetalKeyboardEnable != devEnable)
                {
                    return;
                }
                checkStatus = CheckMetalKeyBoardStatus();

            }   ///IC卡读卡器
            else if (ICReader.Equals(devCode))
            {
                if (DevInfo.ICReaderEnable != devEnable)
                {
                    return;
                }
                checkStatus = CheckICReaderStatus();

            }//银行卡读卡器
            //else if (CardReader.Equals(devCode))
            //{
            //    if (DevInfo.CardReaderEnable != devEnable)
            //    {
            //        return;
            //    }
            //    checkStatus = CheckCardReaderStatus();

            //}
            else
            {
                return;
            }

            SetDevCheckTime(devCode);
        }

        /// <summary>
        /// 检测各个设备可以手动checkType0为自动；1为手动
        /// </summary>
        /// <param name="devCode">设备代码</param>
        public static void DevCheck(string devCode, string checkType)
        {
            CheckDevinfo cd = new CheckDevinfo();
            cd.devCode = devCode;
            cd.checkType = checkType;
            DevCheck(cd);
        }

        /// <summary>
        /// IC卡读卡器的监测
        /// </summary>
        /// <returns></returns>
        private static string CheckICReaderStatus()
        {
            ICReaderStaticMsg = "";
            int status = -1;

            if (DriverCommon.ICReader)
            {
                try
                {
                    //再获取一次状态
                    status = DriverCommon.ICReaderDriver.DICGetStatus();

                    ICReaderStaticMsg = "IC读卡器状态[" + DriverCommon.ICReaderDriver.DICGetErrorMsg(status) + "]";
                }
                catch (Exception ex)
                {
                    Common.WriteLogStr("Error", "IC读卡器异常", ex.Message);
                }

                //如果获取状态是失败，那么则先关闭串口
                if (status != 0)
                {
                    DriverCommon.ICReader = false;
                    try
                    {
                        DriverCommon.ICReaderDriver.DICClose();
                    }
                    catch(Exception ex)
                    {
                        Log4NetHelper.Instance.Error("异常", ex);
                    }
                }
            }
            else
            {

                ICReaderStaticMsg = "IC卡读卡器[打开串口失败]";
                status = Convert.ToInt32(DevStaticXX);
            }

            Common.WriteLogStr("DevStatus", "检测IC卡读卡器", "IC卡读卡器状态[" + status + "]" + ICReaderStaticMsg);
            return status.ToString();
        }

        /// <summary>
        /// 纸币识别器监测
        /// </summary>
        /// <returns></returns>
        private static string CheckCashCodeStatus()
        {
            CashCodeStaticMsg = "";
            int status = -1;
            if (!DriverCommon.CashCode)
            {
                DriverCommon.CashCodeDriver = new CashCodeDriver(DevInfo.CashcodePort, DevInfo.CashcodeBaud);
            }
            if (DriverCommon.CashCode)
            {
                try
                {
                    status = DriverCommon.CashCodeDriver.DICGetStatus();

                    CashCodeStaticMsg = "纸币识别器状态[" + DriverCommon.CashCodeDriver.DICGetErrorMsg(status) + "]";
                }
                catch (Exception ex)
                {
                    Common.WriteLogStr("Error", "纸币识别器异常", ex.Message);
                }
                if (status != 0)
                {
                    DriverCommon.CashCode = false;
                    try
                    {
                        DriverCommon.CashCodeDriver.DICClose();
                    }
                    catch
                    { }
                }
            }
            else
            {
                CashCodeStaticMsg = "纸币识别器故障[打开串口失败]";
                status = Convert.ToInt32(DevStaticXX);
            }

            Common.WriteLogStr("DevStatus", "检测纸币识别器", "纸币识别器状态[" + status + "]" + CashCodeStaticMsg);
            return status.ToString();
        }

        /// <summary>
        /// 监测打印机
        /// </summary>
        /// <returns></returns>
        private static string CheckPrinterStatus()
        {
            ThermalPrinterStaticMsg = "";
            int status = -1;
            if (!DriverCommon.Printer)
            {
                DriverCommon.PrinterDriver = new ThermalPrinterDriver(DevInfo.PrinterPort, DevInfo.PrinterBaud);
            }
            if (DriverCommon.Printer)
            {
                try
                {
                    status = DriverCommon.PrinterDriver.DICGetStatus();

                    ThermalPrinterStaticMsg = "打印机状态[" + DriverCommon.PrinterDriver.DICGetErrorMsg(status) + "]";
                }
                catch (Exception ex)
                {
                    Common.WriteLogStr("Error", "监测打印机异常", ex.Message);
                }

                if (status != 0)
                {
                    DriverCommon.Printer = false;
                    try
                    {
                        DriverCommon.PrinterDriver.DICClose();
                    }
                    catch
                    { }
                }
            }
            else
            {
                ThermalPrinterStaticMsg = "打印机故障[打开串口失败]";
                status = Convert.ToInt32(DevStaticXX);
            }

            Common.WriteLogStr("DevStatus", "检测打印机", "打印机状态[" + status + "]" + ThermalPrinterStaticMsg);

            return status.ToString();
        }

        /// <summary>
        /// 监测金属键盘的
        /// </summary>
        /// <returns></returns>
        public static string CheckMetalKeyBoardStatus()
        {
            MetalKeyboardStaticMsg = "";
            int status = -99;
            if (!DriverCommon.MetalKeyboard)
            {
                DriverCommon.MetalKeyboardDriver = new MetalKeyDriver(DevInfo.MetalKeyboardPort, DevInfo.MetalKeyboardBaud);

            }
            if (DriverCommon.MetalKeyboard)
            {
                try
                {
                    status = DriverCommon.MetalKeyboardDriver.DICGetStatus();

                    MetalKeyboardStaticMsg = "金属键盘[" + DriverCommon.MetalKeyboardDriver.DICGetErrorMsg(status) + "]";
                }
                catch (Exception ex)
                {
                    Common.WriteLogStr("Error", "监测金属键盘异常", ex.Message);
                }

                if (status != 0)
                {
                    DriverCommon.MetalKeyboard = false;
                    try
                    {
                        DriverCommon.MetalKeyboardDriver.DICReset();
                    }
                    catch
                    { }
                    try
                    {
                        DriverCommon.MetalKeyboardDriver.DICClose();
                    }
                    catch
                    { }
                }
            }
            else
            {
                MetalKeyboardStaticMsg = "金属键盘故障[打开串口失败]";
                status = Convert.ToInt32(DevStaticXX);
            }
            Common.WriteLogStr("DevStatus", "检测金属键盘", "金属键盘状态[" + status + "]" + MetalKeyboardStaticMsg);

            return status.ToString();
        }

        /// <summary>
        /// 纸币代码转中文提示
        /// </summary>
        /// <returns></returns>
        public static string ShowBillMsg()
        {
            //面值数组
            int[] mz = new int[] { 100, 50, 20, 10, 5, 2, 1 };
            //   1元:1,2元:2,5元:4,10元:8,20元:16,50元:32,100元:64
            //面值对应的代码
            int[] mzdaima = new int[] { 64, 32, 16, 8, 4, 2, 1 };
            int bill = Client.Billtype;
            if (bill <= 0)
            {
                return "";
            }
            int tembill = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("本机只收：");
            int cst = 0;
            for (int i = 0; i < mzdaima.Length; i++)
            {
                tembill = tembill + mzdaima[i];
                if (tembill == bill)
                {
                    sb.Append(mz[i]).Append("元 ");
                    cst++;
                }
                else if (tembill > bill)
                {
                    tembill = tembill - mzdaima[i];
                }
                else
                {
                    sb.Append(mz[i]).Append("元 ");
                    cst++;

                }
            }
            if (cst == 0)
            {
                return "";
            }

            return sb.ToString();
        }
    }
}
