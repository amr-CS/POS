using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class GLVoucherCategoryModel
    {
        public int    GLVoucherCategoryId         { get; set; }

        [Display(Name = "VoucherCategory", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCategoryNameL1     { get; set; }

        [Display(Name = "GLVoucherCategoryId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCategoryNameL2     { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   GLVoucherCategoryIsActive   { get; set; } = true;
    }
}