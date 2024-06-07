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
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    // Tarek - 13-03-2019 - 01:52 PM
    public class dbCashDesk: IdbCashDesk
    {

        // Message
        public  string vSQLResult { get; set; }
        public  int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCashDesk(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        // CashDesk
        public string funCashDeskGET(
            int? pCashDeskId = null,
            int? pCashDeskParentId = null,
            string pCashDeskCode = null,
            string pCashDeskNameL1 = null,
            string pCashDeskNameL2 = null,
            string pCashDeskAccountNameL1 = null,
            string pCashDeskAccountNameL2 = null,
            bool?  pCashDeskAccountIsActive = null,
            int? pCashDeskTypeId = null,
            bool? pCashDeskIsActive = null,
            bool? pIsDeleted = false,
            int? pCashDeskAccountId = null,
            int? pAccountId = null,
            bool? pIsAccountDetail = null,
            int? pQueryTypeId = null,
            string pLstType = null,
            string pCashDeskList = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("CashDeskParentId", pCashDeskParentId));
            vlstParam.Add(new SqlParameter("CashDeskCode", pCashDeskCode));
            vlstParam.Add(new SqlParameter("CashDeskNameL1", pCashDeskNameL1));
            vlstParam.Add(new SqlParameter("CashDeskNameL2", pCashDeskNameL2));
            vlstParam.Add(new SqlParameter("CashDeskAccountNameL1", pCashDeskNameL1));
            vlstParam.Add(new SqlParameter("CashDeskAccountNameL2", pCashDeskNameL2));
            vlstParam.Add(new SqlParameter("CashDeskAccountIsActive", pCashDeskAccountIsActive));
            vlstParam.Add(new SqlParameter("CashDeskTypeId", pCashDeskTypeId));
            vlstParam.Add(new SqlParameter("CashDeskIsActive", pCashDeskIsActive));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("CashDeskAccountId", pCashDeskAccountId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsAccountDetail", pIsAccountDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("LstType", pLstType));
            vlstParam.Add(new SqlParameter("CashDeskList", pCashDeskList));
            vData = _clsADO.funExecuteScalar("ACC.spCashDeskCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public  DataTable funCashDeskReportGET(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("ACC.spGetCashDeskReport", vlstParam, "Data GET");
            return vData;
        }


    }
}