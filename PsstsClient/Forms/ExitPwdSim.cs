using PsstsClient.Bll;
using PsstsClient.Forms.Pay;
using PsstsClient.Service;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class ExitPwdSim : Form
    {
        private bool capslockon = false;

        public ExitPwdSim()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 全键盘按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardEvent(object sender, EventArgs e)
        {
            TimerInit();
            string key = ((Button)sender).Text;//获取按钮文本
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
                case "Enter":
                    this.btn_ok_Click(null, null);
                    break;
                case "Backspace":
                    if (this.tb_pwd.Text.Length > 0)
                        this.tb_pwd.Text = this.tb_pwd.Text.Substring(0, this.tb_pwd.Text.Length - 1);
                    break;
                default:
                    //this.focustb.Text = this.focustb.Text.Substring(0, this.focustb.SelectionStart) + key + this.focustb.Text.Substring(this.focustb.SelectionStart, this.focustb.Text.Length - this.focustb.SelectionStart);
                    this.tb_pwd.Text += key;
                    break;
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_user.Text) || string.IsNullOrEmpty(tb_pwd.Text))
            {
                ShowMsg mf = new ShowMsg("登录失败", "操作员账号或者密码不能为空");
                mf.ShowDialog();
                return;
            }

            this.timer_returnmain.Enabled = false;
            this.TopMost = false;

            CommonService commonService = new CommonService();
            string msg = string.Empty;
            if (commonService.ChargeEmpLogin(Global.ClientKey, tb_user.Text, tb_pwd.Text, out msg))
            {
                Global.OpEmpNo = tb_user.Text;
                SysMaintainSim fm = new SysMaintainSim();
                /***********正式使用时请取消注释*************/
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.WindowState = FormWindowState.Normal;
                fm.Width = ScreenInfo.ScreenWidth;
                fm.Height = ScreenInfo.ScreenHeight;
                fm.Owner = Main.allower;
                fm.TopMost = true;
                Common.HideWaiting();
                fm.Show();
                this.Close();
            }
            else
            {
                Common.HideWaiting();
                ShowMsg mf = new ShowMsg("登录失败", msg);
                mf.ShowDialog();
            }
        }
        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            btn_cancle_Click(sender, e);
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void ExitPwdSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_returnmain.Stop();
            timer_returnmain.Dispose();
        }

        private void ExitPwdSim_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)//遍历Form上的所有控件 
            {

                if (control is Button && control.Name != "btn_ok" && control.Name != "btn_cancle")
                    control.Click += new EventHandler(KeyboardEvent);
            }

            TimerInit();
            tb_user.Focus();
        }
    }
}
