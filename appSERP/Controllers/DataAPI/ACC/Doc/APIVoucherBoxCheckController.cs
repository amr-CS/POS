using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.dbCode.ACC.Doc;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC.Doc
{
    public class APIVoucherBoxCheckController : ApiController
    {

        private IdbVoucherBoxCheck _dbVoucherBoxCheck;
        public APIVoucherBoxCheckController(IdbVoucherBoxCheck dbVoucherBoxCheck)
        {
            _dbVoucherBoxCheck = dbVoucherBoxCheck;
        }
        [HttpGet]
        public string VoucherBoxCheckGET(
        int? pVoucherBoxCheckId = null,
        int? pGLVoucherId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        string pAccountId = null,
        decimal? pPayDebit = null,
        decimal? pPayCurrencyValue = null,
        decimal? pDebit = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pBaseDebit = null,
        string pNote = null,
        int? pCostCenterId = null,
        bool? pVoucherIsCheck = null,
        int? pCheckBankId = null,
        int? pCheckNo = null,
        DateTime? pCheckDate = null,
        decimal? pCheckDebit = null,
        decimal? pCheckCurrencyValue = null,
        decimal? pCheckBaseDebit = null,
        decimal? pCredit = null,
        decimal? pBaseCredit = null,
        string pCheckNote = null,
        int? pCheckCostCenterId = null,
        int? pCheckBankBranchId = null,
        int? pPayTypeId = null,
        int? pEPayTypeId = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
            string vData = _dbVoucherBoxCheck.funVoucherBoxCheckGET(
            pVoucherBoxCheckId: pVoucherBoxCheckId,
            pGLVoucherId: pGLVoucherId,
            pCashDeskId: pCashDeskId,
            pCurrencyId: pCurrencyId,
            pAccountId: pAccountId,
            pPayDebit: pPayDebit,
            pPayCurrencyValue: pPayCurrencyValue,
            pDebit: pDebit,
            pBaseCurrencyValue: pBaseCurrencyValue,
            pBaseDebit: pBaseDebit,
            pCredit: pCredit,
            pBaseCredit: pBaseCredit,
            pNote: pNote,
            pCostCenterId: pCostCenterId,
            pVoucherIsCheck: pVoucherIsCheck,
            pCheckBankId: pCheckBankId,
            pCheckNo: pCheckNo,
            pCheckDate: pCheckDate,
            pCheckDebit: pCheckDebit,
            pCheckCurrencyValue: pCheckCurrencyValue,
            pCheckBaseDebit: pCheckBaseDebit,
            pCheckNote: pCheckNote,
            pCheckCostCenterId: pCheckCostCenterId,
            pCheckBankBranchId: pCheckBankBranchId,
            pPayTypeId: pPayTypeId,
            pEPayTypeId: pEPayTypeId,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vData;

        }
    }
}
