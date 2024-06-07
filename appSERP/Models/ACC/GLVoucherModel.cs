using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   ///  BELAL    21/1/2018 
    public class GLVoucherModel
    {
        [Display(Name = "GLVoucherId", ResourceType = typeof(appResource))]
        public string   GLVoucherId { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string  GLVoucherCode { get; set; }

        public string GLVoucherNameL1 { get; set; }
        public string GLVoucherNameL2 { get; set; }
        [Display(Name = "GLVoucherNo", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherNo { get; set; }

        [Display(Name = "GLVoucherTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int VoucherTypeId { get; set; }

        [Display(Name = "_FinancialYear", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FinancialYearId { get; set; }

        [Display(Name = "_CashDesk", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CashDeskId { get; set; }

        [Display(Name = "GLVoucherDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public DateTime GLVoucherDate { get; set; }

        [Display(Name = "GLVoucherTime", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public TimeSpan GLVoucherTime   { get; set; }
        [Display(Name = "GLVoucherRef", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherRef { get; set; }

        [Display(Name = "GLVoucherRefDate", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public DateTime  GLVoucherRefDate { get; set; }

        [Display(Name = "PaymentTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int PaymentTypeId { get; set; }

        [Display(Name = "_IsPosted", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsPosted { get; set; }

        [Display(Name = "IsIssued", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsIssued { get; set; }

        [Display(Name = "_Note", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string GLVoucherNote   { get; set; }

        [Display(Name = "_IsCancelled", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool DocIsCancelled  { get; set; }

        [Display(Name = "_IsWait", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool DocIsWait { get; set; }

        [Display(Name = "_IsRepeated", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool GLVoucherIsRepeated { get; set; }

        [Display(Name = "IdPayType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLIdPayType { get; set; }

        [Display(Name = "GLVoucherCategoryId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLVoucherCategoryId { get; set; }

        [Display(Name = "GLOppsVoucherValue", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public decimal GLOppsVoucherValue { get; set; }

        [Display(Name = "GLOppsVoucherId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLOppsVoucherId { get; set; }

        [Display(Name = "OppsVoucherYearId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int GLOppsVoucherYearId { get; set; }
        public int StoreId { get; set; }
        public int InvTransactionTypeId { get; set; }

        [Display(Name = "_Customer", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CSId { get; set; }

        [Display(Name = "VoucherSequence", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int VoucherSeq { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool GLVoucherIsActive { get; set; } = true;
    }
}