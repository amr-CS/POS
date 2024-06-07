using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{   ///  BELAL    21/1/2018 
    public class UserSecurityTransactionTypeModel
    {
        public int UserSecurityTransactionTypeId            { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL1     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL2     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL3     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL4     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL5     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL6     { get; set; }
        [Display(Name = "FontSizeTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL7     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL8     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL9     { get; set; }
        [Display(Name = "_UserSecurityTransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserSecurityTransactionTypeNameL10    { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool UserSecurityTransactionTypeIsActive     { get; set; } = true;
    }
}