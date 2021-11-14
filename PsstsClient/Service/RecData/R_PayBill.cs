using System.Collections.Generic;

namespace PsstsClient.Service.RecData
{
    /// <summary>
    /// 后付费用户缴费凭据打印
    /// </summary>
    public class R_PayBill
    {
        /// <summary>
        /// 供电单位编号
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 供电单位名称
        /// </summary>
        public string orgName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string consNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string consName { get; set; }

        /// <summary>
        /// 用电地址
        /// </summary>
        public string elecAddr { get; set; }

        /// <summary>
        /// 总电量（所缴纳电费对应的总电量。后付费缴纳预收电费，不需要返回）
        /// </summary>
        public int talPq { get; set; }

        /// <summary>
        /// 总电费（所缴纳电费对应的总电费。后付费缴纳预收电费，不需要返回）
        /// </summary>
        public double rcvblAmtTal { get; set; }

        /// <summary>
        /// 本次缴费金额（本次缴纳的电费金额）
        /// </summary>
        public double rcvAmt { get; set; }

        /// <summary>
        /// 本次预收（本次缴纳后，除缴纳欠费的部分，余下的部分金额。）
        /// </summary>
        public double prepayAmt { get; set; }

        /// <summary>
        /// 用电详情
        /// </summary>
        public List<OweDetail> oweDetailList { get; set; }
    }

    public class OweDetail
    {
        /// <summary>
        /// 电费年月
        /// </summary>
        public string rcvblYm { get; set; }

        /// <summary>
        /// 用电类别（后付费缴纳预收电费，不需要返回）
        /// </summary>
        public string elecTypeCode { get; set; }

        /// <summary>
        /// 上次示数（该笔电费中电能表对应的有功总的示数，后付费缴纳预收电费，不需要返回）
        /// </summary>
        public double lastMrNum { get; set; }

        /// <summary>
        /// 本次示数（该笔电费中电能表对应的有功总的示数，后付费缴纳预收电费，不需要返回）
        /// </summary>
        public double thisRead { get; set; }

        /// <summary>
        /// 本次电量（该笔电费中电能表对应的有功总的抄见电量，后付费缴纳预收电费，不需要返回）
        /// </summary>
        public int thisReadPQ { get; set; }

        /// <summary>
        /// 用电类别（该笔电费对应的总电量。后付费缴纳预收电费，不需要返回）
        /// </summary>
        public int tpq { get; set; }

        /// <summary>
        /// 总电费（该笔电费对应的总电费。后付费缴纳预收电费，不需要返回）
        /// </summary>
        public double rcvblAmt { get; set; }
    }
}
