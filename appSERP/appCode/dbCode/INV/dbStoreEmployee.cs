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
    public class dbStoreEmployee : IdbStoreEmployee
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbStoreEmployee(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public  string funStoreEmployeeGET(
       int? pStoreEmployeeId =null,
     string pStoreEmployeeCode = null, 
   string pStoreEmployeeName = null, 
   int? pGeneralNumber = null,
   string pJob        = null, 
  decimal? pProfit = null  ,
 DateTime? pEmployeeStartDate = null,
 DateTime? pEmployeeEndDate   = null, 
 string pNotes  = null, 
 int? pBranchId = null,
 bool? pStoreEmployeeIsActive  = null, 
 bool? pIsDeleted = null,
 int? pCreatedBy     = null, 
 DateTime? pCreatedOn = null,
 int? pLastUpdatedBy    = null, 
 DateTime? pLastUpdatedOn = null,
 int? pLanguageId         = null,
    int? pQueryTypeId    = null,
   string pSearchStartDate = null,
      string pSearchEndDate = null,
      string pList = null
    )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreEmployeeId", pStoreEmployeeId));
            vlstParam.Add(new SqlParameter("StoreEmployeeCode", pStoreEmployeeCode));
            vlstParam.Add(new SqlParameter("StoreEmployeeName", pStoreEmployeeName));
            vlstParam.Add(new SqlParameter("GeneralNumber", pGeneralNumber));
            vlstParam.Add(new SqlParameter("Job", pJob));
            vlstParam.Add(new SqlParameter("Profit", pProfit));
            vlstParam.Add(new SqlParameter("EmployeeStartDate", pEmployeeStartDate));
            vlstParam.Add(new SqlParameter("EmployeeEndDate", pEmployeeEndDate));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("StoreEmployeeIsActive", pStoreEmployeeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("SearchStartDate", pSearchStartDate));
            vlstParam.Add(new SqlParameter("SearchEndDate", pSearchEndDate));
            vlstParam.Add(new SqlParameter("List", pList));
            vData = _clsADO.funExecuteScalar("INV.spStoreEmployeeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetStoreEmployeeReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("INV.spStoreEmployeeReport", vlstParam, "Data GET");


            return vData;
        }

    }
}