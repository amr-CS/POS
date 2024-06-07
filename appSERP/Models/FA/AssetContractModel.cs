using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public  class AssetContractModel
    {

        public int AssetContractId { get; set; }
        [Display(Name = "_Date", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AssetContractDate { get; set; } = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

        [Display(Name = "AssetContractPeriod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetContractPeriod { get; set; }

        [Display(Name = "AssetContractRefNo", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetContractRefNo { get; set; }

        [Display(Name = "AssetContractValue", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetContractValue { get; set; }

        [Display(Name = "_Currency", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CurrencyId { get; set; }

        [Display(Name = "AssetContractNote", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetContractNote { get; set; }

        [Display(Name = "AssetContractNo", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetContractNo { get; set; }

        [Display(Name = "IdPayType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetContractPayTypeId { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        public bool AssetContractIsActive { get; set; } = true;

    }
}