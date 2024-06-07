using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemReplaceModel
    {
        
        public int InvItemReplaceId { get; set; }
        public string InvItemReplaceCode { get; set; }
        public int ReplaceItemId { get; set; }
        public int Notes { get; set; }
        public bool InvItemReplaceIsActive { get; set; }
    }
}