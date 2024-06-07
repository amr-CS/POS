using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public string TransactionNameL1 { get; set; }
        public string TransactionNameL2 { get; set; }
        public string TransactionCode { get; set; }
        public int TransactionTypeId { get; set; }
        public int FinancialYearId { get; set; }
        public int TransactionSoruceId { get; set; }
        public int CashDeskId { get; set; }
        public int AccountId { get; set; }
        public int TransactionSeq { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionDebit { get; set; }
        public decimal TransactionCredit { get; set; }
        public decimal TransactionDebitBase { get; set; }
        public decimal TransactionCreditBase { get; set; }
        public int GLVoucherDtlId { get; set; }
        public string TransactionNote { get; set; }
        public bool IsPosted  {get; set; }
        public int CostCenterId   {get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public int StoreId { get; set; }
        public string TransactionDescription { get; set; }
        public int TransactionRef { get; set; }
        public int TransactionSeqDtl { get; set; }
        public decimal TransactionHdDebit { get; set; }
        public decimal TransactionHdCredit { get; set; }
        public string TransactionHdNote { get; set; }
        public int CSId { get; set; }
        public int AccountingPeriodId { get; set; }
        public bool IsTransfered { get; set; }
        public bool TransactionIsActive { get; set; } = true;
    }
}