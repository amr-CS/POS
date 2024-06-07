using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.LinkPro
{
    public class DataPro
    {
        public string account_id { get; set; }
        public string invoice_code { get; set; } = "invoice"; // [ invoice, credit, debit ]
        public string invoice_pk { get; set; } // فاتورة فريدة لكل فاتورة تتعلق بنفس الحساب
        public List<itemPro> items    { get; set; }
        public string payment_method { get; set; } = "10"; // 10: Cash, 30: Credit, 42:Bank Account, 48:Bank Card

        public string discount_amount { get; set; } = "0.00";

        public CustomerLinkPro customer { get; set; }

        public string reference_pk { get; set; }
        public string reference_date { get; set; }


    }
}