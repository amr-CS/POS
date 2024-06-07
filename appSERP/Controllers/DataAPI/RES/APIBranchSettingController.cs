﻿using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIBranchSettingController : ApiController
    {
        private IdbBranchSetting _dbBranchSetting;
        public APIBranchSettingController(IdbBranchSetting dbBranchSetting) {
            _dbBranchSetting = dbBranchSetting;
        }

        [HttpGet]
        public string  BranchSettingGET(
        int? pBranchSettingId = null,
       bool? IsPOSPrinterNetwork=null,
        string pBranchSettingCode = null,
        string pBranchDesc = null,
        string pBranchDescL = null,
         int?   pBranchId = null,
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
        bool? pIsDeleted = false,
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
            string pAccountId = null,
            string pLinkProApi = null,
            float? MadaPerc = null,
            float? VisaPerc = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            var vData = _dbBranchSetting.funBranchSettingGET(
                    pBranchSettingId: pBranchSettingId,
                    IsPOSPrinterNetwork: IsPOSPrinterNetwork,
                    pBranchSettingCode: pBranchSettingCode,
                    pBranchDesc: pBranchDesc,
                    pBranchDescL: pBranchDescL,
                    pBranchId: pBranchId,
                    pFraction: pFraction,
                    pMaskAmount: pMaskAmount,
                    pFormatDate: pFormatDate,
                    pEmpAtType: pEmpAtType,
                    pEmpDate: pEmpDate,
                    pPlateCode: pPlateCode,
                    pDesFormat: pDesFormat,
                    pDesName: pDesName,
                    pDesType: pDesType,
                    pReportServer: pReportServer,
                    pRrovirtualdir: pRrovirtualdir,
                    pReportsINTerface: pReportsINTerface,
                    pHostname: pHostname,
                    pVirtualdir: pVirtualdir,
                    pPhysicaldir: pPhysicaldir,
                    pUseorarrp: pUseorarrp,
                    pUsequeuetables: pUsequeuetables,
                    pRepExtINTion: pRepExtINTion,
                    pDefaultLocation: pDefaultLocation,
                    pImgPath: pImgPath,
                    pPlateStore: pPlateStore,
                    pPlateUnit: pPlateUnit,
                    pSellStore: pSellStore,
                    pPcDetectionType: pPcDetectionType,
                    pHoldInvTimer: pHoldInvTimer,
                    pInsuranceLimit: pInsuranceLimit,
                    pInvoiceRemark: pInvoiceRemark,
                    pOrderRemark: pOrderRemark,
                    pKitchenPrINTer: pKitchenPrINTer,
                    pFontPath: pFontPath,
                    pBranchPhone: pBranchPhone,
                    pSheepCat: pSheepCat,
                    pAllowSwithoutcprINTers: pAllowSwithoutcprINTers,
                    pLocationImgPath: pLocationImgPath,
                    pFoodPrepareCat: pFoodPrepareCat,
                    pCashCode: pCashCode,
                    pShowRefItem: pShowRefItem,
                    pShowRefProduct: pShowRefProduct,
                    pCustAcc: pCustAcc,
                    pRecevAcc: pRecevAcc,
                    pCostCenter: pCostCenter,
                    pBounsAccount: pBounsAccount,
                    pLaterAccounts: pLaterAccounts,
                    pVPosCaneclAcc: pVPosCaneclAcc,
                    pRentAccounts: pRentAccounts,
                    pDriverSeq: pDriverSeq,
                    pKitchenStore: pKitchenStore,
                    pSheepCatProduct: pSheepCatProduct,
                    pSheepOutRes: pSheepOutRes,
                    pSellAcc: pSellAcc,
                    pInsurAcc: pInsurAcc,
                    pRentAcc: pRentAcc,
                    pShowQty: pShowQty,
                    pSubSeqInv: pSubSeqInv,
                    pBranchMgr: pBranchMgr,
                    pReservType: pReservType,
                    pDeliveryTrans: pDeliveryTrans,
                    pAllowBlkList: pAllowBlkList,
                    pItemDelivery: pItemDelivery,
                    pAllowCancelInvoice: pAllowCancelInvoice,
                    pGrpAddPlate: pGrpAddPlate,
                    pQtyPlateRice: pQtyPlateRice,
                    pRiceCat: pRiceCat,
                    pShowQtyZero: pShowQtyZero,
                    pOrderEmp: pOrderEmp,
                    pOrderPhone: pOrderPhone,
                    pBranchPhoneOrder: pBranchPhoneOrder,
                    pBranchAddress: pBranchAddress,
                    pDefaultProdCost: pDefaultProdCost,
                    pSubSeqOrder: pSubSeqOrder,
                    pDecreaseProdAuto: pDecreaseProdAuto,
                    pCommAccount: pCommAccount,
                    pShortNum: pShortNum,
                    pNewOrderTime: pNewOrderTime,
                    pDeliveryCashier: pDeliveryCashier,
                    pPayCashierAmount: pPayCashierAmount,
                    pAssemblingPrINTer: pAssemblingPrINTer,
                    pDefaultLocationDelivery: pDefaultLocationDelivery,
                    pModifyInvoice: pModifyInvoice,
                    pPrINTCancelInvoice: pPrINTCancelInvoice,
                    pDisplayDirverAccount: pDisplayDirverAccount,
                    pDisplayUpdateDirver: pDisplayUpdateDirver,
                    pPrINTUpdateInvoice: pPrINTUpdateInvoice,
                    pLimitInvId: pLimitInvId,
                    pPrINTBasicInvId: pPrINTBasicInvId,
                    pAutoOpenPeriod: pAutoOpenPeriod,
                    pAutoClosePeriod: pAutoClosePeriod,
                    pLengthPeriodDay: pLengthPeriodDay,
                    pCompIdPost: pCompIdPost,
                    pUpdateInvoiceDriver: pUpdateInvoiceDriver,
                    pShowAllInvoiceForCancel: pShowAllInvoiceForCancel,
                    pShowAllInvoiceForUpdate: pShowAllInvoiceForUpdate,
                    pChangeUpdateDate: pChangeUpdateDate,
                    pManualProduction: pManualProduction,
                    pChangeUpdateCashier: pChangeUpdateCashier,
                    pDiscountMax: pDiscountMax,
                    pAccountId: pAccountId,
                    pLinkProApi: pLinkProApi,
                    pEnterHelfoodAllowed: pEnterHelfoodAllowed,
                    pEnterPartbuildAllowed: pEnterPartbuildAllowed,
                    pAllowDiscount: pAllowDiscount,
                    pConvertProductionFullQty: pConvertProductionFullQty,
                    pCloseFormUpdateAuto: pCloseFormUpdateAuto,
                    pStoreBasic: pStoreBasic,
                    pProductTypeOut: pProductTypeOut,
                    pAssemblingPost: pAssemblingPost,
                    pClientStoreId: pClientStoreId,
                    pBranchAccount: pBranchAccount,
                    pEmpCostId: pEmpCostId,
                    pStoreProduction: pStoreProduction,
                    pChoiceStoreProdAuto: pChoiceStoreProdAuto,
                    pAddQyProductbeforeSpend: pAddQyProductbeforeSpend,
                    pCompanyId: pCompanyId,
                    pIsVat: pIsVat,
                    pVatCode: pVatCode,
                    pVatPerc: pVatPerc,
                    pRoundLowerHalf: pRoundLowerHalf,
                    pIsDeleted :pIsDeleted ,
                    pQueryTypeId  :pQueryTypeId ,
                    MailHost : MailHost,
             MailPassword : MailPassword,
             MailPort : MailPort,
             MailSubject : MailSubject,
             MailBody : MailBody,
             MailFrom : MailFrom,
             MailTo : MailTo,
             IBAN : IBAN,
               BOX_ID: BOX_ID,
                CostID: CostID,
                VatAccount: VatAccount,
                TotalAccount: TotalAccount,
                InsuranceAccount: InsuranceAccount,
                ReturnAccount: ReturnAccount,
                NumberReports: NumberReports,
                 MadaPerc : MadaPerc,
           VisaPerc : VisaPerc

                );

            //  Get Result
            return vData;
        }
    }
}
