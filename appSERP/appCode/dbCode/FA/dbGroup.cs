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
    public class dbGroup: IdbGroup
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGroup(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funGroupGET(
        int? pGroupId = null,
        int? pMainGroupId = null,
        string pGroupNameL1 = null,
        string pGroupNameL2 = null,
        decimal? pGroupPercent = null,
        int? pFixedAssetMethodId = null,
        int? pGroupAssetAccount = null,
        int? pGroupDebitAccount = null,
        int? pGroupCreditAccount = null,
        int? pGroupPurchaseAccount = null,
        int? pGroupSalesAccount = null,
        bool? pGroupIsActive = null,
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
            vlstParam.Add(new SqlParameter("GroupId", pGroupId));
            vlstParam.Add(new SqlParameter("MainGroupId", pMainGroupId));
            vlstParam.Add(new SqlParameter("GroupNameL1", pGroupNameL1));
            vlstParam.Add(new SqlParameter("GroupNameL2", pGroupNameL2));
            vlstParam.Add(new SqlParameter("GroupPercent", pGroupPercent));
            vlstParam.Add(new SqlParameter("FixedAssetMethodId", pFixedAssetMethodId));
            vlstParam.Add(new SqlParameter("GroupAssetAccount", pGroupAssetAccount));
            vlstParam.Add(new SqlParameter("GroupDebitAccount", pGroupDebitAccount));
            vlstParam.Add(new SqlParameter("GroupCreditAccount", pGroupCreditAccount));
            vlstParam.Add(new SqlParameter("GroupPurchaseAccount", pGroupPurchaseAccount));
            vlstParam.Add(new SqlParameter("GroupSalesAccount", pGroupSalesAccount));
            vlstParam.Add(new SqlParameter("GroupIsActive", pGroupIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spGroupCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetGroupReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spGroupReport", vlstParam, "Data GET");


            return vData;
        }
    }
}