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
    public class APIGLVoucherDtlController : ApiController
    {
        private IdbGLVoucherDtl _dbGLVoucherDtl;
        public APIGLVoucherDtlController(IdbGLVoucherDtl dbGLVoucherDtl) {
            _dbGLVoucherDtl = dbGLVoucherDtl;
        }

        [HttpGet]
        public object GLVoucherDtlDataGet(
        int? pGLVoucherDtlId = null,
        string pGLVoucherDtlCode = null,
        string pGLVoucherDtlNameL1 = null,
        string pGLVoucherDtlNameL2 = null,
        string pGLVoucherId = null,
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
        string pGLVoucherDtlTransSeq = null,
        bool? pGLVoucherDtlIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {   
            // Get Data
            string vGLVoucherDtlData = _dbGLVoucherDtl.funGLVoucherDtlGET(
            pGLVoucherDtlId: pGLVoucherDtlId,
            pGLVoucherDtlCode: pGLVoucherDtlCode,
            pGLVoucherDtlNameL1: pGLVoucherDtlNameL1,
            pGLVoucherDtlNameL2: pGLVoucherDtlNameL2,
            pGLVoucherId: pGLVoucherId,
            pGLVoucherTypeId: pGLVoucherTypeId,
            pFinancialYearId: pFinancialYearId,
            pAccountId: pAccountId,
            pCashDeskId: pCashDeskId,
            pCurrencyId: pCurrencyId,
            pGLVoucherDtlDebit: pGLVoucherDtlDebit,
            pGLVoucherDtlCredit: pGLVoucherDtlCredit,
            pGLVoucherDtlDebitBase: pGLVoucherDtlDebitBase,
            pGLVoucherDtlCreditBase: pGLVoucherDtlCreditBase,
            pBaseCurrencyValue: pBaseCurrencyValue,
            pGLVoucherDtlPayDebit: pGLVoucherDtlPayDebit,
            pGLVoucherDtlPayCredit: pGLVoucherDtlPayCredit,
            pPayCurrencyValue: pPayCurrencyValue,
            pGLVoucherDtlNote: pGLVoucherDtlNote,
            pCostCenterId: pCostCenterId,
            pIsPosted: pIsPosted,
            pGLVoucherDtlTransSeq: pGLVoucherDtlTransSeq,
            pGLVoucherDtlIsActive: pGLVoucherDtlIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId );
            // Result
            return vGLVoucherDtlData;
        }
    }
}
