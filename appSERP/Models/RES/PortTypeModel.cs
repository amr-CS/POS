using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class PortTypeModel
    {
        public int PortTypeId { get; set; }
        public string PortTypeCode { get; set; }
        public string PortTypeNameL1 { get; set; }
        public string PortTypeNameL2 { get; set; }
        public bool PortTypeIsActive { get; set; }
    }
}