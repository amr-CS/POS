using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class ProductTypeModel
    {
        public int productTypeId { get; set; }

        public int UnitId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string productTypeCode { get; set; }

        [Display(Name = "productTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string productTypeNameL1 { get; set; }
        [Display(Name = "productTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string productTypeNameL2 { get; set; }
        [Display(Name = "ShortName", ResourceType = typeof(appResource))]
        public string ShortName { get; set; }
        [Display(Name = "ProductTypeLevel", ResourceType = typeof(appResource))]
        public string ProductTypeLevel { get; set; }
        [Display(Name = "_Parent", ResourceType = typeof(appResource))]
        public string ProductTypeParentId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool productTypeIsActive { get; set; } = true;
    }
}