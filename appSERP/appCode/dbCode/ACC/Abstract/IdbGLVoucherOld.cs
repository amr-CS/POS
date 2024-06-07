using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLVoucherOld
    {

        string funGLVoucherGET(
        string pGLVoucherId = null,
        string pGLVoucherCode = null,
        string pGLVoucherNameL1 = null,
        string pGLVoucherNameL2 = null,
        string pGLVoucherNo = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pSystemId = null,
        int? pCashDeskId = null,
        DateTime? pGLVoucherDate = null,
        DateTime? pGLVoucherTime = null,
        int? pGLVoucherRef = null,
        DateTime? pGLVoucherRefDate = null,
        int? pPaymentTypeId = null,
        bool? pIsPosted = null,
         bool? pIsIssued = null,
        string pGLVoucherNote = null,
        int? pUserId = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        bool? pDocIsCancelled = null,
        bool? pDocIsWait = null,
        bool? pGLVoucherIsRepeated = null,
        int? pGLIdPayType = null,
        int? pGLVoucherCategoryId = null,
        decimal? pGLOppsVoucherValue = null,
        int? pGLOppsVoucherId = null,
        int? pGLOppsVoucherYearId = null,
        int? pStoreId = null,
        int? pInvTransactionTypeId = null,
        int? pCSId = null,
        int? pVoucherSeq = null,
        bool? pGLVoucherIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetGlVoucherReport(int? pGLVoucherId = null, int? VoucherTypeId = null, bool? pIsActive = null);

        DataTable funGetGlVoucherReceiptReport(string pGLVoucherNo = null, bool? pIsActive = null);

        DataTable funGetGlVoucherPaymentReport(string pGLVoucherNo = null, bool? pIsActive = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        object vGLVoucherId { get; set; }
    }
}
