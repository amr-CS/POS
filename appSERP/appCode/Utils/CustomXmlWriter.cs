using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace appSERP.appCode.Utils
{
    public class CustomXmlWriter
    {
        public string GetXml(string dataTablName, dynamic data)
        {
            DataTable table = new DataTable(dataTablName);
            using (var reader = ObjectReader.Create(data))
            {
                table.Load(reader);
            }
            using (StringWriter stringWriter = new StringWriter())
            {
                table.WriteXml(stringWriter);
                return stringWriter.ToString();
            }
        }
    }
}