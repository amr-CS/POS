using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.FA
{
    public class MainGroupModel
    {

        public int MainGroupId { get; set; }
        [Display(Name = "MainGroupId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string MainGroupNameL1 { get; set; }
        [Display(Name = "MainGroupId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string MainGroupNameL2 { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool MainGroupIsActive { get; set; } = true;

        [Display(Name = "FixedAssetMethod", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FixedAssetMethodId { get; set; }

        [Display(Name = "_Percent", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainGroupPercent { get; set; }

        [Display(Name = "_Debit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainGroupDebitAccount { get; set; }

        [Display(Name = "_Credit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainGroupCreditAccount { get; set; }

        [Display(Name = "_PurchaseAccount", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainGroupPurchaseAccount { get; set; }

        [Display(Name = "_SalesAccount", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainGroupSalesAccount { get; set; }

    }
}