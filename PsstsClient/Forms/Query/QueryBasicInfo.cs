using PsstsClient.Bll;
using PsstsClient.Forms.Pay;
using PsstsClient.Service;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Query
{
    public partial class QueryBasicInfo : Form
    {
        ArchivesService archivesService = new ArchivesService();

        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

        Main m;

        public QueryBasicInfo()
        {
            InitializeComponent();
        }

        public QueryBasicInfo(object[] rObj)
        {
            customerInfo = (R_QueryCustomerInfo)rObj[0];

            InitializeComponent();
        }

        #region 窗体事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashQuerySim_Load(object sender, EventArgs e)
        {
            m = (Main)Owner;

            R_QueryCustomerInfo queryCustomerInfo = new R_QueryCustomerInfo();
            if (!archivesService.QueryCustomerInfo(customerInfo.consNo, out queryCustomerInfo) || queryCustomerInfo == null)
            {
                //未查询到用户信息弹出提示
                ShowMsg sm = new ShowMsg("查询异常", "未查询到相关信息");
                sm.ShowDialog();
                return;
            }

            TimerInit();

            lab_ConsNo.Text = queryCustomerInfo.consNo;
            lab_ConsName.Text = queryCustomerInfo.consName;
            lab_MobleNo.Text = queryCustomerInfo.mobile;
            lab_ElecAddr.Text = queryCustomerInfo.elecAddr;
            lab_ConsSortCode.Text = Global.GetUserType(queryCustomerInfo.consSortCode);
            lab_OrgNo.Text = queryCustomerInfo.orgName;
            lab_ElecTypeCode.Text = Global.GetElecType(queryCustomerInfo.elecTypeCode);
            lab_MadeNo.Text = queryCustomerInfo.madeNo;
            lab_PrepayBal.Text = queryCustomerInfo.prepayBal;
        }

        private void CashQuerySim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 返回上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_returnprevious_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
            this.pb_returnprevious.Enabled = false;
            this.pb_back_top.Enabled = false;
            this.timer_returnmain.Enabled = false;

            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            m.obj = new object[] { customerInfo };
            this.Close();
            m.JmpFrom("QueryIndex");
        }

        /// <summary>
        /// 返回首页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_back_top_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
            this.pb_back_top.Enabled = false;
            this.pb_returnprevious.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }
        #endregion

        #region 超时定时器
        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        /// <summary>
        /// 时间到超时返回上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            timer_returnmain.Enabled = false;
            this.pb_back_top_Click(sender, e);
        }
        #endregion
    }
}
