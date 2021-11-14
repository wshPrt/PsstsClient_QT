using QRCoder;
using System.Drawing;

namespace PsstsClient.Utility
{
    public class QRCodeUtil
    {
        /// <summary>
        /// 根据文本生成二维码
        /// </summary>
        /// <param name="qrCode">文本内容</param>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public static Bitmap CreateCode(string qrCode, int pixels)
        {
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);

            return qrcode.GetGraphic(2, Color.Black, Color.White, null, 15, 6, false); ;
        }
    }
}
