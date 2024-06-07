using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class DirectPrintModel
    {
        public int DirectPrintId { get; set; }
        public string DirectPrintCode { get; set; }
        public string DirectPrintNameL1 { get; set; }
        public string DirectPrintNameL2 { get; set; }
        public bool DirectPrintIsActive { get; set; }
    }
}