using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace appSERP.Models.FA
{
    public class FixedAssetMethodModel
    {

        public int FixedAssetMethodId { get; set; }
        [Display(Name = "FixedAssetMethod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetMethodNameL1 { get; set; }
        [Display(Name = "FixedAssetMethod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetMethodNameL2 { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool FixedAssetMethodIsActive { get; set; } = true;
    }
}