using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CashDeskDtlModel
    {
        public int CashDeskDtlId { get; set; }
        public string CashDeskDtlCode { get; set; }
        public string CashDeskDtlNameL1 { get; set; }
        public string CashDeskDtlNameL2 { get; set; }
        public int CashDeskTransId { get; set; }
        public int GLVoucherTypeId { get; set; }
        public int FinancialYearId { get; set; }
        public int AccountId { get; set; }
        public int CashDeskId { get; set; }
        public int CurrencyId { get; set; }
        public decimal CashDeskDtlDebit { get; set; }
        public decimal CashDeskDtlCredit { get; set; }
        public decimal CashDeskDtlDebitBase { get; set; }
        public decimal CashDeskDtlCreditBase { get; set; }
        public decimal BaseCurrencyValue { get; set; }
        public decimal CashDeskDtlPayDebit { get; set; }
        public decimal CashDeskDtlPayCredit { get; set; }
        public decimal PayCurrencyValue { get; set; }
        public string CashDeskDtlNote { get; set; }
        public int CostCenterId { get; set; }
        public bool IsPosted { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public int CashDeskDtlTransSeq { get; set; }
        public bool CashDeskDtlIsActive { get; set; } = true;
    }
}