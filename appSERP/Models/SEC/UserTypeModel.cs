using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{   ///  BELAL    21/1/2018 
    public class UserTypeModel
    {
        public int UserTypeId          { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string UserTypeCode     { get; set; }

        [Display(Name = "_UserType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserTypeNameL1   { get; set; }

        [Display(Name = "_UserType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserTypeNameL2   { get; set; }

        [Display(Name = "UserTypeMaxDis", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserTypeMaxDis      { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool UserTypeIsActive   { get; set; } = true;
    }
}