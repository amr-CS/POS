﻿using appSERP.appCode.dbCode.ACC.Abstract;
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
    public class dbAccountType : IdbAccountType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbAccountType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAccountTypeGET(

        int? pAccountTypeId = null,
        string pAccountTypeCode = null,
        string pAccountTypeNameL1 = null,
        string pAccountTypeNameL2 = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        bool? pAccountTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AccountTypeId", pAccountTypeId));
            vlstParam.Add(new SqlParameter("AccountTypeCode", pAccountTypeCode));
            vlstParam.Add(new SqlParameter("AccountTypeNameL1", pAccountTypeNameL1));
            vlstParam.Add(new SqlParameter("AccountTypeNameL2", pAccountTypeNameL2));
            vlstParam.Add(new SqlParameter("AccountTypeIsActive", pAccountTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spAccountTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetAccountTypeReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("ACC.spAccountTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}