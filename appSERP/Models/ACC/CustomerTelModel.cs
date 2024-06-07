using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CustomerTelModel
    {
        public int CustomerTelId { get; set; }
        public string CustomerTelCode { get; set; }
        public string CustomerTelNameL1 { get; set; }
        public string CustomerTelNameL2 { get; set; }
        public int CustomerId { get; set; }
        public bool CustomerTelIsActive { get; set; }
    }
}