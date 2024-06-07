using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCashDeskTrans
    {

        string funCashDeskTransGET(
        string pCashDeskTransId = null,
        string pCashDeskTransCode = null,
        string pCashDeskTransNameL1 = null,
        string pCashDeskTransNameL2 = null,
        string pCashDeskTransNo = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pSystemId = null,
        int? pCashDeskId = null,
        int? pMainCashDeskId = null,
        string pGLVoucherId = null,
        DateTime? pCashDeskTransDate = null,
        DateTime? pCashDeskTransTime = null,
        int? pCashDeskTransRef = null,
        DateTime? pCashDeskTransRefDate = null,
        int? pPaymentTypeId = null,
        bool? pIsPosted = null,
        bool? pIsIssued = null,
        bool? pDateFrom = null,
        bool? pDateTo = null,
        bool? pIsCashDeskIn = null,
        string pCashDeskTransNote = null,
        int? pUserId = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        bool? pDocIsCancelled = null,
        bool? pDocIsWait = null,
        bool? pCashDeskTransIsRepeated = null,
        int? pGLIdPayType = null,
        int? pCashDeskTransCategoryId = null,
        decimal? pGLOppsVoucherValue = null,
        int? pGLOppsVoucherId = null,
        int? pGLOppsVoucherYearId = null,
        int? pStoreId = null,
        int? pInvTransactionTypeId = null,
        int? pCSId = null,
        int? pVoucherSeq = null,
        bool? pCashDeskTransIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        object vCashDeskTransId { get; set; }
        bool vIsCashDeskTransIn { get; set; }
    }
}
