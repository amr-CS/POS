using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class AssetModel
    {
        public int AssetId { get; set; }
        
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string AssetCode { get; set; }

        [Display(Name = "AssetId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetNameL1 { get; set; }

        [Display(Name = "AssetId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetNameL2 { get; set; }

        [Display(Name = "_Qty", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetQty { get; set; }

        [Display(Name = "Site", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SiteId { get; set; }

        [Display(Name = "_PurchasePrice", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetPurchasePrice { get; set; }

        [Display(Name = "_Currency", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CurrencyId { get; set; }

        [Display(Name = "CurrencyValue", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal CurrencyValue { get; set; }

        [Display(Name = "_PurchasePriceBase", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetPurchasePriceBase { get; set; }

        [Display(Name = "_BookValue", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetBookValue { get; set; }

        [Display(Name = "_BookValueBase", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetBookValueBase { get; set; }

        [Display(Name = "_Percent", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetPercent { get; set; }

        [Display(Name = "تاريخ اخر اهلاك")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AssetLastDepDate { get; set; } = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

        [Display(Name = "تاريخ الاستخدام")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; } = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

        [Display(Name = "_TotalDep", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetTotalDep { get; set; }

        [Display(Name = "_TotalDepBase", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetTotalDepBase { get; set; }

        [Display(Name = "BillNo", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int BillNo { get; set; }

        [Display(Name = "PurchaseNo", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int PurchaseNo { get; set; }

        [Display(Name = "تاريخ الشراء")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; } = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

        [Display(Name = "IsAutoPost", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsAutoPost { get; set; }

        [Display(Name = "_IsPosted", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsPosted { get; set; }

        [Display(Name = "حساب مدين بقيمة الاهلاك")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetDebitAccount { get; set; }

        [Display(Name = "حساب دائن بقيمة الاهلاك")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetCreditAccount { get; set; }

        [Display(Name = "_PurchaseAccount", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetPurchaseAccount { get; set; }

        [Display(Name = "_SalesAccount", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetSalesAccount { get; set; }

        [Display(Name = "حساب الاصل")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetAccountId { get; set; }

        [Display(Name = "_Supplier", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetSupplierId { get; set; }

        [Display(Name = "_Supplier", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetSupplierName { get; set; }

        [Display(Name = "اقل سعر للاصل")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetMinPrice { get; set; }

        [Display(Name = "اقل سعر للاصل الاساس")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal AssetMinPriceBase { get; set; }

        [Display(Name = "ProductPeriod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int ProductPeriod { get; set; }

        [Display(Name = "InvItemId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int InvItemId { get; set; }

        [Display(Name = "InvItemId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string InvItemName { get; set; }

        [Display(Name = "MainGroupId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string MainGroupId { get; set; }

        [Display(Name = "GroupId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GroupId { get; set; }


        [Display(Name = "FixedAssetMethod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FixedAssetMethodId { get; set; }

        [Display(Name = "FixedAssetUnit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FixedAssetUnitId { get; set; }

        [Display(Name = "SiteDonor", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int DonorId { get; set; }

        [Display(Name = "BuyGroup", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int BuyGroupId { get; set; }

        [Display(Name = "_Company", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FixedAssetCompanyId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        public bool AssetIsActive { get; set; } = true;
    }
}