using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.APISetting.APIDirectory
{
    public class appAPIDirectory
    {
        // ACC
        public static string vAPIAccount = "/APIAccount/AccountGET";
        public static string vAPIAccountCostCenter = "/APIAccountCostCenter/AccountCostCenterGET";
        public static string vAPIAccountType = "/APIAccountType/AccountTypeGET";
        public static string vAPICashDesk = "/APICashDesk/CashDeskGET";
        public static string vAPIBank = "/APIBank/BankGET";
        public static string vAPICashFlowType = "/APICashFlowType/CashFlowTypeGET";
        public static string vAPICostCenter = "/APICostCenter/CostCenterGET";
        public static string vAPICurrency = "/APICurrency/CurrencyGET";
        public static string vAPICurrencyFactor = "/APICurrencyFactor/CurrencyFactorGET";
        public static string vAPICurrencyGender = "/APICurrencyGender/CurrencyGenderGET";
        public static string vAPICustomerSupplier = "/APICustomerSupplier/CustomerSupplierGET";
        public static string vAPICustomerSupplierGroup = "/APICustomerSupplierGroup/CustomerSupplierGroupGET";
        public static string vAPIDevCompany = "/APIDevCompany/DevCompanyGET";
        public static string vAPIFinancialYear = "/APIFinancialYear/FinancialYearGET";
        public static string vAPIFinancialYearStatus = "/APIFinancialYearStatus/FinancialYearStatusGET";
        public static string vAPIGLTransaction = "/APIGLTransaction/GLTransactionGET";
        public static string vAPIGLVoucherCashDesk = "/APIGLVoucherCashDesk/GLVoucherCashDeskGET";
        public static string vAPIGLVoucherCategory = "/APIGLVoucherCategory/GLVoucherCategoryGET";
        public static string vAPIGLVoucher = "/APIGLVoucher/GLVoucherDataGET";
        public static string vAPIGLVoucherDtl = "/APIGLVoucherDtl/GLVoucherDtlDataGET";
        public static string vAPIPaymentType = "/APIPaymentType/PaymentTypeGET";
        public static string vAPITransactionSource = "/APITransactionSource/TransactionSourceGET";
        public static string vAPITransactionType = "/APITransactionType/TransactionTypeGET";
        public static string vAPIVoucherType = "/APIVoucherType/VoucherTypeGET";
        public static string vAPICashDeskTrans = "/APICashDeskTrans/CashDeskTransDataGET";
        public static string vAPICashDeskDtl = "/APICashDeskDtl/CashDeskDtlDataGET";
        public static string vAPIEstimatedBudgetAccount = "/APIEstimatedBudgetAccount/EstimatedBudgetAccountGET";
        //GD
        public static string vAPICompanyBranch = "/APICompanyBranch/CompanyBranchGET";
        public static string vAPICompanySystem = "/APICompanySystem/CompanySystemGET";
        public static string vAPISystem = "/APISystem/SystemGET";
        //SEC
        public static string vAPIFontSizeType = "/APIFontSizeType/FontSizeTypeGET";
        public static string vAPISecurityGrade = "/APISecurityGrade/SecurityGradeGET";
        public static string vAPIUser = "/APIUser/UserGET";
        public static string vAPIUserLogin = "/APIUserLogin/UserLoginGET";
        public static string vAPIUserLock = "/APIUserLock/UserLockGET";
        public static string vAPIUserSecurityTransactionType = "/APIUserSecurityTransactionType/UserSecurityTransactionTypeGET";
        public static string vAPIUserType = "/APIUserType/UserTypeGET";
        public static string vAPIObjects = "/APIObject/ObjectGET";
        public static string vAPIUserObjectAction = "/APIUserObjectAction/UserObjectActionGET";
        public static string vAPIUserSecurityLog= "/APIUserSecurityLog/UserSecurityLogGET";
        public static string vAPISecurityRole = "/APISecurityRole/SecurityRoleGet";
        public static string vAPISecurityRoleException = "/APISecurityRoleException/SecurityRoleExceptionGet";
        public static string vAPISecurityPolicy = "/APISecurityPolicy/SecurityPolicyGET";
        //SETT
        public static string vAPIArea = "/APIArea/AreaGET";
        public static string vAPICity = "/APICity/CityGET";
        public static string vAPIFont = "/APIFont/FontGET";
        public static string vAPILanguage = "/APILanguage/LanguageGET";
        // SYSSETT
        public static string vAPICountry = "/APICountry/CountryGET";
        public static string vAPICountryType = "/APICountryType/CountryTypeGET";
        public static string vAPIDocStatus = "/APIDocStatus/DocStatusGET";
        public static string vAPISystemMessage = "/APISystemMessage/SystemMessageGet";
        public static string vAPISystemObject = "/APISystemObject/SystemObjectGet";
        public static string vAPIUserFavorite = "/APIUserFavorite/UserFavoriteGet";
        public static string vAPITimeZone = "/APITimeZone/TimeZoneGet";
        // FA
        public static string vAPIAssetTransactionType = "/APIAssetTransactionType/TransactionTypeGET";
        public static string vAPIAssetReasonType = "/APIAssetReasonType/AssetReasonTypeGET";
        public static string vAPIMainGroup = "/APIMainGroup/MainGroupGET";
        public static string vAPIGroup = "/APIGroup/GroupGET";
        public static string vAPIAsset= "/APIAsset/AssetGET";
        public static string vAPIAssetRelease = "/APIAssetRelease/AssetReleaseGET";
        public static string vAPIAssetReleaseDetail = "/APIAssetReleaseDetail/AssetReleaseDetailGET";
        public static string vAPIAssetContract = "/APIAssetContract/AssetContractGET";
        public static string vAPIAssetContractDetail = "/APIAssetContractDetail/AssetContractDetailGET";
        public static string vAPIAssetUnDep = "/APIAssetUnDep/AssetUnDepGET";
        public static string vAPIAssetTrans = "/APIAssetTrans/AssetTransGET";
        public static string vAPIAssetDep = "/APIAssetDep/AssetDepGET";
        public static string vAPISystemSTAT = "/APISystemSTAT/SystemSTATGET";
        public static string vAPIFixedAssetCompanyType = "/APIFixedAssetCompanyType/FixedAssetCompanyTypeGET";
        public static string vAPIFixedAssetCompany = "/APIFixedAssetCompany/FixedAssetCompanyGET";
        public static string vAPIFixedAssetMethod = "/APIFixedAssetMethod/FixedAssetMethodGET";
        public static string vAPIFixedAssetUnit = "/APIFixedAssetUnit/FixedAssetUnitGET";
        public static string vAPISite = "/APISite/SiteGET";
        public static string vAPISiteDonor = "/APISiteDonor/SiteDonorGET";
        //public static string vAPIFixedAssetSite = "/APIFixedAssetSite/APIFixedAssetSiteGET";
        public static string vAPIFixedAssetSite = "/APIFixedAssetSite/FixedAssetSiteGET";
        public static string vAPIBuyGroup = "/APIBuyGroup/BuyGroupGET";
        public static string vAPIAssetContractPayType = "/APIAssetContractPayType/AssetContractPayTypeGET";
        //public static string vAPISiteDetail = "/APISiteDetail/APISiteDetailGET";
        public static string vAPISiteDetail = "/APISiteDetail/SiteDetailGET";
        public static string vAPITrust = "/APITrust/TrustGET";
        public static string vAPIAssetExcelSave = "/APIAssetExcel/AssetEXCELSave";
        // SEC
        public static string vAPIAdmin = "/APIAdmin/AdminGET";
        // INV
        public static string vAPIStoreDepartment = "/APIStoreDepartment/StoreDepartmentGET";
        public static string vAPISalesOrderType = "/APISalesOrderType/SalesOrderTypeGET";
        public static string vAPIOfferType = "/APIOfferType/OfferTypeGET";
        public static string vAPIUnit = "/APIUnit/UnitGET";
        public static string vAPISize = "/APISize/SizeGET";
        public static string vAPISizeType = "/APISizeType/SizeTypeGET";
        public static string vAPIStoreEmployee = "/APIStoreEmployee/StoreEmployeeGET";
        public static string vAPIEPaymentType = "/APIEPaymentType/EPaymentTypeGET";
        public static string vAPIStore = "/APIStore/StoreGET";
        public static string vAPIStoreType = "/APIStoreType/StoreTypeGET";
        public static string vAPIStoreSetting = "/APIStoreSetting/StoreSettingGET";
        public static string vAPIStoreKeeper = "/APIStoreKeeper/StoreKeeperGET";
        public static string vAPIProductType = "/APIProductType/ProductTypeGET";
        public static string vAPICategoryAccount = "/APICategoryAccount/CategoryAccountGET";
        // RES
        public static string vAPIPeriod = "/APIPeriod/PeriodGET";


    }
}