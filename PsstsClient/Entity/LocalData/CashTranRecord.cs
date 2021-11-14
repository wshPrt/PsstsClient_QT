using System;

namespace PsstsClient.Entity.LocalData
{
    /// <summary>
    /// 本地现金交易记录实体
    /// </summary>
    public class CashTranRecord
    {
        /// <summary>
        /// 缴费户号
        /// </summary>
        public string customerid { get; set; }

        /// <summary>
        /// 缴费终端编号
        /// </summary>
        public string machineid { get; set; }

        /// <summary>
        /// 缴费时间
        /// </summary>
        public DateTime tradetime { get; set; }

        /// <summary>
        /// 缴费类型（缴费、购电）
        /// </summary>
        public string tradetype { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string flowno { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string batchno { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        public double trademoney { get; set; }

        /// <summary>
        /// 交易结果（成功、失败）
        /// </summary>
        public string traderesult { get; set; }

        /// <summary>
        /// 处理标志（是、否）
        /// </summary>
        public string dealflag { get; set; }

        /// <summary>
        /// 清机标志（是、否）
        /// </summary>
        public string clearflag { get; set; }

        /// <summary>
        /// 清机流水号
        /// </summary>
        public string clearflowno { get; set; }

        /// <summary>
        /// 同步标记 0 未同步 1 同步
        /// </summary>
        public int synflag { get; set; }
    }
}
