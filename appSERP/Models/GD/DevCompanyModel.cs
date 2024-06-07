using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.GD
{
    ///  BELAL    16/2/2019 
    public class DevCompanyModel
    {
        public int DevCompanyId { get; set; }
        [Display(Name = "_Company", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyNameL1 { get; set; }
        [Display(Name = "_Company", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyNameL2 { get; set; }
        [Display(Name = "_Phone1", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyPhone { get; set; }
        [Display(Name = "_Phone2", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyPhone2 { get; set; }
        [Display(Name = "_Email", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyEmail { get; set; }
        [Display(Name = "_Website", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyWebsite { get; set; }
        [Display(Name = "_Address", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevCompanyAddress { get; set; }
        [Display(Name = "_Image", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public Object DevCompanyImage { get; set; }
        [Display(Name = "صوره كامله")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public Object DevCompanyImageFull { get; set; }
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevAppNameL1 { get; set; }
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevAppNameL2 { get; set; }
        [Display(Name = "صورة البرنامج")]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DevAppImage { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool DevCompanyIsActive { get; set; } = true;


    }
}