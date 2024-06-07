using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbDashBoard
    {
        DataTable funAccountStat(
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
          int? pQueryTypeId = clsQueryType.qSelect);

        DataTable funCashDeskStat(
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
        int? pQueryTypeId = clsQueryType.qSelect);

    DataTable funCostCenterStat(
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
    int? pQueryTypeId = clsQueryType.qSelect);

      DataTable funMainCashDeskStat(
      int? pMainCashDeskId = null,
      string pMainCashDeskCode = null,
      string pMainCashDeskNameL1 = null,
      string pMainCashDeskNameL2 = null,
      int? pAccountId = null,
      int? pBranchId = null,
      int? pCompanyId = null,
      bool? pMainCashDeskIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect);

    DataTable funCustomerSupplierStat(
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
    int? pQueryTypeId = clsQueryType.qSelect);


     DataTable funCompanyBranchStat(
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
     int? pQueryTypeId = clsQueryType.qSelect);


        DataTable funUserStat(
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
        int? pQueryTypeId = clsQueryType.qSelect);


    }
}
