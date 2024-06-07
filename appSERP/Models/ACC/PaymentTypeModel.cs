using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class PaymentTypeModel
    {
        public int PaymentTypeId        { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string PaymentTypeCode   { get; set; }

        [Display(Name = "PaymentTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string PaymentTypeNameL1 { get; set; }

        [Display(Name = "PaymentTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string PaymentTypeNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool PaymentTypeIsActive { get; set; } = true;
    }
}