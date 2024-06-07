using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class SiteDonorModel
    {
        public int SiteDonorId { get; set; }
        [Display(Name = "SiteDonor", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SiteDonorNameL1 { get; set; }
        [Display(Name = "SiteDonor", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SiteDonorNameL2 { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SiteDonorIsActive { get; set; } = true;
    }
}