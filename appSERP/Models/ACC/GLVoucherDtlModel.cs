using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class GLVoucherDtlModel
    {
        public int GLVoucherDtlId { get; set; }
        public string GLVoucherDtlCode { get; set; }
        public string GLVoucherDtlNameL1 { get; set; }
        public string GLVoucherDtlNameL2 { get; set; }
        public string GLVoucherId { get; set; }
        public int GLVoucherTypeId { get; set; }
        public int FinancialYearId { get; set; }
        public int AccountId { get; set; }
        public int CashDeskId { get; set; }
        public int CurrencyId { get; set; }
        public decimal GLVoucherDtlDebit { get; set; }
        public decimal GLVoucherDtlCredit { get; set; }
        public decimal GLVoucherDtlDebitBase { get; set; }
        public decimal GLVoucherDtlCreditBase { get; set; }
        public decimal BaseCurrencyValue { get; set; }
        public decimal GLVoucherDtlPayDebit { get; set; }
        public decimal GLVoucherDtlPayCredit { get; set; }
        public decimal PayCurrencyValue { get; set; }
        public string GLVoucherDtlNote { get; set; }
        public int CostCenterId { get; set; }
        public bool IsPosted { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public int GLVoucherDtlTransSeq { get; set; }
        public bool GLVoucherDtlIsActive { get; set; } = true;

    }
}