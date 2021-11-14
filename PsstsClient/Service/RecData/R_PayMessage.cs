namespace PsstsClient.Service.RecData
{
    public class R_PayMessage
    {
        /// <summary>
        /// 返回数据主体
        /// </summary>
        public string jsonData { get; set; }

        public string mainLogRecordId { get; set; }

        public string requestId { get; set; }
    }
}
