using PsstsClient.Bll;
using PsstsClient.Utility;
using System;

namespace PsstsClient.Driver
{
    public class DriverCommon
    {
        /// <summary>
        /// 热敏打印机
        /// </summary>
        public static bool Printer { get; set; }

        /// <summary>
        /// 热敏打印机驱动
        /// </summary>
        public static ThermalPrinterDriver PrinterDriver { get; set; }

        /// <summary>
        /// 银行卡读卡器
        /// </summary>
        public static bool CardReader { get; set; }

        /// <summary>
        /// 银行卡读卡器驱动
        /// </summary>
        public static CardReaderDriver CardReaderDriver { get; set; }

        /// <summary>
        /// 纸币识别器
        /// </summary>
        private static bool cashcode;
        public static Boolean CashCode
        {
            get { return cashcode; }
            set { cashcode = value; }
        }

        /// <summary>
        /// 纸币识别器驱动
        /// </summary>
        public static CashCodeDriver CashCodeDriver { get; set; }

        /// <summary>
        /// 密码键盘是否打开true 打开
        /// </summary>
        public static bool MetalKeyboard { get; set; }

        /// <summary>
        /// 密码键盘驱动
        /// </summary>
        public static MetalKeyDriver MetalKeyboardDriver { get; set; }

        /// <summary>
        /// IC卡读卡器
        /// </summary>
        public static bool ICReader { get; set; }

        static ICReaderDriver _icReaderDriver = null;

        /// <summary>
        /// IC卡读卡器驱动
        /// </summary>
        public static ICReaderDriver ICReaderDriver
        {
            get
            {
                if (_icReaderDriver == null)
                {
                    _icReaderDriver = new ICReaderDriver(DevInfo.ICReaderPort);
                    ICReader = true;
                }
                return _icReaderDriver;
            }
        }


        /// <summary>
        /// 设备驱动调用前准备
        /// </summary>
        public static void DriverInit()
        {
            ICReader = false;
            CardReader = false;
            CashCode = false;
            MetalKeyboard = false;
            Printer = false;
        }

        /// <summary>
        /// 设备驱动初始化
        /// </summary>
        public static void DriverCreate()
        {
            try
            {
                /*if (!CardReader && DevInfo.CardReaderEnable == DevStatic.devEnable)
            {
                CardReaderDriver = new CardReaderDriver(DevInfo.CardReaderPort, DevInfo.CardReaderBaud);
            }*/
                if (!MetalKeyboard && DevInfo.MetalKeyboardEnable == DevStatic.devEnable)
                {
                    MetalKeyboardDriver = new MetalKeyDriver(DevInfo.MetalKeyboardPort, DevInfo.MetalKeyboardBaud);
                }
                if (!CashCode && DevInfo.CashcodeEnable == DevStatic.devEnable)
                {
                    CashCodeDriver = new CashCodeDriver(DevInfo.CashcodePort, DevInfo.CashcodeBaud);
                }
                if (!Printer && DevInfo.PrinterEnable == DevStatic.devEnable)
                {
                    PrinterDriver = new ThermalPrinterDriver(DevInfo.PrinterPort, DevInfo.PrinterBaud);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("初始化设备异常", ex);
            }            
        }

        /// <summary>
        /// 纸币器
        /// </summary>
        public static void CashcodeDriverCreate()
        {
            try
            {
                if (!CashCode && DevInfo.CashcodeEnable == DevStatic.devEnable)
                {
                    CashCodeDriver = new CashCodeDriver(DevInfo.CashcodePort, DevInfo.CashcodeBaud);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// 凭条打印机
        /// </summary>
        public static void PrinterDriverCreate()
        {
            try
            {
                if (!Printer && DevInfo.PrinterEnable == DevStatic.devEnable)
                {
                    PrinterDriver = new ThermalPrinterDriver(DevInfo.PrinterPort, DevInfo.PrinterBaud);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }
        public static void CashcodeDriverClose()
        {
            try
            {
                if (CashCode)
                {
                    CashCodeDriver.DICClose();
                    CashCodeDriver = null;
                    //CashCode = false;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("Errors", "关闭纸币器失败", "[" + ex + "]");
            }
        }

        public static void PrinterDriverClose()
        {
            try
            {
                if (Printer)
                {
                    PrinterDriver.DICClose();
                    PrinterDriver = null;
                    // Printer = false;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }

        public static void DriverClose()
        {
            try
            {
                if (Printer)
                {
                    try
                    {
                        PrinterDriver.DICClose();
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }
                    PrinterDriver = null;
                    Printer = false;
                }
                if (CashCode)
                {
                    try
                    {
                        CashCodeDriver.StopIdentify();
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }
                    try
                    {
                        CashCodeDriver.DICClose();
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }
                    CashCodeDriver = null;
                    CashCode = false;
                }
                if (MetalKeyboard)
                {
                    try
                    {
                        MetalKeyboardDriver.StopKeyListen();
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }
                    try
                    {
                        MetalKeyboardDriver.KeyboardSwitch(0);
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }
                    try
                    {
                        MetalKeyboardDriver.DICClose();
                    }
                    catch (Exception ex)
                    {
                        Log4NetHelper.Instance.Error(ex.Message, ex);
                    }

                    MetalKeyboardDriver = null;
                    MetalKeyboard = false;
                }

                if (ICReader)
                {
                    _icReaderDriver.DICClose();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }
    }
}