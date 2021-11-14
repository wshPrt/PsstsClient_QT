using PsstsClient.Forms;

namespace PsstsClient.Bll
{
    public class Forms
    {
        /// <summary>
        /// 获取或设置主界面
        /// </summary>
        public static MainFormSim Mainform { get; set; }

        /// <summary>
        /// 获取或设置设置密码输入界面
        /// </summary>
        public static ExitPwdSim Exitpwd { get; set; }

        /// <summary>
        /// 获取或设置设置操作等待界面
        /// </summary>
        public static ShowWaiting ShowWaiting { get; set; }
    }
}
