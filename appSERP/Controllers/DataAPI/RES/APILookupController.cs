using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APILookupController : ApiController
    {

        private IdbLookup _dbLookup;
        public APILookupController(IdbLookup dbLookup)
        {
            _dbLookup = dbLookup;
        }

        [HttpGet]
        public string LookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        DateTime? pdDate1 = null,
        DateTime? pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = clsQueryType.qSelect,
        string pSelectList = null,
        int? BranchId=null

            )
        {
            string vData = _dbLookup.funLookupGET(
            pLookupId : pLookupId,
            pLookupParentId : pLookupParentId,
            pLookupCode : pLookupCode,
            pLookupSeq : pLookupSeq,
            pLookupDescL1 : pLookupDescL1,
            pLookupDescL2 : pLookupDescL2,
            pParentId : pParentId,
            pLookupGroup : pLookupGroup,
            pLookupStatus : pLookupStatus,
            pHC : pHC,
            pNotes : pNotes,
            pUserPriv : pUserPriv,
            pParentIdDtl : pParentIdDtl,
            pIsDeleted : pIsDeleted,
            pLookupDtlId : pLookupDtlId,
            pdLookupDtlCode : pdLookupDtlCode,
            pdLookupDtlDesc : pdLookupDtlDesc,
            pdLookupDtlDescL : pdLookupDtlDescL,
            pdLookupDtlDescShort : pdLookupDtlDescShort,
            pdLookupDtlDescShortL : pdLookupDtlDescShortL,
            pdLookupDtlDesc2 : pdLookupDtlDesc2,
            pdLookupDtlDesc2L : pdLookupDtlDesc2L,
            pdLookupDtlSeq : pdLookupDtlSeq,
            pdTypeSeq : pdTypeSeq,
            pdORD : pdORD,
            pdDflt : pdDflt,
            pdLookupDtlStatus : pdLookupDtlStatus,
            pdNotes : pdNotes,
            pdValue1 : pdValue1,
            pdValue2 : pdValue2,
            pdValue3 : pdValue3,
            pdValLink : pdValLink,
            pdDate1 : pdDate1,
            pdDate2 : pdDate2,
            pdText : pdText,
            pdAccountId : pdAccountId,
            pdAccountId2 : pdAccountId2,
            pdIsDeleted : pdIsDeleted,
            pIsDetail : pIsDetail,
            pQueryTypeId : pQueryTypeId,
            pSelectList: pSelectList,
            BranchId:BranchId
                );
                return vData;
        }
    }
}
