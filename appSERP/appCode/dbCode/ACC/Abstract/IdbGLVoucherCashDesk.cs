using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLVoucherCashDesk
    {

        string funGLVoucherCashDeskGET(
        int? pGLVoucherCashDeskId = null,
        string pGLVoucherCashDeskCode = null,
        string pGLVoucherCashDeskNameL1 = null,
        string pGLVoucherCashDeskNameL2 = null,
        int? pGLVoucherId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pCaskDeskId = null,
        int? pMainCashDeskId = null,
        int? pAccountId = null,
        int? pGLVoucherCashDeskDebit = null,
        int? pGLVoucherCashCredit = null,
        int? pGLVoucherCashDeskDebitBase = null,
        int? pGLVoucherCashDeskCreditBase = null,
        int? pBaseCurrencyValue = null,
        int? pPayDebit = null,
        int? pPayCredit = null,
        int? pCurrencyId = null,
        int? pCostCenterId = null,
        string pGLVoucherCashDeskNote = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        int? pTransSeq = null,
        bool? pGLVoucherCashDeskIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
