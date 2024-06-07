using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace appSERP.Utils
{
    public class SystemMessageCode
    {
        public int SystemMessageTypeId { get; set; }
        public string SystemMessageText { get; set; }
        public bool SuccessStatus { get; set; }

        public static List<SystemMessageCode> Get(bool successStatus, string message)
        {
            return new List<SystemMessageCode>()
            {
               new SystemMessageCode()
               {
                   SystemMessageTypeId = 4,
                   SystemMessageText = message,
                   SuccessStatus = successStatus
               },
            };
        }
        public static List<SystemMessageCode> GetError(string message)
        {
            return Get(false,message);
        }
        public static List<SystemMessageCode> GetSuccess(string message)
        {
            return Get(true, message);
        }

        //public static string ToJSON(this object obj)
        public static string ToJSON(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

    }
}