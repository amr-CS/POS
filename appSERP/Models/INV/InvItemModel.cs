using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class InvItemModel
    {
        public int? InvItemId { get; set; }
        public string InvItemCode { get; set; }
        public string InvItemBarCode { get; set; }
        public string InvItemNameL1 { get; set; }
        public string InvItemNameL2 { get; set; }
        public int?CategoryId { get; set; }
        public bool HasEdate { get; set; }
        public bool FollowUp { get; set; }
        public string SupCompany { get; set; }
        public decimal BonusLimit { get; set; }
        public decimal Bonus { get; set; }
        public decimal DiscLimit { get; set; }
        public decimal DiscPerc { get; set; }
        public decimal OrderLimit { get; set; }
        public decimal ItemMaxQuantity { get; set; }
        public decimal ItemMinQuantity { get; set; }
        public decimal LastBuy { get; set; }
        public decimal LastSell { get; set; }
        public decimal ItemLastCost { get; set; }
        public string Notes { get; set; }
        public int?CurrencyId { get; set; }
        public int?Collective { get; set; }
        public string ItemIdNo { get; set; }
        public int?ItemFactorId { get; set; }
        public string ItemMeasurement { get; set; }
        public int?CategoryMeasureId { get; set; }
        public DateTime ProductDate { get; set; }
        public int?ItemSales { get; set; }
        public int?CategorySizes { get; set; }
        public int?ServiceItem { get; set; }
        public int?GRPId { get; set; }
        public string ItemImage { get; set; }
        public int?CatProduct { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int?StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string PrinterCode { get; set; }
        public int?PrinterId { get; set; }
        public string PrinterName { get; set; }
        public int?DetailGroup { get; set; }
        public int?Cancel { get; set; }
        public int?SequenceByCategory { get; set; }
        public bool IsVATApply { get; set; }
        public string InvItemIsActive { get; set; }

    }
}