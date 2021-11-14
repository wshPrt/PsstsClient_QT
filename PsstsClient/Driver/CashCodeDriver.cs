using PsstsClient.Utility;
using System;
using System.Threading;

namespace PsstsClient.Driver
{
    public delegate void CashEvent(int money, string error);

    public class CashCodeDriver
    {
        private CashCodeAPI.g_BillTable[] tab = new CashCodeAPI.g_BillTable[24];
        private bool IsRunning = false;
        private Thread CashCheckThread;
        private byte z1 = 0;
        private byte z2 = 0;
        private CashEvent cashCodeEvent;

        public CashCodeDriver(int port, long baud)
        {
            tab[0].iCashValue = 1;
            tab[0].sCountryCode = "CHN";
            tab[1].iCashValue = 2;
            tab[0].sCountryCode = "CHN";
            tab[2].iCashValue = 5;
            tab[0].sCountryCode = "CHN";
            tab[3].iCashValue = 10;
            tab[0].sCountryCode = "CHN";
            tab[4].iCashValue = 20;
            tab[0].sCountryCode = "CHN";
            tab[5].iCashValue = 50;
            tab[0].sCountryCode = "CHN";
            tab[6].iCashValue = 100;
            tab[0].sCountryCode = "CHN";
            for (int i = 7; i < 23; i++)
            {
                tab[i].iCashValue = 0;
                tab[0].sCountryCode = "";
            }

            DICOpenPort(port, baud);
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="port"></param>
        /// <param name="baud"></param>
        /// <returns></returns>
        public bool DICOpenPort(int port, long baud)
        {
            try
            {
                if (!CashCodeAPI.OpenPort(port))
                {
                    DriverCommon.CashCode = false;
                    Common.WriteLogStr("CashCode", "打开串口", "失败");
                    return false;
                }

                if (!CashCodeAPI.InitPort(port, 300))//初始化串口
                {
                    CashCodeAPI.ClosePort();
                    DriverCommon.CashCode = false;
                    Common.WriteLogStr("CashCode", "打开串口", "初始化串口失败");
                    return false;
                }

                int iii = CashCodeAPI.PollCMD(CashCodeAPI.CASH_ADDR, ref z1, ref z2);//激活设备  
                if (iii != 0)
                {
                    DriverCommon.CashCode = false;
                    Common.WriteLogStr("CashCode", "激活设备失败", "成功" + iii);
                }
                if (z1 == 0x10)
                {
                    iii = CashCodeAPI.ResetCMD(CashCodeAPI.CASH_ADDR);//复位设备
                    if (iii != 0)
                    {
                        DriverCommon.CashCode = false;
                        Common.WriteLogStr("CashCode", "复位设备失败", "成功" + iii);
                    }
                }
                iii = CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                if (iii != 0)
                {
                    DriverCommon.CashCode = false;
                    Common.WriteLogStr("CashCode", "设置币种失败", "成功" + iii);
                    return false;
                }
                DriverCommon.CashCode = true;
                Common.WriteLogStr("CashCode", "打开串口", "成功" + iii);
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CashCode", "打开串口", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <returns></returns>
        public bool DICReset()
        {
            try
            {
                int IRet = CashCodeAPI.ResetCMD(CashCodeAPI.CASH_ADDR);
                if (IRet == 0)
                {
                    Common.WriteLogStr("CashCode", "复位设备", "成功");
                    return true;
                }
                Common.WriteLogStr("CashCode", "复位设备", "失败[" + DICGetErrorMsg(IRet) + "]");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CashCode", "复位设备", "异常[" + ex.Message + "]");
                return false;
            }

        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool DICClose()
        {
            try
            {
                IsRunning = false;
                CashCodeAPI.ClosePort();
                // DriverCommon.CashCode = false;
                Common.WriteLogStr("CashCode", "关闭串口", "成功");
                return true;

            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CashCode", "关闭串口", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 获取错误信息描述
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        public string DICGetErrorMsg(long ErrorCode)
        {
            string strResult;
            switch (ErrorCode)
            {
                case 1009:
                    strResult = "卡钞";
                    break;
                case 1008:
                    strResult = "钞箱满";
                    break;
                case 1007:
                    strResult = "钞箱异常";
                    break;
                case 1006:
                    strResult = "钞箱卡钞";
                    break;
                case 1005:
                    strResult = "纸币器未初始化";
                    break;
                case 0:
                    strResult = "纸币器正常";
                    break;
                case -1:
                    strResult = "通讯超时";
                    break;
                case -2:
                    strResult = "SYN信号错误";
                    break;
                case -3:
                    strResult = "接收数据失败";
                    break;
                case -4:
                    strResult = "CRC错误";
                    break;
                case -5:
                    strResult = "设备无回应";
                    break;
                case -6:
                    strResult = "无效命令";
                    break;
                case -7:
                    strResult = "执行错误回应";
                    break;
                case -8:
                    strResult = "设备回应状态无效";
                    break;
                default:
                    strResult = "未知错误代码[" + ErrorCode + "]";
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        public int DICGetStatus()
        {
            try
            {
                int iret = CashCodeAPI.PollCMD(CashCodeAPI.CASH_ADDR, ref z1, ref z2);
                if (iret != 0)
                {
                    return iret;
                }
                switch (z1)
                {
                    case 0x1B:	//设备忙
                    case 0x1C:
                    case 0x47:	//设备异常
                        iret = 1000;
                        break;
                    case 0x41:	//钞箱满
                        iret = 1008;
                        break;
                    case 0x42:	//钞箱不在
                        iret = 1007;
                        break;
                    case 0x43:
                    case 0x46:	//设备卡钞
                        iret = 1009;
                        break;
                    case 0x44:	//钞箱卡钞
                        iret = 1006;
                        break;
                    default:
                        iret = 0;
                        break;
                }
                if (iret != 0)
                {
                    Common.WriteLogStr("CashCode", "获取状态", "失败[" + DICGetErrorMsg(iret) + "]");
                    return iret;
                }
                Common.WriteLogStr("CashCode", "获取状态", "成功[" + DICGetErrorMsg(iret) + "]");
                return iret;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CashCode", "获取状态", "异常[" + ex.Message + "]");
                return -6;
            }
        }

        /// <summary>
        /// 开始纸币识别
        /// </summary>
        /// <param name="billtype">
        ///         BillType：赋值为   1：1元   
        ///                            2：2元
        ///                            4：5元
        ///                            8：10元
        ///                           16：20元
        ///                           32：50元
        ///                           64：100元
        ///						或以上纸币组合，组合方式是各纸币赋值的和</param>
        /// <returns></returns>
        public bool StartIdentify(int billtype, CashEvent ce)
        {
            if (IsRunning)
            {
                return IsRunning;
            }

            try
            {
                this.cashCodeEvent = ce;
                int iret = CashCodeAPI.CmdSetSecurity(0, CashCodeAPI.CASH_ADDR);//设置安全
                if (iret != 0)
                {
                    Common.WriteLogStr("CashCode", "开始识别", "CmdSetSecurity错误[" + DICGetErrorMsg(iret) + "]");
                    cashCodeEvent(0, "纸币器故障...");
                    return false;
                }
                iret = CashCodeAPI.CmdBillType(billtype, 0, CashCodeAPI.CASH_ADDR);
                if (iret != 0)
                {
                    Common.WriteLogStr("CashCode", "开始识别", "CmdBillType错误[" + DICGetErrorMsg(iret) + "]");
                    cashCodeEvent(0, "纸币器故障...");
                    return false;
                }
                IsRunning = true;
                CashCheckThread = new Thread(new ThreadStart(StartThrd));
                CashCheckThread.Start();
                Common.WriteLogStr("CashCode", "开始识别", "成功");
                cashCodeEvent(0, "请投入纸币...");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CashCode", "开始识别", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 验钞
        /// </summary>
        private void StartThrd()
        {
            try
            {
                byte index = 24;
                while (IsRunning)
                {
                    CashCodeAPI.PollCMD(CashCodeAPI.CASH_ADDR, ref z1, ref z2);
                    if (z1 == 0x43 || z1 == 0x46)//卡钞
                    {
                        //1009卡钞
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "设备卡钞");
                        cashCodeEvent(0, "设备卡钞...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;
                    }
                    if (z1 == 0x00)//设备未被初始化
                    {
                        //1005 设备未被初始化
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "设备未初始化");
                        cashCodeEvent(0, "设备异常...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;
                    }
                    if (z1 == 0x44)//钞箱卡钞
                    {
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "钞箱卡钞");
                        cashCodeEvent(0, "钞箱卡钞...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;
                    }
                    if (z1 == 0x42)//钞箱不在
                    {
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "钞箱不在");
                        cashCodeEvent(0, "钞箱不在...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;

                    }
                    if (z1 == 0x41)//钞箱已满
                    {
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "钞箱已满");
                        cashCodeEvent(0, "钞箱已满...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;
                    }
                    if (z1 == 0x47)//钞箱异常
                    {
                        IsRunning = false;
                        Common.WriteLogStr("CashCode", "验钞过程", "钞箱异常");
                        cashCodeEvent(0, "钞箱异常...");
                        CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                        return;
                    }

                    //-------------------------------钞箱异常---------------------------------------//

                    if (z1 == 0x81)
                    {
                        index = z2;
                    }
                    if (z1 != 24)
                    {
                        for (int i = 0; i < 24; i++)
                        {
                            if (index == i)
                            {
                                Common.WriteLogStr("CashCode", "验钞过程", "识别金额" + tab[i].iCashValue);
                                cashCodeEvent(tab[i].iCashValue, "请投入纸币...");
                                index = 24;
                                break;
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                IsRunning = false;
                Common.WriteLogStr("CashCode", "验钞过程", "异常[" + ex.Message + "]");
                cashCodeEvent(0, "验钞异常...");
                CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                return;
            }
        }

        /// <summary>
        /// 结束放钞
        /// </summary>
        /// <returns></returns>
        public bool StopIdentify()
        {
            try
            {
                IsRunning = false;
                Common.WriteLogStr("CashCode", "结束验钞", "成功");
                CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                return true;
            }
            catch (Exception ex)
            {
                IsRunning = false;
                Common.WriteLogStr("CashCode", "结束验钞", "异常[" + ex.Message + "]");
                // CashCodeAPI.CmdBillType(0, 0, CashCodeAPI.CASH_ADDR);
                return true;
            }
        }
    }
}
