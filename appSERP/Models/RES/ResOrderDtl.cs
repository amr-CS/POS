using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class ResOrderDtl
    {
        public int? OrderDTLID { get; set; }
        public int? OrderId { get; set; }
        public int? ORDER_LOC_SEQ { get; set; }
        public int? ITEM_UNIT_SEQ { get; set; }
        public int? UnitId { get; set; }
        public int? TAG { get; set; }
        public float? QTY { get; set; }
        public decimal? PRICE { get; set; }
        public string NOTES { get; set; }
        public int? SLICING_TYPE { get; set; }
        public int? SHEEP_REMAINDER { get; set; }
        public int? CUST_SHEEP { get; set; }
        public int? CUST_PLATE { get; set; }
        public int? QTY_PLATE { get; set; }
        public int? TYP { get; set; }
        public float? PRICE_INSUR { get; set; }
        public float? UPDATE_PRICE { get; set; }
        public float? DISC_AMT { get; set; }
        public float? VAT_PRICE { get; set; }
        public float? VAT_TOTAL { get; set; }
        public int? COMP_ID { get; set; }
        public bool? IsDeleted { get; set; }
    }
}