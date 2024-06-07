using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SYSSETT
{
    public class UserFavoriteModel
    {
        public int UserFavoriteId { get; set; }
        [Display(Name = "UserName", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserId { get; set; }
        [Display(Name = "_Object", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int ObjectId { get; set; } 
    }
}