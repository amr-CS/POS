using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbDashBoard: IdbDashBoard
    {

        private IclsADO _clsADO;
        public dbDashBoard(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        // Account Stat
        public DataTable funAccountStat(
          int? pAccountId = null,
          string pAccountNo = null,
          string pAccountNameL1 = null,
          string pAccountNameL2 = null,
          int? pAccountTypeId = null,
          int? pAccountParentId = null,
          int? pAccountLevel = null,
          int? pCurrencyId = null,
          int? pIsCostCenter = null,
          int? pCurrencyFactorId = null,
          int? pSecurityGradeId = null,
          bool? pAccountIsDebit = null,
          int? pAccountingReportId = null,
          bool? pAccountIsCumulative = null,
          int? pCompanyId = null,
          int? pCashFlowTypeId = null,
          bool? pAccountIsActive = null,
          bool? pIsDeleted = false,
          int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("AccountNo", pAccountNo));
            vlstParam.Add(new SqlParameter("AccountNameL1", pAccountNameL1));
            vlstParam.Add(new SqlParameter("AccountNameL2", pAccountNameL2));
            vlstParam.Add(new SqlParameter("AccountTypeId", pAccountTypeId));
            vlstParam.Add(new SqlParameter("AccountParentId", pAccountParentId));
            vlstParam.Add(new SqlParameter("AccountLevel", pAccountLevel));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("IsCostCenter", pIsCostCenter));
            vlstParam.Add(new SqlParameter("CurrencyFactorId", pCurrencyFactorId));
            vlstParam.Add(new SqlParameter("SecurityGradeId", pSecurityGradeId));
            vlstParam.Add(new SqlParameter("AccountIsDebit", pAccountIsDebit));
            vlstParam.Add(new SqlParameter("AccountingReportId", pAccountingReportId));
            vlstParam.Add(new SqlParameter("AccountIsCumulative", pAccountIsCumulative));
            vlstParam.Add(new SqlParameter("CashFlowTypeId", pCashFlowTypeId));
            vlstParam.Add(new SqlParameter("AccountIsActive", pAccountIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spAccountCRUD", vlstParam, "Data GET").ToString();
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;

        }
        // Cash Desk Stat
        public DataTable funCashDeskStat(
       int? pCashDeskId = null,
       string pCashDeskCode = null,
       string pCashDeskNameL1 = null,
       string pCashDeskNameL2 = null,
       int? pAccountId = null,
       int? pBranchId = null,
       int? pCompanyId = null,
       bool? pCashDeskIsActive = null,
       int? pMainCashDeskId = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("CashDeskCode", pCashDeskCode));
            vlstParam.Add(new SqlParameter("CashDeskNameL1", pCashDeskNameL1));
            vlstParam.Add(new SqlParameter("CashDeskNameL2", pCashDeskNameL2));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("CashDeskIsActive", pCashDeskIsActive));
            vlstParam.Add(new SqlParameter("MainCashDeskId", pMainCashDeskId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCashDeskCRUD", vlstParam, "Data GET").ToString();
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;
        }
        // Cost Center Stat
        public DataTable funCostCenterStat(
    int? pCostCenterId = null,
    string pCostCenterCode = null,
    string pCostCenterNameL1 = null,
    string pCostCenterNameL2 = null,
    int? pCostCenterParentId = null,
    int? pCostCenterLevel = null,
    bool? pCostCenterIsAccumulative = null,
    int? pBranchId = null,
    int? pCompanyId = null,
    bool? pCostCenterIsActive = null,
    bool? pIsDeleted = false,
    int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("CostCenterCode", pCostCenterCode));
            vlstParam.Add(new SqlParameter("CostCenterNameL1", pCostCenterNameL1));
            vlstParam.Add(new SqlParameter("CostCenterNameL2", pCostCenterNameL2));
            vlstParam.Add(new SqlParameter("CostCenterParentId", pCostCenterParentId));
            vlstParam.Add(new SqlParameter("CostCenterLevel", pCostCenterLevel));
            vlstParam.Add(new SqlParameter("CostCenterIsAccumulative", pCostCenterIsAccumulative));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CostCenterIsActive", pCostCenterIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCostCenterCRUD", vlstParam, "Data GET").ToString();
            DataTable vDtResult = new DataTable();
            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;

        }
        // Main Cash Desk Stat

        public DataTable funMainCashDeskStat(
      int? pMainCashDeskId = null,
      string pMainCashDeskCode = null,
      string pMainCashDeskNameL1 = null,
      string pMainCashDeskNameL2 = null,
      int? pAccountId = null,
      int? pBranchId = null,
      int? pCompanyId = null,
      bool? pMainCashDeskIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("MainCashDeskId", pMainCashDeskId));
            vlstParam.Add(new SqlParameter("MainCashDeskCode", pMainCashDeskCode));
            vlstParam.Add(new SqlParameter("MainCashDeskNameL1", pMainCashDeskNameL1));
            vlstParam.Add(new SqlParameter("MainCashDeskNameL2", pMainCashDeskNameL2));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("MainCashDeskIsActive", pMainCashDeskIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spMainCashDeskCRUD", vlstParam, "Data GET").ToString();
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;

        }
        // Customer and Supplier Stat
        public DataTable funCustomerSupplierStat(
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
    int? pQueryTypeId = clsQueryType.qSelect)
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
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;

        }
        // Company And Branch Stat
        public DataTable funCompanyBranchStat(
     int? pCompanyBranchId = null,
     string pCompanyBranchCode = null,
     string pCompanyBranchNameL1 = null,
     string pCompanyBranchNameL2 = null,
     int? pCompanyBranchLevel = null,
     bool? pIsHolding = null,
     string pAccountCodeHierarchy = null,
     int? pLastClosedYear = null,
     int? pLastClosedMonth = null,
     bool? pRefNumberIsVisible = null,
     bool? pCostCenterIsRequired = null,
     bool? pPostIsSerialized = null,
     bool? pDepositIsSentDirectToBank = null,
     bool? pIsPostZeroEntry = null,
     int? pDefaultCurrencyId = null,
     int? pPLAccountId = null,
     int? pRDAccountId = null,
     int? pFinancialYearId = null,
     int? pLanguage1Id = null,
     int? pLanguage2Id = null,
     bool? pCompanyBranchIsActive = null,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyBranchId", pCompanyBranchId));
            vlstParam.Add(new SqlParameter("CompanyBranchCode", pCompanyBranchCode));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", pCompanyBranchNameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", pCompanyBranchNameL2));
            vlstParam.Add(new SqlParameter("CompanyBranchLevel", pCompanyBranchLevel));
            vlstParam.Add(new SqlParameter("IsHolding", pIsHolding));
            vlstParam.Add(new SqlParameter("AccountCodeHierarchy", pAccountCodeHierarchy));
            vlstParam.Add(new SqlParameter("LastClosedYear", pLastClosedYear));
            vlstParam.Add(new SqlParameter("LastClosedMonth", pLastClosedMonth));
            vlstParam.Add(new SqlParameter("RefNumberIsVisible", pRefNumberIsVisible));
            vlstParam.Add(new SqlParameter("CostCenterIsRequired", pCostCenterIsRequired));
            vlstParam.Add(new SqlParameter("PostIsSerialized", pPostIsSerialized));
            vlstParam.Add(new SqlParameter("DepositIsSentDirectToBank", pDepositIsSentDirectToBank));
            vlstParam.Add(new SqlParameter("IsPostZeroEntry", pIsPostZeroEntry));
            vlstParam.Add(new SqlParameter("DefaultCurrencyId", pDefaultCurrencyId));
            vlstParam.Add(new SqlParameter("PLAccountId", pPLAccountId));
            vlstParam.Add(new SqlParameter("RDAccountId", pRDAccountId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("Language1Id", pLanguage1Id));
            vlstParam.Add(new SqlParameter("Language2Id", pLanguage2Id));
            vlstParam.Add(new SqlParameter("CompanyBranchIsActive", pCompanyBranchIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", 401));
            vData = _clsADO.funExecuteScalar("GD.spCompanyBranchCRUD", vlstParam, "Data GET").ToString();
            // Data [Data Table]
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;
        }
        // User Stat
        public DataTable funUserStat(
   int? pUserId = null,
   string pUserCode = null,
   string pUserFullName = null,
   string pUserAddress = null,
   string pUserPhone = null,
   string pUserEmail = null,
   string pUserName = null,
   string pUserPassword = null,
   bool? pIsUserLock = null,
   string pUserImage = null,
   int? pSecurityGradeId = null,
   int? pCountryId = null,
   int? pCompanyId = null,
   int? pBranchId = null,
   int? pFontSizeTypeId = null,
   int? pUserTypeId = null,
   bool? pUserIsActive = null,
   bool? pIsDeleted = false,
   int? pLanguageId = null,
   int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("UserCode", pUserCode));
            vlstParam.Add(new SqlParameter("UserFullName", pUserFullName));
            vlstParam.Add(new SqlParameter("UserAddress", pUserAddress));
            vlstParam.Add(new SqlParameter("UserPhone", pUserPhone));
            vlstParam.Add(new SqlParameter("UserEmail", pUserEmail));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("UserPassword", pUserPassword));
            vlstParam.Add(new SqlParameter("IsUserLock", pIsUserLock));
            vlstParam.Add(new SqlParameter("UserImage", pUserImage));
            vlstParam.Add(new SqlParameter("SecurityGradeId", pSecurityGradeId));
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("FontSizeTypeId", pFontSizeTypeId));
            vlstParam.Add(new SqlParameter("UserTypeId", pUserTypeId));
            vlstParam.Add(new SqlParameter("UserIsActive", pUserIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", pLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserCRUD", vlstParam, "Data GET").ToString();
            // Data [Data Table]
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vData))
            {
                vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
            }
            else
            {

            }
            return vDtResult;

        }
    }
}