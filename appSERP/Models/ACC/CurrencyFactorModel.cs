using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class CurrencyFactorModel
    {
        public int     CurrencyFactorId       { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string  CurrencyFactorCode     { get; set; }

        [Display(Name = "CurrencyFactorId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string  CurrencyFactorNameL1   { get; set; }

        [Display(Name = "CurrencyFactorId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string  CurrencyFactorNameL2   { get; set; }

        [Display(Name = "_Value", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal CurrencyFactorValue    { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool    CurrencyFactorIsActive { get; set; } = true;
    }
}