using PsstsClient.Bll;
using System;
using System.Text;

namespace PsstsClient.Utility
{
    public class Global
    {
        /// <summary>
        /// 注册秘钥
        /// </summary>
        public static string RegPwd { get; set; }

        public static string SecretKey { get; set; }

        /// <summary>
        /// 服务IP地址
        /// </summary>
        public static string ServiceIP { get; set; }

        /// <summary>
        /// 服务端口号
        /// </summary>
        public static int ServicePort { get; set; }

        /// <summary>
        /// 是否加密数据
        /// </summary>
        public static bool IsEncry { get; set; }

        /// <summary>
        /// 终端绑定Key
        /// </summary>
        public static string ClientKey { get; set; }

        /// <summary>
        /// 服务端连接心跳发送间隔时间
        /// </summary>
        public static int HeartbeatTime { get; set; }

        /// <summary>
        /// 数据上报轮询时间间隔
        /// </summary>
        public static int DataReported { get; set; }

        /// <summary>
        /// 渠道商供电单位
        /// </summary>
        public static string plOrgNo { get; set; }

        /// <summary>
        /// 渠道商编号
        /// </summary>
        public static string ChanelNo { get; set; }

        /// <summary>
        /// 操作员工号
        /// </summary>
        public static string OpEmpNo { get; set; }

        /// <summary>
        /// 请求返回成功标志
        /// </summary>
        public static string Successful = "0000";

        /// <summary>
        /// 电力机构自助终端缴费代码
        /// </summary>
        public static string TerminalChargeCode = "010301";

        /// <summary>
        /// 电力机构自助终端卡表售电代码
        /// </summary>
        public static string TerminalCardCode = "010302";

        /// <summary>
        /// IC卡购电标记
        /// </summary>
        public static string ICCardFlag = "01";

        /// <summary>
        /// 缴费购电标记
        /// </summary>
        public static string PayCost = "02";

        /// <summary>
        /// 结算方式（01=现金结算、05=POS机刷卡、21=微信支付、22=支付宝支付）
        /// </summary>
        public static string SettleMode = "01";

        /// <summary>
        /// 现金支付代码
        /// </summary>
        public static string CashPay = "01";

        /// <summary>
        /// 微信支付代码
        /// </summary>
        public static string WenXinPay = "21";

        /// <summary>
        /// 支付宝支付代码
        /// </summary>
        public static string Alipay = "22";

        /// <summary>
        /// 现金代收渠道商编号
        /// </summary>
        public static string CashAgentNumber = "17";

        /// <summary>
        /// 对账文件目录
        /// </summary>
        public static string CheckFileDir = "\\CheckFile";

        /// <summary>
        /// 序列号保存路径
        /// </summary>
        public static string PaySerNumFile = "\\PrintModel\\payserialnum.txt";

        /// <summary>
        /// 对账文件FTP服务器IP
        /// </summary>
        public static string FtpIP { get; set; }

        /// <summary>
        /// 对账文件FTP账号
        /// </summary>
        public static string FtpUser { get; set; }

        /// <summary>
        /// 对账文件FTP密码
        /// </summary>
        public static string FtpPwd { get; set; }

        /// <summary>
        /// 对账文件FTP服务器端口
        /// </summary>
        public static int FtpPort { get; set; }

        /// <summary>
        /// 微信支付
        /// </summary>
        public static string WeiXinPayMode = "微信支付";

        /// <summary>
        /// 现金支付
        /// </summary>
        public static string CashPayMode = "现金支付";

        /// <summary>
        /// 卡表充值
        /// </summary>
        public static string ICCardRecharge = "卡表充值";

        /// <summary>
        /// 电费缴纳
        /// </summary>
        public static string BillPay = "电费缴纳";

        /// <summary>
        /// 缴费成功
        /// </summary>
        public static string PayConstSuccess = "缴费成功";

        /// <summary>
        /// 缴费失败
        /// </summary>
        public static string PayConstFailure = "缴费失败";

