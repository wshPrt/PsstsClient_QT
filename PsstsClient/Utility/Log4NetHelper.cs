using log4net;
using System;

namespace PsstsClient.Utility
{
    public class Log4NetHelper
    {
        #region 单例模式
        private static readonly object lockHelper = new object();
        private volatile static Log4NetHelper _instance = null;

        public static Log4NetHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new Log4NetHelper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private static readonly ILog logInfo = LogManager.GetLogger("loginfo");//这里的 loginfo 和 log4net.config 里的名字要一样
        private static readonly ILog logDebug = LogManager.GetLogger("logdebug");//这里的 loginfo 和 log4net.config 里的名字要一样
        private static readonly ILog logError = LogManager.GetLogger("logerror");//这里的 logerror 和 log4net.config 里的名字要一样

        /// <summary>
        /// 写入info日志
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            if (logInfo.IsInfoEnabled)
            {
                logInfo.Info(message);
            }
        }

        /// <summary>
        /// 写入调试日志
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            if (logDebug.IsInfoEnabled)
            {
                logDebug.Debug(message);
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            if (logError.IsInfoEnabled)
            {
                logError.Error(message);
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Error(string message, Exception ex)
        {
            if (logError.IsInfoEnabled)
            {
                logError.Error(message, ex);
            }
        }
    }
}
