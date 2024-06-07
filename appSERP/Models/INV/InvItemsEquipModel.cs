using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemsEquipModel
    {
        public int EquipId { get; set; }
        public string EquipCode { get; set; }
        public string EquipName { get; set; }
        public int ItemId { get; set; }
        public string Notes { get; set; }
        public bool EquipIsActive { get; set; }
    }
}