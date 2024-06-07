using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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

namespace appSERP.appCode.dbCode.SEC
{
    public class dbUserSecurityTransactionType : IdbUserSecurityTransactionType
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbUserSecurityTransactionType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funUserSecurityTransactionTypeGET(
        string pUserSecurityTransactionTypeId = null,
        string pUserSecurityTransactionTypeNameL1 = null,
        string pUserSecurityTransactionTypeNameL2 = null,
        string pUserSecurityTransactionTypeNameL3 = null,
        string pUserSecurityTransactionTypeNameL4 = null,
        string pUserSecurityTransactionTypeNameL5 = null,
        string pUserSecurityTransactionTypeNameL6 = null,
        string pUserSecurityTransactionTypeNameL7 = null,
        string pUserSecurityTransactionTypeNameL8 = null,
        string pUserSecurityTransactionTypeNameL9 = null,
        string pUserSecurityTransactionTypeNameL10 = null,
        bool? pUserSecurityTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeId", pUserSecurityTransactionTypeId));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL1", pUserSecurityTransactionTypeNameL1));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL2", pUserSecurityTransactionTypeNameL2));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL3", pUserSecurityTransactionTypeNameL3));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL4", pUserSecurityTransactionTypeNameL4));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL5", pUserSecurityTransactionTypeNameL5));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL6", pUserSecurityTransactionTypeNameL6));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL7", pUserSecurityTransactionTypeNameL7));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL8", pUserSecurityTransactionTypeNameL8));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL9", pUserSecurityTransactionTypeNameL9));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeNameL10", pUserSecurityTransactionTypeNameL10));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeIsActive", pUserSecurityTransactionTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserSecurityTransactionTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetUserSecurityTransactionTypeReport()
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

            vData = _clsADO.funFillDataTable("SEC.spUserSecurityTransactionTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}