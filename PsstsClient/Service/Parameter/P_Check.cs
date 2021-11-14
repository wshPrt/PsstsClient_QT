namespace PsstsClient.Service.Parameter
{
    /// <summary>
    /// 对账服务传入参数实体
    /// </summary>
    public class P_Check
    {
        /// <summary>
        /// 缴费分类
        /// </summary>
        public string cardFlag { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string settleMode { get; set; }

        /// <summary>
        /// 帐务日期
        /// </summary>
        public string acctDate { get; set; }

        /// <summary>
        /// 解款人员工号
        /// </summary>
        public string cashchkEmpNo { get; set; }

        /// <summary>
        /// 电力单位代码
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string batchNo { get; set; }

        /// <summary>
        /// 缴费金额
        /// 不包括被冲正的交易;
        /// 电费金额+违约金+本次调尾-上次调尾
        /// </summary>
        public string rcvAmtSum { get; set; }

        /// <summary>
        /// 缴费总笔数
        /// </summary>
        public string recordNum { get; set; }
    }
}
