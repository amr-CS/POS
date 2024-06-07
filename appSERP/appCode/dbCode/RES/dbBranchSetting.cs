using appSERP.appCode.dbCode.RES.Abstract;
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
    public class dbBranchSetting : IdbBranchSetting
    {

        private IclsADO _clsADO;
        public dbBranchSetting(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funBranchSettingGET(
            int? pBranchSettingId = null,
            bool? IsPOSPrinterNetwork=null,
            string pBranchSettingCode = null,
            string pBranchDesc = null,
            string pBranchDescL = null,
            int? pBranchId = null,
            int? pFraction = null,
            string pMaskAmount = null,
            int? pFormatDate = null,
            int? pEmpAtType = null,
            DateTime? pEmpDate = null,
            int? pPlateCode = null,
            string pDesFormat = null,
            string pDesName = null,
            string pDesType = null,
            string pReportServer = null,
            string pRrovirtualdir = null,
            string pReportsINTerface = null,
            string pHostname = null,
            string pVirtualdir = null,
            string pPhysicaldir = null,
            string pUseorarrp = null,
            string pUsequeuetables = null,
            string pRepExtINTion = null,
            float? pDefaultLocation = null,
            string pImgPath = null,
            int? pPlateStore = null,
            int? pPlateUnit = null,
            int? pSellStore = null,
            int? pPcDetectionType = null,
            int? pHoldInvTimer = null,
            int? pInsuranceLimit = null,
            string pInvoiceRemark = null,
            string pOrderRemark = null,
            string pKitchenPrINTer = null,
            string pFontPath = null,
            string pBranchPhone = null,
            int? pSheepCat = null,
            int? pAllowSwithoutcprINTers = null,
            string pLocationImgPath = null,
            int? pFoodPrepareCat = null,
            int? pCashCode = null,
            bool? pShowRefItem = null,
            bool? pShowRefProduct = null,
            int? pCustAcc = null,
            int? pRecevAcc = null,
            string pCostCenter = null,
            string pBounsAccount = null,
            string pLaterAccounts = null,
            string pVPosCaneclAcc = null,
            string pRentAccounts = null,
            int? pDriverSeq = null,
            int? pKitchenStore = null,
            int? pSheepCatProduct = null,
            int? pSheepOutRes = null,
            int? pSellAcc = null,
            int? pInsurAcc = null,
            int? pRentAcc = null,
            int? pShowQty = null,
            int? pSubSeqInv = null,
            int? pBranchMgr = null,
            int? pReservType = null,
            int? pDeliveryTrans = null,
            bool? pAllowBlkList = null,
            int? pItemDelivery = null,
            bool? pAllowCancelInvoice = null,
            int? pGrpAddPlate = null,
            int? pQtyPlateRice = null,
            int? pRiceCat = null,
            bool? pShowQtyZero = null,
            string pOrderEmp = null,
            string pOrderPhone = null,
            string pBranchPhoneOrder = null,
            string pBranchAddress = null,
            bool? pDefaultProdCost = null,
            int? pSubSeqOrder = null,
            bool? pDecreaseProdAuto = null,
            int? pCommAccount = null,
            string pShortNum = null,
            int? pNewOrderTime = null,
            bool? pDeliveryCashier = null,
            bool? pPayCashierAmount = null,
            bool? pAssemblingPrINTer = null,
            int? pDefaultLocationDelivery = null,
            bool? pModifyInvoice = null,
            bool? pPrINTCancelInvoice = null,
            bool? pDisplayDirverAccount = null,
            bool? pDisplayUpdateDirver = null,
            bool? pPrINTUpdateInvoice = null,
            int? pLimitInvId = null,
            bool? pPrINTBasicInvId = null,
            bool? pAutoOpenPeriod = null,
            bool? pAutoClosePeriod = null,
            int? pLengthPeriodDay = null,
            int? pCompIdPost = null,
            bool? pUpdateInvoiceDriver = null,
            bool? pShowAllInvoiceForCancel = null,
            bool? pShowAllInvoiceForUpdate = null,
            bool? pChangeUpdateDate = null,
            bool? pManualProduction = null,
            bool? pChangeUpdateCashier = null,
            int? pDiscountMax = null,
            bool? pEnterHelfoodAllowed = null,
            bool? pEnterPartbuildAllowed = null,
            bool? pAllowDiscount = null,
            bool? pConvertProductionFullQty = null,
            bool? pCloseFormUpdateAuto = null,
            int? pStoreBasic = null,
            int? pProductTypeOut = null,
            bool? pAssemblingPost = null,
            string pClientStoreId = null,
            string pBranchAccount = null,
            int? pEmpCostId = null,
            int? pStoreProduction = null,
            bool? pChoiceStoreProdAuto = null,
            bool? pAddQyProductbeforeSpend = null,
            int? pCompanyId = null,
            string pIsVat = null,
            string pVatCode = null,
            float? pVatPerc = null,
            float? pRoundLowerHalf = null,
            bool? pIsDeleted = null,
            int? pCreatedBy = null,
            DateTime? pCreatedOn = null,
            int? pLastUpdatedBy = null,
            DateTime? pLastUpdatedOn = null,
            int? pLanguageId = null,
            string MailHost = null,
            string MailPassword = null,
            string MailPort = null,
            string MailSubject = null,
            string MailBody = null,
            string MailFrom = null, 
            string MailTo= null,
            string IBAN= null,
            int? BOX_ID = null,
            int? CostID = null,
            string VatAccount = null,
            string TotalAccount = null,
            string InsuranceAccount = null,
            string ReturnAccount = null,
            string NumberReports = null,
            float? MadaPerc = null,
            float? VisaPerc = null,
            string pAccountId = null,
            string pLinkProApi = null,
            int? pQueryTypeId = null)
                {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("BranchSettingId", pBranchSettingId));
            vlstParam.Add(new SqlParameter("IsPOSPrinterNetwork", IsPOSPrinterNetwork));
            vlstParam.Add(new SqlParameter("BranchSettingCode", pBranchSettingCode));
            vlstParam.Add(new SqlParameter("BranchDesc", pBranchDesc));
            vlstParam.Add(new SqlParameter("BranchDescL", pBranchDescL)); 
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("Fraction", pFraction));
            vlstParam.Add(new SqlParameter("MaskAmount", pMaskAmount));
            vlstParam.Add(new SqlParameter("FormatDate", pFormatDate));
            vlstParam.Add(new SqlParameter("EmpAtType", pEmpAtType));
            vlstParam.Add(new SqlParameter("EmpDate", pEmpDate));
            vlstParam.Add(new SqlParameter("PlateCode", pPlateCode));
            vlstParam.Add(new SqlParameter("DesFormat", pDesFormat));
            vlstParam.Add(new SqlParameter("DesName", pDesName));
            vlstParam.Add(new SqlParameter("DesType", pDesType));
            vlstParam.Add(new SqlParameter("ReportServer", pReportServer));
            vlstParam.Add(new SqlParameter("Rrovirtualdir", pRrovirtualdir));
            vlstParam.Add(new SqlParameter("ReportsINTerface", pReportsINTerface));
            vlstParam.Add(new SqlParameter("Hostname", pHostname));
            vlstParam.Add(new SqlParameter("Virtualdir", pVirtualdir));
            vlstParam.Add(new SqlParameter("Physicaldir", pPhysicaldir));
            vlstParam.Add(new SqlParameter("Useorarrp", pUseorarrp));
            vlstParam.Add(new SqlParameter("Usequeuetables", pUsequeuetables));
            vlstParam.Add(new SqlParameter("RepExtINTion", pRepExtINTion));
            vlstParam.Add(new SqlParameter("DefaultLocation", pDefaultLocation));
            vlstParam.Add(new SqlParameter("ImgPath", HttpRuntime.AppDomainAppPath+@"Image\"+pImgPath));
            vlstParam.Add(new SqlParameter("PlateStore", pPlateStore));
            vlstParam.Add(new SqlParameter("PlateUnit", pPlateUnit));
            vlstParam.Add(new SqlParameter("SellStore", pSellStore));
            vlstParam.Add(new SqlParameter("PcDetectionType", pPcDetectionType));
            vlstParam.Add(new SqlParameter("HoldInvTimer", pHoldInvTimer));
            vlstParam.Add(new SqlParameter("InsuranceLimit", pInsuranceLimit));
            vlstParam.Add(new SqlParameter("InvoiceRemark", pInvoiceRemark));
            vlstParam.Add(new SqlParameter("OrderRemark", pOrderRemark));
            vlstParam.Add(new SqlParameter("KitchenPrINTer", pKitchenPrINTer));
            vlstParam.Add(new SqlParameter("FontPath", pFontPath));
            vlstParam.Add(new SqlParameter("BranchPhone", pBranchPhone));
            vlstParam.Add(new SqlParameter("SheepCat", pSheepCat));
            vlstParam.Add(new SqlParameter("AllowSwithoutcprINTers", pAllowSwithoutcprINTers));
            vlstParam.Add(new SqlParameter("LocationImgPath", pLocationImgPath));
            vlstParam.Add(new SqlParameter("FoodPrepareCat", pFoodPrepareCat));
            vlstParam.Add(new SqlParameter("CashCode", pCashCode));
            vlstParam.Add(new SqlParameter("ShowRefItem", pShowRefItem));
            vlstParam.Add(new SqlParameter("ShowRefProduct", pShowRefProduct));
            vlstParam.Add(new SqlParameter("CustAcc", pCustAcc));
            vlstParam.Add(new SqlParameter("RecevAcc", pRecevAcc));
            vlstParam.Add(new SqlParameter("CostCenter", pCostCenter));
            vlstParam.Add(new SqlParameter("BounsAccount", pBounsAccount));
            vlstParam.Add(new SqlParameter("LaterAccounts", pLaterAccounts));
            vlstParam.Add(new SqlParameter("VPosCaneclAcc", pVPosCaneclAcc));
            vlstParam.Add(new SqlParameter("RentAccounts", pRentAccounts));
            vlstParam.Add(new SqlParameter("DriverSeq", pDriverSeq));
            vlstParam.Add(new SqlParameter("KitchenStore", pKitchenStore));
            vlstParam.Add(new SqlParameter("SheepCatProduct", pSheepCatProduct));
            vlstParam.Add(new SqlParameter("SheepOutRes", pSheepOutRes));
            vlstParam.Add(new SqlParameter("SellAcc", pSellAcc));
            vlstParam.Add(new SqlParameter("InsurAcc", pInsurAcc));
            vlstParam.Add(new SqlParameter("RentAcc", pRentAcc));
            vlstParam.Add(new SqlParameter("ShowQty", pShowQty));
            vlstParam.Add(new SqlParameter("SubSeqInv", pSubSeqInv));
            vlstParam.Add(new SqlParameter("BranchMgr", pBranchMgr));
            vlstParam.Add(new SqlParameter("ReservType", pReservType));
            vlstParam.Add(new SqlParameter("DeliveryTrans", pDeliveryTrans));
            vlstParam.Add(new SqlParameter("AllowBlkList", pAllowBlkList));
            vlstParam.Add(new SqlParameter("ItemDelivery", pItemDelivery));
            vlstParam.Add(new SqlParameter("AllowCancelInvoice", pAllowCancelInvoice));
            vlstParam.Add(new SqlParameter("GrpAddPlate", pGrpAddPlate));
            vlstParam.Add(new SqlParameter("QtyPlateRice", pQtyPlateRice));
            vlstParam.Add(new SqlParameter("RiceCat", pRiceCat));
            vlstParam.Add(new SqlParameter("ShowQtyZero", pShowQtyZero));
            vlstParam.Add(new SqlParameter("OrderEmp", pOrderEmp));
            vlstParam.Add(new SqlParameter("OrderPhone", pOrderPhone));
            vlstParam.Add(new SqlParameter("BranchPhoneOrder", pBranchPhoneOrder));
            vlstParam.Add(new SqlParameter("BranchAddress", pBranchAddress));
            vlstParam.Add(new SqlParameter("DefaultProdCost", pDefaultProdCost));
            vlstParam.Add(new SqlParameter("SubSeqOrder", pSubSeqOrder));
            vlstParam.Add(new SqlParameter("DecreaseProdAuto", pDecreaseProdAuto));
            vlstParam.Add(new SqlParameter("CommAccount", pCommAccount));
            vlstParam.Add(new SqlParameter("ShortNum", pShortNum));
            vlstParam.Add(new SqlParameter("NewOrderTime", pNewOrderTime));
            vlstParam.Add(new SqlParameter("DeliveryCashier", pDeliveryCashier));
            vlstParam.Add(new SqlParameter("PayCashierAmount", pPayCashierAmount));
            vlstParam.Add(new SqlParameter("AssemblingPrINTer", pAssemblingPrINTer));
            vlstParam.Add(new SqlParameter("DefaultLocationDelivery", pDefaultLocationDelivery));
            vlstParam.Add(new SqlParameter("ModifyInvoice", pModifyInvoice));
            vlstParam.Add(new SqlParameter("PrINTCancelInvoice", pPrINTCancelInvoice));
            vlstParam.Add(new SqlParameter("DisplayDirverAccount", pDisplayDirverAccount));
            vlstParam.Add(new SqlParameter("DisplayUpdateDirver", pDisplayUpdateDirver));
            vlstParam.Add(new SqlParameter("PrINTUpdateInvoice", pPrINTUpdateInvoice));
            vlstParam.Add(new SqlParameter("LimitInvId", pLimitInvId));
            vlstParam.Add(new SqlParameter("PrINTBasicInvId", pPrINTBasicInvId));
            vlstParam.Add(new SqlParameter("AutoOpenPeriod", pAutoOpenPeriod));
            vlstParam.Add(new SqlParameter("AutoClosePeriod", pAutoClosePeriod));
            vlstParam.Add(new SqlParameter("LengthPeriodDay", pLengthPeriodDay));
            vlstParam.Add(new SqlParameter("CompIdPost", pCompIdPost));
            vlstParam.Add(new SqlParameter("UpdateInvoiceDriver", pUpdateInvoiceDriver));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForCancel", pShowAllInvoiceForCancel));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForUpdate", pShowAllInvoiceForUpdate));
            vlstParam.Add(new SqlParameter("ChangeUpdateDate", pChangeUpdateDate));
            vlstParam.Add(new SqlParameter("ManualProduction", pManualProduction));
            vlstParam.Add(new SqlParameter("ChangeUpdateCashier", pChangeUpdateCashier));
            vlstParam.Add(new SqlParameter("DiscountMax", pDiscountMax));
            vlstParam.Add(new SqlParameter("EnterHelfoodAllowed", pEnterHelfoodAllowed));
            vlstParam.Add(new SqlParameter("EnterPartbuildAllowed", pEnterPartbuildAllowed));
            vlstParam.Add(new SqlParameter("AllowDiscount", pAllowDiscount));
            vlstParam.Add(new SqlParameter("ConvertProductionFullQty", pConvertProductionFullQty));
            vlstParam.Add(new SqlParameter("CloseFormUpdateAuto", pCloseFormUpdateAuto));
            vlstParam.Add(new SqlParameter("StoreBasic", pStoreBasic));
            vlstParam.Add(new SqlParameter("ProductTypeOut", pProductTypeOut));
            vlstParam.Add(new SqlParameter("AssemblingPost", pAssemblingPost));
            vlstParam.Add(new SqlParameter("ClientStoreId", pClientStoreId));
            vlstParam.Add(new SqlParameter("BranchAccount", pBranchAccount));
            vlstParam.Add(new SqlParameter("EmpCostId", pEmpCostId));
            vlstParam.Add(new SqlParameter("StoreProduction", pStoreProduction));
            vlstParam.Add(new SqlParameter("ChoiceStoreProdAuto", pChoiceStoreProdAuto));
            vlstParam.Add(new SqlParameter("AddQyProductbeforeSpend", pAddQyProductbeforeSpend));
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("IsVat", pIsVat));
            vlstParam.Add(new SqlParameter("VatCode", pVatCode));
            vlstParam.Add(new SqlParameter("VatPerc", pVatPerc));
            vlstParam.Add(new SqlParameter("RoundLowerHalf", pRoundLowerHalf));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("MailHost", MailHost));
            vlstParam.Add(new SqlParameter("MailPassword", MailPassword));
            vlstParam.Add(new SqlParameter("MailPort", MailPort));
            vlstParam.Add(new SqlParameter("MailSubject", MailSubject));
            vlstParam.Add(new SqlParameter("MailBody", MailBody));
            vlstParam.Add(new SqlParameter("MailFrom", MailFrom));
            vlstParam.Add(new SqlParameter("MailTo", MailTo));
            vlstParam.Add(new SqlParameter("IBAN", IBAN));
            vlstParam.Add(new SqlParameter("BOX_ID", BOX_ID));
            vlstParam.Add(new SqlParameter("CostID", CostID));
            vlstParam.Add(new SqlParameter("VatAccount", VatAccount));
            vlstParam.Add(new SqlParameter("TotalAccount", TotalAccount));
            vlstParam.Add(new SqlParameter("InsuranceAccount", InsuranceAccount));
            vlstParam.Add(new SqlParameter("ReturnAccount", ReturnAccount));
            vlstParam.Add(new SqlParameter("NumberReports", NumberReports));

            vlstParam.Add(new SqlParameter("MadaPerc", MadaPerc));
            vlstParam.Add(new SqlParameter("VisaPerc", VisaPerc));
            vlstParam.Add(new SqlParameter("account_id", pAccountId));
            vlstParam.Add(new SqlParameter("LinkProApi", pLinkProApi));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spBranchSettingCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }


        public DataTable GetBranchSetting(
         int? pBranchSettingId = null,
         string pBranchSettingCode = null,
         string pBranchDesc = null,
         string pBranchDescL = null,
         int? pBranchId = null,
         int? pFraction = null,
         string pMaskAmount = null,
         int? pFormatDate = null,
         int? pEmpAtType = null,
         DateTime? pEmpDate = null,
         int? pPlateCode = null,
         string pDesFormat = null,
         string pDesName = null,
         string pDesType = null,
         string pReportServer = null,
         string pRrovirtualdir = null,
         string pReportsINTerface = null,
         string pHostname = null,
         string pVirtualdir = null,
         string pPhysicaldir = null,
         string pUseorarrp = null,
         string pUsequeuetables = null,
         string pRepExtINTion = null,
         float? pDefaultLocation = null,
         string pImgPath = null,
         int? pPlateStore = null,
         int? pPlateUnit = null,
         int? pSellStore = null,
         int? pPcDetectionType = null,
         int? pHoldInvTimer = null,
         int? pInsuranceLimit = null,
         string pInvoiceRemark = null,
         string pOrderRemark = null,
         string pKitchenPrINTer = null,
         string pFontPath = null,
         string pBranchPhone = null,
         int? pSheepCat = null,
         int? pAllowSwithoutcprINTers = null,
         string pLocationImgPath = null,
         int? pFoodPrepareCat = null,
         int? pCashCode = null,
         bool? pShowRefItem = null,
         bool? pShowRefProduct = null,
         int? pCustAcc = null,
         int? pRecevAcc = null,
         string pCostCenter = null,
         string pBounsAccount = null,
         string pLaterAccounts = null,
         string pVPosCaneclAcc = null,
         string pRentAccounts = null,
         int? pDriverSeq = null,
         int? pKitchenStore = null,
         int? pSheepCatProduct = null,
         int? pSheepOutRes = null,
         int? pSellAcc = null,
         int? pInsurAcc = null,
         int? pRentAcc = null,
         int? pShowQty = null,
         int? pSubSeqInv = null,
         int? pBranchMgr = null,
         int? pReservType = null,
         int? pDeliveryTrans = null,
         bool? pAllowBlkList = null,
         int? pItemDelivery = null,
         bool? pAllowCancelInvoice = null,
         int? pGrpAddPlate = null,
         int? pQtyPlateRice = null,
         int? pRiceCat = null,
         bool? pShowQtyZero = null,
         string pOrderEmp = null,
         string pOrderPhone = null,
         string pBranchPhoneOrder = null,
         string pBranchAddress = null,
         bool? pDefaultProdCost = null,
         int? pSubSeqOrder = null,
         bool? pDecreaseProdAuto = null,
         int? pCommAccount = null,
         string pShortNum = null,
         int? pNewOrderTime = null,
         bool? pDeliveryCashier = null,
         bool? pPayCashierAmount = null,
         bool? pAssemblingPrINTer = null,
         int? pDefaultLocationDelivery = null,
         bool? pModifyInvoice = null,
         bool? pPrINTCancelInvoice = null,
         bool? pDisplayDirverAccount = null,
         bool? pDisplayUpdateDirver = null,
         bool? pPrINTUpdateInvoice = null,
         int? pLimitInvId = null,
         bool? pPrINTBasicInvId = null,
         bool? pAutoOpenPeriod = null,
         bool? pAutoClosePeriod = null,
         int? pLengthPeriodDay = null,
         int? pCompIdPost = null,
         bool? pUpdateInvoiceDriver = null,
         bool? pShowAllInvoiceForCancel = null,
         bool? pShowAllInvoiceForUpdate = null,
         bool? pChangeUpdateDate = null,
         bool? pManualProduction = null,
         bool? pChangeUpdateCashier = null,
         int? pDiscountMax = null,
         bool? pEnterHelfoodAllowed = null,
         bool? pEnterPartbuildAllowed = null,
         bool? pAllowDiscount = null,
         bool? pConvertProductionFullQty = null,
         bool? pCloseFormUpdateAuto = null,
         int? pStoreBasic = null,
         int? pProductTypeOut = null,
         bool? pAssemblingPost = null,
         string pClientStoreId = null,
         string pBranchAccount = null,
         int? pEmpCostId = null,
         int? pStoreProduction = null,
         bool? pChoiceStoreProdAuto = null,
         bool? pAddQyProductbeforeSpend = null,
         int? pCompanyId = null,
         string pIsVat = null,
         string pVatCode = null,
         float? pVatPerc = null,
         float? pRoundLowerHalf = null,
         bool? pIsDeleted = null,
         int? pCreatedBy = null,
         DateTime? pCreatedOn = null,
         int? pLastUpdatedBy = null,
         DateTime? pLastUpdatedOn = null,
         int? pLanguageId = null,
         string MailHost = null,
            string MailPassword = null,
            string MailPort = null,
            string MailSubject = null,
            string MailBody = null,
            string MailFrom = null,
            string MailTo = null,
            string IBAN = null,
            int? BOX_ID = null,
            int? CostID = null,
            string VatAccount = null,
            string TotalAccount = null,
            string InsuranceAccount = null,
            string ReturnAccount = null,
            string NumberReports = null,
            float? MadaPerc = null,
            float? VisaPerc = null,
            int? pQueryTypeId = null)
           {
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("BranchSettingId", pBranchSettingId));
            vlstParam.Add(new SqlParameter("BranchSettingCode", pBranchSettingCode));
            vlstParam.Add(new SqlParameter("BranchDesc", pBranchDesc));
            vlstParam.Add(new SqlParameter("BranchDescL", pBranchDescL));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("Fraction", pFraction));
            vlstParam.Add(new SqlParameter("MaskAmount", pMaskAmount));
            vlstParam.Add(new SqlParameter("FormatDate", pFormatDate));
            vlstParam.Add(new SqlParameter("EmpAtType", pEmpAtType));
            vlstParam.Add(new SqlParameter("EmpDate", pEmpDate));
            vlstParam.Add(new SqlParameter("PlateCode", pPlateCode));
            vlstParam.Add(new SqlParameter("DesFormat", pDesFormat));
            vlstParam.Add(new SqlParameter("DesName", pDesName));
            vlstParam.Add(new SqlParameter("DesType", pDesType));
            vlstParam.Add(new SqlParameter("ReportServer", pReportServer));
            vlstParam.Add(new SqlParameter("Rrovirtualdir", pRrovirtualdir));
            vlstParam.Add(new SqlParameter("ReportsINTerface", pReportsINTerface));
            vlstParam.Add(new SqlParameter("Hostname", pHostname));
            vlstParam.Add(new SqlParameter("Virtualdir", pVirtualdir));
            vlstParam.Add(new SqlParameter("Physicaldir", pPhysicaldir));
            vlstParam.Add(new SqlParameter("Useorarrp", pUseorarrp));
            vlstParam.Add(new SqlParameter("Usequeuetables", pUsequeuetables));
            vlstParam.Add(new SqlParameter("RepExtINTion", pRepExtINTion));
            vlstParam.Add(new SqlParameter("DefaultLocation", pDefaultLocation));
            vlstParam.Add(new SqlParameter("ImgPath",  pImgPath));
            vlstParam.Add(new SqlParameter("PlateStore", pPlateStore));
            vlstParam.Add(new SqlParameter("PlateUnit", pPlateUnit));
            vlstParam.Add(new SqlParameter("SellStore", pSellStore));
            vlstParam.Add(new SqlParameter("PcDetectionType", pPcDetectionType));
            vlstParam.Add(new SqlParameter("HoldInvTimer", pHoldInvTimer));
            vlstParam.Add(new SqlParameter("InsuranceLimit", pInsuranceLimit));
            vlstParam.Add(new SqlParameter("InvoiceRemark", pInvoiceRemark));
            vlstParam.Add(new SqlParameter("OrderRemark", pOrderRemark));
            vlstParam.Add(new SqlParameter("KitchenPrINTer", pKitchenPrINTer));
            vlstParam.Add(new SqlParameter("FontPath", pFontPath));
            vlstParam.Add(new SqlParameter("BranchPhone", pBranchPhone));
            vlstParam.Add(new SqlParameter("SheepCat", pSheepCat));
            vlstParam.Add(new SqlParameter("AllowSwithoutcprINTers", pAllowSwithoutcprINTers));
            vlstParam.Add(new SqlParameter("LocationImgPath", pLocationImgPath));
            vlstParam.Add(new SqlParameter("FoodPrepareCat", pFoodPrepareCat));
            vlstParam.Add(new SqlParameter("CashCode", pCashCode));
            vlstParam.Add(new SqlParameter("ShowRefItem", pShowRefItem));
            vlstParam.Add(new SqlParameter("ShowRefProduct", pShowRefProduct));
            vlstParam.Add(new SqlParameter("CustAcc", pCustAcc));
            vlstParam.Add(new SqlParameter("RecevAcc", pRecevAcc));
            vlstParam.Add(new SqlParameter("CostCenter", pCostCenter));
            vlstParam.Add(new SqlParameter("BounsAccount", pBounsAccount));
            vlstParam.Add(new SqlParameter("LaterAccounts", pLaterAccounts));
            vlstParam.Add(new SqlParameter("VPosCaneclAcc", pVPosCaneclAcc));
            vlstParam.Add(new SqlParameter("RentAccounts", pRentAccounts));
            vlstParam.Add(new SqlParameter("DriverSeq", pDriverSeq));
            vlstParam.Add(new SqlParameter("KitchenStore", pKitchenStore));
            vlstParam.Add(new SqlParameter("SheepCatProduct", pSheepCatProduct));
            vlstParam.Add(new SqlParameter("SheepOutRes", pSheepOutRes));
            vlstParam.Add(new SqlParameter("SellAcc", pSellAcc));
            vlstParam.Add(new SqlParameter("InsurAcc", pInsurAcc));
            vlstParam.Add(new SqlParameter("RentAcc", pRentAcc));
            vlstParam.Add(new SqlParameter("ShowQty", pShowQty));
            vlstParam.Add(new SqlParameter("SubSeqInv", pSubSeqInv));
            vlstParam.Add(new SqlParameter("BranchMgr", pBranchMgr));
            vlstParam.Add(new SqlParameter("ReservType", pReservType));
            vlstParam.Add(new SqlParameter("DeliveryTrans", pDeliveryTrans));
            vlstParam.Add(new SqlParameter("AllowBlkList", pAllowBlkList));
            vlstParam.Add(new SqlParameter("ItemDelivery", pItemDelivery));
            vlstParam.Add(new SqlParameter("AllowCancelInvoice", pAllowCancelInvoice));
            vlstParam.Add(new SqlParameter("GrpAddPlate", pGrpAddPlate));
            vlstParam.Add(new SqlParameter("QtyPlateRice", pQtyPlateRice));
            vlstParam.Add(new SqlParameter("RiceCat", pRiceCat));
            vlstParam.Add(new SqlParameter("ShowQtyZero", pShowQtyZero));
            vlstParam.Add(new SqlParameter("OrderEmp", pOrderEmp));
            vlstParam.Add(new SqlParameter("OrderPhone", pOrderPhone));
            vlstParam.Add(new SqlParameter("BranchPhoneOrder", pBranchPhoneOrder));
            vlstParam.Add(new SqlParameter("BranchAddress", pBranchAddress));
            vlstParam.Add(new SqlParameter("DefaultProdCost", pDefaultProdCost));
            vlstParam.Add(new SqlParameter("SubSeqOrder", pSubSeqOrder));
            vlstParam.Add(new SqlParameter("DecreaseProdAuto", pDecreaseProdAuto));
            vlstParam.Add(new SqlParameter("CommAccount", pCommAccount));
            vlstParam.Add(new SqlParameter("ShortNum", pShortNum));
            vlstParam.Add(new SqlParameter("NewOrderTime", pNewOrderTime));
            vlstParam.Add(new SqlParameter("DeliveryCashier", pDeliveryCashier));
            vlstParam.Add(new SqlParameter("PayCashierAmount", pPayCashierAmount));
            vlstParam.Add(new SqlParameter("AssemblingPrINTer", pAssemblingPrINTer));
            vlstParam.Add(new SqlParameter("DefaultLocationDelivery", pDefaultLocationDelivery));
            vlstParam.Add(new SqlParameter("ModifyInvoice", pModifyInvoice));
            vlstParam.Add(new SqlParameter("PrINTCancelInvoice", pPrINTCancelInvoice));
            vlstParam.Add(new SqlParameter("DisplayDirverAccount", pDisplayDirverAccount));
            vlstParam.Add(new SqlParameter("DisplayUpdateDirver", pDisplayUpdateDirver));
            vlstParam.Add(new SqlParameter("PrINTUpdateInvoice", pPrINTUpdateInvoice));
            vlstParam.Add(new SqlParameter("LimitInvId", pLimitInvId));
            vlstParam.Add(new SqlParameter("PrINTBasicInvId", pPrINTBasicInvId));
            vlstParam.Add(new SqlParameter("AutoOpenPeriod", pAutoOpenPeriod));
            vlstParam.Add(new SqlParameter("AutoClosePeriod", pAutoClosePeriod));
            vlstParam.Add(new SqlParameter("LengthPeriodDay", pLengthPeriodDay));
            vlstParam.Add(new SqlParameter("CompIdPost", pCompIdPost));
            vlstParam.Add(new SqlParameter("UpdateInvoiceDriver", pUpdateInvoiceDriver));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForCancel", pShowAllInvoiceForCancel));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForUpdate", pShowAllInvoiceForUpdate));
            vlstParam.Add(new SqlParameter("ChangeUpdateDate", pChangeUpdateDate));
            vlstParam.Add(new SqlParameter("ManualProduction", pManualProduction));
            vlstParam.Add(new SqlParameter("ChangeUpdateCashier", pChangeUpdateCashier));
            vlstParam.Add(new SqlParameter("DiscountMax", pDiscountMax));
            vlstParam.Add(new SqlParameter("EnterHelfoodAllowed", pEnterHelfoodAllowed));
            vlstParam.Add(new SqlParameter("EnterPartbuildAllowed", pEnterPartbuildAllowed));
            vlstParam.Add(new SqlParameter("AllowDiscount", pAllowDiscount));
            vlstParam.Add(new SqlParameter("ConvertProductionFullQty", pConvertProductionFullQty));
            vlstParam.Add(new SqlParameter("CloseFormUpdateAuto", pCloseFormUpdateAuto));
            vlstParam.Add(new SqlParameter("StoreBasic", pStoreBasic));
            vlstParam.Add(new SqlParameter("ProductTypeOut", pProductTypeOut));
            vlstParam.Add(new SqlParameter("AssemblingPost", pAssemblingPost));
            vlstParam.Add(new SqlParameter("ClientStoreId", pClientStoreId));
            vlstParam.Add(new SqlParameter("BranchAccount", pBranchAccount));
            vlstParam.Add(new SqlParameter("EmpCostId", pEmpCostId));
            vlstParam.Add(new SqlParameter("StoreProduction", pStoreProduction));
            vlstParam.Add(new SqlParameter("ChoiceStoreProdAuto", pChoiceStoreProdAuto));
            vlstParam.Add(new SqlParameter("AddQyProductbeforeSpend", pAddQyProductbeforeSpend));
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("IsVat", pIsVat));
            vlstParam.Add(new SqlParameter("VatCode", pVatCode));
            vlstParam.Add(new SqlParameter("VatPerc", pVatPerc));
            vlstParam.Add(new SqlParameter("RoundLowerHalf", pRoundLowerHalf));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("MailHost", MailHost));
            vlstParam.Add(new SqlParameter("MailPassword", MailPassword));
            vlstParam.Add(new SqlParameter("MailPort", MailPort));
            vlstParam.Add(new SqlParameter("MailSubject", MailSubject));
            vlstParam.Add(new SqlParameter("MailBody", MailBody));
            vlstParam.Add(new SqlParameter("MailFrom", MailFrom));
            vlstParam.Add(new SqlParameter("MailTo", MailTo));
            vlstParam.Add(new SqlParameter("IBAN", IBAN));
            vlstParam.Add(new SqlParameter("BOX_ID", BOX_ID));
            vlstParam.Add(new SqlParameter("CostID", CostID));
            vlstParam.Add(new SqlParameter("VatAccount", VatAccount));
            vlstParam.Add(new SqlParameter("TotalAccount", TotalAccount));
            vlstParam.Add(new SqlParameter("InsuranceAccount", InsuranceAccount));
            vlstParam.Add(new SqlParameter("ReturnAccount", ReturnAccount));
            vlstParam.Add(new SqlParameter("NumberReports", NumberReports));
            vlstParam.Add(new SqlParameter("MadaPerc", MadaPerc));
            vlstParam.Add(new SqlParameter("VisaPerc", VisaPerc));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funFillDataTable("RES.spBranchSettingCRUD", vlstParam, "Data GET");
            return vData;
        }
    }
}