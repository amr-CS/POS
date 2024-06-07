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
    public class dbAssetTrans : IdbAssetTrans
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbAssetTrans(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAssetTransGET(
        int? pAssetTransId = null,
        DateTime? pAssetTransDate = null,
        decimal? pAssetTransValue = null,
        decimal? pAssetTransValueBase = null,
        int? pCurrencyId = null,
        string pAssetReasonTypeNote = null,
        string pAssetTransNote = null,
        int? pAssetId = null,
        int? pTransactionTypeId = null,
        int? pAssetReasonTypeId = null,
        bool? pAssetTransIsActive = null,
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
            vlstParam.Add(new SqlParameter("AssetTransId", pAssetTransId));
            vlstParam.Add(new SqlParameter("AssetTransDate", pAssetTransDate));
            vlstParam.Add(new SqlParameter("AssetTransValue", pAssetTransValue));
            vlstParam.Add(new SqlParameter("AssetTransValueBase", pAssetTransValueBase));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("AssetReasonTypeNote", pAssetReasonTypeNote));
            vlstParam.Add(new SqlParameter("AssetTransNote", pAssetTransNote));
            vlstParam.Add(new SqlParameter("AssetId", pAssetId));
            vlstParam.Add(new SqlParameter("TransactionTypeId", pTransactionTypeId));
            vlstParam.Add(new SqlParameter("AssetReasonTypeId", pAssetReasonTypeId));
            vlstParam.Add(new SqlParameter("AssetTransIsActive", pAssetTransIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spAssetTransCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetAssetTransReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spAssetTransReport", vlstParam, "Data GET");


            return vData;
        }
    }
}