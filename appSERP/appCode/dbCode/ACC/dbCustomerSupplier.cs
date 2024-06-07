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
    public class dbCustomerSupplier : IdbCustomerSupplier
    {           // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCustomerSupplier(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funCustomerSupplierGET(
        int? pCSId = null,
        string pCSCode = null,
        string pCSNameL1 = null,
        string pCSNameL2 = null,
        string pCSAddress = null,
        string pCSPhone1 = null,
        string pCSPhone2 = null,
        string pCSEmail = null,
        string pCSContactPerson = null,
        string pCSSalesPurchasePerson = null,
        string pCSTaxNumber = null,
        int? pAreaId = null,
        string pCSCreditLimit = null,
        int? pCSGroupId = null,
        int? pGracePeriod = null,
        int? pAccountId = null,
        int? pBranchId = null,
        bool? pCSIsCustomer = null,
        bool? pCSIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CSId", pCSId));
            vlstParam.Add(new SqlParameter("CSCode", pCSCode));
            vlstParam.Add(new SqlParameter("CSNameL1", pCSNameL1));
            vlstParam.Add(new SqlParameter("CSNameL2", pCSNameL2));
            vlstParam.Add(new SqlParameter("CSAddress", pCSAddress));
            vlstParam.Add(new SqlParameter("CSPhone1", pCSPhone1));
            vlstParam.Add(new SqlParameter("CSPhone2", pCSPhone2));
            vlstParam.Add(new SqlParameter("CSEmail", pCSEmail));
            vlstParam.Add(new SqlParameter("CSContactPerson", pCSContactPerson));
            vlstParam.Add(new SqlParameter("CSSalesPurchasePerson", pCSSalesPurchasePerson));
            vlstParam.Add(new SqlParameter("CSTaxNumber", pCSTaxNumber));
            vlstParam.Add(new SqlParameter("AreaId", pAreaId));
            vlstParam.Add(new SqlParameter("CSCreditLimit", pCSCreditLimit));
            vlstParam.Add(new SqlParameter("CSGroupId", pCSGroupId));
            vlstParam.Add(new SqlParameter("GracePeriod", pGracePeriod));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CSIsCustomer", pCSIsCustomer));
            vlstParam.Add(new SqlParameter("CSIsActive", pCSIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCustomerSupplierCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetCustomerSupplierReport()
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

            vData = _clsADO.funFillDataTable("ACC.spCustomerSupplierReport", vlstParam, "Data GET");


            return vData;
        }
    }
}