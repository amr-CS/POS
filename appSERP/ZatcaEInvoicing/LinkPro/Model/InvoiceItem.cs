using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro.Model
{
    public class InvoiceItem
    {
        public string name { get; set; }
        public string price { get; set; } // السعر بالريال السعودي. قبل ضريبة القيمة المضافة
        public string quantity { get; set; }
    }
}