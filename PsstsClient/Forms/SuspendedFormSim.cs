using System;
using System.Windows.Forms;

namespace PsstsClient.Forms
{
    public partial class SuspendedFormSim : Form
    {
        private int exittime = -1;
        private string exitcode = "";
     
        public SuspendedFormSim()
        {
            InitializeComponent();           
        }

        private void SuspendedFormSim_Shown(object sender, EventArgs e)
        {
           
        }
        private void SuspendedFormSim_Load(object sender, EventArgs e)
        {
         
        }
       

        private void btn_exit1_Click(object sender, EventArgs e)
        {
            exitcode += "1";
            exittime = 20;                  
          
        }

        private void btn_exit2_Click(object sender, EventArgs e)
        {
            exitcode += "2";
            exittime = 20;
        }

        private void btn_exit3_Click(object sender, EventArgs e)
        {
            exitcode += "3";
            exittime = 20;
        }

        private void btn_exit4_Click(object sender, EventArgs e)
        {
            if (exitcode == "123")
            {
                this.TopMost = false;
                Main m = (Main)Main.allower;
                m.TopMost = true;
                m.Show();
                this.Close(); 
            }
            else
            {
                exitcode = "";
            }
        } 
      

        ///测试
        #region
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            I8583 i8583 = new I8583();
            i8583.InitTab();
            i8583.SetTab(3, "000000");                      //交易处理码

                i8583.SetTab(4, "10");            //交易金额,单位分





            i8583.SetTab(11, Bank.GetBankFlow());     //受卡方跟踪号
            i8583.SetTab(22, "021");               //服务点输入方式码
            i8583.SetTab(25, "00");               //服务点条件码
            i8583.SetTab(26, "06");                  //服务点获取码
            //正式使用时请取消注释
            i8583.SetTab(35, "11");               //磁道二数据
            i8583.SetTab(36, "22");               //磁道三数据
            //============
            i8583.SetTab(41, BankInfo.ClientId);        //终端号
            i8583.SetTab(42, BankInfo.MerchantNo);       //供电局商户号
            i8583.SetTab(49, "156");                    //纸币类型为人民币
            i8583.SetTab(52, "1234567812345678"); //PIN密文

            //修改 
            i8583.SetTab(53, "1600000000000000");       //ANSI X9.8 Format（不带主账号信息） 双倍长密钥
            i8583.SetTab(60, "22" + BankInfo.BateNum);            //交易类型码 22 + 批次号 

            Byte[] iii = i8583.Pack8583("0200");
            iii[9] = 0x11;
            Byte[] Mab;

            //测试数据 
            // String s = " 02 00 30 20 04 C0 30 C0 98 11 00 00 00 00 00 00 00 00 01 00 10 68 02 10 00 06 37 62 22 02 36 02 03 23 36 45 5D 49 12 12 04 05 99 91 01 60 01 04 99 62 22 02 36 02 03 23 36 45 5D 15 61 56 00 00 00 00 00 00 00 03 40 59 99 21 60 00 04 91 20 00 00 00 00 00 00 00 00 00 00 D0 00 00 00 00 00 0D 00 00 00 00 38 31 34 30 31 30 35 34 38 39 38 34 36 30 31 38 33 39 38 30 30 30 32 31 35 36 AF 02 90 CA A9 92 AC F5 16 00 00 00 00 00 00 00 00 08 22 00 01 29";
            // s = s.Replace(" ","");

            //请取消注释=============
            String mac_socu = Common.ToHexStringNoBlank(iii, iii.Length);
            if (mac_socu == "") return  ;


           // DriverCommon.MetalKeyboardDriver.LoadWorkkey(BankInfo.MainKeyNo, "5B993D48BD3271B1", "");
            String str = "02 00 30 20 04 C0 30 C0 98 11 00 00 00 00 00 00 00 00 10 00 00 50 02 10 00 06 37 62 22 02 36 02 03 77 47 42 5D 49 12 12 06 00 99 91 50 30 01 04 99 62 22 02 36 02 03 77 47 42 5D 15 61 56 00 00 00 00 00 00 00 03 60 09 99 21 60 00 04 91 20 00 00 00 00 00 00 00 00 00 00 D0 00 00 00 00 00 0D 00 00 00 00 38 31 34 30 31 30 35 34 38 39 38 34 36 30 31 38 33 39 38 30 30 30 32 31 35 36 00 DA 23 66 45 78 79 30 16 00 00 00 00 00 00 00 00 08 22 00 01 29";
            str = str.Replace(" ", "");


