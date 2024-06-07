using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Services;

namespace appSERP.appCode
{
    public class CustomPage: System.Web.UI.Page
    {
        [WebMethod]
        public static object SignMessage(string message)
        {
            // How to associate a private key with the X509Certificate2 class in .net
            // openssl pkcs12 -export -inkey private-key.pem -in digital-certificate.txt -out private-key.pfx

            string KEY = @"D:\tray\privateKey.pfx";
            string PASS = "";

            var cert = new X509Certificate2(KEY, PASS, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey;

            byte[] data = new ASCIIEncoding().GetBytes(message);
            byte[] hash = new SHA1Managed().ComputeHash(data);

            string response = Convert.ToBase64String(csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1")));
            return response;
        }
    }
}