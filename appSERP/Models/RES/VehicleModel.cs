using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string VehicleCode { get; set; }
        public string VecDescL1 { get; set; }
        public string VecDescL2 { get; set; }
        public DateTime InitialDate { get; set; }
        public string PanelNumber { get; set; }
        public int VecModelId { get; set; }
        public string VecVINNO { get; set; }
        public int VecTypeId { get; set; }
        public int BrandId { get; set; }
        public int VecColorId { get; set; }
        public string Comments { get; set; }
        public bool VehicleIsActive { get; set; }
    }
}