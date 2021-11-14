using PsstsClient.Bll;
using PsstsClient.Utility;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PsstsClient.Service
{
    public class BaseBusinessService
    {
        //消息类型（业务类型为0x05）
        byte msgType = 0x05;

        //消息加密类型
        byte compEncry = 0x00;

        /// <summary>
        /// 服务端返回数据包体
        /// </summary>
        public List<byte> RecData { get; set; }

        /// <summary>
        /// 唯一ID生成对象
        /// </summary>
        IdWorker idWorker = new IdWorker(1);

        /// <summary>
        /// 是否请求超时
        /// </summary>
        public bool isTimeOut = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseBusinessService()
        {
            RecData = new List<byte>();
        }

        /// <summary>
        /// 注册绑定终端(根据服务端返回秘钥决定，如果秘钥返回失败则绑定失败)
        /// </summary>
        /// <param name="key">终端Key</param>
        /// <returns>绑定结果</returns>
        public bool BindClient(string key)
        {
            bool result = false;

            try
            {
                byte[] bodyData = Encoding.UTF8.GetBytes(key);

                byte[] recData = new byte[1024];

                SocketHelper.Instance.Send(bodyData, 0x02, out recData);

                string _secretKey = Encoding.UTF8.GetString(recData);

                if (!string.IsNullOrEmpty(_secretKey))
                {
                    result = true;
                    Global.SecretKey = _secretKey;
                    Log4NetHelper.Instance.Debug("绑定成功，返回秘钥：" + _secretKey);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("绑定终端异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="msgBody"></param>
        public bool SendData(string msgBody)
        {
            bool result = false;
            isTimeOut = false;

            try
            {
                byte[] bodyData = Encoding.UTF8.GetBytes(msgBody);

                if (Global.IsEncry)
                {
                    bodyData = EncryDecrypt.AESEncrypt(bodyData, Global.SecretKey);
                    compEncry = 0x02;
                }

                byte[] recData = new byte[5120];

                SocketHelper.Instance.Send(bodyData, msgType, out recData, compEncry);

                RecData.AddRange(recData);
                result = true;
            }
            catch (SocketException sEx)
            {
                if (sEx.ErrorCode == 10060)
                {
                    Log4NetHelper.Instance.Error("请求超时，参数：" + msgBody, sEx);
                    isTimeOut = true;
                }

                Log4NetHelper.Instance.Debug("连接错误码：" + sEx.SocketErrorCode.ToString());
                Log4NetHelper.Instance.Debug("Win32错误码：" + sEx.NativeErrorCode.ToString());
                Log4NetHelper.Instance.Error("发送数据异常", sEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("发送数据异常", ex);
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 生成批次号
        /// </summary>
        /// <returns></returns>
        public string GetBatchNo()
        {
            return DateTime.Now.ToString("yyyyMMdd") + "01";
        }

        /// <summary>
        /// 返回请求唯一ID
        /// </summary>
        /// <returns></returns>
        public string GetRequestID()
        {
            return idWorker.nextId().ToString();
        }

        /// <summary>
        /// 以字符串格式返回数据
        /// </summary>
        /// <returns></returns>
        protected string GetRecString()
        {
            string result = Encoding.UTF8.GetString(RecData.ToArray());
            RecData.Clear();

            return result;
        }

        /// <summary>
        /// 以byte[]格式返回数据
        /// </summary>
        /// <returns></returns>
        protected byte[] GetRecData()
        {
            byte[] result = RecData.ToArray();
            RecData.Clear();

            return result;
        }
    }
}
