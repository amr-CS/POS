using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{
    public class UserSecurityLogModel
    {
        public int SecurityLogId { get; set; }
        [Display(Name = "SecurityLogLat", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityLogLat { get; set; }
        [Display(Name = "SecurityLogLng", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityLogLng { get; set; }
        [Display(Name = "SecurityLogLocation", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityLogLocation { get; set; }

        [Display(Name = "SecurityLogDevice", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SecurityLogDevice { get; set; }

        [Display(Name = "SecurityLogDeviceIsMobile", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SecurityLogDeviceIsMobile { get; set; }

        [Display(Name = "SecurityLogDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public DateTime SecurityLogDate { get; set; }

        [Display(Name = "SecurityLogTime", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public TimeSpan SecurityLogTime { get; set; }

        [Display(Name = "OldPassword", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string OldPassword { get; set; }

        [Display(Name = "NewPassword", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string NewPassword { get; set; }

        [Display(Name = "UserId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserId { get; set; }

        [Display(Name = "UserSecurityTransactionTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserSecurityTransactionTypeId { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SecurityLogIsActive { get; set; } = true;
    }
}