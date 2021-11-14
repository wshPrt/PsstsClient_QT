using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using PsstsClient.Utility;
using PsstsClient.Bll;
using PsstsClient.Forms.Pay;

namespace PsstsClient.Forms.Query{
    public partial class RecoverVersionSim : Form
    {
        private static double chargeVersion = 0.0;
        DbOperate dboperate = new DbOperate();

        public RecoverVersionSim()
        {
            InitializeComponent();           
        }

        private void RecoverVersionSim_Load(object sender, EventArgs e)
        {
            TimerInit();
            //加载终端升级记录
            QueryUpdateRecord();
        }

        private void TimerInit()
        {
            this.timer_returnmain.Enabled = false;
            this.timer_returnmain.Interval = DevInfo.returntime;
            this.timer_returnmain.Enabled = true;
        }

        private void timer_returnmain_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            Main m = (Main)Main.allower;
            m.TopMost = true;
            m.Show();
            this.Close();
        }

        //返回主界面
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            TimerInit();
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

        //恢复终端版本
        private void btn_recover_click(object sender, EventArgs e)
        {
            //获取当前版本，与选择的版本进行比较
            double nowVersion = Double.Parse(Client.thisVersion.Trim());
            
            if(chargeVersion == nowVersion)
            {                
                Common.WriteIniStr("ClientParam.ini", "Software", "softcanupdate", "1");
                Common.WriteIniStr("ClientParam.ini", "Software", "modifyflag", "0");
                Common.HideWaiting();
                this.TopMost = false;
                ShowCommit sc = new ShowCommit("请确认是否恢复?", "是:自动恢复!否:暂不恢复!");
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.Yes)
                {
                    runApp();
                }
                else
                {
                    this.TopMost = true;
                }
            }
            else 
            {
                ShowMsg sm = new ShowMsg("对不起，不允许跨版本恢复", "请重新选择！");
                sm.ShowDialog();
            }
        }

        //获取终端升级记录
        private void QueryUpdateRecord()
        {
            dgv_detail.Columns.Clear();
            DataTable dt = null;

            String sql = "select updateflow,oldversion,newversion,updatetime,updateload from updaterecord order by updatetime desc";
            dt = dboperate.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_detail.DataSource = dt;
                //设置单元格与标题内容居中
                dgv_detail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_detail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //设置各列的标题与格式
                dgv_detail.Columns[0].HeaderText = "升级批次";
                dgv_detail.Columns[0].Width = 110;
                dgv_detail.Columns[1].HeaderText = "原版本号";               
                dgv_detail.Columns[2].HeaderText = "新版本号";               
                dgv_detail.Columns[3].HeaderText = "升级时间";
                dgv_detail.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgv_detail.Columns[3].Width = 160;
                dgv_detail.Columns[4].HeaderText = "备份路径";
                dgv_detail.Columns[4].Width = 160;
            }
        }

        //鼠标点击升级记录单击事件
        private void dgv_detail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TimerInit();
            int currentRow = this.dgv_detail.CurrentCell.RowIndex;
            string result = dgv_detail.CurrentRow.Cells[2].Value.ToString().Trim();
            string recoverload = dgv_detail.CurrentRow.Cells[4].Value.ToString();
            //写入配置文件
            Common.WriteIniStr("ClientParam.ini", "Software", "recoverload", recoverload);
            chargeVersion = Double.Parse(result);
        }

        private void runApp()
        {
            //关闭本程序，启动客户端主程序
            String mainExe = Environment.CurrentDirectory + "\\" + Client.Updatesoftname + ".exe";
            if (!File.Exists(mainExe))
            {
                mainExe = Environment.CurrentDirectory + "\\ClientUpdate.exe";
                if (!File.Exists(mainExe))
                {
                    MessageBox.Show("自助终端恢复程序丢失，请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            SystemAPI.HideTask(false);
            System.Diagnostics.Process.Start(mainExe);
            this.Close();
        }   
    }
}
