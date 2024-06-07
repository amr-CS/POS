using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvEquipmentModel
    {
      
        public int EquipmentId { get; set; }
        public string EquipmentCode { get; set; }
        public string EquipmentNameL1 { get; set; }
        public string EquipmentNameL2 { get; set; }
        public string Notes { get; set; }
        public bool EquipmentIsActive { get; set; }
    }
}