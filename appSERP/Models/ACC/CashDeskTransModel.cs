using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CashDeskTransModel
    {
        [Display(Name = "CashDeskTransId", ResourceType = typeof(appResource))]
        public string CashDeskTransId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string CashDeskTransCode { get; set; }
        public string CashDeskTransNameL1 { get; set; }
        public string CashDeskTransNameL2 { get; set; }
        [Display(Name = "CashDeskTransNo", ResourceType = typeof(appResource))]
        public string CashDeskTransNo { get; set; }
        [Display(Name = "CashDeskTransTypeId", ResourceType = typeof(appResource))]
        public int VoucherTypeId { get; set; }
        [Display(Name = "_FinancialYear", ResourceType = typeof(appResource))]
        public int FinancialYearId { get; set; }
        [Display(Name = "_CashDesk", ResourceType = typeof(appResource))]
        public int CashDeskId { get; set; }
        [Display(Name = "_MainCashDesk", ResourceType = typeof(appResource))]
        public int MainCashDeskId { get; set; }
        [Display(Name = "GLVoucherId", ResourceType = typeof(appResource))]
        public string GLVoucherId { get; set; }
        [Display(Name = "CashDeskTransDate", ResourceType = typeof(appResource))]
        public DateTime CashDeskTransDate { get; set; }
        [Display(Name = "CashDeskTransTime", ResourceType = typeof(appResource))]
        public TimeSpan CashDeskTransTime { get; set; }
        [Display(Name = "CashDeskTransRef", ResourceType = typeof(appResource))]
        public int CashDeskTransRef { get; set; }
        [Display(Name = "CashDeskTransRefDate", ResourceType = typeof(appResource))]
        public DateTime CashDeskTransRefDate { get; set; }
        [Display(Name = "PaymentTypeId", ResourceType = typeof(appResource))]
        public int PaymentTypeId { get; set; }
        [Display(Name = "_IsPosted", ResourceType = typeof(appResource))]
        public bool IsPosted { get; set; }
        [Display(Name = "IsIssued", ResourceType = typeof(appResource))]
        public bool IsIssued { get; set; }
        public bool IsCashDeskIn { get; set; }
        [Display(Name = "_Note", ResourceType = typeof(appResource))]
        public string CashDeskTransNote { get; set; }
        [Display(Name = "_IsCancelled", ResourceType = typeof(appResource))]
        public bool DocIsCancelled { get; set; }
        [Display(Name = "_IsWait", ResourceType = typeof(appResource))]
        public bool DocIsWait { get; set; }
        [Display(Name = "_IsRepeated", ResourceType = typeof(appResource))]
        public bool CashDeskTransIsRepeated { get; set; }
        [Display(Name = "IdPayType", ResourceType = typeof(appResource))]
        public int GLIdPayType { get; set; }
        [Display(Name = "CashDeskTransCategoryId", ResourceType = typeof(appResource))]
        public int CashDeskTransCategoryId { get; set; }
        [Display(Name = "GLOppsVoucherValue", ResourceType = typeof(appResource))]
        public decimal GLOppsVoucherValue { get; set; }
        [Display(Name = "GLOppsVoucherId", ResourceType = typeof(appResource))]
        public int GLOppsVoucherId { get; set; }
        [Display(Name = "OppsVoucherYearId", ResourceType = typeof(appResource))]
        public int GLOppsVoucherYearId { get; set; }
        public int StoreId { get; set; }
        public int InvTransactionTypeId { get; set; }
        [Display(Name = "_Customer", ResourceType = typeof(appResource))]
        public int CSId { get; set; }
        [Display(Name = "VoucherSequence", ResourceType = typeof(appResource))]
        public int VoucherSeq { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        public bool CashDeskTransIsActive { get; set; } = true;








    }
}