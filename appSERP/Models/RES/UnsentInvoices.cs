using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    // كلاس لكي نظيف فيه جميع الفواتير الغير مجتازة عند الهيئة
    public class UnsentInvoices
    {
        public int pInvId { get; set; }
        public int? pOrderId { get; set; }
    }
}