using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SYSSETT
{   ///  BELAL    21/1/2018 
    public class SystemMessageModel
    {
        public int SystemMessageId     { get; set; }

        [Display(Name = "SystemMessageTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SystemMessageTypeId { get; set; }

        [Display(Name = "_Language", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int LanguageId          { get; set; }

        [Display(Name = "SystemMessageId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SystemMessageText{ get; set; } 
    }
}