using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace appSERP.Logger
{
    public sealed class Log : ILog
    {
        //private Log()
        //{
        //}
        //private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        //public static Log GetInstance
        //{
        //    get
        //    {
        //        return instance.Value;
        //    }
        //}

        public void LogException(string message)
        {
            string pathDirectory = string.Format(@"{0}\{1}\{2}\{3}", AppDomain.CurrentDomain.BaseDirectory, "WhiteCloud", "Log User File", "Exception");
            string fileName = string.Format("{0}_{1}.txt", "Exception", DateTime.Now.ToString("dd-MM-yyyy"));
            string filePath = string.Format(@"{0}\{1}", pathDirectory, fileName);
            if (Directory.Exists(pathDirectory) == false)
                Directory.CreateDirectory(pathDirectory);
            //string fileName = string.Format("{0}_{1}.log", "Exception"
            //    , DateTime.Now.ToString("dd'-'MM'-'yyyy")
            //    );
            //string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("== Exception : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            sb.AppendLine(message);
            sb.AppendLine("============================================================================");
            //using (StreamWriter writer = new StreamWriter(logFilePath, true))
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}