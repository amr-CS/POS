using appSERP.appCode.dbCode.RES.Abstract;
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

namespace appSERP.appCode.dbCode.RES
{
    public class dbResEmployee : IdbResEmployee
    {
        private IclsADO _clsADO;
        public dbResEmployee(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funResEmployeeGET(
        int? pResEmployeeId = null,
        string pResEmployeeCode = null,
        int? pEmpSeq = null,
        int? Credit = null,
        string pResEmployeeNameL1 = null,
        string pResEmployeeNameL2 = null,
        DateTime? pHireDate = null,
        int? pDeptSeq = null,
        int? pEmpStatusId = null,
        DateTime? pExitDate = null,
        string pAddress = null,
        DateTime? pBirthDate = null,
        string pMobile = null,
        int? pGender = null,
        int? pIdentityTypeId = null,
        int? pIdentityNumber = null,
        DateTime? pIdentityDate = null,
        int? pNationalityId = null,
        decimal? pDeliveryValue = null,
        int? pValueTypeId = null,
        decimal? pPercentageRange = null,
        int? pExitTypeId = null,
        string pExitReason = null,
        bool? pResEmployeeIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null,
        string pLstNationality  = null,
        string pLstIdentityType  = null,
        string pLstEmpStatus  = null,
        string pLstValueType  = null,
        string pLstExitType  = null,
        int? UserId=null
        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ResEmployeeId", pResEmployeeId));
            vlstParam.Add(new SqlParameter("ResEmployeeCode", pResEmployeeCode));
            vlstParam.Add(new SqlParameter("Credit", Credit));
            vlstParam.Add(new SqlParameter("EmpSeq", pEmpSeq));
            vlstParam.Add(new SqlParameter("ResEmployeeNameL1", pResEmployeeNameL1));
            vlstParam.Add(new SqlParameter("ResEmployeeNameL2", pResEmployeeNameL2));
            vlstParam.Add(new SqlParameter("HireDate", pHireDate));
            vlstParam.Add(new SqlParameter("DeptSeq", pDeptSeq));
            vlstParam.Add(new SqlParameter("EmpStatusId", pEmpStatusId));
            vlstParam.Add(new SqlParameter("ExitDate", pExitDate));
            vlstParam.Add(new SqlParameter("Address", pAddress));
            vlstParam.Add(new SqlParameter("BirthDate", pBirthDate));
            vlstParam.Add(new SqlParameter("Mobile", pMobile));
            vlstParam.Add(new SqlParameter("Gender", pGender));
            vlstParam.Add(new SqlParameter("IdentityTypeId", pIdentityTypeId));
            vlstParam.Add(new SqlParameter("IdentityNumber", pIdentityNumber));
            vlstParam.Add(new SqlParameter("IdentityDate", pIdentityDate));
            vlstParam.Add(new SqlParameter("NationalityId", pNationalityId));
            vlstParam.Add(new SqlParameter("DeliveryValue", pDeliveryValue));
            vlstParam.Add(new SqlParameter("ValueTypeId", pValueTypeId));
            vlstParam.Add(new SqlParameter("PercentageRange", pPercentageRange));
            vlstParam.Add(new SqlParameter("ExitTypeId", pExitTypeId));
            vlstParam.Add(new SqlParameter("ExitReason", pExitReason));
            vlstParam.Add(new SqlParameter("ResEmployeeIsActive", pResEmployeeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("LstNationality", pLstNationality));
            vlstParam.Add(new SqlParameter("LstIdentityType", pLstIdentityType));
            vlstParam.Add(new SqlParameter("LstEmpStatus", pLstEmpStatus));
            vlstParam.Add(new SqlParameter("LstValueType", pLstValueType));
            vlstParam.Add(new SqlParameter("LstExitType", pLstExitType));
            vlstParam.Add(new SqlParameter("UserId", UserId));

            vData = _clsADO.funExecuteScalar("RES.spResEmployeeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetResEmployeeReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("RES.spGetResEmployeeReport", vlstParam, "Data GET");


            return vData;
        }

    }
}