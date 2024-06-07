using appSERP.appCode.dbCode.FA.Abstract;
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

namespace appSERP.appCode.dbCode.FA
{
    public class dbFixedAssetCompany: IdbFixedAssetCompany
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbFixedAssetCompany(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funFixedAssetCompanyGET(
        int? pFixedAssetCompanyId = null,
        string pFixedAssetCompanyCode = null,
        string pFixedAssetCompanyNameL1 = null,
        string pFixedAssetCompanyNameL2 = null,
        int? pFixedAssetCompanyTypeId = null,
        bool? pFixedAssetCompanyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("FixedAssetCompanyId", pFixedAssetCompanyId));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyCode", pFixedAssetCompanyCode));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyNameL1", pFixedAssetCompanyNameL1));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyNameL2", pFixedAssetCompanyNameL2));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeId", pFixedAssetCompanyTypeId));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyIsActive", pFixedAssetCompanyIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spFixedAssetCompanyCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetFixedAssetCompanyReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spFixedAssetCompanyReport", vlstParam, "Data GET");


            return vData;
        }

    }
}