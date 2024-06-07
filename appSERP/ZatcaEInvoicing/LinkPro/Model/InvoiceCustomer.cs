using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro.Model
{
    public class InvoiceCustomer
    {
        public string organization { get; set; }
        public string tax_number { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string building_number { get; set; }
        public string postal_zone { get; set; }
        public string district_name { get; set; }
    }
}