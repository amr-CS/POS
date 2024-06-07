using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.GD
{   ///  BELAL    21/1/2018 
    public class CompanyBranchModel
    {
        public int CompanyBranchId { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CompanyBranchCode { get; set; }

        [Display(Name = "_Company", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CompanyBranchNameL1 { get; set; }

        [Display(Name = "_Company", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string CompanyBranchNameL2 { get; set; }

        [Display(Name = "_Level", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CompanyBranchLevel { get; set; }

        [Display(Name = "IsHolding", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsHolding { get; set; }

        [Display(Name = "AccountCodeHierarchy", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AccountCodeHierarchy { get; set; }

        [Display(Name = "LastClosedYear", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int LastClosedYear { get; set; }

        [Display(Name = "LastClosedMonth", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int LastClosedMonth { get; set; }

        [Display(Name = "RefNumberIsVisible", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool RefNumberIsVisible { get; set; }

        [Display(Name = "CostCenterIsRequired", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool CostCenterIsRequired { get; set; }

        [Display(Name = "PostIsSerialized", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool PostIsSerialized { get; set; }

        [Display(Name = "_VoucherType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool DepositIsSentDirectToBank { get; set; }

        [Display(Name = "IsPostZeroEntry", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsPostZeroEntry { get; set; }

        [Display(Name = "DefaultCurrencyId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int DefaultCurrencyId { get; set; }

        [Display(Name = "PLAccountId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int  PLAccountId { get; set; }

        [Display(Name = "RDAccountId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int  RDAccountId { get; set; }

        [Display(Name = "_FinancialYear", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FinancialYearId { get; set; }

        [Display(Name = "_Language", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int Language1Id { get; set; }

        [Display(Name = "_Language", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int  Language2Id { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool CompanyBranchIsActive { get; set; } = true;

    }
}