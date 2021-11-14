namespace PsstsClient.Entity
{
    public class RecMessageEntity
    {
        public string businessMethod { get; set; }
        public string businessType { get; set; }
        public string error { get; set; }
        public string requestId { get; set; }
        public string status { get; set; }
        public object jsonData { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public bool result { get; set; }
    }
}
