using PsstsClient.Bll;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Query
{
    public partial class QueryIndex : Form
    {
        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

        Main m;

        public QueryIndex()
        {
            InitializeComponent();
        }

        public QueryIndex(object[] rObj)
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
        private void QueryIndex_Load(object sender, EventArgs e)
        {
            m = (Main)Owner;

            TimerInit();
        }

        private void QueryIndex_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 返回首页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_back_top_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.pb_back_top.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }

        /// <summary>
        /// 基本信息按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_BasicInfo_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.pb_back_top.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            m.obj = new object[] { customerInfo };
            this.Close();
            m.JmpFrom("QueryBasicInfo");
        }

        /// <summary>
        /// 电费信息按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ElectricChargeInfo_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.pb_back_top.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            m.obj = new object[] { customerInfo };
            this.Close();
            m.JmpFrom("QueryElecInfo");
        }

        /// <summary>
        /// 缴费信息按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_FeesInfo_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.pb_back_top.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            m.obj = new object[] { customerInfo };
            this.Close();
            m.JmpFrom("QueryFeesInfo");
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

        private void but_PowerPurchaseInfo_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.pb_back_top.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            m.obj = new object[] { customerInfo };
            this.Close();
            m.JmpFrom("QueryPowerPurchaseInfo");
        }
    }
}
