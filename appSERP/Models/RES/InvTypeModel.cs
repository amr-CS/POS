using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class InvTypeModel
    {
        public int InvTypeId { get; set; }
        public string InvTypeCode { get; set; }
        public string InvTypeNameL1 { get; set; }
        public string InvTypeNameL2 { get; set; }
        public bool InvTypeIsActive { get; set; }
        

    }
}