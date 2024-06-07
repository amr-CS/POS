using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class AssetReasonTypeModel
    {
        public int AssetReasonTypeId { get; set; }

        [Display(Name = "AssetReasonType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetReasonTypeNameL1 { get; set; }

        [Display(Name = "AssetReasonType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetReasonTypeNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AssetReasonTypeIsActive { get; set; } = true;
    }
}