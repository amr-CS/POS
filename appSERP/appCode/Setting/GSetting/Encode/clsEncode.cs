using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.Encode
{
    public static class clsEncode
    {

        // Encode
        public static string funBase64Encode(string pTextToEncode)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(pTextToEncode);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        // Decode
        public static string funBase64Decode(string pTextToDecode)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(pTextToDecode);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    
    }
}