using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class CurrencyGenderModel
    {
        public int    CurrencyGenderId       { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string CurrencyGenderCode     { get; set; }

        [Display(Name = "_Gender", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CurrencyGenderNameL1   { get; set; }

        [Display(Name = "_Gender", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CurrencyGenderNameL2   { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CurrencyGenderIsActive { get; set; } = true;
    }
}