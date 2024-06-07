using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{
    public class SecurityRoleModel
    {
        // Master
        public int SecurityRoleId { get; set; }

        [Display(Name = "SecurityRoleId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityRoleNameL1 { get; set; }

        [Display(Name = "SecurityRoleId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityRoleNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SecurityRoleIsActive { get; set; } = true;

        public bool IsMaster { get; set; }

        // Detail
        public int SecurityRoleObjectId { get; set; }

        [Display(Name = "_Object", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int ObjectId { get; set; }

        [Display(Name = "ObjectAction", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string ObjectAction { get; set; }
      
    
    }
}