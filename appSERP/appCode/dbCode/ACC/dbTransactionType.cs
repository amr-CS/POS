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
    public class dbTransactionType : IdbTransactionType
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbTransactionType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funTransactionTypeGET(
        int? pTransactionTypeId = null,
        string pTransactionTypeCode = null,
        string pTransactionTypeNameL1 = null,
        string pTransactionTypeNameL2 = null,
        int? pSystemId = null,
        int? pSystemTransactionTypeId = null,
        bool? pTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("TransactionTypeId", pTransactionTypeId));
            vlstParam.Add(new SqlParameter("TransactionTypeCode", pTransactionTypeCode));
            vlstParam.Add(new SqlParameter("TransactionTypeNameL1", pTransactionTypeNameL1));
            vlstParam.Add(new SqlParameter("TransactionTypeNameL2", pTransactionTypeNameL2));
            vlstParam.Add(new SqlParameter("SystemId", pSystemId));
            vlstParam.Add(new SqlParameter("SystemTransactionTypeId", pSystemTransactionTypeId));
            vlstParam.Add(new SqlParameter("TransactionTypeIsActive", pTransactionTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spTransactionTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetTransactionTypeReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("ACC.spTransactionTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}