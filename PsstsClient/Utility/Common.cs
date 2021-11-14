using PsstsClient.Bll;
using PsstsClient.Forms;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PsstsClient.Utility
{
    public class Common
    {
        static object lockobj = new object();
        /// <summary>
        /// 读INI文件
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReadIniStr(string iniFile, string section, string key)
        {
            string iniPath = Environment.CurrentDirectory + "\\" + iniFile;

            // 每次从ini中读取多少字节
            StringBuilder temp = new StringBuilder(50);
            // section=配置节，key=键名，temp=上面，path=路径
            SystemAPI.GetPrivateProfileString(section, key, "", temp, 50, iniPath);
            return temp.ToString();
        }

        /// <summary>
        /// 读INI文件
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int ReadIniInt(string iniFile, string section, string key)
        {
            string iniPath = Environment.CurrentDirectory + "\\" + iniFile;
            return SystemAPI.GetPrivateProfileInt(section, key, 1, iniPath);
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static void WriteIniStr(string iniFile, string section, string key, string val)
        {
            string iniPath = Environment.CurrentDirectory + "\\" + iniFile;
            SystemAPI.WritePrivateProfileString(section, key, val, iniPath);
        }
        private static ShowWaiting waiting;
        public static ShowWaiting Waiting
        {
            get { return waiting; }
            set { waiting = value; }
        }

        static bool isShowWaiting = false;

        /// <summary>
        /// 显示等待界面
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="Msg"></param>
        public static void ShowWaiting(Control ctl, string Msg)
        {
            try
            {
                HideWaiting();
                Common.Waiting = new ShowWaiting(ctl, Msg);
                Common.Waiting.TopMost = true;
                Common.Waiting.Width = ScreenInfo.ScreenWidth + 10;
                Common.Waiting.Height = ScreenInfo.ScreenHeight + 10;
                new Thread((ThreadStart)delegate
                {
                    Application.Run(Common.Waiting);
                }).Start();

                isShowWaiting = true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("ShowWaiting", ex);
            }
        }

        /// <summary>
        /// 显示等待界面
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="Msg"></param>
        /// <param name="timeOut">超时时间</param>
        public static void ShowWaiting(Control ctl, string Msg, int timeOut)
        {
            try
            {
                HideWaiting();
                Common.Waiting = new ShowWaiting(ctl, Msg, timeOut);
                Common.Waiting.TopMost = true;
                Common.Waiting.Width = ScreenInfo.ScreenWidth + 10;
                Common.Waiting.Height = ScreenInfo.ScreenHeight + 10;
                new Thread((ThreadStart)delegate
                {
                    Application.Run(Common.Waiting);
                }).Start();

                isShowWaiting = true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("ShowWaiting", ex);
            }
        }

        /// <summary>
        /// 结束等待界面，结束后还留在本窗口
        /// </summary>
        public static void HideWaiting()
        {
            if (!isShowWaiting)
                return;

            try
            {
                Thread.Sleep(200);
                if (Waiting.IsHandleCreated)
                    Waiting.Invoke((EventHandler)delegate { Waiting.Close(); });

                isShowWaiting = false;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }

            Bll.Forms.ShowWaiting = null;
        }

        private static System.Timers.Timer t = new System.Timers.Timer();   //实例化Timer类，设置间隔时间为10000毫秒；  ;
        /// <summary>
        /// 结束等待界面会延时，窗口跳转用
        /// </summary>
        public static void HideWaitingTimeOut()
        {
            try
            {
                t.Interval = 2000;
                t.Elapsed += new System.Timers.ElapsedEventHandler(theout); //到达时间的时候执行事件；   
                t.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；   
                t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；
                isShowWaiting = false;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }

        }


        private static void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                HideWaiting();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
            }
        }
        /// <summary>
        /// 将字符串转换成ASCII码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string tranToAcsii(string str)
        {
            byte[] ba = ASCIIEncoding.Default.GetBytes(str);
            string tempstr = "";
            foreach (byte ss in ba)
            {
                tempstr += ss.ToString("x");
            }
            return tempstr;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="file"></param>
        /// <param name="caption"></param>
        /// <param name="content"></param>
        public static void WriteLogStr(string file, string caption, string content)
        {
            lock (lockobj)
            {
                CreateLogFile(file);
                string filePath = Environment.CurrentDirectory + "\\logfile\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("yyyyMMdd") + file + ".txt";
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(filePath, true, Encoding.UTF8);
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t" + caption + "\t" + content);
                    sw.Flush();
                    sw.Dispose();
                    sw.Close();
                    sw = null;
                }
                catch (Exception ex)
                {
                    if (null != sw)
                    {
                        sw.Dispose();
                        sw.Close();
                    }
                    ex.ToString();
                }
            }

        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateLogFile(string filename)
        {
            String month = DateTime.Now.ToString("yyyyMM");
            //MessageBox.Show(month);
            string filePath = Environment.CurrentDirectory + "\\logfile\\" + month;
            //MessageBox.Show(filePath);
            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            filePath += "\\" + DateTime.Now.ToString("yyyyMMdd") + filename + ".txt";
            //MessageBox.Show(filePath);
            if (!File.Exists(filePath))
            {
                try
                {
                    FileStream file = File.Create(filePath);
                    file.Dispose();
                    file.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        public static string getLocalIP()
        {
            string ipv4 = string.Empty;
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPAddress[] ipAddress = Dns.GetHostAddresses(strHostName); //取得本机IP

            foreach (IPAddress address in ipAddress)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipv4 = address.ToString();
                }
            }
            return ipv4;
        }

        ///   <summary>    
        ///   获取网卡硬件地址    
        ///   </summary>    
        ///   <returns> string </returns>    
        public static string GetMoAddress()
        {
            string MoAddress = " ";
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        MoAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }

            return MoAddress.ToString().Replace(":", "");
        }

        /// <summary>
        /// 将结构转换为字节数组
        /// </summary>
        /// <param name="obj">结构对象</param>
        /// <returns>字节数组</returns>
        public static byte[] StructToBytes(object obj, uint usize)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(obj);  //794 435
                                             //  MessageBox.Show("得到结构数组大小为"+size);
                                             //  MessageBox.Show("usize:"+usize);
                                             //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);

            //  MessageBox.Show("分配结构体大小的内存空间:" + structPtr + ": "+size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(obj, structPtr, false);
            //  MessageBox.Show("将结构体拷到分配好的内存空间:" + obj);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //  MessageBox.Show("内存空间拷到byte数组:" + size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            size = (int)usize;
            // MessageBox.Show("返回byte数组:" + size);
            byte[] reByte = new byte[size];
            if (size < bytes.Length)
            {
                Array.Copy(bytes, reByte, size);
                return reByte;
            }
            else
            {
                return bytes;
            }
        }

        /// <summary>
        /// 将结构转换为字节数组
        /// </summary>
        /// <param name="obj">结构对象</param>
        /// <returns>字节数组</returns>
        public static byte[] StructToBytes(object obj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(obj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(obj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;

        }

        /// <summary>
        /// byte数组转结构
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">结构类型</param>
        /// <returns>转换后的结构</returns>
        public static object BytesToStruct(byte[] bytes, Type type)
        {
            try
            {

                //得到结构的大小
                int size = Marshal.SizeOf(type);

                byte[] soure = new byte[size];
                //Log(size.ToString(), 1);
                //byte数组长度小于结构的大小
                if (size > bytes.Length)
                {
                    bytes.CopyTo(soure, 0);
                }
                else
                {
                    soure = bytes;
                }
                //分配结构大小的内存空间
                IntPtr structPtr = Marshal.AllocHGlobal(size);
                //将byte数组拷到分配好的内存空间
                Marshal.Copy(soure, 0, structPtr, size);
                //将内存空间转换为目标结构
                object obj = Marshal.PtrToStructure(structPtr, type);
                //释放内存空间
                Marshal.FreeHGlobal(structPtr);
                //返回结构
                return obj;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                return null;
            }
        }


        /// <summary>
        /// Byte数组转String 例如 {0x31,0x30} 转成[31 30 ] 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                    strB.Append(" ");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// Byte数组转String 例如 {0x31,0x30} 转成[31 30 ]
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="length">byte数组要的转换长度</param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes, int length) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            int size = length;
            if (size > bytes.Length)
                size = bytes.Length;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                    strB.Append(" ");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
        public static string ByteToHexString(byte[] bytes, int length) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            int size = length;
            if (size > bytes.Length)
                size = bytes.Length;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// Byte数组转String 例如 {0x31,0x30} 转成[31 30 ]
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="length">byte数组要的转换长度</param>
        /// <returns></returns>
        public static string ToHexStringNoBlank(byte[] bytes, int length) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            int size = length;
            if (size > bytes.Length)
                size = bytes.Length;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                    //strB.Append(" ");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 获取各月份缴费流水号  
        /// </summary>
        /// <param name="i">排列号</param>
        /// <returns></returns>
        public static String GetPayFlow(int i)
        {
            return DateTime.Now.ToString("yyMMddHHmmssfff") + i.ToString("000");
        }

        /// <summary>
        /// 类型为B的转换成Byte数组
        /// 长度不足右补零
        /// 例如 124fe 转换成 0x12,0x4f,0xe0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string str)
        {
            string str_tmp = "";
            char c;
            //删除非 A-F, 0-9, 字符
            for (int i = 0; i < str.Length; i++)
            {
                c = str[i];
                if (Uri.IsHexDigit(c))
                    str_tmp += c;
            }
            // 如果长度与传进来的不符，调整字符串
            if (str.Length % 2 != 0)
            {
                str_tmp += "0";
            }

            int byteLength = str_tmp.Length / 2;
            byte[] bytes = new byte[byteLength];
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = BitConverter.GetBytes(HexValue(str_tmp[j]) * 16 + HexValue(str_tmp[j + 1]))[0];
                j = j + 2;
            }
            return bytes;
        }

        public static int HexValue(char a)
        {
            switch (a)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'a':
                case 'A':
                    return 10;
                case 'b':
                case 'B':
                    return 11;
                case 'c':
                case 'C':
                    return 12;
                case 'd':
                case 'D':
                    return 13;
                case 'e':
                case 'E':
                    return 14;
                case 'f':
                case 'F':
                    return 15;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 类型为A的转换成Byte数组
        /// 长度不足右补空格
        /// 例如将 12345 转换成 0x31,0x32,0x33,0x34,0x35
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte[] StringToByteA(string str, int len)
        {
            string str_tmp = ""; //临时字符串，主要用于长度不匹配时
            if (str.Length > len)
            {
                str_tmp = new string(str.ToCharArray(), 0, len);
            }
            else if (str.Length == len)
            {
                str_tmp = str;
            }
            else
            {
                str_tmp = str;
                for (int i = 0; i < (len - str.Length); i++)
                    str_tmp += " ";//右补空格
            }

            return System.Text.Encoding.Default.GetBytes(str_tmp);
        }

        /// <summary>
        /// 字符串进行异或运算，并返回八个字节BABE893344556677
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static String GetXor(String data1, String data2)
        {

            data1 = new string(data1.Replace(" ", "").ToCharArray(), 0, 16);
            data2 = new string(data2.Replace(" ", "").ToCharArray(), 0, 16);

            byte[] bTmpBuf1 = new byte[8];
            byte[] bTmpBuf2 = new byte[8];
            bTmpBuf1 = StringToByte(data1);
            bTmpBuf2 = StringToByte(data2);

            Byte[] retu = new Byte[bTmpBuf1.Length];

            for (int i = 0; i < bTmpBuf1.Length; i++)
            {
                retu[i] = (byte)(bTmpBuf1[i] ^ bTmpBuf2[i]);
            }
            return ToHexString(retu).Replace(" ", "");
        }

        /// <summary>
        /// 字节数组异或 //返回字符串8个字节
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static String GetXor(byte[] data1, byte[] data2)
        {
            Byte[] retu = new Byte[data1.Length];

            for (int i = 0; i < data1.Length; i++)
            {
                retu[i] = (byte)(data1[i] ^ data2[i]);
            }
            return ToHexString(retu).Replace(" ", "");
        }

        ///<summary> 
        /// 从16进制转换成汉字 
        /// </summary> 
        /// <param name="hex"></param> 
        /// <param name="charset">编码,如"utf-8","gb2312","UTF-16le"</param> 
        /// <returns></returns> 
        public static string UnHex(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格 
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }

        /// <summary>
        /// 中文转16进制
        /// </summary>
        /// <param name="Msg">要转的中文</param>
        /// <returns>返回值</returns>
        public static string ChStrToHex(string Msg)
        {
            return Str2Hex(Msg, "UTF-16le");
        }

        /// <summary>
        /// 字符串转16进制用于与后台
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Str2Hex(string s, string charset)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            byte[] arrByte = System.Text.Encoding.GetEncoding("UTF-16le").GetBytes(s);
            for (int i = 0; i < arrByte.Length; i++)
            {
                result = System.Convert.ToString(0xFF & arrByte[i], 16);        //Convert.ToString(byte, 16)把byte转化成十六进制string 
                if (result.Length < 2)
                    sb.Append(0);
                sb.Append(result.ToUpper());
            }

            return sb.ToString();
        }
    }
}
