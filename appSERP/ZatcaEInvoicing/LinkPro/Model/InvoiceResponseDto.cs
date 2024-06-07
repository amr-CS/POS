using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro.Model
{
    public class InvoiceResponseDto
    {
        public string status { get; set; }
        public string qrcode { get; set; }
        public string note { get; set; }
        public string payable_amount { get; set; }
        public string statusCode { get; set; }
        public bool isSuccess { get; set; } = false;
    }
}