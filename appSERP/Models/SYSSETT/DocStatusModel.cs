using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SYSSETT
{   ///  BELAL    21/1/2018 
    public class DocStatusModel
    {
        public int DocStatusId { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DocStatusNameL1 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DocStatusNameL2 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DocStatusNameL3 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL4 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL5 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL6 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL7 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL8 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL9 { get; set; }
        [Display(Name = "_DocStatus", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNameL10 { get; set; }
        [Display(Name = "dtNext", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]

        public string DocStatusNext { get; set; }
        [Display(Name = "ProName", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string DocStatusProName { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool DocStatusIsActive { get; set; } = true;
    }
}