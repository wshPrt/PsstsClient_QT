using Newtonsoft.Json;
using PsstsClient.Service.RecData;
using PsstsClient.Utility;
using System;
using System.Net.Sockets;
using System.Text;

namespace PsstsClient.Service
{
    public class PayResultService : BaseBusinessService
    {
        /// <summary>
        /// 监听交易结果推送消息
        /// </summary>
        /// <param name="isTimeOut"></param>
        /// <param name="payResult"></param>
        /// <returns></returns>
        public bool PayResultListening(out bool isTimeOut, out R_PayResult payResult)
        {
            isTimeOut = false;
            payResult = null;
            bool result = false;

            ////测试阶段模拟返回交易结果
            //Thread.Sleep(8000);

            //payResult = new R_PayResult();
            //payResult.serialNo = "15555444222";
            //payResult.status = 1;

            //return true;

            try
            {
                byte[] recByte = new byte[5120];

                //先更新读取消息超时时间为90秒
                SocketHelper.Instance.GetTcpClient.ReceiveTimeout = 90 * 1000;
                int recLen = SocketHelper.Instance.GetTcpClient.Client.Receive(recByte);

                if (recLen > 0)
                {
                    string recData = Encoding.UTF8.GetString(SocketHelper.Instance.MessageParsing(recByte));
                    Log4NetHelper.Instance.Debug("监听交易结果返回数据：" + recData);
                    R_PayMessage rPayMsg = JsonConvert.DeserializeObject<R_PayMessage>(recData);
                    payResult = JsonConvert.DeserializeObject<R_PayResult>(rPayMsg.jsonData);
                    result = payResult.status == 1;
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    isTimeOut = true;
                    Log4NetHelper.Instance.Debug("交易结果读取超时");
                }
                else
                {
                    Log4NetHelper.Instance.Error("读取交易推送消息异常", ex);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("读取交易推送消息异常", ex);
            }
            finally
            {
                SocketHelper.Instance.ResetTimeOut();
            }

            return result;
        }
    }
}
