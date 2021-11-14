using System;
using System.Windows.Forms;

namespace PsstsClient.Forms.Pay
{
    public partial class ShowMsg : Form
    {
        private int atout = 20;
        private string msgTxt2 = "";

        public ShowMsg()
        {
            InitializeComponent();
        }

        public ShowMsg(string msg1, string msg2)
        {
            InitializeComponent();
            this.lb_msg1.Text = msg1;
            this.lb_msg2.Text = msg2;
            msgTxt2 = msg2;
        }

        private void ShowMsg_Load(object sender, EventArgs e)
        {
            this.timer_returnmain.Interval = 1000;
            this.timer_returnmain.Enabled = true;
            this.lb_msg1.Parent = this.pb_background;
            this.lb_msg2.Parent = this.pb_background;
            this.TopMost = true;
            atout = 30;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            if (atout > 0)
            {
                atout--;
                this.lb_msg2.Text = msgTxt2 + "\r\n\r\n[" + atout + "S]自动：确定 \r\n\r\n ";
                this.TopMost = true;
            }
            else
            {
                this.btn_ok_Click(sender, e);
                timer_returnmain.Enabled = false;
            }

        }
    }
}
