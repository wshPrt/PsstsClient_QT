using System;
using System.IO;
using System.Text;

namespace PsstsClient.Utility
{
    public class FileHelper
    {
        #region 单例模式
        private static readonly object lockHelper = new object();
        private volatile static FileHelper _instance = null;

        public static FileHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new FileHelper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 读取文件字符串
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public string ReadFileString(string fileName)
        {
            string result = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 拷贝文件到新的位置
        /// </summary>
        /// <param name="fileName">源文件路径</param>
        /// <param name="newPath">要拷贝到的指定路径</param>
        /// <param name="newfileName">新文件名</param>
        /// <returns></returns>
        public bool CopyFileTo(string fileName, string newPath, string newfileName)
        {
            bool result = false;

            try
            {
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                FileInfo file = new FileInfo(fileName);
                file.CopyTo(newPath + newfileName, true);
                result = true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("拷贝文件异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 写入内容到文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool WriteFile(string context, string fileName)
        {
            bool result = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("gb2312")))
                {
                    sw.Write(context);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写入文件异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 判断目录是否存在
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <param name="isCreate">如果不存在是否创建目录</param>
        /// <returns></returns>
        public bool ExistsDir(string path, bool isCreate = false)
        {
            bool result = false;

            try
            {
                result = Directory.Exists(path);

                if (!result)
                {
                    if (isCreate)
                    {
                        Directory.CreateDirectory(path);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("目录判断异常", ex);
            }

            return result;
        }
    }
}
