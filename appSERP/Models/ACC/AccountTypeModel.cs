using appSERP.Views.Shared.appResource;
using System.ComponentModel.DataAnnotations;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class AccountTypeModel
    {
        public int AccountTypeId { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountTypeCode { get; set; }

        [Display(Name = "AccountTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountTypeNameL1 { get; set; }

        [Display(Name = "AccountTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountTypeNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool   AccountTypeIsActive { get; set; } = true;
    }
}