using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class VoucherBoxCheck
    {
        public int VoucherBoxCheckId { get; set; }

        public int GLVoucherId { get; set; }
        public int CashDeskId { get; set; }
        public int CurrencyId { get; set; }
        public string AccountId { get; set; }
        public decimal PayDebit { get; set; }
        public decimal PayCurrencyValue { get; set; }
        public decimal Debit { get; set; }
        public decimal BaseCurrencyValue { get; set; }
        public decimal BaseDebit { get; set; }
        public decimal Credit { get; set; }
        public decimal BaseCredit { get; set; }
        public string Note { get; set; }
        public int? CostCenterId { get; set; }
        public bool? VoucherIsCheck { get; set; }
        public int? CheckBankId { get; set; }
        public int? CheckNo { get; set; }
        public DateTime CheckDate { get; set; }
        public decimal? CheckDebit { get; set; }
        public decimal? CheckCurrencyValue { get; set; }
        public decimal? CheckBaseDebit { get; set; }
        public string CheckNote { get; set; }
        public int? CheckCostCenterId { get; set; }
        public int? CheckBankBranchId { get; set; }
        public int? PayTypeId { get; set; }
        public int EPayTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}