        /// <summary>
        /// 销账失败
        /// </summary>
        public static string ChargeOffsFailure = "销账失败";

        /// <summary>
        /// byte[]转十六进制
        /// </summary>
        /// <param name="recData"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] recData)
        {
            StringBuilder stringBuilder = new StringBuilder(recData.Length * 3);

            foreach (byte tmp in recData)
            {
                stringBuilder.Append(" " + Convert.ToString(tmp, 16).PadLeft(2, '0'));
            }

            return stringBuilder.ToString().ToUpper();
        }

        /// <summary>
        /// 返回缴费方式字典内容
        /// </summary>
        /// <param name="payModeCode"></param>
        /// <returns></returns>
        public static string GetPayMode(string payModeCode)
        {
            string result = string.Empty;

            switch (payModeCode)
            {
                case "01": result = "电力机构"; break;
                case "0101": result = "电力机构坐收"; break;
                case "010101": result = "电力机构柜台收费"; break;
                case "010102": result = "电力机构卡表购电"; break;
                case "010105": result = "电力机构主动转帐缴费"; break;
                case "0102": result = "电力机构走收"; break;
                case "010201": result = "电力机构走收"; break;
                case "0103": result = "电力机构自助缴费终端"; break;
                case "010301": result = "电力机构自助缴费终端收费"; break;
                case "010302": result = "电力机构自助缴费终端卡表售电"; break;
                case "02": result = "金融机构"; break;
                case "0201": result = "金融机构银行代收"; break;
                case "020101": result = "金融机构银行柜台代收"; break;
                case "020102": result = "金融机构银行柜台卡表售电"; break;
                case "020104": result = "金融机构网上银行"; break;
                case "0204": result = "金融机构银行自助缴费终端"; break;
                case "020401": result = "金融机构银行自助缴费终端收费"; break;
                case "020402": result = "金融机构银行自助缴费终端卡表售电"; break;
                case "020403": result = "金融机构ATM售电"; break;
                case "020404": result = "金融机构ATM收费"; break;
                case "03": result = "非金融机构"; break;
                case "0301": result = "非金融机构代收"; break;
                case "030101": result = "非金融机构收费"; break;
                case "030102": result = "非金融机构代办网点卡表售电"; break;
                case "030107": result = "非金融机构POS机收费"; break;
                case "030108": result = "非金融机构POS机售电"; break;
                case "030146": result = "微信缴费"; break;
                case "0303": result = "非金融机构自助缴费终端"; break;
                case "030301": result = "非金融机构自助缴费终端收费"; break;
                case "030302": result = "非金融机构自助缴费终端售电"; break;
            }

            return result;
        }

        /// <summary>
        /// 返回结算方式字典内容
        /// </summary>
        /// <param name="settleModeCode"></param>
        /// <returns></returns>
        public static string GetSettleMode(string settleModeCode)
        {
            string result = string.Empty;

            switch (settleModeCode)
            {
                case "01": result = "现金"; break;
                case "05": result = "POS机刷卡"; break;
                case "21": result = "微信"; break;
                case "22": result = "支付宝"; break;
            }

            return result;
        }

        /// <summary>
        /// 返回用户类型字典内容
        /// </summary>
        /// <param name="consSortCode"></param>
        /// <returns></returns>
        public static string GetUserType(string consSortCode)
        {
            string result = string.Empty;

            switch (consSortCode)
            {
                case "00": result = "考核"; break;
                case "01": result = "高压"; break;
                case "0101": result = "分级管理"; break;
                case "0102": result = "台区综合变"; break;
                case "0103": result = "高压负控用户"; break;
                case "02": result = "低压非居民"; break;
                case "0201": result = "低压非居民电卡表用户"; break;
                case "0202": result = "低压非居民网络表用户"; break;
                case "03": result = "低压居民"; break;
                case "0301": result = "低压居民电卡表用户"; break;
                case "0302": result = "低压居民网络表用户"; break;
                case "04": result = "县间结算"; break;
                case "05": result = "趸售"; break;
            }

            return result;
        }

