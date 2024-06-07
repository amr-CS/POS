using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class StoreConversion
    {
		public int StoreConversionDtlId { get; set; }
		public int StoreId { get; set; }
		public int StoreConversionId { get; set; }
		public int StoreConversionType { get; set; }
		public int StoreConversionYear { get; set; }
		public int SoureStoreType { get; set; }
		public int ItemId { get; set; }
		public int UnitId { get; set; }
		//public DateTime ExpireDate { get; set; }
		public int StoreSectId { get; set; }
		public float ItemQty { get; set; }
		public string Notes { get; set; }
		public bool IsDeleted { get; set; }
		public int CreatedBy { get; set; }
	//	public DateTime CreatedOn { get; set; }
		public int LastUpdatedBy { get; set; }
		public float Cost { get; set; }
		public float TotalCost { get; set; }
		
	}
}