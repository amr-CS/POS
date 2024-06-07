using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemEquipmentModel
    {
        
        public int InvItemEquipmentId { get; set; }
        public string InvItemEquipmentCode { get; set; }
        public int ItemId { get; set; }
        public int EquipmentId { get; set; }
        public int Notes { get; set; }
        public bool InvItemEquipmentIsActive { get; set; }
    
    }
}