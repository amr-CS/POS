using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class StoreDepartmentModel
    {
        public int StoreDepartmentId { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreDepartmentCode { get; set; }

        [Display(Name = "StoreDepartmentId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreDepartmentNameL1 { get; set; }

        [Display(Name = "StoreDepartmentId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreDepartmentNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool StoreDepartmentIsActive { get; set; } = true;
    }
}