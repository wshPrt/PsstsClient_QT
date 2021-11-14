using System;
using System.Media;
using System.Windows.Forms;

namespace PsstsClient.Utility
{
    public class SoundUtil
    {
        private static SoundPlayer simpleSound;
        /// <summary>
        /// 请核对您的电能卡信息，正确无误后请选择支付方式
        /// </summary>
        public static void SayCardinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\cardinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请核对您的购电信息，正确无误后点击确认进行写卡
        /// </summary>
        public static void SayCheckcardinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\checkcardinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请核对您的客户信息，正确无误后选择缴费类型
        /// </summary>
        public static void SayCheckcustomerinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\checkcustomerinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请核对您的信息，正确无误后选择支付方式
        /// </summary>
        public static void SayCheckfeeinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\checkfeeinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请核对您的客户信息，正确无误后点欠费缴纳进行缴费，点预收电费进行预收
        /// </summary>
        public static void SayCheckinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\checkinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 提交卡表购电服务中请稍后
        /// </summary>
        public static void SayCommitcardinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\commitcardinfo.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请确认您的支付金额
        /// </summary>
        public static void SayCommitMoney()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\commitMoney.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 正在处理请稍后
        /// </summary>
        public static void SayDobusiness()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\dobusiness.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 您的支付金额不足，本次支付金额将做预存电费处理
        /// </summary>
        public static void SayDobusiness1()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\dobusiness1.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请正确输入您的客户编号并点击确认
        /// </summary>
        public static void SayInputcustomerid()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\inputcustomerid.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请正确输入您的密码并点击确认
        /// </summary>
        public static void SayInputpwd()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\inputpwd.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请正确插入您的电能卡
        /// </summary>
        public static void SayInsertcard()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\insertcard.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 纸币器由红灯变绿后方可投币，请将纸币平整后放入纸币器入口
        /// </summary>
        public static void SayInsertmoney()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\insertmoney.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请正确插入您的银行卡
        /// </summary>
        public static void SayInsertmoneycard()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\insertmoneycard.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 您的电费已结清，如需继续缴费请选择预存电费
        /// </summary>
        public static void SayNofeerecode()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\nofeerecode.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 发票打印完成请取回您的发票
        /// </summary>
        public static void SayOverprintinvoice()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\overprintinvoice.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 凭条打印完成请取回您的凭条
        /// </summary>
        public static void SayOverprintslip()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\overprintslip.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 请核对您的信息正确无误后请选择支付方式
        /// </summary>
        public static void SayPreinfo()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\preinfo.wav");
            simpleSound.Play();

        }
        /// <summary>
        /// 发票打印中请稍后
        /// </summary>
        public static void SayPrintinvoice()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\printinvoice.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 凭条打印中请稍后
        /// </summary>
        public static void SayPrintslip()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\printslip.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 正在读卡请稍后
        /// </summary>
        public static void SayReadcard()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\readcard.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 检测到纸币器入口有纸币，请将纸币取走并选择继续放钞
        /// </summary>
        public static void SayRemovemoney()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\removemoney.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 谢谢使用自助服务终端再见
        /// </summary>
        public static void SaySaygoodbye()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\saygoodbye.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 默认现金支付如需其他支付方式请选择银联支付
        /// </summary>
        public static void SaySelectpaymode()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\selectpaymode.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 欢迎使用电力自助服务终端
        /// </summary>
        public static void SayWelcome()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\welcome.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 正在写卡请稍后
        /// </summary>
        public static void SayWritecard()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\writecard.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 写卡失败请取回您的购电卡
        /// </summary>
        public static void SayWritecardfail()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\writecardfail.wav");
            simpleSound.Play();
        }
        /// <summary>
        /// 写卡成功请取回您的购电卡
        /// </summary>
        public static void SayWritecardsuccess()
        {
            simpleSound = new SoundPlayer(Application.StartupPath + "\\sound\\writecardsuccess.wav");
            simpleSound.Play();
        }
    }
}
