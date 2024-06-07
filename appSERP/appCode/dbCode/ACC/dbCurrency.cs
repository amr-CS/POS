using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbCurrency: IdbCurrency
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCurrency(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCurrencyGET(
        int? pCurrencyId = null,
        string pCurrencyCode = null,
        string pCurrencyNameL1 = null,
        string pCurrencyNameL2 = null,
        decimal? pCurrencyExchange = null,
        int? pCurrencyDecimal = null,
        int? pCurrencyFactorId = null,
        bool? pCurrencyIsDefault = null,
        int? pCurrencyGenderId = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCurrencyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("CurrencyCode", pCurrencyCode));
            vlstParam.Add(new SqlParameter("CurrencyNameL1", pCurrencyNameL1));
            vlstParam.Add(new SqlParameter("CurrencyNameL2", pCurrencyNameL2));
            vlstParam.Add(new SqlParameter("CurrencyExchange", pCurrencyExchange));
            vlstParam.Add(new SqlParameter("CurrencyDecimal", pCurrencyDecimal));
            vlstParam.Add(new SqlParameter("CurrencyFactorId", pCurrencyFactorId));
            vlstParam.Add(new SqlParameter("CurrencyIsDefault", pCurrencyIsDefault));
            vlstParam.Add(new SqlParameter("CurrencyGenderId", pCurrencyGenderId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CurrencyIsActive", pCurrencyIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCurrencyCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetCurrencyReport(bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("ACC.spCurrencyReport", vlstParam, "Data GET");


            return vData;
        }

    }
}