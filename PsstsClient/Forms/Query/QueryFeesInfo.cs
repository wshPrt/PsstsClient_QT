using PsstsClient.Bll;
using PsstsClient.Forms.Pay;
using PsstsClient.Service;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PsstsClient.Forms.Query
{
    public partial class QueryFeesInfo : Form
    {
        List<R_Fees> feesList;
        int feesCount = 0;
        int dataIndex = 0;
        PayService payService = new PayService();
        R_QueryCustomerInfo customerInfo = new R_QueryCustomerInfo();

        Main m;

        public QueryFeesInfo()
        {
            InitializeComponent();
        }

        public QueryFeesInfo(object[] rObj)
        {
            feesList = new List<R_Fees>();
            customerInfo = (R_QueryCustomerInfo)rObj[0];

            InitializeComponent();
        }

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryFeesInfo_Load(object sender, EventArgs e)
        {
            m = (Main)Owner;

            try
            {
                TimerInit();

                if (!payService.Fees(customerInfo.consNo, customerInfo.orgNo, out feesList) || feesList == null)
                {
                    //未查询到用户信息弹出提示
                    //ShowMsg sm = new ShowMsg("查询异常", "未查询到缴费信息");
                    //sm.ShowDialog();
                    return;
                }

                feesCount = feesList.Count;

                if (feesCount > 1)
                {
                    but_Next.Visible = true;
                }

                SetData();                
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("窗体加载异常", ex);
            }
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
        /// 返回首页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_back_top_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.but_Next.Enabled = false;
            this.but_Prev.Enabled = false;
            this.pb_back_top.Enabled = false;
            this.pb_returnprevious.Enabled = false;
            this.Hide();
            m.nowformname = this.Name;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("MainFormSim");
        }

        /// <summary>
        /// 返回上一页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_returnprevious_Click(object sender, EventArgs e)
        {
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
            this.but_Next.Enabled = false;
            this.but_Prev.Enabled = false;
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
        /// 下一条按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Next_Click(object sender, EventArgs e)
        {
            dataIndex += 1;

            try
            {
                SetData();

                RestNextPrevButton();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("上一条异常", ex);
            }
        }

        /// <summary>
        /// 上一条按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Prev_Click(object sender, EventArgs e)
        {
            dataIndex -= 1;

            try
            {
                SetData();

                RestNextPrevButton();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("下一条异常", ex);
            }
        }

        /// <summary>
        /// 根据索引和数据重置按钮隐藏显示
        /// </summary>
        private void RestNextPrevButton()
        {
            TimerInit();

            if (dataIndex == 0)
            {
                but_Prev.Visible = false;
            }
            else
            {
                but_Prev.Visible = true;
            }

            if ((dataIndex + 1) == feesCount)
            {
                but_Next.Visible = false;
            }
            else
            {
                but_Next.Visible = true;
            }
        }
        #endregion

        /// <summary>
        /// 页面内容赋值
        /// </summary>
        private void SetData()
        {
            lab_ConsNo.Text = feesList[dataIndex].consNo;
            lab_ConsName.Text = feesList[dataIndex].consName;
            lab_OrgName.Text = feesList[dataIndex].orgName;
            lab_PayMode.Text = Global.GetPayMode(feesList[dataIndex].payMode);
            lab_ChargeDate.Text = feesList[dataIndex].chargeDate;
            lab_SettleMode.Text = Global.GetSettleMode(feesList[dataIndex].settleMode);
            lab_RcvAmt.Text = feesList[dataIndex].rcvAmt.ToString("0.00");
        }

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
    }
}