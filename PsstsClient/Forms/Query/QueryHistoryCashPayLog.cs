using System;
using System.Windows.Forms;
using System.Data;
using PsstsClient.Utility;
using PsstsClient.Bll;
using PsstsClient.Forms.Pay;

namespace PsstsClient.Forms.Query
{
    public partial class QueryHistoryCashPayLog : Form
    {
        private bool capslockon = false;
        DbOperate dboperate = new DbOperate();
        public QueryHistoryCashPayLog()
        {
            InitializeComponent();
        }

        private void QueryHistoryCashPayLog_Load(object sender, EventArgs e)
        {
          
            TimerInit();
            foreach (System.Windows.Forms.Control control in this.Controls)//遍历Form上的所有控件 
            {              
                if (control is TextBox)
                {
                    control.Enter += new EventHandler(this.TextboxEnter);
                    control.Click += new EventHandler(this.TextboxClick);
                }
                if (control is Button && control.Name != "btn_ok" && control.Name != "btn_cancle" && control.Name != "btn_entry")
                    control.Click += new EventHandler(KeyboardEvent);

            }
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
            dateTimePicker2.Value = DateTime.Now.AddDays(1);

        }
        /// <summary>
        /// 输入框焦点获取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxEnter(object sender, EventArgs e)
        {
            if (this.focustb != (TextBox)sender)
                cursorposition = ((TextBox)sender).Text.Length;
            this.focustb = (TextBox)sender;

        }

        /// <summary>
        /// 输入框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxClick(object sender, EventArgs e)
        {
            TimerInit();
            this.focustb = (TextBox)sender;
            cursorposition = ((TextBox)sender).SelectionStart;
        }
        private TextBox focustb;                //光标所在的textbox
        private int cursorposition = 0;//光标所在位置
        /// <summary>
        /// 全键盘按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardEvent(object sender, EventArgs e)
        {
            this.focustb.Focus();
            TimerInit();
            String key = ((Button)sender).Text;//获取按钮文本
            switch (key)
            {
                case "CapsLock":
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Button)
                        {
                            if (ctrl.Text.Length == 1)
                            {
                                if (capslockon)
                                {
                                    ctrl.Text = ctrl.Text.ToLower();
                                }
                                else
                                {
                                    ctrl.Text = ctrl.Text.ToUpper();
                                }
                            }
                        }
                    }
                    capslockon = !capslockon;
                    break;
                case "Shift":
                    break;
                case "Tab":
                    break;
                case "清空":
                    this.focustb.Text = "";
                    cursorposition = 0;
                    break;
                case "删除":
                    if (this.focustb.SelectionStart > 0)
                    {
                        try
                        {
                            cursorposition = this.focustb.SelectionStart;
                            this.focustb.Text = this.focustb.Text.Substring(0, cursorposition - 1) + this.focustb.Text.Substring(cursorposition, this.focustb.Text.Length - cursorposition);
                            cursorposition = cursorposition - 1;
                        }
                        catch (Exception ex)
                        {
                            Log4NetHelper.Instance.Error(ex.Message, ex);
                        }
                    }
                    break;
                default:
                    cursorposition = this.focustb.SelectionStart;
                    this.focustb.Text = this.focustb.Text.Substring(0, cursorposition)
                                      + key
                                      + this.focustb.Text.Substring(cursorposition, focustb.Text.Length - cursorposition);
                    cursorposition += key.Length;
                    break;
            }
            this.focustb.SelectionStart = cursorposition;
            this.focustb.Focus();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            TimerInit();
            SysMaintainSim fm = new SysMaintainSim();       
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.WindowState = FormWindowState.Normal;
            fm.Width = ScreenInfo.ScreenWidth;
            fm.Height = ScreenInfo.ScreenHeight;
            fm.Owner = Main.allower;
            fm.TopMost = true;         
            fm.Show();
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            TimerInit();
            String oldpwd = this.tb_query.Text.Trim();
            label3.Text = "投币金额";
            label2.Text="交易记录";
            if (oldpwd.Length == 0)
            {
                //MessageBox.Show("请正确输入交易流水号!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowMsg sm = new ShowMsg("查询失败", "请正确输入交易流水号!");
                sm.ShowDialog();
                return;
            }
            QueryHistoryCashPay("");
            QueryMoneyLog("");
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        //交易金额
        private void QueryMoneyLog(String sql)
        {
            Money_detail.Columns.Clear();
            DataTable dt = null;
            //DbOperate dboperate = new DbOperate();
            //dboperate.dbpath = "";
            if (sql == "" || sql.Length <= 0)
            {
                sql = "select customerid,flowno,checktime,checkmoney,dealflag,clearflowno  from cashcoderecord ";
                string sql1 = " where  flowno like '%" + this.tb_query.Text + "%' or customerid like '%" + this.tb_query.Text + "%'  order by tradetime desc";
                string sql2 = " where  flowno like '*" + this.tb_query.Text + "*' or customerid like '*" + this.tb_query.Text + "*' order by tradetime desc";
                dt = dboperate.GetDataTable(sql + sql1);
                if (dt.Rows.Count <= 0)
                    dt = dboperate.GetDataTable(sql + sql2);
            }
            else
            {
                dt = dboperate.GetDataTable(sql);
            }
            
            if (dt != null && dt.Rows.Count > 0)
            {
                Money_detail.DataSource = dt;

                //设置单元格与标题内容居中
                Money_detail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Money_detail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置各列的标题与格式
                Money_detail.Columns[0].HeaderText = "户号";
                Money_detail.Columns[1].HeaderText = "交易流水号";
                Money_detail.Columns[2].HeaderText = "投币时间";
                Money_detail.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                Money_detail.Columns[3].HeaderText = "投币金额";
                Money_detail.Columns[3].DefaultCellStyle.Format = "0.00";
                Money_detail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Money_detail.Columns[4].HeaderText = "处理标志";
                Money_detail.Columns[5].HeaderText = "清机流水号";
                this.label3.Text = "投币：次数[" + dt.Rows.Count + "],合计金额[" + Convert.ToString(dt.Compute("Sum(checkmoney)", "")) + "]元";
            }         
        }

