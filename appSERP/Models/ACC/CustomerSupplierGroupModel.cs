using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class CustomerSupplierGroupModel
    {
        public int    CSGroupId              { get; set; }

        [Display(Name = "_CSGroup", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSGroupNameL1          { get; set; }

        [Display(Name = "_CSGroup", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSGroupNameL2          { get; set; }

        [Display(Name = "_CreditLimit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    CSGroupCreditLimit     { get; set; }

        [Display(Name = "GracePeriodDays", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    CSGroupGracePeriodDays { get; set; }

        [Display(Name = "_IsCustomerGroup", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CSGroupIsCustomerGroup { get; set; }

        [Display(Name = "_IsDefault", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CSGroupIsDefault       { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CSGroupIsActive        { get; set; } = true;
    }
}