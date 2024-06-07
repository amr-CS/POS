using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class FixedAssetCompanyTypeModel
    {
        public int    FixedAssetCompanyTypeId       { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyTypeCode     { get; set; }
        [Display(Name = "FixedAssetCompanyTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyTypeNameL1   { get; set; }
        [Display(Name = "FixedAssetCompanyTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FixedAssetCompanyTypeNameL2   { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   FixedAssetCompanyTypeIsActive { get; set; } = true;
    }
}