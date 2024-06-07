using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{   ///  BELAL    21/1/2018 
    public class FontSizeTypeModel
    {
        public int FontSizeTypeId        { get; set; }

        [Display(Name = "_FontSizeType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FontSizeTypeNameL1 { get; set; }

        [Display(Name = "_FontSizeType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string FontSizeTypeNameL2 { get; set; }

        [Display(Name = "_Value", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FontSizeTypeValue     { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool FontSizeTypeIsActive { get; set; } = true;

    }
}