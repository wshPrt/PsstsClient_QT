using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace PsstsClient.Utility
{
    public class SocketHelper
    {
        TcpClient tcpClient;

        /// <summary>
        /// 头标志
        /// </summary>
        byte[] headLogo = new byte[4] { 0x00, 0x85, 0x24, 0x56 };

        //包体长度
        byte[] bodyLength = new byte[4];

        //报文长度偏移量
        int lenBodyOffset = 6;

        //报文偏移量
        int bodyOffset = 10;

        //加密类型偏移量
        int compEncryOffset = 5;

        //消息类型偏移量
        int msgTypeOffset = 4;

        //消息类型（业务类型为0x05）
        //byte msgType = 0x05;

        /// <summary>
        /// 完整数据包
        /// </summary>
        List<byte> packageData = new List<byte>();

        #region 单例模式
        private static readonly object lockHelper = new object();
        private volatile static SocketHelper _instance = null;

        public static SocketHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SocketHelper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        public TcpClient GetTcpClient { get { return tcpClient; } }

        private SocketHelper()
        {
            try
            {
                if (tcpClient == null)
                    tcpClient = new TcpClient();

                Connect();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("连接异常", ex);
            }
        }

        public void Connect()
        {
            if (tcpClient.Client == null)
                tcpClient = new TcpClient();

            tcpClient.Connect(Global.ServiceIP, Global.ServicePort);
            ResetTimeOut();
        }

        /// <summary>
        /// 重置请求超时事件
        /// </summary>
        public void ResetTimeOut()
        {
            tcpClient.ReceiveTimeout = 30000;
        }

        /// <summary>
        /// 发送数据并返回服务端返回数据
        /// </summary>
        /// <param name="data">要发送的数据</param>
        /// <param name="_recBodyData">返回的数据</param>
        public void Send(byte[] data, byte msgType, out byte[] _recBodyData, byte compEncry = 0x00)
        {
            try
            {
                byte[] recData = new byte[5120];

                tcpClient.Client.Send(AddHeadePack(msgType, data, compEncry));
                tcpClient.Client.Receive(recData);

                //如果发送的消息类型为业务消息类型验证返回数据是否业务类型
                if (msgType == 0x05)
                {
                    //判断读取到的消息类型
                    while (!(recData[msgTypeOffset] == msgType))
                    {
                        SocketHelper.Instance.Receive(out recData);
                    }
                }

                _recBodyData = MessageParsing(recData);
            }
            catch (SocketException sEx)
            {
                if (sEx.ErrorCode == 10060)
                {
                    Log4NetHelper.Instance.Debug("请求超时");
                }

                throw sEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="_recData"></param>
        /// <returns></returns>
        public int Receive(out byte[] _recData)
        {
            int result = 0;

            try
            {
                byte[] recData = new byte[5120];

                tcpClient.Client.Receive(recData);
                _recData = recData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        //心跳数据
        byte[] heartbeat = new byte[10] { 0x00, 0x85, 0x24, 0x56, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 };

        /// <summary>
        /// 发送心跳
        /// </summary>
        /// <param name="heartbeat"></param>
        public void SendHeartbeat()
        {
            try
            {
                byte[] recData = new byte[20];

                tcpClient.Client.Send(heartbeat);
                tcpClient.Client.Receive(recData);
                Log4NetHelper.Instance.Info("发送心跳正常，返回数据："+ StringUtil.ByteArrayToHexString(recData));
            }
            catch (SocketException sEx)
            {
                throw sEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加包头
        /// </summary>
        /// <param name="bodyPack"></param>
        /// <param name="compEncry"></param>
        /// <returns></returns>
        private byte[] AddHeadePack(byte msgType, byte[] bodyPack, byte compEncry = 0x00)
        {
            List<byte> completeMsg = new List<byte>();

            bodyLength = BitConverter.GetBytes(bodyPack.Length).Reverse().ToArray();

            completeMsg.AddRange(headLogo);
            completeMsg.Add(msgType);
            completeMsg.Add(compEncry);
            completeMsg.AddRange(bodyLength);
            completeMsg.AddRange(bodyPack);

            return completeMsg.ToArray();
        }

        /// <summary>
        /// 数据解析并返回包体
        /// </summary>
        /// <param name="recData">返回数据报文</param>
        /// <returns></returns>
        public byte[] MessageParsing(byte[] recData)
        {
            List<byte> dataBody = new List<byte>();

            //读取报文长度
            byte[] bodyLen = new byte[4];
            Array.Copy(recData, lenBodyOffset, bodyLen, 0, 4);
            //进行倒序
            bodyLen = bodyLen.Reverse().ToArray();
            //转成Int32
            int len = BitConverter.ToInt32(bodyLen, 0);

            //解析返回包体
            byte[] recBodyData = new byte[len];
            Array.Copy(recData, bodyOffset, recBodyData, 0, len);

            //解析加密和解压包体
            switch (recData[compEncryOffset])
            {
                case 0x01:
                    recBodyData = GZipUtil.Decompress(recBodyData);
                    break;
                case 0x02:
                    recBodyData = EncryDecrypt.AESDecrypt(recBodyData, Global.SecretKey);
                    break;
                case 0x03:
                    recBodyData = EncryDecrypt.AESDecrypt(recBodyData, Global.SecretKey);
                    recBodyData = GZipUtil.Decompress(recBodyData);
                    break;
            }

            return recBodyData;
        }

        /// <summary>
        /// 释放实例，关闭基础连接
        /// </summary>
        public void Close()
        {
            GetTcpClient.Client.Close();
            GetTcpClient.Close();
        }
    }
}
