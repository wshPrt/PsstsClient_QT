using System;

namespace PsstsClient.Entity.LocalData
{
    public class WriteCardrRcord
    {
        /// <summary>
        /// 主键（自动编号）
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string customerid { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string flowno { get; set; }

        /// <summary>
        /// 写卡结果
        /// </summary>
        public int issucess { get; set; }

        /// <summary>
        /// 是否上报(调用服务端写卡回调服务，若返回成功则修改为True)
        /// </summary>
        public int isreport { get; set; }

        /// <summary>
        /// 写卡时间
        /// </summary>
        public DateTime datetime { get; set; }
    }
}
