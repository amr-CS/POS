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
    public class dbCostCenter: IdbCostCenter
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        //CostCenter Setting
        public string vParentId { get; set; }
        public int? vLevel { get; set; }
        public string vCostCenterCode { get; set; }
        public string vCostCenterName { get; set; }
        public string vBranchId { get; set; }
        public string vBranchName { get; set; }
        public int vCostCenterLevel { get; set; }

        private IclsADO _clsADO;
        public dbCostCenter(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funCostCenterGET(
        int? pCostCenterId = null,
        string pCostCenterCode = null,
        string pCostCenterNameL1 = null,
        string pCostCenterNameL2 = null,
        int? pCostCenterParentId = null,
        int? pCostCenterLevel = null,
        bool? pCostCenterIsAccumulative = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCostCenterIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null

        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("CostCenterCode", pCostCenterCode));
            vlstParam.Add(new SqlParameter("CostCenterNameL1", pCostCenterNameL1));
            vlstParam.Add(new SqlParameter("CostCenterNameL2", pCostCenterNameL2));
            vlstParam.Add(new SqlParameter("CostCenterParentId", pCostCenterParentId));
            vlstParam.Add(new SqlParameter("CostCenterLevel", pCostCenterLevel));
            vlstParam.Add(new SqlParameter("CostCenterIsAccumulative", pCostCenterIsAccumulative));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CostCenterIsActive", pCostCenterIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCostCenterCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funCostCenterReportGET(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("ACC.spGetCostCentersReport", vlstParam, "Data GET");
            return vData;
        }

    }
}