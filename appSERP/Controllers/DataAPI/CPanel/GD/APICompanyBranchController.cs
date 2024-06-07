using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.dbCode.GD;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.GD
{
    public class APICompanyBranchController : ApiController
    {

        private IdbCompanyBranch _dbCompanyBranch;
        public APICompanyBranchController(IdbCompanyBranch dbCompanyBranch) {
            _dbCompanyBranch = dbCompanyBranch;
        }

        [HttpGet]
        public string CompanyBranchGET(
        int? pCompanyBranchId = null,
        string pCompanyBranchCode = null,
        string pCompanyBranchNameL1 = null,
        string pCompanyBranchNameL2 = null,
        int? pCompanyBranchLevel = null,
        bool? pIsHolding = null,
        string pAccountCodeHierarchy = null,
        int? pLastClosedYear = null,
        int? pLastClosedMonth = null,
        bool? pRefNumberIsVisible = null,
        bool? pCostCenterIsRequired = null,
        bool? pPostIsSerialized = null,
        bool? pDepositIsSentDirectToBank = null,
        bool? pIsPostZeroEntry = null,
        int? pDefaultCurrencyId = null,
        int? pPLAccountId = null,
        int? pRDAccountId = null,
        int? pFinancialYearId = null,
        int? pLanguage1Id = null,
        int? pLanguage2Id = null,
        bool? pCompanyBranchIsActive = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCompanyBranch.funCompanyBranchGET
                (
            pCompanyBranchId : pCompanyBranchId,
            pCompanyBranchCode : pCompanyBranchCode,
            pCompanyBranchNameL1 : pCompanyBranchNameL1,
            pCompanyBranchNameL2 : pCompanyBranchNameL2,
            pCompanyBranchLevel : pCompanyBranchLevel,
            pIsHolding : pIsHolding,
            pAccountCodeHierarchy : pAccountCodeHierarchy,
            pLastClosedYear : pLastClosedYear,
            pLastClosedMonth : pLastClosedMonth,
            pRefNumberIsVisible : pRefNumberIsVisible,
            pCostCenterIsRequired : pCostCenterIsRequired,
            pPostIsSerialized : pPostIsSerialized,
            pDepositIsSentDirectToBank : pDepositIsSentDirectToBank,
            pIsPostZeroEntry : pIsPostZeroEntry,
            pDefaultCurrencyId : pDefaultCurrencyId,
            pPLAccountId : pPLAccountId,
            pRDAccountId : pRDAccountId,
            pFinancialYearId : pFinancialYearId,
            pCompanyBranchIsActive : pCompanyBranchIsActive,
            pLanguage1Id: pLanguage1Id,
            pLanguage2Id: pLanguage2Id,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );

            // RESULT 
            return vData;
        }
    }
}
