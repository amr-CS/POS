using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class PrinterModel
    {
        public int PrinterId { get; set; }
        public string PrinterCode { get; set; }
        public int PrinterSeq { get; set; }
        public string ReportNameL1 { get; set; }
        public string ReportNameL2 { get; set; }
        public string PrinterDescL1 { get; set; }
        public string PrinterDescL2 { get; set; }
        public bool PrinterIsActive { get; set; }
    }
}