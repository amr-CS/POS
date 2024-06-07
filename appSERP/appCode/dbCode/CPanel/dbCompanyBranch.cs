using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.GD
{
   
    public class dbCompanyBranch : IdbCompanyBranch
    {
        public string vDataTableString { get; set; }
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCompanyBranch(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCompanyBranchGET(
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
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyBranchId", pCompanyBranchId));
            vlstParam.Add(new SqlParameter("CompanyBranchCode", pCompanyBranchCode));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", pCompanyBranchNameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", pCompanyBranchNameL2));
            vlstParam.Add(new SqlParameter("CompanyBranchLevel", pCompanyBranchLevel));
            vlstParam.Add(new SqlParameter("IsHolding", pIsHolding));
            vlstParam.Add(new SqlParameter("AccountCodeHierarchy", pAccountCodeHierarchy));
            vlstParam.Add(new SqlParameter("LastClosedYear", pLastClosedYear));
            vlstParam.Add(new SqlParameter("LastClosedMonth", pLastClosedMonth));
            vlstParam.Add(new SqlParameter("RefNumberIsVisible", pRefNumberIsVisible));
            vlstParam.Add(new SqlParameter("CostCenterIsRequired", pCostCenterIsRequired));
            vlstParam.Add(new SqlParameter("PostIsSerialized", pPostIsSerialized));
            vlstParam.Add(new SqlParameter("DepositIsSentDirectToBank", pDepositIsSentDirectToBank));
            vlstParam.Add(new SqlParameter("IsPostZeroEntry", pIsPostZeroEntry));
            vlstParam.Add(new SqlParameter("DefaultCurrencyId", pDefaultCurrencyId));
            vlstParam.Add(new SqlParameter("PLAccountId", pPLAccountId));
            vlstParam.Add(new SqlParameter("RDAccountId", pRDAccountId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("Language1Id", pLanguage1Id));
            vlstParam.Add(new SqlParameter("Language2Id", pLanguage2Id));
            vlstParam.Add(new SqlParameter("CompanyBranchIsActive", pCompanyBranchIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("GD.spCompanyBranchCRUD", vlstParam, "Data GET").ToString();
           
            return vData;
        }
        public DataTable funCompanyBranchStat(
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
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyBranchId", pCompanyBranchId));
            vlstParam.Add(new SqlParameter("CompanyBranchCode", pCompanyBranchCode));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", pCompanyBranchNameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", pCompanyBranchNameL2));
            vlstParam.Add(new SqlParameter("CompanyBranchLevel", pCompanyBranchLevel));
            vlstParam.Add(new SqlParameter("IsHolding", pIsHolding));
            vlstParam.Add(new SqlParameter("AccountCodeHierarchy", pAccountCodeHierarchy));
            vlstParam.Add(new SqlParameter("LastClosedYear", pLastClosedYear));
            vlstParam.Add(new SqlParameter("LastClosedMonth", pLastClosedMonth));
            vlstParam.Add(new SqlParameter("RefNumberIsVisible", pRefNumberIsVisible));
            vlstParam.Add(new SqlParameter("CostCenterIsRequired", pCostCenterIsRequired));
            vlstParam.Add(new SqlParameter("PostIsSerialized", pPostIsSerialized));
            vlstParam.Add(new SqlParameter("DepositIsSentDirectToBank", pDepositIsSentDirectToBank));
            vlstParam.Add(new SqlParameter("IsPostZeroEntry", pIsPostZeroEntry));
            vlstParam.Add(new SqlParameter("DefaultCurrencyId", pDefaultCurrencyId));
            vlstParam.Add(new SqlParameter("PLAccountId", pPLAccountId));
            vlstParam.Add(new SqlParameter("RDAccountId", pRDAccountId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("Language1Id", pLanguage1Id));
            vlstParam.Add(new SqlParameter("Language2Id", pLanguage2Id));
            vlstParam.Add(new SqlParameter("CompanyBranchIsActive", pCompanyBranchIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", 401));
            vData = _clsADO.funExecuteScalar("GD.spCompanyBranchCRUD", vlstParam, "Data GET").ToString();
            // Data [Data Table]
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;
        }
    }
}