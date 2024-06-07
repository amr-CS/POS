using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.CPanel.Abstract
{
    public interface IdbCompanyBranch
    {
        string funCompanyBranchGET(
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
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funCompanyBranchStat(
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
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect);

        string vDataTableString { get; set; }
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
