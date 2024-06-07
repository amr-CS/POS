using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbGLCustomer: IdbGLCustomer
    {

        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGLCustomer(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funGLCustomerGET(
         int? pCustomerId = null ,
       string pCustomerCode = null,
         string pCustomerSequence = null ,
         int? pDelivaryCompanyType = null ,
         float? pDelivaryCompanyValue = null ,
         string pSeqByType = null ,
         string pCustomerNameL1 = null ,
         string pCustomerNameL2 = null ,
         string pCustomerAddress = null ,
         string pCustomerPhoneNumber = null ,
         string pCustomerTaxNumber = null ,
         string pCustomerPostBox = null ,
         string pCustomerFax = null ,
         string pCustomerEmail = null ,
         string pAuthorizePerson = null,
         int? pCustomerTypeId = null,
         int? pSalesId = null,
         int? pSellCostTypeId = null,
         int? pCustomerDailyStopType = null,
         int? pCustomerDailyDay = null,
         int? pAreaId  = null,
         int? pCategoryId = null,
         int? pStatus = null,
         string pAuthorizePersonTel = null,
         string pCustomerVATCode = null,
         int? pCustomerParentId = null,
         int? pCountryId = null,
         int? pCityId = null,
         decimal? pCustomerAmountLimit = null, 
         int? pAccountId = null,
          int? pTypeId = null,
         bool? pCustomerIsActive = null,
         bool? pIsDeleted = null,
         int?  pIsParent   = null,
         bool? pIsCustomer = null,
         bool? pIsBlackList = null,
        string pNotes = null,
        string pOrganization = null,
         string pStreet = null,
         string pCity = null,
         string pBuildingNumber = null,
         string pPostalZone = null,
         string pDistrictName = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CustomerId", pCustomerId));
            vlstParam.Add(new SqlParameter("CustomerCode", pCustomerCode));
            vlstParam.Add(new SqlParameter("CustomerSequence", pCustomerSequence));
            vlstParam.Add(new SqlParameter("SeqByType", pSeqByType));
            vlstParam.Add(new SqlParameter("CustomerNameL1", pCustomerNameL1));
            vlstParam.Add(new SqlParameter("CustomerNameL2", pCustomerNameL2));
            vlstParam.Add(new SqlParameter("CustomerAddress", pCustomerAddress));
            vlstParam.Add(new SqlParameter("CustomerPhoneNumber", pCustomerPhoneNumber));  vlstParam.Add(new SqlParameter("CustomerTaxNumber", pCustomerTaxNumber));
            vlstParam.Add(new SqlParameter("CustomerPostBox", pCustomerPostBox));
            vlstParam.Add(new SqlParameter("CustomerFax", pCustomerFax));
            vlstParam.Add(new SqlParameter("CustomerEmail", pCustomerEmail));
            vlstParam.Add(new SqlParameter("AuthorizePerson", pAuthorizePerson));
            vlstParam.Add(new SqlParameter("CustomerTypeId", pCustomerTypeId)); 
            vlstParam.Add(new SqlParameter("SalesId", pSalesId));
            vlstParam.Add(new SqlParameter("SellCostTypeId", pSellCostTypeId));
            vlstParam.Add(new SqlParameter("CustomerDailyStopType", pCustomerDailyStopType));
            vlstParam.Add(new SqlParameter("CustomerDailyDay", pCustomerDailyDay));
            vlstParam.Add(new SqlParameter("AreaId", pAreaId));
            vlstParam.Add(new SqlParameter("CategoryId", pCategoryId));
            vlstParam.Add(new SqlParameter("Status", pStatus));
            vlstParam.Add(new SqlParameter("AuthorizePersonTel", pAuthorizePersonTel));
            vlstParam.Add(new SqlParameter("CustomerVATCode", pCustomerVATCode));
            vlstParam.Add(new SqlParameter("CustomerParentId", pCustomerParentId));
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("CityId", pCityId));
            vlstParam.Add(new SqlParameter("CustomerAmountLimit", pCustomerAmountLimit));
            vlstParam.Add(new SqlParameter("DelivaryCompanyType", pDelivaryCompanyType));
            vlstParam.Add(new SqlParameter("DelivaryCompanyValue", pDelivaryCompanyValue));

          
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("TypeId", pTypeId));
            vlstParam.Add(new SqlParameter("IsCustomer", pIsCustomer));
            vlstParam.Add(new SqlParameter("CustomerIsActive", pCustomerIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("IsParent", pIsParent));
            vlstParam.Add(new SqlParameter("IsBlackList", pIsBlackList));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("organization", pOrganization));
            vlstParam.Add(new SqlParameter("street", pStreet));
            vlstParam.Add(new SqlParameter("city", pCity));
            vlstParam.Add(new SqlParameter("building_number", pBuildingNumber));
            vlstParam.Add(new SqlParameter("postal_zone", pPostalZone));
            vlstParam.Add(new SqlParameter("district_name", pDistrictName));

            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));

            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLCustomerCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetGLCustomerReport(int? pCustomerId = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CustomerId", pCustomerId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));

            vData = _clsADO.funFillDataTable("ACC.spGLCustomerReport", vlstParam, "Data GET");


            return vData;
        }
    }
}