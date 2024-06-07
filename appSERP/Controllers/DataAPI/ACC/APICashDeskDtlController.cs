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
    public class APICashDeskDtlController : ApiController
    {
        private IdbCashDeskDtl _dbCashDeskDtl;
        public APICashDeskDtlController(IdbCashDeskDtl dbCashDeskDtl)
        {
            _dbCashDeskDtl = dbCashDeskDtl;
        }

        [HttpGet]
        public object CashDeskDtlDataGet(
     int? pCashDeskDtlId = null,
     string pCashDeskDtlCode = null,
     string pCashDeskDtlNameL1 = null,
     string pCashDeskDtlNameL2 = null,
     string pCashDeskTransId = null,
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
     string pCashDeskDtlTransSeq = null,
     bool? pCashDeskDtlIsActive = null,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vCashDeskDtlData = _dbCashDeskDtl.funCashDeskDtlGET(
            pCashDeskDtlId: pCashDeskDtlId,
            pCashDeskDtlCode: pCashDeskDtlCode,
            pCashDeskDtlNameL1: pCashDeskDtlNameL1,
            pCashDeskDtlNameL2: pCashDeskDtlNameL2,
            pCashDeskTransId: pCashDeskTransId,
            pGLVoucherTypeId: pGLVoucherTypeId,
            pFinancialYearId: pFinancialYearId,
            pAccountId: pAccountId,
            pCashDeskId: pCashDeskId,
            pCurrencyId: pCurrencyId,
            pCashDeskDtlDebit: pCashDeskDtlDebit,
            pCashDeskDtlCredit: pCashDeskDtlCredit,
            pCashDeskDtlDebitBase: pCashDeskDtlDebitBase,
            pCashDeskDtlCreditBase: pCashDeskDtlCreditBase,
            pBaseCurrencyValue: pBaseCurrencyValue,
            pCashDeskDtlPayDebit: pCashDeskDtlPayDebit,
            pCashDeskDtlPayCredit: pCashDeskDtlPayCredit,
            pPayCurrencyValue: pPayCurrencyValue,
            pCashDeskDtlNote: pCashDeskDtlNote,
            pCostCenterId: pCostCenterId,
            pIsPosted: pIsPosted,
            pCashDeskDtlTransSeq: pCashDeskDtlTransSeq,
            pCashDeskDtlIsActive: pCashDeskDtlIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vCashDeskDtlData;
        }
    }
}
