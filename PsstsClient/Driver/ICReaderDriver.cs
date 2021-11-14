using System;
using System.Runtime.InteropServices;
using PsstsClient.Entity;
using PsstsClient.Utility;
using static PsstsClient.Driver.DicCRT310Reader;

namespace PsstsClient.Driver
{
    public class ICReaderDriver
    {
        //是否打开串口
        bool isOpenPort = false;

        //设备串口号 
        int drivePort = 0;

        public ICReaderDriver(int cprot)
        {
            drivePort = cprot;
        }

        #region 读卡器操作
        /// <summary>
        /// 打开读卡器串口
        /// </summary>
        /// <returns></returns>
        public bool OpenPort()
        {
            bool result = false;

            try
            {
                if (isOpenPort)
                    return true;

                result = DicCRT310Reader.DICOpenPort(drivePort);
                isOpenPort = result;
                DriverCommon.ICReader = result;
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("打开串口异常", avEx);
            }

            return result;
        }

        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="cardInfo">卡数据实体</param>
        /// <returns></returns>
        public bool ReadCard(out CardInfoEntity cardInfo)
        {
            cardInfo = null;
            bool result = false;

            try
            {
                lpstruReadCardData lpstruCard = new lpstruReadCardData();

                if (DicCRT310Reader.DICReadCard(ref lpstruCard))
                {
                    cardInfo = new CardInfoEntity();
                    cardInfo.cardType = lpstruCard.cardType;
                    cardInfo.cardSnr = lpstruCard.cardSnr;
                    cardInfo.cardRandom = lpstruCard.cardRandom;
                    cardInfo.dfFile81 = lpstruCard.dfFile81;
                    cardInfo.dfFile82 = lpstruCard.dfFile82;
                    cardInfo.dfFile83 = lpstruCard.dfFile83;
                    cardInfo.dfFile84 = lpstruCard.dfFile84;
                    cardInfo.dfFile85 = lpstruCard.dfFIle85;
                    cardInfo.dfFile86 = lpstruCard.dfFile86;
                    cardInfo.dfFile87 = lpstruCard.dfFile87;
                    cardInfo.dfFile88 = lpstruCard.dfFile88;
                    cardInfo.mfFile82 = lpstruCard.mfFile82;

                    result = true;
                }
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("读卡异常", avEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("读卡异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <returns></returns>
        public bool WriteCard(lpstruWriteCardData writeCardInfo)
        {
            bool result = false;

            try
            {
                if (!isOpenPort)
                {
                    Log4NetHelper.Instance.Debug("串口未打开，不写卡");
                    return result;
                }

                result = DicCRT310Reader.DICWriteCard(ref writeCardInfo);
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("写卡异常", avEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("写卡异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 允许插卡
        /// </summary>
        /// <returns></returns>
        public bool AllowedCard()
        {
            bool result = false;

            try
            {
                if (!isOpenPort)
                    OpenPort();

                result = DicCRT310Reader.Entry();
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("允许插卡异常", avEx);
            }

            return result;
        }

        /// <summary>
        /// 不允许插卡
        /// </summary>
        /// <returns></returns>
        public bool DontAllowedCard()
        {
            bool result = false;

            try
            {
                if (!isOpenPort)
                    OpenPort();

                result = DicCRT310Reader.DisEntry();
                Log4NetHelper.Instance.Debug("不允许插卡成功");
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("不允许插卡异常", avEx);
            }

            return result;
        }

        /// <summary>
        /// 吐出卡片
        /// </summary>
        /// <param name="isOut"></param>
        public void OutCard(bool isOut)
        {
            try
            {
                if (!isOpenPort)
                    OpenPort();

                DicCRT310Reader.Eject();
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("吐卡异常", avEx);
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        public int DICGetStatus()
        {
            int result = 0;

            try
            {
                result = DicCRT310Reader.DICGetStatus();
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("获取读卡器状态异常", avEx);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("获取读卡器状态异常", ex);
            }

            return result;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void DICClose()
        {
            try
            {
                if (isOpenPort)
                {
                    if (DicCRT310Reader.DICClose())
                    {
                        isOpenPort = false;
                    }
                    else
                    {
                        Log4NetHelper.Instance.Debug("关闭串口异常");
                    }
                }
            }
            catch (AccessViolationException avEx)
            {
                Log4NetHelper.Instance.Error("关闭串口异常", avEx);
            }
        }
        #endregion

        /// <summary>
        /// 返回错误内容
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string DICGetErrorMsg(int status)
        {
            string result = string.Empty;

            try
            {
                switch (status)
                {
                    case -1: result = "读卡器异常"; break;
                    case 1: result = "机内无卡"; break;
                    case 2: result = "在非持卡位置有卡或卡长度异常"; break;
                    case 6: result = "机内有卡且IC触电已下落"; break;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Instance.Error("DICGetErrorMsg异常", ex);
            }

            return result;
        }
    }
}
