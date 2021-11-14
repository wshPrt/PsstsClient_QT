namespace PsstsClient.Bll
{
    public class MemberCommon
    {
        public static int C_ID_LENGTH = 16; //用户编号长度

        public static string RECIEVESTR = "";   //Socket通讯接收到的数据

        public static string USER_ID = "";      //用户编号

        public static string TEMP_USER_ID = "";


        public static char WORDSPLIT = '_';

        public static string TEMPRECIEVESTR = "";

        public static void NULLMEMBER()
        {
            RECIEVESTR = "";
            USER_ID = "";
            TEMPRECIEVESTR = "";
        }
    }
}
