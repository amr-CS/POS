using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace appSERP.Models.INV
{
    public class OfferTypeModel
    {
        public int OfferTypeId { get; set; }

        public int UnitId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string OfferTypeCode { get; set; }

        [Display(Name = "OfferTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string OfferTypeNameL1 { get; set; }

        [Display(Name = "OfferTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string OfferTypeNameL2 { get; set; }
        [Display(Name = "Abbr", ResourceType = typeof(appResource))]
        public string Abbr { get; set; }
        [Display(Name = "_IsDefault", ResourceType = typeof(appResource))]
        public bool IsDefault { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool OfferTypeIsActive { get; set; } = true;
    }
}