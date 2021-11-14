using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class ChangePwdSim : Form
    {
        private bool capslockon = false;

        public ChangePwdSim()
        {
            InitializeComponent();
        }

        private void ChangePwdSim_Load(object sender, EventArgs e)
        {
            TimerInit();
            foreach (System.Windows.Forms.Control control in this.Controls)//遍历Form上的所有控件 
            {
                if (control is TextBox)
                {
                    control.Enter += new EventHandler(this.TextboxEnter);
                    control.Click += new EventHandler(this.TextboxClick);
                    control.TextChanged += new EventHandler(this.TextBoxChanged);
                }
                if (control is Button && control.Name != "btn_ok" && control.Name != "btn_cancle")
                    control.Click += new EventHandler(KeyboardEvent);

            }
        }
        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }
        /// <summary>
        /// 文本改变时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxChanged(object sender, EventArgs e)
        {
            TextBox thisTb = ((TextBox)sender);
            int len = thisTb.Text.Trim().Length;
            if (len >= thisTb.MaxLength)
            {
                thisTb.Text = thisTb.Text.Substring(0, thisTb.MaxLength);
            }
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
                case "Enter":
                    this.btn_ok_Click(null, null);
                    break;
                case "Backspace":
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
            
        }
        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            timer_returnmain.Enabled = false;
            this.TopMost = false;
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();
        }
    }
}