        public static string GetCtlMode(string ctlMode)
        {
            string result = string.Empty;

            switch (ctlMode)
            {
                case "00": result = "考核"; break;
                case "01": result = "高压"; break;
                case "0101": result = "分级管理"; break;
                case "0102": result = "台区综合变"; break;
                case "0103": result = "高压负控用户"; break;
                case "02": result = "低压非居民"; break;
                case "0201": result = "低压非居民电卡表用户"; break;
                case "0202": result = "低压非居民网络表用户"; break;
                case "03": result = "低压居民"; break;
                case "0301": result = "低压居民电卡表用户"; break;
                case "0302": result = "低压居民网络表用户"; break;
                case "04": result = "县间结算"; break;
                case "05": result = "趸售"; break;
            }

            return result;
        }

        /// <summary>
        /// 返回用电类型字典内容
        /// </summary>
        /// <param name="elecTypeCode"></param>
        /// <returns></returns>
        public static string GetElecType(string elecTypeCode)
        {
            string result = string.Empty;

            switch (elecTypeCode)
            {
                case "000": result = "考核"; break;
                case "100": result = "大工业用电"; break;
                case "101": result = "大工业中小化肥"; break;
                case "102": result = "大工业其它优待"; break;
                case "200": result = "居民生活用电"; break;
                case "201": result = "乡村居民生活用电"; break;
                case "202": result = "城镇居民生活用电"; break;
                case "203": result = "中小学教学用电"; break;
                case "204": result = "居民增值税用户"; break;
                case "300": result = "农业生产用电"; break;
                case "301": result = "农业排灌"; break;
                case "302": result = "贫困县农业排灌用电"; break;
                case "400": result = "一般工商业"; break;
                case "401": result = "非居民照明"; break;
                case "402": result = "非工业"; break;
                case "403": result = "普通工业"; break;
                case "404": result = "普通工业中小化肥"; break;
                case "405": result = "商业用电"; break;
                case "500": result = "趸售"; break;
                case "501": result = "趸售大工业"; break;
                case "502": result = "趸售普工、非普工业"; break;
                case "503": result = "趸售非居民"; break;
                case "504": result = "趸售居民生活用电"; break;
                case "505": result = "趸售农业生产用电"; break;
                case "506": result = "趸售商业用电"; break;
                case "800": result = "分布式能源"; break;
                case "801": result = "光伏发电"; break;
                case "802": result = "天然气三联供发电"; break;
                case "803": result = "生物质发电"; break;
                case "804": result = "风力发电"; break;
                case "805": result = "地热发电"; break;
                case "806": result = "海洋能发电"; break;
                case "807": result = "资源综合利用发电（含煤矿瓦斯发电）"; break;
                case "808": result = "光伏补贴"; break;
                case "900": result = "其它用电"; break;
                case "901": result = "大用户直购电"; break;
                case "902": result = "抽水蓄能"; break;
                case "903": result = "售邻省"; break;
                case "904": result = "其他"; break;
            }

            return result;
        }

