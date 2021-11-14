using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PsstsClient.Driver
{
    public delegate void CardReaderError(string error);
    public delegate void CardReaderRead(string mag1, string mag2, string mag3);

    public class CardReaderDriver
    {
        private IntPtr hDev;

        private CardReaderError cardreaderEor;
        private CardReaderRead cardreaderRe;
        private bool IsRunning = false;

        public CardReaderDriver(int port, long baud)
        {
            if (DICOpenPort(port, baud))
            {
                if (DICGetStatus() == -1)
                {
                    DriverCommon.CardReader = false;
                    DICClose();
                }
                else
                {
                    DriverCommon.CardReader = true;
                }
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool DICOpenPort(int port, long baud)
        {
            try
            {
                hDev = CardReaderAPI.CommOpenWithBaut("Com" + port, (int)baud);

                if ((int)hDev <= 0)
                {
                    Common.WriteLogStr("CardReader", "打开串口", "打开串口失败");
                    return false;
                }
                Common.WriteLogStr("CardReader", "打开串口", "打开串口成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "打开串口", "打开串口异常，异常信息[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <returns></returns>
        public int DICGetStatus()
        {
            try
            {
                byte Position = 0x00, FrontSetting = 0x00, RearSetting = 0x00;
                int LRet = 0;
                int IRet = CardReaderAPI.CRT310_GetStatus(hDev, ref Position, ref FrontSetting, ref RearSetting);
                if (IRet != 0)
                {
                    Common.WriteLogStr("CardReader", "获取状态", "获取状态失败");
                    return -1;
                }
                switch (Position)
                {
                    case 0x46:
                        LRet = 1;       //卡内有长卡（卡的长度长于标准卡）
                        break;
                    case 0x47:
                        LRet = 2;       //卡内有短卡（卡的长度短于标准卡）
                        break;
                    case 0x48:
                        LRet = 3;       //卡机前端不持卡位置有卡
                        break;
                    case 0x49:
                        LRet = 4;       //机前端持卡位置有卡
                        break;
                    case 0x4A:
                        LRet = 5;       //机内停卡位置有卡
                        break;
                    case 0x4B:
                        LRet = 6;       //机内IC卡位置有卡，并且IC卡触点已下落
                        break;
                    case 0x4C:
                        LRet = 7;       //机后端持卡位置有卡
                        break;
                    case 0x4D:
                        LRet = 8;       //机后端不持卡位置有卡
                        break;
                    case 0x4E:
                        LRet = 9;       //机内无卡
                        break;
                    default:
                        LRet = 10;
                        break;
                }
                Common.WriteLogStr("CardReader", "获取状态", "获取状态成功[" + DICGetErrorMsg(LRet) + "]");
                return LRet;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "获取状态", "获取状态异常[" + ex.Message + "]");
                return -1;
            }
        }

        /// <summary>
        /// 设备复位
        /// </summary>
        /// <returns></returns>
        public bool DICReset()
        {
            try
            {
                int iret = CardReaderAPI.CRT310_Reset(hDev, 0x32);
                if (iret == 0)
                {
                    Common.WriteLogStr("CardReader", "设备复位", "复位成功");
                    CardReaderAPI.CRT310_CardSetting(hDev, 0x31, 0x31);
                    return true;
                }
                else
                {
                    Common.WriteLogStr("CardReader", "设备复位", "复位失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "设备复位", "复位异常[" + ex.Message + "]");
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
                int iret = CardReaderAPI.CommClose(hDev);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "关闭串口", "关闭串口失败");
                    return false;
                }
                Common.WriteLogStr("CardReader", "关闭串口", "关闭串口成功");
                DriverCommon.CardReader = false;
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "关闭串口", "关闭串口异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 允许插卡
        /// </summary>
        /// <returns></returns>
        public bool EnableInsert()
        {
            try
            {
                int iret = CardReaderAPI.CRT310_CardSetting(hDev, 0x34, 0x31);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "允许插卡", "允许插卡失败");
                    return false;
                }

                Common.WriteLogStr("CardReader", "允许插卡", "允许插卡成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "允许插卡", "允许插卡异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 禁止插卡
        /// </summary>
        /// <returns></returns>
        public bool DisEnableInsert()
        {
            try
            {
                int iret = CardReaderAPI.CRT310_CardSetting(hDev, 0x31, 0x31);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "禁止插卡", "禁止插卡失败");
                    return false;
                }
                Common.WriteLogStr("CardReader", "禁止插卡", "禁止插卡成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "禁止插卡", "禁止插卡异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public bool ReadCard(ref string str1, ref string str2, ref string str3)
        {
            try
            {
                byte[] CardInfo = new byte[500];
                int iret = CardReaderAPI.MC_ReadTrack(hDev, 0x30, 0x37, CardInfo);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "读    卡", "读卡失败");
                    return false;
                }
                if (CardInfo[0] != 0x1F)
                {
                    Common.WriteLogStr("CardReader", "读    卡", "读卡失败");
                    return false;
                }
                string CardData = "";
                string t = "";
                for (int i = 0; i < CardInfo.Length; i++)
                {
                    if (CardInfo[0] == 0)
                        break;
                    if (CardInfo[i] == 31)
                    {
                        t += string.Format("{0}", '~');
                        CardData += t;
                        t = "";
                    }
                    else if (CardInfo[i] != 89)
                    {

                        t += string.Format("{0}", (char)CardInfo[i]);
                        CardData += t;
                        t = "";
                    }
                }
                string Msg = "";
                Msg = CardData;

                char[] Mag1 = new char[500];
                char[] Mag2 = new char[500];
                char[] Mag3 = new char[500];

                string mags1 = "";
                string mags2 = "";
                string mags3 = "";

                string[] allmag = CardData.Split('~');
                if (allmag.Length < 4)
                {
                    return false;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (i == 1)
                    {
                        mags1 = string.Copy(allmag[i]);
                    }
                    if (i == 2)
                    {
                        mags2 = string.Copy(allmag[i]);

                    }
                    if (i == 3)
                    {
                        mags3 = string.Copy(allmag[i]);
                    }
                }
                str1 = mags1.Split('\0')[0];
                str2 = mags2.Split('\0')[0];
                str3 = mags3.Split('\0')[0];

                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "读    卡", "读卡异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 吐卡
        /// </summary>
        /// <returns></returns>
        public bool EjectCard()
        {
            try
            {
                int iret = CardReaderAPI.CRT310_MovePosition(hDev, 0x31);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "吐    卡", "吐卡失败");
                    return false;
                }
                Common.WriteLogStr("CardReader", "吐    卡", "吐卡成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "吐    卡", "吐卡异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 吞卡
        /// </summary>
        /// <returns></returns>
        public bool SwallowCard()
        {
            try
            {
                int iret = CardReaderAPI.CRT310_MovePosition(hDev, 0x33);
                if (iret != 0)
                {
                    Common.WriteLogStr("CardReader", "吞    卡", "吞卡失败");
                    return false;
                }
                Common.WriteLogStr("CardReader", "吞    卡", "吞卡成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "吞    卡", "吐卡异常[" + ex.Message + "]");
                return false;
            }
        }

        public string DICGetErrorMsg(long ErrorCode)
        {
            string strResult;
            // TODO: Add your dispatch handler code here
            switch (ErrorCode)
            {
                case -1:
                    strResult = "执行失败";
                    break;
                case 0:
                    strResult = "执行成功";
                    break;
                case 1:
                    strResult = "卡内有长卡（卡的长度长于标准卡）";
                    break;
                case 2:
                    strResult = "卡内有短卡（卡的长度短于标准卡）";
                    break;
                case 3:
                    strResult = "卡机前端不持卡位置有卡";
                    break;
                case 4:
                    strResult = "机前端持卡位置有卡";
                    break;
                case 5:
                    strResult = "机内停卡位置有卡";
                    break;
                case 0x4B:
                    strResult = "机内IC卡位置有卡，并且IC卡触点已下落";
                    break;
                case 7:
                    strResult = "机后端持卡位置有卡";
                    break;
                case 8:
                    strResult = "机后端不持卡位置有卡";
                    break;
                case 9:
                    strResult = "机内无卡";
                    break;
                default:
                    strResult = "未知返回码[" + ErrorCode + "]";
                    break;
            }

            return strResult;
        }

        public bool StartReadCard(CardReaderError crError, CardReaderRead crRead)
        {
            this.cardreaderEor = crError;
            this.cardreaderRe = crRead;

            try
            {
                if (!this.EnableInsert())
                {
                    Common.WriteLogStr("CardReader", "监测投卡", "允许插卡失败");
                    cardreaderEor("设备故障...");
                    return false;
                }
                IsRunning = true;
                Thread ListenCardThread = new Thread(new ThreadStart(StartThrd));
                ListenCardThread.Start();
                Common.WriteLogStr("CardReader", "监测投卡", "成功");
                cardreaderEor("请插入您的银行卡...");
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                Common.WriteLogStr("CardReader", "监测投卡", "设备异常，允许插卡失败");
                return false;
            }
        }

        private void StartThrd()
        {
            string mag1 = "", mag2 = "", mag3 = "";
            try
            {
                while (IsRunning)
                {
                    int status = this.DICGetStatus();
                    if (status == 5)    //检测到有卡，开始读卡
                    {
                        Thread.Sleep(500);
                        if (this.ReadCard(ref mag1, ref mag2, ref mag3))
                        {
                            cardreaderRe(mag1, mag2, mag3);
                            IsRunning = false;
                        }
                        else
                        {
                            cardreaderEor("无效卡或卡片损坏...");
                        }
                    }
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("CardReader", "监测投卡", "设备异常，检测插卡故障");
                Common.WriteLogStr("CardReader", "监测投卡", ex.Message);
                return;
            }
        }

        public bool StopReadCard()
        {
            IsRunning = false;
            this.EjectCard();
            this.DisEnableInsert();
            Common.WriteLogStr("CardReader", "停止读卡", "成功");
            return true;
        }
    }
}
