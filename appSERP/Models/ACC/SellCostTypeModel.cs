using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class SellCostTypeModel
    {

        public int SellCostTypeId { get; set; }
        public string SellCostTypeCode { get; set; }
       
        public string SellCostTypeNameL1 { get; set; }

       
        public string SellCostTypeNameL2 { get; set; }

        
    
        public bool SellCostTypeIsActive { get; set; } = true;
    }
}