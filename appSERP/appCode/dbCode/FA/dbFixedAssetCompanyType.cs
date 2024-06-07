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
    public class dbFixedAssetCompanyType : IdbFixedAssetCompanyType
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbFixedAssetCompanyType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funFixedAssetCompanyTypeGET(
        int? pFixedAssetCompanyTypeId = null,
        string pFixedAssetCompanyTypeCode = null,
        string pFixedAssetCompanyTypeNameL1 = null,
        string pFixedAssetCompanyTypeNameL2 = null,
        bool? pFixedAssetCompanyTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeId", pFixedAssetCompanyTypeId));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeCode", pFixedAssetCompanyTypeCode));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeNameL1", pFixedAssetCompanyTypeNameL1));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeNameL2", pFixedAssetCompanyTypeNameL2));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyTypeIsActive", pFixedAssetCompanyTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spFixedAssetCompanyTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetFixedAssetCompanyTypeReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spFixedAssetCompanyTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}