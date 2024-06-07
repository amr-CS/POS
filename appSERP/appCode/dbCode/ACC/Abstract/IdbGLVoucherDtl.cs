using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLVoucherDtl
    {
        string funGLVoucherDtlGET(
        int? pGLVoucherDtlId = null,
        string pGLVoucherDtlCode = null,
        string pGLVoucherDtlNameL1 = null,
        string pGLVoucherDtlNameL2 = null,
        string pGLVoucherId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pAccountId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        decimal? pGLVoucherDtlDebit = null,
        decimal? pGLVoucherDtlCredit = null,
        decimal? pGLVoucherDtlDebitBase = null,
        decimal? pGLVoucherDtlCreditBase = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pGLVoucherDtlPayDebit = null,
        decimal? pGLVoucherDtlPayCredit = null,
        decimal? pPayCurrencyValue = null,
        string pGLVoucherDtlNote = null,
        int? pCostCenterId = null,
        bool? pIsPosted = null,
        string pUserFullName = null,
        string pUserName = null,
        string pGLVoucherDtlTransSeq = null,
        bool? pGLVoucherDtlIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
