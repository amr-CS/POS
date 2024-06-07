using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CustomerSiteModel
    {
        public int    CustomerSiteId { get; set; }
        public string CustomerSiteCode { get; set; }
        public string CustomerSiteNameL1 { get; set; }
        public string CustomerSiteNameL2 { get; set; }
        public int    CustomerId { get; set; }
        public bool   CustomerSiteIsActive { get; set; }
    }
}