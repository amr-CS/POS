using System;
using System.Collections.Generic;

namespace appSERP.Models
{
    public partial class ItemUnit
    {
        public int InvItemUnitId { get; set; }
        public int UnitId { get; set; }
        public float? PartsInParents { get; set; }
        public string UnitCode { get; set; }
        public string UnitNameL1 { get; set; }
        public float UnitParentId { get; set; }
        public string UnitParentCode { get; set; }
        public string UnitParentName { get; set; }
        public decimal? UnitCost { get; set; }
        public string Notes { get; set; }
        public int DefaultUnit { get; set; }
        public decimal UnitOrderLimit { get; set; }
        public int ItemId { get; set; }
        public int BranchId { get; set; }
        public int Barcode { get; set; }
        public bool? IsDecreasable { get; set; }
        public bool? SellUnit { get; set; }
        public bool? UnitProduction { get; set; }
        public bool? IsDefault { get; set; }
        public bool? UnitIsActive { get; set; }

        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

    }
}
