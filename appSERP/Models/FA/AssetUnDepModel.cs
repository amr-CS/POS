using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class AssetUnDepModel
    {
        public int AssetUnDepId { get; set; }

        [Display(Name = "AssetLastDepDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public DateTime AssetLastDepDate { get; set; }

        [Display(Name = "AssetUnDepDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public DateTime AssetUnDepDate { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AssetUnDepIsActive { get; set; } = true;
    }
}