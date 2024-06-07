using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class GLVoucherCashDeskModel
    {
        public int GLVoucherCashDeskId          { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCashDeskCode     { get; set; }
        [Display(Name = "_CashDesk", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCashDeskNameL1   { get; set; }

        [Display(Name = "_CashDesk", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCashDeskNameL2   { get; set; }

        [Display(Name = "GLVoucherId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherId                  { get; set; }

        [Display(Name = "GLVoucherTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherTypeId              { get; set; }

        [Display(Name = "FinancialYear", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FinancialYearId              { get; set; }
        [Display(Name = "_CaskDesk", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CaskDeskId                   { get; set; }

        [Display(Name = "_MainCashDesk", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int MainCashDeskId               { get; set; }

        [Display(Name = "_Account", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AccountId                    { get; set; }

        [Display(Name = "_Debit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherCashDeskDebit       { get; set; }

        [Display(Name = "_Credit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherCashCredit          { get; set; }

        [Display(Name = "_DebitBase", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherCashDeskDebitBase   { get; set; }

        [Display(Name = "_CreditBase", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int  GLVoucherCashDeskCreditBase { get; set; }

        [Display(Name = "_Value", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int BaseCurrencyValue            { get; set; }

        [Display(Name = "_Debit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int PayDebit                     { get; set; }

        [Display(Name = "_Credit", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int PayCredit                    { get; set; }

        [Display(Name = "_Currency", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CurrencyId                   { get; set; }

        [Display(Name = "_CostCenter", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CostCenterId                 { get; set; }

        [Display(Name = "_Note", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherCashDeskNote     { get; set; }

        [Display(Name = "VoucherSequence", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int TransSeq                     { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool GLVoucherCashDeskIsActive   { get; set; } = true;

    }
}