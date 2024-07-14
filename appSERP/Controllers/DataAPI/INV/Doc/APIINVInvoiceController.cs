﻿using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV.Doc
{
    public class APIINVInvoiceController : ApiController
    {
        private IdbINVInvoice _dbINVInvoice;
        public APIINVInvoiceController(IdbINVInvoice dbINVInvoice)
        {
            _dbINVInvoice = dbINVInvoice;
        }
        [HttpGet]
        public object spReturnData(string psGLVoucherNo, DateTime? psDateFrom = null, DateTime? psDateTo = null)
        {
            object vData = _dbINVInvoice.spReturnData(
                psGLVoucherNo,psDateFrom,psDateTo
                );

            return vData;

        }

        [HttpGet]
        public string INVInvoiceGET(
        int? phInvId = null,
        int? phInvtype = null,
        int? UserId = null,
        int? phYEAR = null,
        int? phInvRef = null,
        DateTime? phInvDate = null,
        int? phSellerId = null,
        bool? phPayCash = null,
        bool? phPayCheck = null,
        bool? phPayLater = null,
        float? phInvBaseAmt = null,
        int? phDiscPerc = null,
        bool? phIsPosted = null,
        int? phStoreId = null,
        float? phDiscAmt = null,
        int? phInvSubCost = null,
        string phNotes = null,
        int? phPermitId = null,
        int? phPermitType = null,
        int? phOrderType = null,
        int? phOrderId = null,
        int? phCustomerId = null,
        int? phSaleTax = null,
        int? phSaleTax2 = null,
        int? phPerson = null,
        string phInvSeq = null,
        DateTime? phInvRefDate = null,
        float? phInvCurValue = null,
        int? phInvCur = null,
        float? phInvDisc = null,
        int? pCreatedBy = null,
        DateTime? CreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? LastUpdatedOn = null,
        float? phPermitYear = null,
        int? phBankId = null,
        int? phBranchId = null,
        int? phCardNo = null,
        int? phAccountId = null,
        DateTime? phExpireDate = null,
        int? phCardType = null,
        int? phAMT = null,
        float? phCurValue = null,
        float? phBaseAmt = null,
        string phBankSource = null,
        int? phPayVisa = null,
        int? phAreaId = null,
        int? phQutId = null,
        int? phQutType = null,
        int? phTypeId = null,
        bool? phPAYED = null,
        int? phGetComm = null,
        string phDELIVERIES = null,
        float? phReturnOnDelivery = null,
        int? phGoodInvId = null,
        int? phSetSaleRet = null,
        int? phRetOnDelyear = null,
        int? phPatId = null,
        int? phVisitNo = null,
        int? phReqNo = null,
        int? phSurgId = null,
        int? phDebitType = null,
        int? phInsurTrans = null,
        int? phContNo = null,
        int? phInsurancePerc = null,
        int? phCmpAccId = null,
        int? phSalesId = null,
        int? phFromBranches = null,
        bool? phInvIsWait = null,
        bool? phInvIsCancel = null,
        int? phPeriodId = null,
        int? phBranchCompId = null,
        int? phBranchTransId = null,
        int? phCompanyId = null,
        bool? phInvoiceIsActive = null,
        bool? phIsDeleted = null,
        int? pdInvDTLId = null,
        int? pdInvId = null,
        int? pdInvType = null,
        int? pdYEAR = null,
        int? pdStoreId = null,
        int? pdItemId = null,
        int? pdUnitId = null,
        DateTime? pdExpireDate = null,
        int? pdBackType = null,
        int? pdBackId = null,
        int? pdBackYear = null,
        int? pdItemPrice = null,
        float? pdItemQty = null,
        DateTime? pdGuaranteeDate = null,
        float? pdTotalItemCredit = null,
        float? pdTotalItemDebit = null,
        float? pdTotalBaseItemCredit = null,
        float? pdTotalBaseItemDebit = null,
        int? pdDiscType = null,
        int? pdDiscValue = null,
        float? pdDiscAmtCredit = null,
        float? pdDiscAmtDebit = null,
        float? pdDiscBaseCredit = null,
        float? pdDiscBaseDebit = null,
        bool? pdIsPosted = null,
        string pdNotes = null,
        string pdAccountId = null,
        float? pdItemCostDebit = null,
        float? pdItemCostCredit = null,
        int? pdSellAccId = null,
        int? pdCostAccId = null,
        int? pdDiscAccId = null,
        int? pdTaxAccId = null,
        float? pdTaxDebit = null,
        float? pdTaxBaseDebit = null,
        float? pdItemCost = null,
        float? pdTaxBaseCredit = null,
        float? pdTaxCredit = null,
        int? pdBackSellAccId = null,
        int? pdBackBuyAccId = null,
        float? pdItemStoreCurValue = null,
        float? pdItemCurVALUE = null,
        float? pdItemCur = null,
        float? pdTotalItemSbaseCredit = null,
        float? pdTotalItemSbaseDebit = null,
        int? pdItemDefCur = null,
        int? pdTransSeq = null,
        int? pdEmpAccId = null,
        float? pdEmpAmt = null,
        float? pdEmpBaseAmt = null,
        int? pdEmpRatio = null,
        float? pdEmpCurValue = null,
        float? pdItemCostBase = null,
        int? pdDelivId = null,
        int? pdDelYear = null,
        int? pdDelTransSeq = null,
        int? pdInStoreId = null,
        string pdNonDescribe = null,
        DateTime? pdDate = null,
        string pdItemName = null,
        float? pdVatAMT = null,
        int? pdVatDebitAccId = null,
        int? pdVatCreditAccId = null,
        int? pdCompanyId = null,
        bool? pdInvIsActive = null,
        bool? pdIsDeleted = null,
        int? pInvLaterId = null,
        int? pInvType = null,
        int? pLInvId = null,
        int? pYEAR = null,
        int? pAccountId = null,
        int? pLaterAmtCredit = null,
        int? pLaterAmtDebit = null,
        int? pLaterCurValue = null,
        int? pLaterBaseAmtCredit = null,
        int? pLaterBaseAmtDebit = null,
        bool? pIsPosted = null,
        string pNotes = null,
        int? pStoreId = null,
        int? pCostCenterId = null,
        int? pTransSeq = null,
        // POS
        int? pSubSeq = null,
        int? pPayTypeId = null,
        int? pCashDeskId = null,
        int? pInvStatus = null,
        int? pOrderSeq = null,
        float? pInsurance = null,
        int? pInsurPerc = null,
        float? pService = null,
        int? pServicePerc = null,
        float? pTax = null,
        int? pTaxPerc = null,
        int? pDiscount = null,
        int? pDiscountPerc = null,
        int? pPointId = null,
        int? pDelivery = null,
        int? pDeliveryPerc = null,
        string pInvMachine = null,
        string pPcIdentification = null,
        int? pOrderLocSeq = null,
        int? pOrederDaySeq = null,
        int? pInvPayType = null,
        bool? pDeliveryInvoice = null,
        DateTime? pDeliveryDate = null,
        int? pDelLocSeq = null,
        string pInvPhoneNo = null,
        bool? pIsPrepare = null,
        bool? pIsTransPost = null,
        int? pPriceCat = null,
        int? pSiteId = null,
        string pLocAddressInvoice = null,
        int? pAnotherInvId = null,
        int? pCasherDiscount = null,
        int? pDiscountSell = null,
        string pCustomerName = null,
        decimal? pAddAMT = null,
        bool? pDelSheepRemain = null,
        decimal? pDiscAmt = null,
        int? pItemUnitId = null,
        decimal? pPrice = null,
        int? pQty = null,
        float? pQtyPlate = null,
        float? QtyTransfer = null,
        float? QtyLastRemain = null,
        int? pSheepRemainder = null,
        int? pTag = null,
        int? pVatPrice = null,
        float? pVatTotal = null,
        int? pItemType = null,
        // Search Parameters
        string phNumbers = null,
        string psGLVoucherNo = null,
        DateTime? psDateFrom = null,
        DateTime? psDateTo = null,
        float? pUsedPoints = null,
        int? pMealPoints = null,

        bool? pIsDeleted = null,
        int? ppType = null,
        int? pQueryTypeId = clsQueryType.qSelect,
        string pSearchDateFrom = null,
        string pSearchDateTo = null,
        string pInvItemNameL1 = null,
         string pLstUnit = null,
         string pLstInvItemId = null,
         int? branchId=null
        )
        {

            string vData = _dbINVInvoice.funINVInvoiceGET(
            UserId: UserId,
            phInvId: phInvId,
            phInvtype: phInvtype,
            phYEAR: phYEAR,
            phInvRef: phInvRef,
            phInvDate: phInvDate,

            phSellerId: phSellerId,
            phPayCash: phPayCash,
            phPayCheck: phPayCheck,
            phPayLater: phPayLater,
            phInvBaseAmt: phInvBaseAmt,
            phDiscPerc: phDiscPerc,
            phIsPosted: phIsPosted,
            phStoreId: phStoreId,
            phDiscAmt: phDiscAmt,
            phInvSubCost: phInvSubCost,
            phNotes: phNotes,
            phPermitId: phPermitId,
            phPermitType: phPermitType,
            phOrderType: phOrderType,
            phOrderId: phOrderId,
            phCustomerId: phCustomerId,
            phSaleTax: phSaleTax,
            phSaleTax2: phSaleTax2,
            phPerson: phPerson,
            phInvSeq: phInvSeq,
            phInvRefDate: phInvRefDate,
            phInvCurValue: phInvCurValue,
            phInvCur: phInvCur,
            phInvDisc: phInvDisc,
            phPermitYear: phPermitYear,
            phBankId: phBankId,
            phBranchId: phBranchId,
            phCardNo: phCardNo,
            phAccountId: phAccountId,
            phExpireDate: phExpireDate,
            phCardType: phCardType,
            phAMT: phAMT,
            phCurValue: phCurValue,
            phBaseAmt: phBaseAmt,
            phBankSource: phBankSource,
            phPayVisa: phPayVisa,
            phAreaId: phAreaId,
            phQutId: phQutId,
            phQutType: phQutType,
            phTypeId: phTypeId,
            phPAYED: phPAYED,
            phGetComm: phGetComm,
            phDELIVERIES: phDELIVERIES,
            phReturnOnDelivery: phReturnOnDelivery,
            phGoodInvId: phGoodInvId,
            phSetSaleRet: phSetSaleRet,
            phRetOnDelyear: phRetOnDelyear,
            phPatId: phPatId,
            phVisitNo: phVisitNo,
            phReqNo: phReqNo,
            phSurgId: phSurgId,
            phDebitType: phDebitType,
            phInsurTrans: phInsurTrans,
            phContNo: phContNo,
            phInsurancePerc: phInsurancePerc,
            phCmpAccId: phCmpAccId,
            phSalesId: phSalesId,
            phFromBranches: phFromBranches,
            phInvIsWait: phInvIsWait,
            phInvIsCancel: phInvIsCancel,
            phPeriodId: phPeriodId,
            phBranchCompId: phBranchCompId,
            phBranchTransId: phBranchTransId,
            phCompanyId: phCompanyId,
            pUsedPoints: pUsedPoints,
            pMealPoints: pMealPoints,
            phInvoiceIsActive: phInvoiceIsActive,
            phIsDeleted: phIsDeleted,
            pdInvDTLId: pdInvDTLId,

            pdInvId: pdInvId,
            pdInvType: pdInvType,
            pdYEAR: pdYEAR,
            pdStoreId: pdStoreId,
            pdItemId: pdItemId,
            pdUnitId: pdUnitId,
            pdExpireDate: pdExpireDate,
            pdBackType: pdBackType,
            pdBackId: pdBackId,
            pdBackYear: pdBackYear,
            pdItemPrice: pdItemPrice,
            pdItemQty: pdItemQty,
            pdGuaranteeDate: pdGuaranteeDate,
            pdTotalItemCredit: pdTotalItemCredit,
            pdTotalItemDebit: pdTotalItemDebit,
            pdTotalBaseItemCredit: pdTotalBaseItemCredit,
            pdTotalBaseItemDebit: pdTotalBaseItemDebit,
            pdDiscType: pdDiscType,
            pdDiscValue: pdDiscValue,
            pdDiscAmtCredit: pdDiscAmtCredit,
            pdDiscAmtDebit: pdDiscAmtDebit,
            pdDiscBaseCredit: pdDiscBaseCredit,
            pdDiscBaseDebit: pdDiscBaseDebit,
            pdIsPosted: pdIsPosted,
            pdNotes: pdNotes,
            pdAccountId: pdAccountId,
            pdItemCostDebit: pdItemCostDebit,
            pdItemCostCredit: pdItemCostCredit,
            pdSellAccId: pdSellAccId,
            pdCostAccId: pdCostAccId,
            pdDiscAccId: pdDiscAccId,
            pdTaxAccId: pdTaxAccId,
            pdTaxDebit: pdTaxDebit,
            pdTaxBaseDebit: pdTaxBaseDebit,
            pdItemCost: pdItemCost,
            pdTaxBaseCredit: pdTaxBaseCredit,
            pdTaxCredit: pdTaxCredit,
            pdBackSellAccId: pdBackSellAccId,
            pdBackBuyAccId: pdBackBuyAccId,
            pdItemStoreCurValue: pdItemStoreCurValue,
            pdItemCurVALUE: pdItemCurVALUE,
            pdItemCur: pdItemCur,
            pdTotalItemSbaseCredit: pdTotalItemSbaseCredit,
            pdTotalItemSbaseDebit: pdTotalItemSbaseDebit,
            pdItemDefCur: pdItemDefCur,
            pdTransSeq: pdTransSeq,
            pdEmpAccId: pdEmpAccId,
            pdEmpAmt: pdEmpAmt,
            pdEmpBaseAmt: pdEmpBaseAmt,
            pdEmpRatio: pdEmpRatio,
            pdEmpCurValue: pdEmpCurValue,
            pdItemCostBase: pdItemCostBase,
            pdDelivId: pdDelivId,
            pdDelYear: pdDelYear,
            pdDelTransSeq: pdDelTransSeq,
            pdInStoreId: pdInStoreId,
            pdNonDescribe: pdNonDescribe,
            pdDate: pdDate,
            pdItemName: pdItemName,
            pdVatAMT: pdVatAMT,
            pdVatDebitAccId: pdVatDebitAccId,
            pdVatCreditAccId: pdVatCreditAccId,
            pdInvIsActive: pdInvIsActive,
            pdIsDeleted: pdIsDeleted,
            pInvLaterId: pInvLaterId,
            pInvType: pInvType,
            pLInvId: pLInvId,
            pYEAR: pYEAR,
            pAccountId: pAccountId,
            pLaterAmtCredit: pLaterAmtCredit,
            pLaterAmtDebit: pLaterAmtDebit,
            pLaterCurValue: pLaterCurValue,
            pLaterBaseAmtCredit: pLaterBaseAmtCredit,
            pLaterBaseAmtDebit: pLaterBaseAmtDebit,
            pIsPosted: pIsPosted,
            pNotes: pNotes,
            pStoreId: pStoreId,
            pCostCenterId: pCostCenterId,
            pTransSeq: pTransSeq,
           //POS
           pPayTypeId: pPayTypeId,
           pCashDeskId: pCashDeskId,
           pInvStatus: pInvStatus,
           pOrderSeq: pOrderSeq,
           pInsurance: pInsurance,
           pInsurPerc: pInsurPerc,
           pService: pService,
           pServicePerc: pServicePerc,
           pTax: pTax,
           pTaxPerc: pTaxPerc,
           pDiscount: pDiscount,
           pDiscountPerc: pDiscountPerc,
           pPointId: pPointId,
           pDelivery: pDelivery,
           pDeliveryPerc: pDeliveryPerc,
           pInvMachine: pInvMachine,
           pPcIdentification: pPcIdentification,
           pOrderLocSeq: pOrderLocSeq,
           pOrederDaySeq: pOrederDaySeq,
           pInvPayType: pInvPayType,
           pDeliveryInvoice: pDeliveryInvoice,
           pDeliveryDate: pDeliveryDate,
           pDelLocSeq: pDelLocSeq,
           pInvPhoneNo: pInvPhoneNo,
           pIsPrepare: pIsPrepare,
           pIsTransPost: pIsTransPost,
           pPriceCat: pPriceCat,
           pSiteId: pSiteId,
           pLocAddressInvoice: pLocAddressInvoice,
           pAnotherInvId: pAnotherInvId,
           pCasherDiscount: pCasherDiscount,
           pDiscountSell: pDiscountSell,
           pCustomerName: pCustomerName,
          pAddAMT: pAddAMT,
          pDelSheepRemain: pDelSheepRemain,
          pDiscAmt: pDiscAmt,
          pItemUnitId: pItemUnitId,
          pPrice: pPrice,
          pQty: pQty,
          pQtyPlate: pQtyPlate,
          QtyTransfer: QtyTransfer,
          QtyLastRemain: QtyLastRemain,
          pSheepRemainder: pSheepRemainder,
          pTag: pTag,
          pVatPrice: pVatPrice,
          pVatTotal: pVatTotal,
          pItemType: pItemType,


           // Search Parameters
           phNumbers: phNumbers,
           psGLVoucherNo: psGLVoucherNo,
           psDateFrom: psDateFrom,
           psDateTo: psDateTo,
           pIsDeleted: pIsDeleted,
           ppType: ppType,
           pQueryTypeId: pQueryTypeId,
           pSearchDateFrom: pSearchDateFrom,
           pSearchDateTo: pSearchDateTo,
           pInvItemNameL1: pInvItemNameL1,
           pLstUnit: pLstUnit,
           pLstInvItemId: pLstInvItemId,
          pCreatedBy: pCreatedBy,
          pCreatedOn: CreatedOn,
          pLastUpdatedBy: pLastUpdatedBy,
          pLastUpdatedOn: LastUpdatedOn,
          branchId: branchId
           );

            // Return Result
            return vData;
        }

        // BH
        [HttpGet]
        public object funInvoiceOrderOrPOS(DateTime pDateFrom , DateTime pDateTo, int pBranchId, string pInvCode = null, bool? pIsPassed=null)
        {
            object vData = _dbINVInvoice.funInvoiceOrderOrPOS(
                pDateFrom: pDateFrom, pDateTo: pDateTo, pBranchId: pBranchId, pInvCode: pInvCode, pQueryTypeId: 400
                , pIsPassed: pIsPassed
                );

            return vData;
        }

    }
}
