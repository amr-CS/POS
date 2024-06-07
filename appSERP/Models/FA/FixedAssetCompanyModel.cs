using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class FixedAssetCompanyModel
    {
        public int FixedAssetCompanyId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyCode { get; set; }
        [Display(Name = "FixedAssetCompanyId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyNameL1 { get; set; }
        [Display(Name = "FixedAssetCompanyId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyNameL2 { get; set; }
        [Display(Name = "FixedAssetCompanyTypeId", ResourceType = typeof(appResource))]
        public int FixedAssetCompanyTypeId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool FixedAssetCompanyIsActive { get; set; } = true;
    }
}