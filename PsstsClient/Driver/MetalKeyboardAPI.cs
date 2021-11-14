using System.Runtime.InteropServices;

namespace PsstsClient.Driver
{
    public class MetalKeyboardAPI
    {
        const string ZT_EPP_API_Path = @"ImportDLL\ZT_EPP_API.dll";

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="Port">串口</param>
        /// <param name="BaudRate">波特率</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_OpenCom(int Port, int BaudRate);

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_CloseCom();

        /// <summary>
        /// 设备复位
        /// </summary>
        /// <param name="IType">0、不清除密钥；1、清除所有密钥</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinInitialization(int iInitMode);


        /// <summary>
        /// 键盘的版本信息和生产序列号
        /// </summary>
        /// <param name="cpVersion">版本信息</param>
        /// <param name="cpSN">生产序号</param>
        /// <param name="cpRechang">描述代码</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinReadVersion(byte[] cpVersion, byte[] cpSN, byte[] cpRechang);

        /// <summary>
        /// 下载主密钥
        /// </summary>
        /// <param name="iKMode"></param>
        /// <param name="iKeyNo"></param>
        /// <param name="?"></param>
        /// <param name="cpExChk"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinLoadMasterKey(int iKMode, int iKeyNo, string lpKey, ref string cpExChk);


        /// <summary>
        /// 下载工作密钥
        /// </summary>
        /// <param name="iKMode">DES_MODE:   1     //8字节主密钥   TDES_MODE:  2     //16 字节主密钥    TDES_MODE2: 3     //24 字节主密钥</param>
        /// <param name="iMKeyNo">主密钥号</param>
        /// <param name="iKeyNo">工作密钥号</param>
        /// <param name="lpKey">密钥</param>
        /// <param name="cpExChk">KCV</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinLoadWorkKey(int iKMode, int iMKeyNo, int iKeyNo, string lpKey, ref string cpExChk);

        /// <summary>
        /// 激活工作密钥
        /// </summary>
        /// <param name="iMKeyNo">主密钥号</param>
        /// <param name="iWKeyNo">工作密钥号</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_ActivWorkPin(int iMKeyNo, int iWKeyNo);

        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="iKMode">原下载的相应工作密钥的长度 
        ///                      1:PEA_DES   8字节的工作密钥DES 运算;
        ///                      2:PEA_TDES  16 字节的工作密钥TDES 运算; 
        ///                      3:PEA_TDES2  24字节的工作密钥 
        ///                      4:PEA_MDES   8 字节的主密钥DES 运算;
        ///                      5:PEA_MTDES  16 字节的主密钥TDES 运</param>
        /// <param name="iMode">ECB ：代表模式0；(目前是以ECB 方式)   CBC：代表模式1。(部分支持, 如C45 或以后的)</param>
        /// <param name="lpValue">需加密的数据</param>
        /// <param name="cpExValue">加密后的数据</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinAdd(int iKMode, int iMode, string lpValue, byte[] cpExValue);

        /// <summary>
        /// 数据解密
        /// </summary>
        /// <param name="iKMode"> 原下载的相应工作密钥的长度
        ///    1:PEA_DES 8 字节的工作密钥 DES
        ///     运算;
        ///     2:PEA_TDES 16 字节的工作密钥
        ///     TDES 运算;
        ///    3:PEA_TDES2 24 字节的工作密钥
        ///    4:PEA_MDES 8 字节的主密钥 DES
        ///     运算;
        ///    5:PEA_MTDES 16 字节的主密钥
        ///    TDES 运算;</param>
        /// <param name="iMode">ECB ：代表模式0；(目前是以ECB 方式)   CBC：代表模式1。</param>
        /// <param name="lpValue">需解密的数据</param>
        /// <param name="cpExValue">解密后的数据</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinUnAdd(int iKMode, int iMode, string lpValue, byte[] cpExValue);

        /// <summary>
        /// 打开键盘
        /// </summary>
        /// <param name="iValue">00  表示关闭键盘和关闭按键BZ声音** 
        ///                      01  表示打开键盘但关闭按键BZ声音 
        ///                      02  表示关闭键盘但打开按键BZ声音 
        ///                      03  表示打开键盘且打开按键BZ声音 </param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_OpenKeyVoic(int iValue);

        /// <summary>
        /// 键盘监测
        /// </summary>
        /// <param name="UcChar"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinReportPressed(byte[] cpKey, int iTimeOut);

        /// <summary>
        /// 读取Pin密文
        /// </summary>
        /// <param name="iKMode">工作密钥的长度模式:nKMode:  
        ///                      0:PEA_BE    前加密  
        ///                      1:PEA_DES   8字节的工作密钥DES运算; 
        ///                      2:PEA_TDES  16 字节的工作密钥TDES 运算; 
        ///                      3:PEA_TDES2  24字节的工作密钥 </param>
        /// <param name="cpPinBlock"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinReadPin(short iKMode, byte[] cpPinBlock);

        /// <summary>
        /// 启动密码键盘加密
        /// </summary>
        /// <param name="iPinLen">密码长度</param>
        /// <param name="iDispMode">显示模式DISP-MD为1 字节：01 ＝显示或返回串口“*”, 01 </param>
        /// <param name="iPINMode">加密模式nPINMode 为1 字节：00= 由算法参数决定加密模式， 
        ///                                                   01＝PIN 与CARD-NO 进行运算后加密（ISO9564-1 格式0），
        ///                                                   02=PIN不与CARD-NO 进行运算直接ASCII 码加密（ASCII 格式）,
        ///                                                   03==PIN 不与CARD-NO 进行运算直接BCD码加密（IBM3624 格式）。</param>
        /// <param name="iPromMode">0</param>
        /// <param name="iTimeOut">超时时间</param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinStartAdd(int iPinLen, int iDispMode, int iPINMode, int iPromMode, int iTimeOut);

        /// <summary>
        /// 
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
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_PinCalMAC(int iKMode, int iMacMode, string lpValue, byte[] cpExValue);


        /// <summary>
        /// 设置算法参数
        /// </summary>
        /// <param name="iPara"></param>
        /// <param name="iFCode"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int ZT_EPP_SetDesPara(int iPara, int iFCode);
        //=================================================================
        /// <summary>
        /// MAC运算
        /// </summary>
        /// <param name="nMKeyNo"></param>
        /// <param name="nWKeyNo"></param>
        /// <param name="nKMode"></param>
        /// <param name="nMacMode"></param>
        /// <param name="lpValue"></param>
        /// <param name="lpExMac"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int SZZT_MAC(int nMKeyNo, int nWKeyNo, int nKMode, int nMacMode, string lpValue, byte[] lpExMac, int nType);

        /// <summary>
        /// 启动密码加密键盘加密(前加密)
        /// </summary>
        /// <param name="nKMode"></param>
        /// <param name="nMKeyNo"></param>
        /// <param name="nWKeyNo"></param>
        /// <param name="nPinLen"></param>
        /// <param name="AddMode"></param>
        /// <param name="lpCardNo"></param>
        /// <param name="TimeOut"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int SZZT_InputPin(int nKMode, int nMKeyNo, int nWKeyNo, int nPinLen, int AddMode, string lpCardNo, int TimeOut);

        /// <summary>
        /// 取用户密码
        /// </summary>
        /// <param name="lpPinBlock"></param>
        /// <returns></returns>
        [DllImport(ZT_EPP_API_Path)]
        public static extern int SZZT_GetPinBlock(byte[] lpPinBlock);
    }
}
