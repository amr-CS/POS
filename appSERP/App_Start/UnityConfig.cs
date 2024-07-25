using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.dbCode.ACC.Doc;
using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.dbCode.GD;
using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.SYSSETT;
using appSERP.appCode.Setting.SYSSETT.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.Setting.User.Abstract;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.Logger;
using appSERP.ZatcaEInvoicing.LinkPro;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace appSERP
{
    public static class UnityConfig
    {
        static IUnityContainer container = new UnityContainer();

        public static void RegisterComponents()
        {
			//var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<ILog, Log>();            
            container.RegisterType<IclsADO, clsADO>();
            container.RegisterType<IdbINVInvoice, dbINVInvoice>();
            container.RegisterType<IdbInvItem, dbInvItem>();
            container.RegisterType<IdbInvStoreItemQty, dbInvStoreItemQty>();
            container.RegisterType<IdbBank, dbBank>();
            container.RegisterType<IdbGLTransaction, dbGLTransaction>();
            container.RegisterType<IdbCashDesk, dbCashDesk>();
            container.RegisterType<IdbCashFlowType, dbCashFlowType>();
            container.RegisterType<IdbUserType, dbUserType>();
            container.RegisterType<IdbProduction, dbProduction>();
            container.RegisterType<IdbUserSecurityTransactionType, dbUserSecurityTransactionType>();
            container.RegisterType<IdbAccountType, dbAccountType>();
            container.RegisterType<IdbAccountCostCenter, dbAccountCostCenter>();
            container.RegisterType<IdbCostCenter, dbCostCenter>();
            container.RegisterType<IdbPOSReport, dbPOSReport>();
            container.RegisterType<appCode.dbCode.ACC.Abstract.IdbDashBoard, appCode.dbCode.ACC.dbDashBoard>();
            container.RegisterType<IdbCurrency, dbCurrency>();
            container.RegisterType<IdbCashDeskDtl, dbCashDeskDtl>();
            container.RegisterType<IdbCurrencyFactor, dbCurrencyFactor>();
            container.RegisterType<IdbCurrencyGender, dbCurrencyGender>();
            container.RegisterType<IdbCustomerSupplier, dbCustomerSupplier>();
            container.RegisterType<IdbGLCustomer, dbGLCustomer>();
            container.RegisterType<IdbCustomerCategory, dbCustomerCategory>();
            container.RegisterType<IdbCustomerSite, dbCustomerSite>();
            container.RegisterType<IdbCustomerTel, dbCustomerTel>();
            container.RegisterType<IdbCustomerSupplierGroup, dbCustomerSupplierGroup>();
            container.RegisterType<IdbFinancialYear, dbFinancialYear>();
            container.RegisterType<IdbFinancialYearStatus, dbFinancialYearStatus>();
            container.RegisterType<IdbGLVoucherCashDesk, dbGLVoucherCashDesk>();
            container.RegisterType<IdbVoucherBoxCheck, dbVoucherBoxCheck>();
            container.RegisterType<IdbGLVoucherCategory, dbGLVoucherCategory>();
            container.RegisterType<IdbVoucherType, dbVoucherType>();
            container.RegisterType<IdbGLVoucher, dbGLVoucher>();
            container.RegisterType<IdbGLVoucherOld, dbGLVoucherOld>();
            container.RegisterType<IdbGLVoucherDtl, dbGLVoucherDtl>();
            container.RegisterType<IdbPaymentType, dbPaymentType>();
            container.RegisterType<IdbEPaymentType, dbEPaymentType>();
            container.RegisterType<IdbTransactionSource, dbTransactionSource>();
            container.RegisterType<IdbTransactionType, dbTransactionType>();            
            container.RegisterType<appCode.dbCode.ACC.Abstract.IdbAssetTransactionType, appCode.dbCode.ACC.dbAssetTransactionType>();


            container.RegisterType<appCode.dbCode.FA.Abstract.IdbAssetTransactionType, appCode.dbCode.FA.dbAssetTransactionType>();
            container.RegisterType<IdbAsset, dbAsset>();
            container.RegisterType<IdbAssetContract, dbAssetContract>();
            container.RegisterType<IdbAssetContractDetail, dbAssetContractDetail>();
            container.RegisterType<IdbAssetContractPayType, dbAssetContractPayType>();
            container.RegisterType<IdbAssetDep, dbAssetDep>();
            container.RegisterType<IdbAssetReasonType, dbAssetReasonType>();
            container.RegisterType<IdbAssetRelease, dbAssetRelease>();
            container.RegisterType<IdbAssetReleaseDetail, dbAssetReleaseDetail>();
            container.RegisterType<IdbAssetUnDep, dbAssetUnDep>();
            container.RegisterType<IdbFixedAssetSite, dbFixedAssetSite>();
            container.RegisterType<IdbAssetTrans, dbAssetTrans>();
            container.RegisterType<IdbFixedAssetCompany, dbFixedAssetCompany>();
            container.RegisterType<IdbFixedAssetMethod, dbFixedAssetMethod>();
            container.RegisterType<IdbFixedAssetCompanyType, dbFixedAssetCompanyType>();
            container.RegisterType<IdbFixedAssetUnit, dbFixedAssetUnit>();
            container.RegisterType<IdbBuyGroup, dbBuyGroup>();
            container.RegisterType<IdbGroup, dbGroup>();
            container.RegisterType<IdbUserGroup, dbUserGroup>();
            container.RegisterType<IdbMainGroup, dbMainGroup>();
            container.RegisterType<IdbSiteDetail, dbSiteDetail>();
            container.RegisterType<IdbSiteDonor, dbSiteDonor>();
            container.RegisterType<IdbSite, dbSite>();
            container.RegisterType<IdbLookup, dbLookup>();
            container.RegisterType<IdbFontSizeType, dbFontSizeType>();
            container.RegisterType<IdbSize, dbSize>();
            container.RegisterType<IdbSizeType, dbSizeType>();
            container.RegisterType<IdbOfferType, dbOfferType>();

            container.RegisterType<IdbCompanyBranch, dbCompanyBranch>();
            container.RegisterType<IdbCompanySystem, dbCompanySystem>();
            container.RegisterType<IdbDevCompany, dbDevCompany>();
            container.RegisterType<IdbStoreConversion, dbStoreConversion>();
            container.RegisterType<IdbStoreDepartment, dbStoreDepartment>();
            container.RegisterType<IdbStoreEmployee, dbStoreEmployee>();
            container.RegisterType<IdbStoreType, dbStoreType>();
            container.RegisterType<IdbStore, dbStore>();
            container.RegisterType<IdbStoreKeeper, dbStoreKeeper>();
            container.RegisterType<IdbStoreSetting, dbStoreSetting>();
            container.RegisterType<IdbSalesOrderType, dbSalesOrderType>();
            container.RegisterType<IdbSalesMen, dbSalesMen>();
            container.RegisterType<IdbBranchSetting, dbBranchSetting>();
            container.RegisterType<IdbVehicle, dbVehicle>();
            container.RegisterType<IdbVehicleDriver, dbVehicleDriver>();
            container.RegisterType<IdbPeriod, dbPeriod>();
            container.RegisterType<IdbPrinter, dbPrinter>();
            container.RegisterType<IdbResEmployee, dbResEmployee>();
            container.RegisterType<IdbResOrder, dbResOrder>();
            container.RegisterType<IdbDirectPrint, dbDirectPrint>();
            container.RegisterType<IdbCashier, dbCashier>();            
            container.RegisterType<appCode.dbCode.RES.Abstract.IdbDashBoard, appCode.dbCode.RES.dbDashBoard>();
            container.RegisterType<IdbEmpStatus, dbEmpStatus>();
            container.RegisterType<IdbExitType, dbExitType>();
            container.RegisterType<IdbIdentityType, dbIdentityType>();
            container.RegisterType<IdbInvType, dbInvType>();
            container.RegisterType<IdbNationality, dbNationality>();
            container.RegisterType<IdbPortType, dbPortType>();
            container.RegisterType<IdbPrinterDTL, dbPrinterDTL>();
            container.RegisterType<IdbValueType, dbValueType>();
            container.RegisterType<IdbVAccountCategory, dbVAccountCategory>();
            container.RegisterType<IdbVehBrand, dbVehBrand>();
            container.RegisterType<IdbVehColor, dbVehColor>();
            container.RegisterType<IdbVehModel, dbVehModel>();
            container.RegisterType<IdbVehStatus, dbVehStatus>();
            container.RegisterType<IdbVehType, dbVehType>();
            container.RegisterType<IdbVUnit, dbVUnit>();
            container.RegisterType<IdbResOrderDtl, dbResOrderDtl>();
            container.RegisterType<IdbResOrderLocation, dbResOrderLocation>();
            container.RegisterType<IdbUser, dbUser>();
            container.RegisterType<IdbUserCashier, dbUserCashier>();
            container.RegisterType<IdbUserLock, dbUserLock>();
            container.RegisterType<IdbUserSecurityLog, dbUserSecurityLog>();
            container.RegisterType<IdbUserFavorite, dbUserFavorite>();
            container.RegisterType<IdbUserObjectAction, dbUserObjectAction>();
            container.RegisterType<IdbUnit, dbUnit>();
            container.RegisterType<IdbInvItemUnit, dbInvItemUnit>();
            container.RegisterType<IdbInvItemsUnitsPrice, dbInvItemsUnitsPrice>();
            container.RegisterType<IdbCashDeskTrans, dbCashDeskTrans>();
            container.RegisterType<IdbCountry, dbCountry>();
            container.RegisterType<IdbCountryType, dbCountryType>();
            container.RegisterType<IdbCommunicationType, dbCommunicationType>();
            container.RegisterType<IdbCategoryAccount, dbCategoryAccount>();
            container.RegisterType<IdbEstimatedBudgetAccount, dbEstimatedBudgetAccount>();
            container.RegisterType<IdbAccountLastChild, dbAccountLastChild>();
            container.RegisterType<IdbFont, dbFont>();
            container.RegisterType<IdbSellCostType, dbSellCostType>();
            container.RegisterType<IdbSystem, dbSystem>();
            container.RegisterType<IdbSystemMessage, dbSystemMessage>();
            container.RegisterType<IdbSystemSTAT, dbSystemSTAT>();
            container.RegisterType<IdbInvItemBarcode, dbInvItemBarcode>();
            container.RegisterType<IdbInvItemEquipment, dbInvItemEquipment>();
            container.RegisterType<IdbInvItemReplace, dbInvItemReplace>();
            container.RegisterType<IdbInvSubItem, dbInvSubItem>();
            container.RegisterType<IdbInvItemsEquip, dbInvItemsEquip>();
            container.RegisterType<IdbProductType, dbProductType>();
            container.RegisterType<IdbObjects, dbObjects>();
            container.RegisterType<IdbTrust, dbTrust>();
            container.RegisterType<IdbExpireDate, dbExpireDate>();
            container.RegisterType<IdbTimeZone, dbTimeZone>();
            container.RegisterType<IdbCity, dbCity>();
            container.RegisterType<IdbPlate, dbPlate>();
            container.RegisterType<IdbSecurityGrade, dbSecurityGrade>();
            container.RegisterType<IdbSecurityRole, dbSecurityRole>();
            container.RegisterType<IdbSecurityPolicy, dbSecurityPolicy>();
            container.RegisterType<IdbSecurityRoleException, dbSecurityRoleException>();
            container.RegisterType<IdbInvBoxes, dbInvBoxes>();
            container.RegisterType<IdbInvEquipment, dbInvEquipment>();
            container.RegisterType<IdbArea, dbArea>();
            container.RegisterType<IdbInvChecks, dbInvChecks>();            
            container.RegisterType<appCode.dbCode.SETT.Abstract.IdbDocStatus, appCode.dbCode.SETT.dbDocStatus>();
            container.RegisterType<appCode.dbCode.SYSSETT.Abstract.IdbDocStatus, appCode.dbCode.SYSSETT.dbDocStatus>();
            container.RegisterType<IdbLanguage, dbLanguage>();
            container.RegisterType<IdbAccount, dbAccount>();

            //clsAPI
            container.RegisterType<IclsAPI, clsAPI>();
            container.RegisterType<IclsUserType, clsUserType>();
            container.RegisterType<ISYSSETTSetting, SYSSETTSetting>();
            container.RegisterType<IDevCompanySetting, DevCompanySetting>();
            container.RegisterType<IdbMenuItem, dbMenuItem>();
            container.RegisterType<IdbSupplierMenu, dbSupplierMenu>();


            //BH
            container.RegisterType<IZatcaEInvoice, ZatcaEInvoiceAPI>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //Register API Controllers
            GlobalConfiguration.Configuration.DependencyResolver =
            new Unity.WebApi.UnityDependencyResolver(container);

        }

        
        public static T GetInstanceUC<T>() 
        {
            return container.Resolve<T>();
        }
        public static T GetInstanceUC<T, TM>()
        {
            var services = container.ResolveAll<T>();
            var serviceTM = services.First(o => o.GetType() == typeof(TM));
            return serviceTM;
        }

    }
}