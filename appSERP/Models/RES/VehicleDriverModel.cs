using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class VehicleDriverModel
    {
        public int VehicleDriverId { get; set; }
        public string VehicleDriverCode { get; set; }
        public int VehicleId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionStatusId { get; set; }
        public decimal Counter { get; set; }
        public string Notes { get; set; }
        public bool VehicleDriverIsActive { get; set; }


    }
}