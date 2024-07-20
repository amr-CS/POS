using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace appSERP.ScheduledBH
{
    public class LogBh
    {
        public static void LogException(string message)
        {
            string pathDirectory = string.Format(@"{0}\{1}\{2}\{3}", AppDomain.CurrentDomain.BaseDirectory, "WhiteCloud", "Log User File", "Scheduled");
            string fileName = string.Format("{0}_{1}.txt", "Scheduled", DateTime.Now.ToString("dd-MM-yyyy"));
            string filePath = string.Format(@"{0}\{1}", pathDirectory, fileName);
            if (Directory.Exists(pathDirectory) == false)
                Directory.CreateDirectory(pathDirectory);
        
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("== Scheduled : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            sb.AppendLine(message);
            sb.AppendLine("============================================================================");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
