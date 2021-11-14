using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PsstsClient.Utility
{
#pragma warning disable CA1063 // Implement IDisposable Correctly
    public class FTPUtil : IDisposable
#pragma warning restore CA1063 // Implement IDisposable Correctly
    {
        FtpClient ftpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_serverIP"></param>
        /// <param name="_port"></param>
        /// <param name="_user"></param>
        /// <param name="_password"></param>
        public FTPUtil(string _serverIP, int _port, string _user, string _password)
        {
            try
            {
                ftpClient = new FtpClient();
                ftpClient.Host = _serverIP;
                ftpClient.Port = _port;
                ftpClient.Credentials = new System.Net.NetworkCredential(_user, _password);
                ftpClient.Encoding = Encoding.UTF8;
                ftpClient.Connect();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("FTPUtil实例化异常", ex);
            }
        }

#pragma warning disable CA1063 // Implement IDisposable Correctly
        public void Dispose()
#pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            if (ftpClient != null)
            {
                ftpClient.Disconnect();
                ftpClient.Dispose();
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="localPath"></param>
        /// <param name="remotePath"></param>
        /// <returns></returns>
        public bool UPLoadFile(string localPath, string remotePath)
        {
            bool result = false;

            try
            {
                result = ftpClient.UploadFile(localPath, remotePath) == FtpStatus.Success;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("上传文件异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="remotePath"></param>
        /// <returns></returns>
        public bool UPLoadFile(Stream fileStream, string remotePath)
        {
            bool result = false;

            try
            {
                result = ftpClient.Upload(fileStream, remotePath) == FtpStatus.Success;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("上传文件异常", ex);
            }

            return result;
        }

        /*/// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public bool CreateDirectory(string dirName)
        {
            bool result = false;

            try
            {
                result = ftpClient.CreateDirectory(dirName);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("FTP创建目录异常", ex);
            }

            return result;
        }*/

        public FtpListItem[] GetList(string remoteDir)
        {
            return ftpClient.GetListing(remoteDir);
        }

        public List<string> GetDirList(string remoteDir)
        {
            List<string> result = new List<string>();

            try
            {
                //ftpClient.dir
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 判断目录是否存在，不存在则创建对应目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool DirectoryExists(string path)
        {
            bool result = false;

            try
            {
                result = ftpClient.DirectoryExists(path);

                if (!result)
                {
                    ftpClient.CreateDirectory(path);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("判断目录或创建目录异常", ex);
            }

            return result;
        }
    }
}
