using appSERP.appCode.dbCode.INV.Abstract;
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

namespace appSERP.appCode.dbCode.INV
{
    public class dbSalesOrderType: IdbSalesOrderType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSalesOrderType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funSalesOrderTypeGET(

        int? pSalesOrderTypeId = null,
        string pSalesOrderTypeCode = null,
        string pSalesOrderTypeNameL1 = null,
        string pSalesOrderTypeNameL2 = null,
        string pAbbr = null, 
        bool? pIsDefault = null,
        int? pBranchId = null,
        bool? pSalesOrderTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SalesOrderTypeId", pSalesOrderTypeId));
            vlstParam.Add(new SqlParameter("SalesOrderTypeCode", pSalesOrderTypeCode));
            vlstParam.Add(new SqlParameter("SalesOrderTypeNameL1", pSalesOrderTypeNameL1));
            vlstParam.Add(new SqlParameter("SalesOrderTypeNameL2", pSalesOrderTypeNameL2));
            vlstParam.Add(new SqlParameter("Abbr", pAbbr));
            vlstParam.Add(new SqlParameter("IsDefault", pIsDefault));
            vlstParam.Add(new SqlParameter("SalesOrderTypeIsActive", pSalesOrderTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spSalesOrderTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetSalesOrderTypeReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("INV.spSalesOrderTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}