using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APIGLTransactionController : ApiController
    {
        private IdbGLTransaction _dbGLTransaction;
        public APIGLTransactionController(IdbGLTransaction dbGLTransaction)
        {
            _dbGLTransaction = dbGLTransaction;
        }
        [HttpGet]
        public string GLTransactionGET(
        int? pTransactionId = null,
        string pTransactionCode = null,
        string pTransactionNameL1 = null,
        string pTransactionNameL2 = null,
        int? pTransactionTypeId = null,
        int? pFinancialYearId = null,
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
        string pChildAccounts  = null,
        bool? pTransactionIsActive = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbGLTransaction.funGLTransactionGET(
            pTransactionId : pTransactionId,
            pTransactionCode : pTransactionCode,
            pTransactionNameL1 : pTransactionNameL1,
            pTransactionNameL2 : pTransactionNameL2,
            pTransactionTypeId : pTransactionTypeId,
            pFinancialYearId : pFinancialYearId,
            pGLVoucherDtlId : pGLVoucherDtlId,
            pTransactionSoruceId : pTransactionSoruceId,
            pCashDeskId : pCashDeskId,
            pAccountId : pAccountId,
            pTransactionSeq : pTransactionSeq,
            pTransactionDate : pTransactionDate,
            pTransactionDebit : pTransactionDebit,
            pTransactionCredit : pTransactionCredit,
            pTransactionDebitBase: pTransactionDebitBase,
            pTransactionCreditBase : pTransactionCreditBase,
            pTransactionNote : pTransactionNote,
            pIsPosted : pIsPosted,
            pCostCenterId : pCostCenterId,
            pStoreId : pStoreId,
            pTransactionDescription : pTransactionDescription,
            pTransactionRef : pTransactionRef,
            pTransactionSeqDtl : pTransactionSeqDtl,
            pCurrencyId : pCurrencyId,
            pTransactionHdDebit : pTransactionHdDebit,
            pTransactionHdCredit : pTransactionHdCredit,
            pTransactionHdNote : pTransactionHdNote,
            pCSId : pCSId,
            pAccountingPeriodId : pAccountingPeriodId,
            pIsTransfered : pIsTransfered,
            pChildAccounts: pChildAccounts,
            pTransactionIsActive : pTransactionIsActive,
            pQueryTypeId : pQueryTypeId
                );

            // Result
            return vData;
        }


        [HttpGet]
        public string GLTransactionReportGET(
        int? pTransactionId = null,
        string pTransactionCode = null,
        string pTransactionNameL1 = null,
        string pTransactionNameL2 = null,
        int? pTransactionTypeId = null,
        int? pFinancialYearId = null,
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
        int? pQueryTypeId = clsQueryType.qSelect,
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        string pAccountFrom = null,
        string pAccountTo = null
        )
        {
            // Get Data 
            string vData = _dbGLTransaction.funGLTransactionReportGET(
            pTransactionId: pTransactionId,
            pTransactionCode: pTransactionCode,
            pTransactionNameL1: pTransactionNameL1,
            pTransactionNameL2: pTransactionNameL2,
            pTransactionTypeId: pTransactionTypeId,
            pFinancialYearId: pFinancialYearId,
            pGLVoucherDtlId: pGLVoucherDtlId,
            pTransactionSoruceId: pTransactionSoruceId,
            pCashDeskId: pCashDeskId,
            pAccountId: pAccountId,
            pTransactionSeq: pTransactionSeq,
            pTransactionDate: pTransactionDate,
            pTransactionDebit: pTransactionDebit,
            pTransactionCredit: pTransactionCredit,
            pTransactionDebitBase: pTransactionDebitBase,
            pTransactionCreditBase: pTransactionCreditBase,
            pTransactionNote: pTransactionNote,
            pIsPosted: pIsPosted,
            pCostCenterId: pCostCenterId,
            pStoreId: pStoreId,
            pTransactionDescription: pTransactionDescription,
            pTransactionRef: pTransactionRef,
            pTransactionSeqDtl: pTransactionSeqDtl,
            pCurrencyId: pCurrencyId,
            pTransactionHdDebit: pTransactionHdDebit,
            pTransactionHdCredit: pTransactionHdCredit,
            pTransactionHdNote: pTransactionHdNote,
            pCSId: pCSId,
            pAccountingPeriodId: pAccountingPeriodId,
            pIsTransfered: pIsTransfered,
            pChildAccounts: pChildAccounts,
            pTransactionIsActive: pTransactionIsActive,
            pQueryTypeId: pQueryTypeId,
            pDateFrom:pDateFrom,
            pDateTo: pDateTo,
            pAccountFrom: pAccountFrom,
            pAccountTo: pAccountTo
                );

            // Result
            return vData;
        }
    }
}
