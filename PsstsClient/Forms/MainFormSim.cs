using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    /// <summary>
    /// 重要说明，已有现金缴费的窗口界面全部曾加Sim，把原来使用的pictureBox全部去掉使用按钮和内嵌资源图片来实现
    /// 银联相关没改，后续若是贵州银联自助终端使用也必须修改
    /// </summary>
    public partial class MainFormSim : Form
    {
        Main m;

        public MainFormSim()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 后台进程空闲时间进行状态监测和记录补全
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //声音欢迎使用自助服务终端
            SoundUtil.SayWelcome();
        }

        private void btn_pay_cash_Click(object sender, EventArgs e)
        {
            //if (DevInfo.ICReaderEnable != DevStatic.devEnable)
            //{
            //    MessageBox.Show("读卡器未能正常启动");
            //    return;
            //}

            this.Hide();
            Client.FlowType = Client.icflow;
            m.nowformname = this.Name;
            this.btn_pay_cash.Enabled = false;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("InputICCardSim");
        }

        private void MainFormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.CancelAsync();
            }
        }

        private void MainFormSim_Load(object sender, EventArgs e)
        {
            m = (Main)this.Owner;

            DevStatic.AutoCheck = true;
            //btn_pay_cash.Focus();
            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
                this.backgroundWorker1.WorkerSupportsCancellation = true;
            }
        }

        private void MainFormSim_Paint(object sender, PaintEventArgs e)
        {
            lock (Main.objLock)
            {

            }
        }

        private void btn_pay_ic_Click(object sender, EventArgs e)
        {
            //现金缴费
            if (DevInfo.CashcodeEnable != DevStatic.devEnable)
            {
                MessageBox.Show("现金缴费未启用");
                return;
            }
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");
            this.Hide();
            Client.FlowType = Client.nflow;
            
            m.nowformname = this.Name;
            this.btn_pay_cash.Enabled = false;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("IputCustomeridSim");
        }

        private void btn_pay_bank_Click(object sender, EventArgs e)
        {
            Client.FlowType = Client.queryflow;
            Common.ShowWaiting((Main)this.Owner, "载入中,请稍后...");

            this.Hide();
            m.nowformname = this.Name;
            this.btn_pay_cash.Enabled = false;
            this.TopMost = false;
            this.Close();
            m.JmpFrom("IputCustomeridSim");
        }
    }
}