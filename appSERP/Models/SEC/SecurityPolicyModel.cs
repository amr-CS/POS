using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{
    public class SecurityPolicyModel
    {
       
        public int SecurityPolicyId { get; set; }
        [Display(Name = "SecurityPolicySeq", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SecurityPolicySeq { get; set; }
        [Display(Name = "SecurityPolicyId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityPolicyNameL1 { get; set; }
        [Display(Name = "SecurityPolicyId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityPolicyNameL2 { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SecurityPolicyIsActive { get; set; } = true;
    }
}