using System.Collections;

namespace PsstsClient.Entity
{
    public class BaseDataEntity
    {
        /// <summary>
        /// 请求唯一ID,此ID同一个客户端不能重复，用力区分请求返回对应数据
        /// </summary>
        public string requestId { get; set; }

        /// <summary>
        /// 业务服务标识
        /// </summary>
        public string businessType { get; set; }

        /// <summary>
        /// 业务服务子标识，与业务标识组合后表示某一个业务接口
        /// </summary>
        public string businessMethod { get; set; }

        public string jsonData { get; set; }
    }
}
