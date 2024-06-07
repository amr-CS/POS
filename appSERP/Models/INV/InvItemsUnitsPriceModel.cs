using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemsUnitsPriceModel
    {
        public int PriceId { get; set; }
        public string PriceCode { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public int SellCostType { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }
        public bool PriceIsActive { get; set; }
    }
}