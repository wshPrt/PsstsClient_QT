using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Text;
using System.Threading;

namespace PsstsClient.Driver
{
    public delegate void MetalKeyBoardEvent(byte keyval, string error);

    public class MetalKeyDriver
    {
        private MetalKeyBoardEvent KeyEvent;

        public int GetMetalKeyPort { set; get; }

        /// <summary>
        /// 键盘是否在运行监听按键
        /// </summary>
        public static bool IsRunning = false;
        static object lockobj = new object();

        public MetalKeyDriver(int port, int baud)
        {
            GetMetalKeyPort = port;
            if (DICOpenPort(port, baud))
            {
                if (DICGetStatus() == 0)
                    DriverCommon.MetalKeyboard = true;
                else
                {
                    DriverCommon.MetalKeyboard = false;
                    DICClose();
                }
            }
            else
                DriverCommon.MetalKeyboard = false;
        }

        public string DICGetErrorMsg(int ErrorCode)
        {
            string strResult;
            switch (ErrorCode)
            {
                case 0:
                    strResult = "命令成功执行";
                    break;
                case -1:
                    strResult = "命令参数错";
                    break;
                case -2:
                    strResult = "打开串口错";
                    break;
                case -3:
                    strResult = "关闭串口错";
                    break;
                case -4:
                    strResult = "SAM卡解密错";
                    break;
                case -5:
                    strResult = "SAM卡认证错";
                    break;
                case -6:
                    strResult = "输入非法字符";
                    break;
                case -7:
                    strResult = "发送数据错";
                    break;
                case -8:
                    strResult = "超时，无数据返回";
                    break;
                case -9:
                    strResult = "不支持此PIN加密模式";
                    break;
                case 10:
                    strResult = "发送到串口错";
                    break;
                case 11:
                    strResult = "WaitCom Error";
                    break;
                case 80:
                    strResult = "自检时，COU错";
                    break;
                case 81:
                    strResult = "SRAM错误";
                    break;
                case 82:
                    strResult = "键盘有短路错";
                    break;
                case 83:
                    strResult = "串口电平错";
                    break;
                case 84:
                    strResult = "CPU卡出错";
                    break;
                case 85:
                    strResult = "电池可能损坏";
                    break;
                case 86:
                    strResult = "主密钥失败";
                    break;
                case 87:
                    strResult = "杂项错";
                    break;
                case 12:
                    strResult = "读串口错";
                    break;
                case 13:
                    strResult = "设置超时错";
                    break;
                case 14:
                    strResult = "关闭串口错";
                    break;
                case 15:
                    strResult = "超时检测错";
                    break;
                default:
                    strResult = "未知错误代码[" + ErrorCode.ToString() + "]";
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// 初始化设备
        /// </summary>
        /// <param name="port"></param>
        /// <param name="baud"></param>
        /// <returns></returns>
        public bool DICOpenPort(int port, int baud)
        {
            try
            {
                int iret = MetalKeyboardAPI.ZT_EPP_OpenCom(port, baud);
                if (iret != 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "打开串口", "失败");
                    return false;
                }
                DriverCommon.MetalKeyboard = true;
                Common.WriteLogStr("MetalKeyboard", "打开串口", "成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "打开串口", "异常[" + ex.Message + "]");
                DriverCommon.MetalKeyboard = false;
                return false;
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        public int DICGetStatus()
        {
            try
            {
                byte[] Version, SN, Rechang;
                Version = new byte[32];
                SN = new byte[32];
                Rechang = new byte[32];
                int iret = MetalKeyboardAPI.ZT_EPP_PinReadVersion(Version, SN, Rechang);
                Common.WriteLogStr("MetalKeyboard", "获取状态", DICGetErrorMsg(iret));
                return iret;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "获取状态", "异常[" + ex.Message + "]");
                return -99;
            }
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <returns></returns>
        public int DICReset()
        {
            try
            {
                int iret = MetalKeyboardAPI.ZT_EPP_PinInitialization(0);
                Common.WriteLogStr("MetalKeyboard", "复位设备", DICGetErrorMsg(iret));
                return iret;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "复位设备", "异常[" + ex.Message + "]");
                return 1;
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
                DriverCommon.MetalKeyboard = false;
                int iret = MetalKeyboardAPI.ZT_EPP_CloseCom();
                if (iret == 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "关闭串口", "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "关闭串口", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "关闭串口", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 键盘开关
        /// </summary>
        /// <param name="type">  00  表示关闭键盘和关闭按键BZ声音
        ///                      01  表示打开键盘但关闭按键BZ声音 
        ///                      02  表示关闭键盘但打开按键BZ声音 
        ///                      03  表示打开键盘且打开按键BZ声音 </param>
        /// <returns></returns>
        /// <returns></returns>
        public bool KeyboardSwitch(int type)
        {
            try
            {
                int iret = MetalKeyboardAPI.ZT_EPP_OpenKeyVoic(type);
                if (iret == 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "键盘开关", "成功，参数为[" + type.ToString() + "]");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "键盘开关", "失败，参数为[" + type.ToString() + "]");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "键盘开关", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 下载工作密钥
        /// </summary>
        /// <param name="mainkeyid">主密钥号</param>
        /// <param name="workkeyid">工作密钥号</param>
        /// <param name="workkey">工作密钥</param>
        /// <param name="kcv">验证KCV</param>
        /// <returns></returns>    
        public bool LoadWorkkey(int mainkeyid, int workkeyid, string workkey, string kcv)
        {
            try
            {
                string ucauthcode = "";
                //工作秘钥 使用3DE算法下载
                //int iret= MetalKeyboardAPI.ZT_EPP_SetDesPara(0, 0x30);
                //if (iret == 0)
                //{ 
                int ikmod = 2;
                if (workkeyid == BankInfo.MacKeyNo)
                {
                    ikmod = 1;
                }
                int iret = MetalKeyboardAPI.ZT_EPP_PinLoadWorkKey(ikmod, mainkeyid, workkeyid, workkey, ref ucauthcode);
                if (iret == 0)
                {

                    #region
                    byte[] kcv_tmp = new byte[64];
                    string kcv_out = "";
                    iret = MetalKeyboardAPI.ZT_EPP_ActivWorkPin(mainkeyid, workkeyid);
                    //iret = MetalKeyboardAPI.ZT_EPP_SetDesPara(0, 0x30);
                    if (iret == 0)
                    {
                        //
                        ////16个字节的工作秘钥长度
                        if (workkeyid == BankInfo.PinKeyNo)//PINKEY的 加密算法是16个字节TDES
                        {

                            MetalKeyboardAPI.ZT_EPP_PinAdd(2, 0, "0000000000000000", kcv_tmp);
                            kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                            // MessageBox.Show(kcv + "==" + kcv_out);
                            Common.WriteLogStr("MetalKeyboard", "下载pinkey验证", "返回kcv" + kcv + " 计算验证kcv" + kcv_out);
                        }
                        else if (workkeyid == BankInfo.MacKeyNo)//MAC算法是8字节DES
                        {
                            MetalKeyboardAPI.ZT_EPP_PinAdd(1, 0, "0000000000000000", kcv_tmp);
                            kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                            //MessageBox.Show(kcv + "==" + kcv_out);
                            Common.WriteLogStr("MetalKeyboard", "下载mackey验证", "返回kcv" + kcv + " 计算验证kcv" + kcv_out);
                        }
                    }
                    #endregion

                    Common.WriteLogStr("MetalKeyboard", "更新密钥", "成功");
                    return true;
                }
                //  }
                Common.WriteLogStr("MetalKeyboard", "更新密钥", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "更新密钥", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 设置主密钥
        /// </summary>
        /// <param name="iKMode"></param>
        /// <param name="iKeyNo"></param>
        /// <param name="mainkey"></param>
        /// <param name="kcv"></param>
        /// <returns></returns>
        public bool LoadMainkey(int iKMode, int iKeyNo, string mainkey, ref string kcv)
        {
            try
            {
                //工作秘钥 使用3DE算法下载
                MetalKeyboardAPI.ZT_EPP_SetDesPara(0, 0x30);
                int iret = MetalKeyboardAPI.ZT_EPP_PinLoadMasterKey(iKMode, iKeyNo, mainkey, ref kcv);
                if (iret == 0)
                {

                    #region
                    //MetalKeyboardAPI.ZT_EPP_ActivWorkPin(mainkeyid, workkeyid);
                    //
                    ////16个字节的工作秘钥长度
                    //if (workkeyid == 0)//PINKEY的 加密算法是16个字节TDES
                    //{
                    //    MetalKeyboardAPI.ZT_EPP_PinAdd(2, 0, "0000000000000000", kcv_tmp);
                    //    kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                    //    MessageBox.Show(kcv + "==" + kcv_out);
                    //}
                    //else if (workkeyid == 1)//MAC算法是8字节DES
                    //{
                    //    MetalKeyboardAPI.ZT_EPP_PinAdd(1, 0, "0000000000000000", kcv_tmp);
                    //    kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                    //    MessageBox.Show(kcv + "==" + kcv_out);
                    //}
                    #endregion

                    Common.WriteLogStr("MetalKeyboard", "更新主密钥", "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "更新主密钥", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "更新主密钥", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 主密钥解密，实际是不需要解的，直接把工作密钥密文存键盘里
        /// </summary>
        /// <param name="iKMode"></param>
        /// <param name="iMode"></param>
        /// <param name="decStr"></param>
        /// <param name="outStr"></param>
        /// <returns></returns>
        public bool MainkeyDec(int iKMode, int iMode, string decStr, ref string outStr)
        {
            try
            {
                byte[] cc = new byte[64];
                int iret = MetalKeyboardAPI.ZT_EPP_PinUnAdd(iKMode, iMode, decStr, cc);
                if (iret == 0)
                {
                    outStr = Encoding.Default.GetString(cc);
                    #region
                    //MetalKeyboardAPI.ZT_EPP_ActivWorkPin(mainkeyid, workkeyid);
                    //
                    ////16个字节的工作秘钥长度
                    //if (workkeyid == 0)//PINKEY的 加密算法是16个字节TDES
                    //{
                    //    MetalKeyboardAPI.ZT_EPP_PinAdd(2, 0, "0000000000000000", kcv_tmp);
                    //    kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                    //    MessageBox.Show(kcv + "==" + kcv_out);
                    //}
                    //else if (workkeyid == 1)//MAC算法是8字节DES
                    //{
                    //    MetalKeyboardAPI.ZT_EPP_PinAdd(1, 0, "0000000000000000", kcv_tmp);
                    //    kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim().Substring(0, kcv.Length);
                    //    MessageBox.Show(kcv + "==" + kcv_out);
                    //}
                    #endregion

                    Common.WriteLogStr("MetalKeyboard", "主密钥解密" + outStr, "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "主密钥解密", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "主密钥解密", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 激活工作密钥
        /// </summary>
        /// <param name="MainKeyId">主密钥号</param>
        /// <param name="WorkKeyId">工作密钥号</param>
        /// <returns></returns>
        public bool ActivateWorkkey(int MainKeyId, int WorkKeyId)
        {
            try
            {
                int iret = MetalKeyboardAPI.ZT_EPP_ActivWorkPin(MainKeyId, WorkKeyId);
                if (iret == 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "激活密钥", "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "激活密钥", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "激活密钥", "异常[" + ex.Message + "]");
                return false;

            }
        }

        /// <summary>
        /// 设置算法
        /// </summary>
        /// <returns></returns>
        public bool SetPara(int iPara, int iFcode)
        {
            try
            {
                int iret = MetalKeyboardAPI.ZT_EPP_SetDesPara(iPara, iFcode);

                if (iret != 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "设置算法", "失败");
                    return false;
                }
                Common.WriteLogStr("MetalKeyboard", "设置算法", "成功");
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                Common.WriteLogStr("MetalKeyboard", "设置算法", "失败");
                return false;
            }
        }

        /// <summary>
        /// MAC 运算
        /// </summary>
        /// <param name="iKMode">原下载的相应工作密钥的长度 
        ///                  1:PEA_DES      8字节的工作密钥DES 运算;
        ///                  2:PEA_TDES     16 字节的工作密钥TDES 运算; 
        ///                  3:PEA_TDES2    24字节的工作密钥 
        ///                  4:PEA_MDES     8 字节的主密钥DES 运算;
        ///                  5:PEA_MTDES    16 字节的主密钥TDES 运算;  </param>
        /// <param name="iMacMode">MAC 运算 
        /// 1: 表示X9.9/X9.19 算法 
        /// 2 表示:PSAM(ECB) 算法 
        /// 3: 表示PBOC 算法 
        /// 4: 表示银联的算法 
        /// 5: 表示CBC 算法 </param>
        /// <param name="lpValue"></param>
        /// <param name="cpExValue"></param>
        public bool GetMac(int iKMode, int iMacMode, string lpValue, ref string macStr)
        {
            try
            {
                byte[] cpExValue = new byte[64];
                //贵州PEA_DES 1   iMacMode 1
                int iret = MetalKeyboardAPI.ZT_EPP_PinCalMAC(iKMode, iMacMode, lpValue, cpExValue);
                if (iret != 0)
                {

                    Common.WriteLogStr("MetalKeyboard", "MAC 运算", "失败");
                    return false;
                }
                macStr = Encoding.Default.GetString(cpExValue).Split('\0')[0].Trim();
                Common.WriteLogStr("MetalKeyboard", "MAC 运算", "成功");
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                Common.WriteLogStr("MetalKeyboard", "MAC 运算", "失败");
                return false;
            }
        }

        /// <summary>
        /// 启动pin运算
        /// </summary>
        /// <param name="PinLen">密码长度</param>
        /// <param name="AddMode">加密模式nPINMode 为1 字节：00= 由算法参数决定加密模式， 
        ///                                                   01＝PIN 与CARD-NO 进行运算后加密（ISO9564-1 格式0），
        ///                                                   02=PIN不与CARD-NO 进行运算直接ASCII 码加密（ASCII 格式）,
        ///                                                   03==PIN 不与CARD-NO 进行运算直接BCD码加密（IBM3624 格式）。</param>/// <param name="TimeOut">超时时间</param>
        /// <returns></returns>
        public bool PinStart(int PinLen, int AddMode, int TimeOut)
        {
            try
            {
                // String mes = "";
                //======测试
                int iret = MetalKeyboardAPI.SZZT_InputPin(2, 0, 0, 6, 1, "", 60);
                //===========
                if (iret == 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 贵州
        /// </summary>
        /// <param name="TimeOut"></param>
        /// <returns></returns>
        public bool PinStart(int TimeOut)
        {
            try
            {
                // String mes = "";
                //======测试
                int iret = MetalKeyboardAPI.ZT_EPP_PinStartAdd(6, 0x01, 0x00, 0, TimeOut);
                //===========
                if (iret == 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "成功");
                    return true;
                }
                Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "失败");
                return false;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "启动PIN运算", "异常[" + ex.Message + "]");
                return false;

            }
        }

        /// <summary>
        /// 取出密码
        /// </summary>
        /// <param name="PinBlock"></param>
        /// <returns></returns>
        public bool ReadPinBlock(ref string PinBlock)
        {
            try
            {
                byte[] pin = new byte[80];
                //int iret = MetalKeyboardAPI.ZT_EPP_PinReadPin(0, pin);//修改 
                int iret = MetalKeyboardAPI.SZZT_GetPinBlock(pin);
                PinBlock = System.Text.Encoding.Default.GetString(pin).Split('\0')[0].Trim(); ;
                if (iret != 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "获取密文", "失败");
                    return false;
                }
                Common.WriteLogStr("MetalKeyboard", "获取密文", "成功");
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "获取密文", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 监听按键
        /// </summary>
        /// <returns></returns>
        public byte ListenKey()
        {
            try
            {
                byte[] UcKey = new byte[255];
                int iret = MetalKeyboardAPI.ZT_EPP_PinReportPressed(UcKey, 100);
                if (iret != 0)
                    return 0x00;//按键异常
                                //  Common.WriteLogStr("MetalKeyboard", "按下键为",UcKey[1]+"");
                return UcKey[0];
                //if (UcKey[0] == 0x00)
                //    return 0x00;//没有按键
                //if (UcKey[0] == 0x33)
                //{
                //    return UcKey[1];//数字键 0 0x30,1 0x31,2 0x32，……,9 0x39
                //}
                //else if (UcKey[0] == 0x30 && UcKey[1] == 0x44)//确认键
                //{
                //    return 0x13;
                //}
                //else if (UcKey[0] == 0x31 && UcKey[1] == 0x42)//退出键
                //{
                //    return 0x27;
                //}
                //else if (UcKey[0] == 0x30 && UcKey[1] == 0x38)//清除键
                //{
                //    return 0x08;
                //}
                //else if (UcKey[0] == 50 && UcKey[1] == 51)//上翻键
                //{
                //    return 0x02;
                //}
                //else if (UcKey[0] == 50 && UcKey[1] == 65)//下翻键
                //{
                //    return 0x03;
                //}
                //else if (UcKey[0] == 0x32 && UcKey[1] == 0x45)//小数点
                //{
                //    return 0x2E;
                //}
                //else
                //{
                //    return 0x2A;//其他按键 *
                //}
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("监听按键异常", avex);
                return 0x00;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "监听按键", "异常[" + ex.Message + "]");
                return 0x00;
            }
        }
        private Thread ListenKeyThread;
        public bool StartKeyListen(MetalKeyBoardEvent KeyPress)
        {
            try
            {
                if (!IsRunning)
                {
                    IsRunning = true;
                    this.KeyEvent = KeyPress;
                    if (null == ListenKeyThread)
                    {
                        ListenKeyThread = new Thread(new ThreadStart(StartThrd));
                        ListenKeyThread.IsBackground = true;
                    }
                    ListenKeyThread.Start();
                    Common.WriteLogStr("MetalKeyboard", "按键监测", "成功");
                    KeyPress(0, "请在键盘输入...");
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("StartKeyListen异常", ex);
            }

            return true;

        }

        private void StartThrd()
        {
            lock (lockobj)
            {
                while (IsRunning)
                {
                    byte key = this.ListenKey();
                    if (key != 0x00)
                        KeyEvent(key, "请在键盘输入...");
                }
            }
        }

        public bool StopKeyListen()
        {
            if (ListenKeyThread != null)
            {
                try
                {
                    IsRunning = false;
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    IsRunning = false;
                    Common.WriteLogStr("MetalKeyboard", "StopKeyListen", ex.ToString());
                    return false;

                }
                ListenKeyThread = null;
                Common.WriteLogStr("MetalKeyboard", "StopKeyListen", "kkkkkkkkk");
            }

            return true;
        }

        public bool MacAdd(string data, ref string mac)
        {
            try
            {
                byte[] mac_t = new byte[64];
                // MetalKeyboardAPI.ZT_EPP_SetDesPara(1, 0x20);               
                int iret = MetalKeyboardAPI.ZT_EPP_PinCalMAC(1, 1, data, mac_t);


                if (iret != 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "MAC运算", "失败");
                    return false;
                }
                Common.WriteLogStr("MetalKeyboard", "MAC运算", "成功");
                mac = Encoding.Default.GetString(mac_t).Split('\0')[0].Trim();
                return true;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "MAC运算", "异常[" + ex.Message + "]");
                return false;
            }
        }

        /// <summary>
        /// 测试，Mac返回字节数字 方便异或
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] MacAdd(string data)
        {
            try
            {
                byte[] mac_t = new byte[64];
                // MetalKeyboardAPI.ZT_EPP_SetDesPara(1, 0x20);

                int iret = MetalKeyboardAPI.ZT_EPP_PinCalMAC(1, 1, data, mac_t);
                //  MetalKeyboardAPI.SZZT_MAC(BankInfo.MainKeyNo,BankInfo.MacKeyNo,1,1,data,mac_t,1);

                if (iret != 0)
                {
                    Common.WriteLogStr("MetalKeyboard", "MAC运算", "失败");
                    return null;
                }
                Common.WriteLogStr("MetalKeyboard", "MAC运算", "成功");
                //  mac = System.Text.Encoding.Default.GetString(mac_t).Split('\0')[0].Trim();
                return mac_t;
            }
            catch (Exception ex)
            {
                Common.WriteLogStr("MetalKeyboard", "MAC运算", "异常[" + ex.Message + "]");
                return null;
            }
        }
    }
}