        /// <summary>
        /// 加载INI中的配置信息
        /// </summary>
        public static void LoadConfig()
        {
            //读取client配置文件
            DevInfo.PrinterPort = Common.ReadIniInt("ClientParam.ini", "ThermalPrinter", "port");
            DevInfo.PrinterBaud = Common.ReadIniInt("ClientParam.ini", "ThermalPrinter", "baud");
            DevInfo.PrinterEnable = Common.ReadIniInt("ClientParam.ini", "ThermalPrinter", "enable");

            DevInfo.CashcodePort = Common.ReadIniInt("ClientParam.ini", "CashCode", "port");
            DevInfo.CashcodeBaud = Common.ReadIniInt("ClientParam.ini", "CashCode", "baud");
            DevInfo.CashcodeEnable = Common.ReadIniInt("ClientParam.ini", "CashCode", "enable");
            Client.Billtype = Common.ReadIniInt("ClientParam.ini", "CashCode", "billtype");

            DevInfo.CardReaderPort = Common.ReadIniInt("ClientParam.ini", "CardReader", "port");
            DevInfo.CardReaderBaud = Common.ReadIniInt("ClientParam.ini", "CardReader", "baud");
            DevInfo.CardReaderEnable = Common.ReadIniInt("ClientParam.ini", "CardReader", "enable");

            DevInfo.MetalKeyboardPort = Common.ReadIniInt("ClientParam.ini", "MetalKeyboard", "port");
            DevInfo.MetalKeyboardBaud = Common.ReadIniInt("ClientParam.ini", "MetalKeyboard", "baud");
            DevInfo.MetalKeyboardEnable = Common.ReadIniInt("ClientParam.ini", "MetalKeyboard", "enable");
            DevInfo.IcReaderPsam = Common.ReadIniInt("ClientParam.ini", "MetalKeyboard", "psam");
            DevInfo.ICDevVendor = Common.ReadIniStr("ClientParam.ini", "ICReader", "devVendor");
            DevInfo.ICReaderPort = Common.ReadIniInt("ClientParam.ini", "ICReader", "port");
            DevInfo.ICReaderBaud = Common.ReadIniInt("ClientParam.ini", "ICReader", "baud");

            DevInfo.returntime = Common.ReadIniInt("ClientParam.ini", "MachineSet", "returntime") * 1000;

            Client.MachineCode = Common.ReadIniStr("ClientParam.ini", "Machine", "machinecode");

            Client.SystemPwd = Common.ReadIniStr("ClientParam.ini", "Software", "systempwd");

            //获取终端IP和Mac
            DevInfo.LocalIP = Common.getLocalIP();
            DevInfo.LocalMac = Common.GetMoAddress();

            //读取营销服务配置
            Global.ServiceIP = Common.ReadIniStr("ClientParam.ini", "MarketingService", "servierip");
            Global.ServicePort = Common.ReadIniInt("ClientParam.ini", "MarketingService", "servierport");
            Global.ClientKey = Common.ReadIniStr("ClientParam.ini", "MarketingService", "clickkey");
            Global.ChanelNo = Common.ReadIniStr("ClientParam.ini", "MarketingService", "chanelno");
            Global.IsEncry = Common.ReadIniInt("ClientParam.ini", "MarketingService", "encryption") == 1;
            Global.HeartbeatTime = Common.ReadIniInt("ClientParam.ini", "MarketingService", "heartbeattime") * 1000;
            Global.DataReported = Common.ReadIniInt("ClientParam.ini", "MarketingService", "datareported") * 1000;
            Global.FtpIP = Common.ReadIniStr("ClientParam.ini", "MarketingService", "ftpip");
            Global.FtpUser = Common.ReadIniStr("ClientParam.ini", "MarketingService", "ftpuser");
            Global.FtpPwd = Common.ReadIniStr("ClientParam.ini", "MarketingService", "ftppwd");
            Global.FtpPort = Common.ReadIniInt("ClientParam.ini", "MarketingService", "ftpport");
            Global.plOrgNo = Common.ReadIniStr("ClientParam.ini", "MarketingService", "plOrgNo");

            //读取注册秘钥
            Global.RegPwd = Common.ReadIniStr("ClientParam.ini", "register", "password");

            DevStatic.intervalMin = Common.ReadIniInt("ClientParam.ini", "Machine", "IntervalCheckDevMin");
            Client.UpdateAppTime = Common.ReadIniInt("ClientParam.ini", "Software", "UpdatAppTime");
            Client.ClientServiceUri = Common.ReadIniStr("ClientParam.ini", "Software", "clientServiceUri");
            Client.Updatesoftname = Common.ReadIniStr("ClientParam.ini", "Software", "updatesoftname");
            PayLogStatic.intervalMin = Common.ReadIniInt("ClientParam.ini", "Machine", "IntervalCheckPayLogMin");
        }
    }
}