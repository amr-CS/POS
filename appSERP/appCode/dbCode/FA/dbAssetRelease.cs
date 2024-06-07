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
    public class dbAssetRelease : IdbAssetRelease
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbAssetRelease(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAssetReleaseGET(
        int? pAssetReleaseId = null,
        string pAssetReleaseNameL1 = null,
        string pAssetReleaseNameL2 = null,
        string pAssetReleaseCode = null,
        DateTime? pAssetReleaseDate = null,
        int? pTrustId = null,
        int? pTransactionTypeId = null,
        string pNote = null,
        bool? pAssetReleaseIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AssetReleaseId", pAssetReleaseId));
            vlstParam.Add(new SqlParameter("AssetReleaseNameL1", pAssetReleaseNameL1));
            vlstParam.Add(new SqlParameter("AssetReleaseNameL2", pAssetReleaseNameL2));
            vlstParam.Add(new SqlParameter("AssetReleaseCode", pAssetReleaseCode));
            vlstParam.Add(new SqlParameter("AssetReleaseDate", pAssetReleaseDate));
            vlstParam.Add(new SqlParameter("TrustId", pTrustId));
            vlstParam.Add(new SqlParameter("TransactionTypeId", pTransactionTypeId));
            vlstParam.Add(new SqlParameter("Note", pNote));
            vlstParam.Add(new SqlParameter("AssetReleaseIsActive", pAssetReleaseIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spAssetReleaseCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetAssetReleaseReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spAssetReleaseReport", vlstParam, "Data GET");


            return vData;
        }
    }
}