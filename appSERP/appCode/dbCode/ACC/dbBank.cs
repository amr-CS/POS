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
    public class dbBank :IdbBank
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbBank(clsADO clsADO) {
            _clsADO = clsADO;        
        }
       
        // Bank
        public  string funBankGET(
            int? pBankId = null,
            int? pBankParentId = null,
            string pBankCode = null,
            string pBankNameL1 = null,
            string pBankNameL2 = null,
            string pBankAccountNameL1 = null,
            string pBankAccountNameL2 = null,
            bool? pBankAccountIsActive = null,
            int? pBankTypeId = null,
            bool? pBankIsActive = null,
            bool? pIsDeleted = false,
            int? pBankAccountId = null,
            string pAccountId = null,
            bool? pIsAccountDetail = null,
            int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("BankId", pBankId));
            vlstParam.Add(new SqlParameter("BankParentId", pBankParentId));
            vlstParam.Add(new SqlParameter("BankCode", pBankCode));
            vlstParam.Add(new SqlParameter("BankNameL1", pBankNameL1));
            vlstParam.Add(new SqlParameter("BankNameL2", pBankNameL2));
            vlstParam.Add(new SqlParameter("BankAccountNameL1", pBankNameL1));
            vlstParam.Add(new SqlParameter("BankAccountNameL2", pBankNameL2));
            vlstParam.Add(new SqlParameter("BankAccountIsActive", pBankAccountIsActive));
            vlstParam.Add(new SqlParameter("BankTypeId", pBankTypeId));
            vlstParam.Add(new SqlParameter("BankIsActive", pBankIsActive));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("BankAccountId", pBankAccountId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsAccountDetail", pIsAccountDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spBankCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public  DataTable funBankReportGET(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("ACC.spGetBankReport", vlstParam, "Data GET");
            return vData;
        }
    }
}