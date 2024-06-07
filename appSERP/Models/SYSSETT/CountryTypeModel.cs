using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SYSSETT
{   ///  BELAL    21/1/2018 
    public class CountryTypeModel
    {
         public int CountryTypeId        { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string CountryTypeCode   { get; set; }

        [Display(Name = "_CountryType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CountryTypeNameL1 { get; set; }

        [Display(Name = "_CountryType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CountryTypeNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool CountryTypeIsActive { get; set; } = true;
    }
}