        //清机记录
        private void QueryClearRecord(String sql)
        {
            clear_detail.Columns.Clear();
            if (sql == "" || sql.Length <= 0)
            {
                sql = "select clearno from clearrecord";
            }
            //DbOperate dboperate = new DbOperate();            
            DataTable dt = dboperate.GetDataTable(sql);
            clear_detail.DataSource = dt;
            //设置单元格与标题内容居中
            clear_detail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clear_detail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置各列的标题与格式
            if (dt.Rows.Count > 0)
            {
                clear_detail.Columns[0].HeaderText = "清机批次";
                clear_detail.Columns[0].Width = 200;
                this.label4.Text = "清机记录：总共[" + dt.Rows.Count + "]条";
            }
            
        }

        //交易记录
        private void QueryHistoryCashPay(String path)
        {
            DataTable dt = null;
            //DbOperate dboperate = new DbOperate();
            dboperate.dbpath = Application.StartupPath + "\\DataBaseBak\\" + path + "\\PsstsClient.mdb";

            dgv_detail.Columns.Clear();
            String sql = "select customerid,tradetype,tradetime,trademoney,flowno,traderesult,dealflag,clearflag,clearflowno from cashpayrecord ";//and traderesult=\"失败\"
            string sql1 = " where  flowno like '%" + this.tb_query.Text + "%' or customerid like '%" + this.tb_query.Text + "%'  order by tradetime desc";
            string sql2 = " where  flowno like '*" + this.tb_query.Text + "*' or customerid like '*" + this.tb_query.Text + "*' order by tradetime desc";
            dt = dboperate.GetDataTable(sql + sql1);
            if (dt.Rows.Count <= 0)
                dt = dboperate.GetDataTable(sql + sql2);
            if (dt.Rows.Count > 0)
            {
                dgv_detail.DataSource = dt;
                //设置单元格与标题内容居中
                dgv_detail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_detail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //设置各列的标题与格式
                dgv_detail.Columns[0].HeaderText = "户号";
                dgv_detail.Columns[1].HeaderText = "类型";
                dgv_detail.Columns[1].Width = 50;
                dgv_detail.Columns[2].HeaderText = "缴费时间";
                dgv_detail.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgv_detail.Columns[2].Width = 130;
                dgv_detail.Columns[3].HeaderText = "金额(元)";
                dgv_detail.Columns[3].DefaultCellStyle.Format = "0.00";
                dgv_detail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_detail.Columns[4].HeaderText = "交易流水号";
                dgv_detail.Columns[4].Width = 130;
                dgv_detail.Columns[5].HeaderText = "交易结果";
                dgv_detail.Columns[6].HeaderText = "退款标志";
                dgv_detail.Columns[7].HeaderText = "清机标志";
                dgv_detail.Columns[8].HeaderText = "清机流水号";
                this.label2.Text = "交易记录：笔数[" + dt.Rows.Count + "],合计金额[" + Convert.ToString(dt.Compute("Sum(trademoney)", "")) + "]元";
            }
        }

        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;         
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();  

        }

        private void clear_detail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TimerInit();
            int currentRow = this.clear_detail.CurrentCell.RowIndex;
            string result = clear_detail.CurrentRow.Cells[0].Value.ToString();
            QueryHistoryCashPay(result);
        }

        private void dgv_detail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TimerInit();
            int currentRow = this.dgv_detail.CurrentCell.RowIndex;
            string result = dgv_detail.CurrentRow.Cells[4].Value.ToString();           

            String sql = "select customerid,flowno,checktime,checkmoney,dealflag,clearflowno from cashcoderecord where  flowno= '" + result + "' order by checktime";
            QueryMoneyLog(sql);
        }

        private void btn_entry_Click(object sender, EventArgs e)
        {
            TimerInit();
            string sql = "";
            //String dateTime1 = this.dateTimePicker1.Text.Trim();
            //String dateTime2 = this.dateTimePicker2.Text.Trim();
            DateTime dt = DateTime.Now;
            DateTime dateTime1 = this.dateTimePicker1.Value.Date;           
            DateTime dateTime2 = this.dateTimePicker2.Value.Date;
            //判断日期是否合法（不大于当前日期，两个日期差必须大于0）
            if (dateTime1 > dt || dateTime2 < dateTime1)
            {
                ShowMsg sm = new ShowMsg("选择日期失败", "请选择正确的日期段!");
                sm.ShowDialog();
                return;
            }
            else
            {
                sql = "select clearno from clearrecord where cleartime between #"+dateTime1+"# and #"+dateTime2+"#";
            }

            //加载清机记录表
            QueryClearRecord(sql);
            //交易记录暂定为空
            //QueryHistoryCashPay("");            
        }
      
    }


}
