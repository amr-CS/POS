using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbEstimatedBudgetAccount: IdbEstimatedBudgetAccount
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbEstimatedBudgetAccount(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        //public static string funEstimatedBudgetAccountGET(
        //int? pEstimatedBudgetAccountId = null,
        //int? pAccountId  = null,
        //decimal?  pEstimatedBudgetAccountValue = null, 
        //int? pCompanyId = null,
        //int? pBranchId = null,
        //bool? pIsDeleted = false,
        //int? pQueryTypeId = null)
        //{
        //    // Declaration 
        //    string vData = string.Empty;
        //    // Parameters
        //    List<SqlParameter> vlstParam = new List<SqlParameter>();
        //    vlstParam.Add(new SqlParameter("EstimatedBudgetAccountId", pEstimatedBudgetAccountId));
        //    vlstParam.Add(new SqlParameter("AccountId", pAccountId));
        //    vlstParam.Add(new SqlParameter("EstimatedBudgetAccountValue", pEstimatedBudgetAccountValue));
        //    vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
        //    vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
        //    vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
        //    vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
        //    vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
        //    vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
        //    vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
        //    vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
        //    vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
        //    vData = clsADO.funExecuteScalar("ACC.spAccountTypeCRUD", vlstParam, "Data GET").ToString();
        //    return vData;
        //}
        public string funEstimatedBudgetAccountGET(
       int? pEstimatedBudgetAccountId = null,
       int? pAccountId = null,
       int? pMonthId = null,
       int? pYearId = null,
       string pDateFrom = null,
       string pDateTo = null,
       decimal? pEstimatedBudgetAccountValue = null,
       int? pCompanyId = null,
       int? pBranchId = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("EstimatedBudgetAccountId", pEstimatedBudgetAccountId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("MonthId", pMonthId));
            vlstParam.Add(new SqlParameter("YearId", pYearId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("EstimatedBudgetAccountValue", pEstimatedBudgetAccountValue));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spEstimatedBudgetAccountCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}