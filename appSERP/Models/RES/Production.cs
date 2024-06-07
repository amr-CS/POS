using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class Production
    {
        public int ProductionDtlId { get; set; }
        public int ItemId { get; set; }
        public int DestStore { get; set; }
        public int SellStore { get; set; }
        public int AddId { get; set; }
        public float QTY { get; set; }
        public int UnitId { get; set; }
        public int TagId { get; set; }
        public string Notes { get; set; }
        public int RemainderQty { get; set; }
        public int branchid { get; set; }

    }
}