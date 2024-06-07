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
    public class dbAssetReleaseDetail: IdbAssetReleaseDetail
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbAssetReleaseDetail(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAssetReleaseDetailGET(
        int? pAssetReleaseDetailId = null,
        string pAssetReleaseDetailNameL1 = null,
        string pAssetReleaseDetailNameL2 = null,
        string pAssetReleaseDetailCode = null,
        int? pAssetReleaseQty = null,
        int? pAssetReleaseSeq = null,
        int? pAssetReleaseId = null,
        int? pAssetId = null,
        bool? pAssetReleaseDetailIsActive = null,
        bool? pIsDeleted = null,
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
            vlstParam.Add(new SqlParameter("AssetReleaseDetailId", pAssetReleaseDetailId));
            vlstParam.Add(new SqlParameter("AssetReleaseDetailNameL1", pAssetReleaseDetailNameL1));
            vlstParam.Add(new SqlParameter("AssetReleaseDetailNameL2", pAssetReleaseDetailNameL2));
            vlstParam.Add(new SqlParameter("AssetReleaseDetailCode", pAssetReleaseDetailCode));
            vlstParam.Add(new SqlParameter("AssetReleaseQty", pAssetReleaseQty));
            vlstParam.Add(new SqlParameter("AssetReleaseSeq", pAssetReleaseSeq));
            vlstParam.Add(new SqlParameter("AssetReleaseId", pAssetReleaseId));
            vlstParam.Add(new SqlParameter("AssetId", pAssetId));
            vlstParam.Add(new SqlParameter("AssetReleaseDetailIsActive", pAssetReleaseDetailIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spAssetReleaseDetailCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public  DataTable funGetAssetReleaseDetailReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spAssetReleaseDetailReport", vlstParam, "Data GET");


            return vData;
        }
    }
}