using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCashDeskDtl
    {
        string funCashDeskDtlGET(
        int? pCashDeskDtlId = null,
        string pCashDeskDtlCode = null,
        string pCashDeskDtlNameL1 = null,
        string pCashDeskDtlNameL2 = null,
        string pCashDeskTransId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pAccountId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        decimal? pCashDeskDtlDebit = null,
        decimal? pCashDeskDtlCredit = null,
        decimal? pCashDeskDtlDebitBase = null,
        decimal? pCashDeskDtlCreditBase = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pCashDeskDtlPayDebit = null,
        decimal? pCashDeskDtlPayCredit = null,
        decimal? pPayCurrencyValue = null,
        string pCashDeskDtlNote = null,
        int? pCostCenterId = null,
        bool? pIsPosted = null,
        string pUserFullName = null,
        string pUserName = null,
        string pCashDeskDtlTransSeq = null,
        bool? pCashDeskDtlIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
