using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvChecksController : ApiController
    {
        private IdbInvChecks _dbInvChecks;
        public APIInvChecksController(IdbInvChecks dbInvChecks) {
            _dbInvChecks = dbInvChecks;
        }

        [HttpGet]
        public  string CheckGET(
        int? pCheckId = null,
        string pCheckCode = null,
        int? pInvId = null,
        int? pInvType = null,
        int? pYear = null,
        int? pCheckDtlId = null,
        int? pAccountId = null,
        int? pBankId = null,
        int? pBranchId = null,
        int? pCheckNo = null,
        DateTime? pCheckPayDate = null,
        int? pCostCenterId = null,
        float? pCheckCredit = null,
        float? pCheckDebit = null,
        float? pCurValue = null,
        float? pCheckBaseCredit = null,
        float? pCheckBaseDebit = null,
        bool? pIsPosted = null,
        bool? pPosting = null,
        int? pStoreId = null,
        string pNotes = null,
        float? pTransSeq = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Values
            string vData = _dbInvChecks.funCheckGET(
            pCheckId: pCheckId,
            pCheckCode: pCheckCode,
            pInvId: pInvId,
            pInvType: pInvType,
            pYear: pYear,
            pCheckDtlId: pCheckDtlId,
            pAccountId: pAccountId,
            pBankId: pBankId,
            pBranchId: pBranchId,
            pCheckNo: pCheckNo,
            pCheckPayDate: pCheckPayDate,
            pCostCenterId: pCostCenterId,
            pCheckCredit: pCheckCredit,
            pCheckDebit: pCheckDebit,
            pCurValue: pCurValue,
            pCheckBaseCredit: pCheckBaseCredit,
            pCheckBaseDebit: pCheckBaseDebit,
            pIsPosted: pIsPosted,
            pPosting: pPosting,
            pStoreId: pStoreId,
            pNotes: pNotes,
            pTransSeq: pTransSeq,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Get Result
            return vData;
        }
    }
}
