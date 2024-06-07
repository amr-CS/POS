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
    public class dbMainGroup : IdbMainGroup
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbMainGroup(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funMainGroupGET(
        int? pMainGroupId = null,
        string pMainGroupNameL1 = null,
        string pMainGroupNameL2 = null,
        bool? pMainGroupIsActive = null,
        int? pFixedAssetMethodId = null,
        decimal? pMainGroupPercent = null,
        int? pMainGroupDebitAccount = null,
        int? pMainGroupCreditAccount = null,
        int? pMainGroupPurchaseAccount = null,
        int? pMainGroupSalesAccount = null,
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
            vlstParam.Add(new SqlParameter("MainGroupId", pMainGroupId));
            vlstParam.Add(new SqlParameter("MainGroupNameL1", pMainGroupNameL1));
            vlstParam.Add(new SqlParameter("MainGroupNameL2", pMainGroupNameL2));
            vlstParam.Add(new SqlParameter("MainGroupIsActive", pMainGroupIsActive));
            vlstParam.Add(new SqlParameter("FixedAssetMethodId", pFixedAssetMethodId));
            vlstParam.Add(new SqlParameter("MainGroupPercent", pMainGroupPercent));
            vlstParam.Add(new SqlParameter("MainGroupDebitAccount", pMainGroupDebitAccount));
            vlstParam.Add(new SqlParameter("MainGroupCreditAccount", pMainGroupCreditAccount));
            vlstParam.Add(new SqlParameter("MainGroupPurchaseAccount", pMainGroupPurchaseAccount));
            vlstParam.Add(new SqlParameter("MainGroupSalesAccount", pMainGroupSalesAccount));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spMainGroupCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public DataTable funGetMainGroupsReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spMainGroupReport", vlstParam, "Data GET");


            return vData;
        }
    }
}