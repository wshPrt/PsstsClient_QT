using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class ShowWaiting : Form
    {
        public ShowWaiting()
        {
            InitializeComponent();
        }

        public static string showmsg = "";
        System.Timers.Timer timer;
        private delegate void setText();//定义一个线程委托
        public static int showtime = 60;
        private int closeTimeout = 0;
        setText ding; //实例化一个委托
        setText ded; //实例化一个委托

        public ShowWaiting(Control ctl, string Msg)
        {
            InitializeComponent();
            showmsg = Msg;
            InitTimeout();
            closeTimeout = 1;
            this.Size = ctl.Size;
            this.Location = new Point(ctl.Location.X, ctl.Location.Y);
            this.label1.Location = new Point((ctl.Size.Width - this.label1.Size.Width) / 2, ctl.Height / 2 + 70);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="Msg"></param>
        /// <param name="timeOut"></param>
        public ShowWaiting(Control ctl, string Msg, int timeOut)
        {
            InitializeComponent();
            showmsg = Msg;
            showtime = timeOut;
            closeTimeout = 1;
            this.Size = ctl.Size;
            this.Location = new Point(ctl.Location.X, ctl.Location.Y);
            this.label1.Location = new Point((ctl.Size.Width - this.label1.Size.Width) / 2, ctl.Height / 2 + 70);
        }

        /// <summary>
        /// 初始化加载等待的时间
        /// </summary>
        public static void InitTimeout()
        {

            if (DevInfo.returntime <= 0)
            {
                InitTimeout();
            }
            else
                showtime = DevInfo.returntime / 1000 + 10;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowWaiting_Load(object sender, EventArgs e)
        {
            this.label1.Text = showmsg;
            this.label1.Text = showmsg;
            ding = new setText(Threading); //实例化一个委托
            ded = new setText(Threaded); //实例化一个委托 
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        public void Threading()
        {
            this.label1.Text = "[" + showtime + "S]" + showmsg;
            this.TopMost = true;

        }

        public void Threaded()
        {
            if (this.timer != null)
                this.timer.Stop();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                showtime--;
                if (showtime >= 0)
                {
                    this.Invoke(ding); //在拥用此控件的基础窗体句柄的线程上执行指定的委托
                }
                else
                {
                    this.Invoke(ded); //在拥用此控件的基础窗体句柄的线程上执行指定的委托
                }

            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error(ex.Message, ex);
                if (this.timer != null)
                    this.timer.Stop();
            }
        }

        private void ShowWaiting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.timer != null)
                this.timer.Stop();
        }
    }
}
