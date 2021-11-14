using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PsstsClient.Utility
{
    public class DbOperate
    {
        protected OleDbConnection dbconn;//定义数据库连接对象
        protected OleDbCommand dbcomm = new OleDbCommand();//定义数据库操作对象
        public string dbpath = Application.StartupPath + "\\PsstsClient.mdb";//设置数据库路径,如连接有问题请在前面加上"..\..\",但在发布时要去掉前面的"..\..\"


        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        protected void CreateDbConn()
        {
            try
            {//捕获连接异常
                dbconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbpath + ";; Jet OLEDB:Database Password=dicpsi");//初始化数据库连接对象
                dbcomm.Connection = dbconn;//设置数据库操作对象使用此dbconn对象
                dbconn.Open();//打开数据库连接
            }
            catch (OleDbException ex) //如果出现数据库连接异常,则关闭数据库连接并弹出提示框
            {
                this.CloseDbConn();//关闭数据库连接
                MessageBox.Show("数据连接错误！可能是数据库被删除了，请联系相关技术人员！错误信息[" + ex.Message + "]", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Console.Write(dbex.Message);

            }
            catch (Exception ex) //如果出现其他异常,则关闭数据库连接并弹出提示框
            {
                this.CloseDbConn(); //关闭数据库连接
                MessageBox.Show("数据连接错误！可能是数据库被删除了，请联系相关技术人员！错误信息[" + ex.Message + "]", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        protected void CloseDbConn()
        {
            if (dbconn.State == ConnectionState.Open) //如果数据库为打开状态,则关闭
            {
                dbconn.Close();//关闭数据库连接
            }
            dbconn.Dispose();//释放连接资源
            dbcomm.Dispose();//释放操作资源
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        public void ExcuteSql(string sqlText)
        {
            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型为文本类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                dbcomm.ExecuteNonQuery();//执行操作
            }
            catch (Exception e) //如果出现异常,则提示错误
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("数据库操作错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                CloseDbConn();//关闭连接
            }
        }

        /// <summary>
        /// 判断是否执行成功，返回所影响的行数
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <returns>影响的行数</returns>
        public int ExcuteIntSql(string sqlText)
        {
            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                return dbcomm.ExecuteNonQuery();//执行操作,并返回影响的行数
            }
            catch (Exception)
            {
                //MessageBox.Show("数据库操作错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;//如果出现异常,则返回0
            }
            finally
            {
                CloseDbConn();//关闭连接
            }
        }

        /// <summary>
        /// 返回查询出的单条数字记录结果
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <returns>查询出的数字结果</returns>
        public int ExcuteScrSql(string sqlText)
        {
            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                return Convert.ToInt32(dbcomm.ExecuteScalar());//执行操作,并返回查询出的结果
            }
            catch (Exception)
            {
                return 0;//如果出现异常,则返回0
            }
            finally
            {
                CloseDbConn();//关闭连接
            }
        }

        /// <summary>
        /// 返回查询出的单条文字记录结果
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <returns>查询出的文字结果</returns>
        public string ExcuteStrScrSql(string sqlText)
        {
            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                return dbcomm.ExecuteScalar().ToString();//执行操作,并返回查询出的结果
            }
            catch (Exception)
            {
                return "";//如果出现异常，则返回空字符串
            }
            finally
            {
                CloseDbConn();//关闭连接
            }
        }

        /// <summary>
        /// 返回查询出的数据表
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <returns>查询出的数据表</returns>
        public DataTable GetDataTable(string sqlText)
        {
            OleDbDataAdapter dbdapt = new OleDbDataAdapter();//实例化一个数据缓存适配器
            DataTable dt = new DataTable();//实例化一个数据表

            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                dbdapt.SelectCommand = dbcomm;//执行SQL语句,选择出数据
                dbdapt.Fill(dt);//填充数据表
            }
            catch (Exception)
            {

            }
            finally
            {
                CloseDbConn();//关闭连接
            }
            return dt;//返回查询出的数据表
        }

        /// <summary>
        /// 按指定条数读出的Table数据表
        /// </summary>
        /// <param name="sqlText">传入的SQL</param>
        /// <param name="pre">开始读数据的记录号</param>
        /// <param name="maxcunt">所要读出的最大条数</param>
        /// <returns>返回一数据表</returns>
        public DataTable GetPageDataTable(string sqlText, int pre, int maxcunt)
        {
            OleDbDataAdapter dbdapt = new OleDbDataAdapter();//实例化一个数据缓存适配器
            DataSet ds = new DataSet();//实例化一个数据缓存器
            try
            {//捕获异常
                CreateDbConn();//建立连接
                dbcomm.CommandType = CommandType.Text;//设置操作类型
                dbcomm.CommandText = sqlText;//设置操作的SQL语句
                dbdapt.SelectCommand = dbcomm;//执行操作,选择出数据
                dbdapt.Fill(ds, pre, maxcunt, "db_Table");//按指定的条数填充数据表
            }
            catch (Exception)
            {

            }
            finally
            {
                CloseDbConn();//关闭连接
            }
            return ds.Tables["db_Table"];//返回数据表
        }
    }
}
