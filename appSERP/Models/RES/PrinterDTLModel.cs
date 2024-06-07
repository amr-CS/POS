using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class PrinterDTLModel
    {

        public int PrinterDTLId { get; set; }
        public string PrinterDTLCode { get; set; }
        public int PrinterDTLSeq { get; set; }
        public int InvTypeId { get; set; }
        public string PrinterName { get; set; }
        public string PrinterIP { get; set; }
        public int PortTypeId { get; set; }
        public int PortNo { get; set; }
        public int DirectPrintId { get; set; }
        public int PrintNum { get; set; }
        public bool PrinterDTLIsActive { get; set; }
     
    }
}