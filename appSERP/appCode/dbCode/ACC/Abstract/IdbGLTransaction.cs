using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLTransaction
    {
        string funGLTransactionGET(
        int? pTransactionId = null,
        string pTransactionCode = null,
        string pTransactionNameL1 = null,
        string pTransactionNameL2 = null,
        int? pTransactionTypeId = null,
        int? pFinancialYearId = null,
        int? pBranchId = null,
        int? pGLVoucherDtlId = null,
        int? pTransactionSoruceId = null,
        int? pCashDeskId = null,
        int? pAccountId = null,
        int? pTransactionSeq = null,
        int? pTransactionDate = null,
        decimal? pTransactionDebit = null,
        decimal? pTransactionCredit = null,
        decimal? pTransactionDebitBase = null,
        decimal? pTransactionCreditBase = null,
        string pTransactionNote = null,
        int? pIsPosted = null,
        int? pCostCenterId = null,
        string pUserFullName = null,
        string pUserName = null,
        int? pStoreId = null,
        string pTransactionDescription = null,
        int? pTransactionRef = null,
        int? pTransactionSeqDtl = null,
        int? pCurrencyId = null,
        decimal? pTransactionHdDebit = null,
        decimal? pTransactionHdCredit = null,
        string pTransactionHdNote = null,
        int? pCSId = null,
        int? pAccountingPeriodId = null,
        bool? pIsTransfered = null,
        string pChildAccounts = null,
        bool? pTransactionIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);


        string funGLTransactionReportGET(
      int? pTransactionId = null,
      string pTransactionCode = null,
      string pTransactionNameL1 = null,
      string pTransactionNameL2 = null,
      int? pTransactionTypeId = null,
      int? pFinancialYearId = null,
      int? pBranchId = null,
      int? pGLVoucherDtlId = null,
      int? pTransactionSoruceId = null,
      int? pCashDeskId = null,
      string pAccountId = null,
      int? pTransactionSeq = null,
      int? pTransactionDate = null,
      decimal? pTransactionDebit = null,
      decimal? pTransactionCredit = null,
      decimal? pTransactionDebitBase = null,
      decimal? pTransactionCreditBase = null,
      string pTransactionNote = null,
      int? pIsPosted = null,
      int? pCostCenterId = null,
      string pUserFullName = null,
      string pUserName = null,
      int? pStoreId = null,
      string pTransactionDescription = null,
      int? pTransactionRef = null,
      int? pTransactionSeqDtl = null,
      int? pCurrencyId = null,
      decimal? pTransactionHdDebit = null,
      decimal? pTransactionHdCredit = null,
      string pTransactionHdNote = null,
      int? pCSId = null,
      int? pAccountingPeriodId = null,
      bool? pIsTransfered = null,
      string pChildAccounts = null,
      bool? pTransactionIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = null,
      DateTime? pDateFrom = null,
      DateTime? pDateTo = null,
      string pAccountFrom = null,
      string pAccountTo = null
            );


        DataTable funTransactionReport(int? ItemId = null, DateTime? DateFrom = null, DateTime? DateTo = null, int? InvTypeId = null,
          int? StoreId = null, int? reportTypeId = null);

        DataTable funGetGLTransactionReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null);

        DataTable funGetGLTransactionReportTotal(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null);

        DataTable funGetGLTransactionReportTotalCostCenter(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null);

        DataTable funGetGLTransactionReportDetailsCostCenter(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
