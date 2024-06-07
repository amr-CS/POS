using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.SYSSETT
{
    public class SystemObjectModel
    {
        public int ObjectId { get; set; }
        public int ObjectProName { get; set; }
        public int ObjectTypeId { get; set; }
        public string ObjectNameL1 { get; set; }
        public string ObjectNameL2 { get; set; }
        public string ObjectNameL3 { get; set; }
        public string ObjectNameL4 { get; set; }
        public string ObjectNameL5 { get; set; }
        public string ObjectNameL6 { get; set; }
        public string ObjectNameL7 { get; set; }
        public string ObjectNameL8 { get; set; }
        public string ObjectNameL9 { get; set; }
        public string ObjectNameL10 { get; set; }
        public string ObjectPKName { get; set; }
        public bool SystemObjectIsActive { get; set; } = true;
    }
}