using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using appSERP.appCode.SQL.QueryType;

using System.Web;

namespace appSERP.appCode.Setting.GSetting.Encode
{
    public static class InvoiceQR
    {
     
            public static string encodeQrText(string sallerName, string sallerTRN, string invoiceDateTime, string totalWithVAT, string VATTotal)
            {
                //use UTF8 with sallerName to solve arabic issue
                //byte[] bytes = Encoding.UTF8.GetBytes(sallerName);
                //string L1 = bytes.Length.ToString("X");
                //string tag1Hex = BitConverter.ToString(bytes);
                //tag1Hex = tag1Hex.Replace("-", "");

                string L1 = sallerName.Length.ToString("X");
                string L2 = sallerTRN.Length.ToString("X");
                string L3 = invoiceDateTime.Length.ToString("X");
                string L4 = totalWithVAT.Length.ToString("X");
                string L5 = VATTotal.Length.ToString("X");
                //length tag must be 2 digit like '0C' 
                //string hex = "01" + ((L1.Length == 1) ? ("0" + L1) : L1) + tag1Hex +
                //             "02" + ((L2.Length == 1) ? ("0" + L2) : L2) + ToHexString(sallerTRN) +
                //             "03" + ((L3.Length == 1) ? ("0" + L3) : L3) + ToHexString(invoiceDateTime) +
                //             "04" + ((L4.Length == 1) ? ("0" + L4) : L4) + ToHexString(totalWithVAT) +
                //             "05" + ((L5.Length == 1) ? ("0" + L5) : L5) + ToHexString(VATTotal);
            string hex = "01" + ((L1.Length == 1) ? ("0" + L1) : L1) + ToHexString(sallerName) +
                             "02" + ((L2.Length == 1) ? ("0" + L2) : L2) + ToHexString(sallerTRN) +
                             "03" + ((L3.Length == 1) ? ("0" + L3) : L3) + ToHexString(invoiceDateTime) +
                             "04" + ((L4.Length == 1) ? ("0" + L4) : L4) + ToHexString(totalWithVAT) +
                             "05" + ((L5.Length == 1) ? ("0" + L5) : L5) + ToHexString(VATTotal);

                return HexToBase64(hex);
            }

            private static string ToHexString(string str)
            {
                byte[] bytes = Encoding.Default.GetBytes(str);
                string hexString = BitConverter.ToString(bytes);
                hexString = hexString.Replace("-", "");
                return hexString;
            }

            private static string HexToBase64(string strInput)
            {
                try
                {
                    var bytes = new byte[strInput.Length / 2];
                    for (var i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
                    }
                    return Convert.ToBase64String(bytes);
                }
                catch (Exception)
                {
                    return "-1";
                }
            }

            public static Bitmap generateQRImage(string text)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                return qrCodeImage;
            }

        public static string InvoiceDateForQR(DateTime d)
        {
           return d.ToString("yyyy-MM-dd") + ' ' + d.ToString("HH:mm:ss");
        }

    }
}