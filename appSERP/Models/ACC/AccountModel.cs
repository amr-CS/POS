using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class AccountModel
    {
        public int AccountId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        //[Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountNo { get; set; }

        [Display(Name = "_Account", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountNameL1 { get; set; }

        [Display(Name = "_Account", ResourceType = typeof(appResource))]
        //[Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountNameL2 { get; set; }

        [Display(Name = "_Parent", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AccountParentId { get; set; }

        [Display(Name = "_Level", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AccountLevel { get; set; }

        [Display(Name = "_Currency", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CurrencyId { get; set; }

        [Display(Name = "_CostCenter", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsCostCenter { get; set; }


        [Display(Name = "CurrencyFactorId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CurrencyFactorId { get; set; }

        [Display(Name = "SecurityGradeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SecurityGradeId { get; set; }

        [Display(Name = "_Debit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AccountIsDebit { get; set; }

        [Display(Name = "AccountTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AccountTypeId { get; set; }

        [Display(Name = "AccountingReportId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AccountingReportId { get; set; }

        [Display(Name = "AccountIsCumulative", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AccountIsCumulative { get; set; }


        [Display(Name = "CashFlowTypeId", ResourceType = typeof(appResource))]
        //[Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int? CashFlowTypeId { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AccountIsActive { get; set; } = true;

        public int CompanyId { get; set; }

    }
}