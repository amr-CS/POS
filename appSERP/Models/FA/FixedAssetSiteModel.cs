using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class FixedAssetSiteModel
    {
        public int FixedAssetSiteId { get; set; }
        [Display(Name = "FixedAssetSiteQty", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FixedAssetSiteQty { get; set; }
        [Display(Name = "FixedAssetSiteTransDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FixedAssetSiteTransDate { get; set; } = Convert.ToDateTime( DateTime.Now.Date.ToString("yyyy-MM-dd"));
        [Display(Name = "AssetId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetId { get; set; }
        [Display(Name = "SiteDetail", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SiteDetailId { get; set; }
        [Display(Name = "TransactionTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int TransactionTypeId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool FixedAssetSiteIsActive { get; set; } = true;
    }
}