using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace appSERP.appCode.Setting.Mail
{
    public class clsMail
    {
        // Company Mail
        public static string vMail = "amr.whitecloud@outlook.com";
        public static string vMailPassword = "@whitecloudamr15";
        public static string vMailHost = "smtp-mail.outlook.com";
        public static int vMailPort = 587;


        // Send Mail
        public static void funSendMail(string pSubject, string pBody, string pMessageTo, List<string> pLstFilePath)
        {
            // Main Data
            String FROM = vMail;
            String FROMNAME = "";
            String TO = pMessageTo;
            String SMTP_USERNAME = vMail;
            String SMTP_PASSWORD = vMailPassword;
            String HOST = vMailHost;
            int PORT = vMailPort;
            String SUBJECT = pSubject;
            String BODY = pBody;

            // Build Message
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;



            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    // Send
                    client.Send(message);
                }
                catch (Exception ex)
                {
                   
                    // Error
                }
            }


            message.Dispose();

        }


        // fun Is Email Valid
        public static bool funIsEmailValid(string pEmailToCheck)
        {
            try
            {
                var vMailAddress = new System.Net.Mail.MailAddress(pEmailToCheck);
                return vMailAddress.Address == pEmailToCheck;
            }
            catch
            {
                return false;
            }
        }

    }
}