            int tmp = str.Length % 16;

            if (tmp != 0)
            {
                for (int i = 0; i < 16 - tmp; i++)
                {
                    str += "0";
                }
            }
            string xor_str = "";
            xor_str = str.Substring(0, 16);
            int len = str.Length;
            for (int i = 0; i < len / 16 - 1; i++)
            {
                xor_str = GetXor(xor_str, str.Substring(i * 16 + 16, 16));
            }

            byte[] xor_byte = System.Text.Encoding.Default.GetBytes(xor_str);
            String xor_str1 = Common.ToHexString(xor_byte).Replace(" ", "");
            Byte[] kcv_tmp = new Byte[64];
            MetalKeyboardAPI.ZT_EPP_SetDesPara(1,20);
            DriverCommon.MetalKeyboardDriver.ActivateWorkkey(0,1);
            MetalKeyboardAPI.ZT_EPP_PinAdd(1, 0, xor_str1.Substring(0,16), kcv_tmp);
            String kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim();

            String xor_end = GetXor(xor_str1.Substring(16), kcv_out).Replace(" ","");

            MetalKeyboardAPI.ZT_EPP_SetDesPara(1, 20);
            DriverCommon.MetalKeyboardDriver.ActivateWorkkey(0, 1);
            MetalKeyboardAPI.ZT_EPP_PinAdd(1, 0, xor_end, kcv_tmp);
            kcv_out = System.Text.Encoding.Default.GetString(kcv_tmp).Split('\0')[0].Trim();
            MessageBox.Show(kcv_out);

        }

        /// <summary>
        /// 进行异或运算，并返回八个字节BABE893344556677
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        private String GetXor(String data1, String data2)
        {

            data1 = new string(data1.Replace(" ", "").ToCharArray(), 0, 16);
            data2 = new string(data2.Replace(" ", "").ToCharArray(), 0, 16);

            byte[] bTmpBuf1 = new byte[8];
            byte[] bTmpBuf2 = new byte[8];
            bTmpBuf1 = StringToByte(data1);
            bTmpBuf2 = StringToByte(data2);

            Byte[] retu = new Byte[bTmpBuf1.Length];

            for (int i = 0; i < bTmpBuf1.Length; i++)
            {
                retu[i] = (byte)(bTmpBuf1[i] ^ bTmpBuf2[i]);
            }
            return Common.ToHexString(retu).Replace(" ", "");


        }

        /// <summary>
        /// 类型为B的转换成Byte数组
        /// 长度不足右补零
        /// 例如 124fe 转换成 0x12,0x4f,0xe0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private byte[] StringToByte(string str)
        {
            string str_tmp = "";
            char c;
            //删除非 A-F, 0-9, 字符
            for (int i = 0; i < str.Length; i++)
            {
                c = str[i];
                if (Uri.IsHexDigit(c))
                    str_tmp += c;
            }
            // 如果长度与传进来的不符，调整字符串
            if (str.Length % 2 != 0)
            {
                str_tmp += "0";
            }

            int byteLength = str_tmp.Length / 2;
            byte[] bytes = new byte[byteLength];
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = BitConverter.GetBytes(HexValue(str_tmp[j]) * 16 + HexValue(str_tmp[j + 1]))[0];
                j = j + 2;
            }
            return bytes;
        }

        private int HexValue(char a)
        {
            switch (a)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'a':
                case 'A':
                    return 10;
                case 'b':
                case 'B':
                    return 11;
                case 'c':
                case 'C':
                    return 12;
                case 'd':
                case 'D':
                    return 13;
                case 'e':
                case 'E':
                    return 14;
                case 'f':
                case 'F':
                    return 15;
                default:
                    return 0;
            }
        }
         */
        #endregion

    }
}
