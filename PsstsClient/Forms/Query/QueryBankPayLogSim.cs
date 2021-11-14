using System;
using System.Windows.Forms;
using System.Text;
using System.Data;
using PsstsClient.Utility;
using PsstsClient.Bll;
using PsstsClient.Forms.Pay;
using PsstsClient.Driver;

namespace PsstsClient.Forms.Query
{
    public partial class QueryBankPayLogSim : Form
    {
        private bool capslockon = false;
        DbOperate dboperate = new DbOperate();//实例化一个数据库操作对象,以便对下面数据进行相关的数据库操作

        public QueryBankPayLogSim()
        {
            InitializeComponent();
        }

        private void QueryBankPayLogSim_Load(object sender, EventArgs e)
        {
            TimerInit();
            foreach (Control control in this.Controls)//遍历Form上的所有控件 
            {
                if (control is TextBox)
                {
                    control.Enter += new EventHandler(this.TextboxEnter);
                    control.Click += new EventHandler(this.TextboxClick);
                }
                if (control is Button && control.Name != "btn_ok" && control.Name != "btn_cancle" && control.Name != "btn_record")
                    control.Click += new EventHandler(KeyboardEvent);

            }
            //不允许多选
            this.dgv_detail.MultiSelect = false;


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
            TimerInit();
            this.focustb.Focus();
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
                case "冲正":
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
            this.timer_returnmain.Interval = DevInfo.returntime;
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
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
            String oldpwd = this.tb_queryWhere.Text.Trim();
            if (oldpwd.Length == 0)
            {
                //MessageBox.Show("请正确输入交易流水号或户号!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowMsg sm = new ShowMsg("按户号或流水号查询", "请正确输入交易流水号或户号!");
                sm.ShowDialog();
                return;
            }
            Common.ShowWaiting(this, "正在查询,请稍候...");
            QueryBankPayLogSimLog();
            Common.HideWaiting();
        }



        private void QueryBankPayLogSimLog()
        {
            dgv_detail.Columns.Clear();
            String sql = "select customerid,tradetype,tradetime,trademoney,flowno,traderesult,dealflag,clearflag,spackinfo,rpackinfo,id from unionpayrecord ";
            string sql1 = " where  flowno like '%" + this.tb_queryWhere.Text + "%' or customerid like '%" + this.tb_queryWhere.Text + "%'  order by tradetime desc";
            string sql2 = " where  flowno like '*" + this.tb_queryWhere.Text + "*' or customerid like '*" + this.tb_queryWhere.Text + "*' order by tradetime desc";
            DataTable dt = dboperate.GetDataTable(sql + sql1);
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
                dgv_detail.Columns[0].Width = 120;
                dgv_detail.Columns[1].HeaderText = "类型";
                dgv_detail.Columns[1].Width = 80;
                dgv_detail.Columns[2].HeaderText = "缴费时间";
                dgv_detail.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgv_detail.Columns[2].Width = 180;
                dgv_detail.Columns[3].HeaderText = "金额(元)";
                dgv_detail.Columns[3].DefaultCellStyle.Format = "0.00";
                dgv_detail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_detail.Columns[4].HeaderText = "交易流水号";
                dgv_detail.Columns[4].Width = 80;
                dgv_detail.Columns[5].HeaderText = "缴费结果";
                dgv_detail.Columns[6].Width = 80;
                dgv_detail.Columns[6].HeaderText = "冲正标志";
                dgv_detail.Columns[6].Width = 80;
                dgv_detail.Columns[7].HeaderText = "冲正结果";
                dgv_detail.Columns[7].Width = 200;
                dgv_detail.Columns[8].HeaderText = "发送";
                dgv_detail.Columns[8].Width = 10;
                dgv_detail.Columns[9].HeaderText = "接收";
                dgv_detail.Columns[9].Width = 10;
                dgv_detail.Columns[10].HeaderText = "ID";
                dgv_detail.Columns[10].Width = 10;
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

        private void dgv_detail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int currentRow = this.dgv_detail.CurrentCell.RowIndex;
            dgv_detail.Rows[currentRow].Selected = true;

        }
        /// <summary>
        /// 冲正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_repay_Click(object sender, EventArgs e)
        {
            TimerInit();
        }
        /// <summary>
        /// 往StringBuilder增加内容
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="info"></param>
        private void SbAddInfo(ref StringBuilder sb, object info)
        {
            sb.Append("\r\n");
            sb.Append(info);
        }

        private void btn_record_Click(object sender, EventArgs e)
        {
            
        }
    }
}