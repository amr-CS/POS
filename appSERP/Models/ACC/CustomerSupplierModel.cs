using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class CustomerSupplierModel
    {
        public int CSId                     { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSCode                { get; set; }

        [Display(Name = "_Customer", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string CSNameL1              { get; set; }
        [Display(Name = "_Customer", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSNameL2              { get; set; }

        [Display(Name = "_Address", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSAddress             { get; set; }

        [Display(Name = "_Phone1", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSPhone1              { get; set; }

        [Display(Name = "_Phone2", ResourceType = typeof(appResource))]
        //[Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSPhone2              { get; set; }

        [Display(Name = "_Email", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSEmail               { get; set; }

        [Display(Name = "ContactPerson", ResourceType = typeof(appResource))]
        //[Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSContactPerson       { get; set; }

        [Display(Name = "SalesPurchasePerson", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSSalesPurchasePerson { get; set; }

        [Display(Name = "TaxNumber", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CSTaxNumber           { get; set; }

        [Display(Name = "_Area", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    AreaId                { get; set; }

        [Display(Name = "_CreditLimit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    CSCreditLimit         { get; set; }

        [Display(Name = "_CSGroup", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    CSGroupId             { get; set; }

        [Display(Name = "GracePeriodDays", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    GracePeriod           { get; set; }

        [Display(Name = "_Account", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int    AccountId             { get; set; }

        [Display(Name = "_IsCustomer", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CSIsCustomer          { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   CSIsActive            { get; set; } = true;
    }
}