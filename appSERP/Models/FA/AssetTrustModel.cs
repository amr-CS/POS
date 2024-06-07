using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    ///  BELAL    23/3/2019 
    public class AssetTrustModel
    {
        public int AssetTrustId { get; set; }
        [Display(Name = "AssetId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetId { get; set; }
        [Display(Name = "Trust", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int TrustId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        public bool AssetTrustIsActive { get; set; } = true;
    }
}