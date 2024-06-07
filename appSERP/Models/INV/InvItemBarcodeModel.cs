using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemBarcodeModel
    {
       
        public int InvItemBarcodeId { get; set; }
        public string InvItemBarcodeCode { get; set; }
        public int ItemId { get; set; }
        public string ItemBarCode { get; set; }
        public bool InvItemBarcodeIsActive { get; set; }
    }
}