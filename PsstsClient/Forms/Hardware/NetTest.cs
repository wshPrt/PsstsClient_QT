using System;
using System.Windows.Forms;
using System.Net.Sockets;
using PsstsClient.Utility;
using System.Net;

namespace PsstsClient.Forms.Hardware
{
    public partial class NetTest : Form
    {
        private HardwareTest ht = null;

        public NetTest()
        {
            InitializeComponent();
        }

        private void NetTest_Load(object sender, EventArgs e)
        {
            this.tb_serverip.Text = Common.ReadIniStr("register.ini", "server", "serverip");
            this.tb_serverport.Text = Common.ReadIniStr("register.ini", "server", "serverport");

            ht = (HardwareTest)this.Parent.Parent;
            ht.ClearMsg();
            ht.ShowMsg(null, "网络连接测试");
        }

        private void btn_nettest_Click(object sender, EventArgs e)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse(this.tb_serverip.Text.Trim());
            System.Net.Sockets.Socket clientSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, int.Parse(tb_serverport.Text.Trim()))); //配置服务器IP与端口
                ht.ShowMsg("网络测试", "socket连接建立成功");

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch
            {
                ht.ShowMsg("网络测试", "socket连接建立失败");
                return;
            }
        }
    }
}