using PsstsClient.Entity.LocalData;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ExceptionServices;

namespace PsstsClient.Bll
{
    public class B_LocalData
    {
        #region 单例模式
        private static readonly object lockHelper = new object();
        private volatile static B_LocalData _instance = null;

        public static B_LocalData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new B_LocalData();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private DbOperate db = new DbOperate();

        /// <summary>
        /// 写入用户投币记录
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="serialno"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public bool InsertCashRecord(string consNo, string serialno, int money)
        {
            bool result = false;

            try
            {
                string sql = "Insert into cashcoderecord (customerid,machineid,checktime,checkmoney,dealflag,flowno,clearflowno) "
                          + "values ('" + consNo + "','" + Client.MachineCode + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + money.ToString() + ", '否','" + serialno + "','0000000000')";

                result = db.ExcuteIntSql(sql) > 0;
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("写入投币记录异常", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Debug("用户：" + consNo + " 流水号：" + serialno + " 投币：" + money + " 记录写入失败");
                Log4NetHelper.Instance.Error("写入投币记录异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 写入本地购电记录
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="serialno"></param>
        /// <param name="buyType"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public bool InsertTradingRecord(string consNo, string serialno, string batchNo, string buyType, string money)
        {
            bool result = false;

            try
            {
                string sql = "insert into cashpayrecord(customerid,machineid,tradetime,tradetype,flowno,batchno,trademoney,traderesult,dealflag,clearflag,clearflowno,synflag) "
                    + "values('" + consNo + "','" + Client.MachineCode + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + buyType + "','"
                    + serialno + "','" + batchNo + "'," + money + ",'失败','否','否','0000000000',-1)";
                int sqlResult = db.ExcuteIntSql(sql);

                result = sqlResult > 0;
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("写入本地购电记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写入本地购电记录失败", ex);
            }

            return result;
        }

        /// <summary>
        /// 写入本地扫码交易记录
        /// </summary>
        /// <param name="consNo"></param>
        /// <param name="serialno"></param>
        /// <param name="buyType"></param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public bool InsertScanCodePayRecord(string consNo, string serialno, string buyType)
        {
            bool result = false;

            try
            {
                string sql = string.Format("insert into scancodepayrecord (flowno,machineid,tradetime,customerid,tradetype,trademoney,traderesult) values('{0}','{1}','{2}','{3}','{4}',{5},'{6}')", serialno, Client.MachineCode, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), consNo, buyType, 0, "失败");

                int sqlResult = db.ExcuteIntSql(sql);

                result = sqlResult > 0;
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("写入扫码交易记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写入扫码交易记录失败", ex);
            }

            return result;
        }

        /// <summary>
        /// 修改本地扫码交易记录
        /// </summary>
        /// <param name="serialno">流水号</param>
        /// <param name="money">交易金额</param>
        /// <returns></returns>
        public void UpScanCodePayRecord(string serialno, decimal money)
        {
            try
            {
                string sql = "update scancodepayrecord t set t.traderesult = \"成功\" ,t.trademoney=" + money.ToString("0.00") + "  where  t.flowno =\"" + serialno + "\"";

                db.ExcuteIntSql(sql);
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("写入扫码交易记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写入扫码交易记录失败", ex);
            }
        }

        /// <summary>
        /// 修改本地记录为成功
        /// </summary>
        /// <param name="flowNo">流水号</param>
        [HandleProcessCorruptedStateExceptions]
        public void UpTradingRecord(string serialno)
        {
            string sql = "update cashpayrecord t set t.traderesult = \"成功\" ,t.synflag=0  where  t.flowno =\"" + serialno + "\"";
            try
            {
                int upSqlResult = db.ExcuteIntSql(sql);
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("交易成功修改本地记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("交易成功修改本地记录失败", ex);
            }
        }

        /// <summary>
        /// 读取本地现金交易记录
        /// </summary>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public List<CashTranRecord> QueryCashRecord(bool isSucess = false)
        {
            List<CashTranRecord> recordList = null;
            string sql = string.Empty;

            if (isSucess)
            {
                sql = "select * from cashpayrecord where traderesult = '成功'";
            }
            else
            {
                sql = "select * from cashpayrecord";
            }

            try
            {
                DataTable data = db.GetDataTable(sql);

                recordList = DataTableToModel.ToListModel<CashTranRecord>(data);
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("读取本地交易记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("读取本地交易记录失败", ex);
            }

            return recordList;
        }

        /// <summary>
        /// 删除本地现金交易记录
        /// </summary>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public bool DeleteCashRecord()
        {
            bool result = false;
            string sql = "delete from cashpayrecord";

            try
            {
                //删除交易记录
                db.ExcuteIntSql(sql);

                //删除投币记录
                sql = "delete from cashcoderecord";
                db.ExcuteIntSql(sql);
                result = true;
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("读取本地交易记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("读取本地交易记录失败", ex);
            }

            return result;
        }

        /// <summary>
        /// 写入写卡记录
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="serialno">流水号</param>
        /// <param name="writeSucess">写卡结果(true=写卡成功、false=写卡失败)</param>
        /// <param name="isreport">写卡回调结果(true=上报成功、false=上报失败)</param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public bool WriteCatdRecord(string consNo, string serialno, bool writeSucess, bool isreport)
        {
            bool result = false;

            try
            {
                string sql = string.Format("insert into writecardrecord (customerid,flowno,issucess,isreport) values('{0}','{1}',{2},{3})", consNo, serialno, writeSucess, isreport);
                int sqlResult = db.ExcuteIntSql(sql);

                result = sqlResult > 0;
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("写卡结果本地记录写入失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写卡结果本地记录写入失败", ex);
            }


            return result;
        }

        /// <summary>
        /// 修改本地写卡记录
        /// </summary>
        /// <param name="consNo">用户编号</param>
        /// <param name="serialno">流水号</param>
        [HandleProcessCorruptedStateExceptions]
        public void UpWriteCatdRecord(string consNo, string serialno)
        {
            string sql = sql = "update writecardrecord t set t.isreport = true where  t.customerid =\"" + consNo + "\" and serialno = \"" + serialno + "\"";

            try
            {
                int upSqlResult = db.ExcuteIntSql(sql);
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("修改写卡本地记录失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("修改写卡本地记录失败", ex);
            }
        }

        /// <summary>
        /// 查询本地写卡成功上报失败的记录
        /// </summary>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        public List<WriteCardrRcord> QueryWriteCatdRecord()
        {
            List<WriteCardrRcord> recordList = null;
            string sql = "select * from writecardrecord where issucess = true and isreport = false order by datetime asc";

            try
            {
                DataTable data = db.GetDataTable(sql);

                recordList = DataTableToModel.ToListModel<WriteCardrRcord>(data);
            }
            catch (AccessViolationException avex)
            {
                Log4NetHelper.Instance.Error("查询本地写卡结果失败", avex);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("查询本地写卡结果失败", ex);
            }

            return recordList;
        }
    }
}
