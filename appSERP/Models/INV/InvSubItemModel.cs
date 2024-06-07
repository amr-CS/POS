using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvSubItemModel
    {
        public int SubItemId { get; set; }
        public string SubItemCode { get; set; }
        public string SubItemNameL1 { get; set; }
        public string SubItemNameL2 { get; set; }
        public int PiecesCount { get; set; }
        public int ItemId { get; set; }
        public bool SubItemIsActive { get; set; }
    }
}