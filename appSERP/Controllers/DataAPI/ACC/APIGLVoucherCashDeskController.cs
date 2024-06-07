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
    public class APIGLVoucherCashDeskController : ApiController
    {
        private IdbGLVoucherCashDesk _dbGLVoucherCashDesk;
        public APIGLVoucherCashDeskController(IdbGLVoucherCashDesk dbGLVoucherCashDesk) {
            _dbGLVoucherCashDesk = dbGLVoucherCashDesk;
        }

        [HttpGet]
        public  string GLVoucherCashDeskGET(
        int? pGLVoucherCashDeskId = null,
        string pGLVoucherCashDeskCode = null,
        string pGLVoucherCashDeskNameL1 = null,
        string pGLVoucherCashDeskNameL2 = null,
        int? pGLVoucherId = null,
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
        int? pTransSeq = null,
        bool? pGLVoucherCashDeskIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
        // Get Data 
        string vData = _dbGLVoucherCashDesk.funGLVoucherCashDeskGET(
        pGLVoucherCashDeskId : pGLVoucherCashDeskId,
        pGLVoucherCashDeskCode : pGLVoucherCashDeskCode,
        pGLVoucherCashDeskNameL1 : pGLVoucherCashDeskNameL1,
        pGLVoucherCashDeskNameL2 : pGLVoucherCashDeskNameL2,
        pGLVoucherId : pGLVoucherId,
        pGLVoucherTypeId : pGLVoucherTypeId,
        pFinancialYearId : pFinancialYearId,
        pCaskDeskId : pCaskDeskId,
        pMainCashDeskId : pMainCashDeskId,
        pAccountId : pAccountId,
        pGLVoucherCashDeskDebit : pGLVoucherCashDeskDebit,
        pGLVoucherCashCredit : pGLVoucherCashCredit,
        pGLVoucherCashDeskDebitBase : pGLVoucherCashDeskDebitBase,
        pGLVoucherCashDeskCreditBase : pGLVoucherCashDeskCreditBase,
        pBaseCurrencyValue : pBaseCurrencyValue,
        pPayDebit : pPayDebit,
        pPayCredit : pPayCredit,
        pCurrencyId : pCurrencyId,
        pCostCenterId : pCostCenterId,
        pGLVoucherCashDeskNote : pGLVoucherCashDeskNote,
        pTransSeq : pTransSeq,
        pGLVoucherCashDeskIsActive : pGLVoucherCashDeskIsActive,
        pIsDeleted : pIsDeleted,
        pQueryTypeId: pQueryTypeId);
            
        // Result
        return vData;
        }
    }
}
