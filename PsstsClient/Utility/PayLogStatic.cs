using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PsstsClient.Utility
{
    public class PayLogStatic
    {
        //static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 最后一次检测时间
        /// </summary>
        public static long LastCheckTime = 0;

        /// <summary>
        /// 间隔1分钟检测一次，每分钟同步一下交易记录
        /// </summary>
        public static int intervalMin = 1;
        
        /// <summary>
        /// 数据转移，防止银联交易数据存储过大，进行转存到其他表
        /// </summary>
        private static void DataTransfer()
        {
            string YYYY = DateTime.Now.Year.ToString("0000");
            string MM = DateTime.Now.Month.ToString("00");
            string YYYYMM = YYYY + MM;
            string bakDirPath = Environment.CurrentDirectory + "\\DataBaseBak\\";
            //目录不存在则先创建
            if (!Directory.Exists(bakDirPath))
            {
                Directory.CreateDirectory(bakDirPath);
            }
            string bakFile = bakDirPath + YYYY + ".mdb";
            string dbpath = Application.StartupPath + "\\PsstsClient.mdb";//设置数据库路径,如连接有问题请在前面加上"..\..\",但在发布时要去掉前面的"..\..\"
                                                                               //不存在则拷贝，拷贝完则删除上一年的记录
            if (!File.Exists(@bakFile))
            {
                File.Copy(dbpath, bakFile, true);
                string delsql = "delete * from unionpayrecord where tradetime<#" + YYYY + "/12/31#";

            }
        }

        /// <summary>
        /// 同步银联中心的记录同步现金记录的dt转字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static string bankDtToString(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr2 in dt.Rows)
            {
                sb.Append(dr2["flowno"]);
                sb.Append("|");
                sb.Append(dr2["customerid"]);
                sb.Append("|");
                if ("供电缴费".Equals(dr2["tradetype"]))
                {
                    sb.Append("1");
                }
                else if ("预存缴费".Equals(dr2["tradetype"]))
                {
                    sb.Append("2");
                }
                sb.Append("|");
                sb.Append(dr2["trademoney"]);
                sb.Append("|");
                sb.Append(((DateTime)(dr2["tradetime"])).ToString("yyyy-MM-dd hh:mm:mm"));
                sb.Append("|");
                sb.Append(dr2["traderesult"]);
                sb.Append("|");
                sb.Append(dr2["dealflag"]);
                sb.Append("|");
                sb.Append(dr2["clearflag"]);
                sb.Append("#");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 同步现金记录的dt转字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static string dtToString(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr2 in dt.Rows)
            {
                sb.Append(dr2["flowno"]);
                sb.Append("|");
                sb.Append(dr2["customerid"]);
                sb.Append("|");
                sb.Append("0");
                sb.Append("|");
                sb.Append(dr2["trademoney"]);
                sb.Append("|");
                sb.Append(((DateTime)(dr2["tradetime"])).ToString("yyyy-MM-dd hh:mm:mm"));
                sb.Append("|");
                if ("成功".Equals(dr2["traderesult"]))
                {
                    sb.Append("00");
                }
                else if ("失败".Equals(dr2["traderesult"]))
                {
                    sb.Append("06");
                }
                sb.Append("|");
                if ("是".Equals(dr2["clearflag"]))
                {
                    sb.Append("1");
                }
                else if ("否".Equals(dr2["clearflag"]))
                {
                    sb.Append("0");
                }
                sb.Append("|");
                sb.Append(dr2["clearflowno"]);
                sb.Append("#");
            }
            return sb.ToString();
        }
    }
}
