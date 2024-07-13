using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.Utils;
using appSERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV.Doc
{
    public class dbINVInvoice : IdbINVInvoice
    {
        public int FirstCount { get; set; } = 0;
        public int SecondCount { get; set; } = 0;
        public DataTable InvoicePosData { get; set; }
        public DataTable TableData { get; set; }

        private IclsADO _clsADO;
        public dbINVInvoice(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        #region Added by BH
        /// <summary>
        /// دالة فحص وجود الصنف او وحدته في فواتير الحركات المخزنية
        /// من آجل لا يسمح بحذف الصنف او وحدته إذا وجد له حركات مخزنية
        /// - ثم قد يستخدم الاستعلام من آجل التحقق من تعديل وحدة الصنف اذا وجد لها حركات لا يسمح بتعديلها
        /// خاصة العبوة وغيرها من البيانات الحساسة لوحدة الصنف
        /// </summary>
        /// <param name="pItemId">رقم الصنف</param>
        /// <param name="pUnitId">رقم وحدة الصنف</param>
        /// <returns></returns>
        public DataTable GetItemHasInvoice(int? pItemId, int? pUnitId = null)
        {
            // الصنف له فاتورة او الصنف موجود في فاتورة
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "";
            if (pItemId != null && pItemId > 0)
            {
                vlstParam.Add(new SqlParameter("@itemId", pItemId));
                strWhere = " ItemId=@itemId ";
            }
            if (pUnitId != null && pUnitId > 0)
            {
                vlstParam.Add(new SqlParameter("@UnitId", pUnitId));
                if (pItemId != null && pItemId > 0)
                    strWhere += " and ";
                strWhere += " UnitId = @UnitId";
            }
            string queryText = $"select top 1 ItemId, UnitId from INV.tblInvoiceDTL where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }

        #endregion
        public string funINVInvoiceGET(
        int? UserId = null,
        int? phPatId = null,

        int? phInvId = null,
        int? phInvtype = null,
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
        int? phTableId = null,
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
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
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
        float? pLaterAmtCredit = null,
        float? pLaterAmtDebit = null,
        float? pLaterCurValue = null,
        float? pLaterBaseAmtCredit = null,
        float? pLaterBaseAmtDebit = null,
        bool? pIsPosted = null,
        string pNotes = null,
        int? pStoreId = null,
        int? pCostCenterId = null,
        int? pTransSeq = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        float? pUsedPoints = null,
        int? pMealPoints = null,
        int? pBranchId = null,
        //POS
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
        float? pDiscount = null,
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
        int? ppType = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null,
        string pSearchDateFrom = null,
        string pSearchDateTo = null,
        string pInvItemNameL1 = null,
        string pLstUnit = null,
        string pLstInvItemId = null,
        int? branchId = null
        )
        {
            //  if (phInvDate == null) { phInvDate = clsTimeSetting.funBranchTime(); }
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("hInvId", phInvId));
            //vlstParam.Add(new SqlParameter("hPatId", phPatId));
            vlstParam.Add(new SqlParameter("hInvtype", phInvtype));
            vlstParam.Add(new SqlParameter("hYEAR", phYEAR));
            vlstParam.Add(new SqlParameter("hInvRef", phInvRef));
            vlstParam.Add(new SqlParameter("hInvDate", DateTime.Now));
            vlstParam.Add(new SqlParameter("hSellerId", phSellerId));
            vlstParam.Add(new SqlParameter("hPayCash", phPayCash));
            vlstParam.Add(new SqlParameter("hPayCheck", phPayCheck));
            vlstParam.Add(new SqlParameter("hPayLater", phPayLater));
            vlstParam.Add(new SqlParameter("hInvBaseAmt", phInvBaseAmt));
            vlstParam.Add(new SqlParameter("hDiscPerc", phDiscPerc));
            vlstParam.Add(new SqlParameter("hIsPosted", phIsPosted));
            vlstParam.Add(new SqlParameter("hStoreId", phStoreId));
            vlstParam.Add(new SqlParameter("hDiscAmt", phDiscAmt));
            vlstParam.Add(new SqlParameter("hInvSubCost", phInvSubCost));
            vlstParam.Add(new SqlParameter("hNotes", phNotes));
            vlstParam.Add(new SqlParameter("hPermitId", phPermitId));
            vlstParam.Add(new SqlParameter("hPermitType", phPermitType));
            vlstParam.Add(new SqlParameter("hOrderType", phOrderType));
            vlstParam.Add(new SqlParameter("hOrderId", phOrderId));
            vlstParam.Add(new SqlParameter("hCustomerId", phCustomerId));
            vlstParam.Add(new SqlParameter("hSaleTax", phSaleTax));
            vlstParam.Add(new SqlParameter("hSaleTax2", phSaleTax2));
            vlstParam.Add(new SqlParameter("hPerson", phPerson));
            vlstParam.Add(new SqlParameter("hInvSeq", phInvSeq));
            vlstParam.Add(new SqlParameter("hInvRefDate", phInvRefDate));
            vlstParam.Add(new SqlParameter("hInvCurValue", phInvCurValue));
            vlstParam.Add(new SqlParameter("hInvCur", phInvCur));
            vlstParam.Add(new SqlParameter("hInvDisc", phInvDisc));
            vlstParam.Add(new SqlParameter("hPermitYear", phPermitYear));
            vlstParam.Add(new SqlParameter("hBankId", phBankId));
            vlstParam.Add(new SqlParameter("hBranchId", clsBranch.vBranchId));
            vlstParam.Add(new SqlParameter("hCardNo", phCardNo));
            vlstParam.Add(new SqlParameter("hAccountId", phAccountId));
            vlstParam.Add(new SqlParameter("hExpireDate", phExpireDate));
            vlstParam.Add(new SqlParameter("hCardType", phCardType));
            vlstParam.Add(new SqlParameter("hAMT", phAMT));
            vlstParam.Add(new SqlParameter("hCurValue", phCurValue));
            vlstParam.Add(new SqlParameter("hBaseAmt", phBaseAmt));
            vlstParam.Add(new SqlParameter("hBankSource", phBankSource));
            vlstParam.Add(new SqlParameter("hPayVisa", phPayVisa));
            vlstParam.Add(new SqlParameter("hAreaId", phAreaId));
            vlstParam.Add(new SqlParameter("hQutId", phQutId));
            vlstParam.Add(new SqlParameter("hQutType", phQutType));
            vlstParam.Add(new SqlParameter("hTypeId", phTypeId));
            vlstParam.Add(new SqlParameter("hPAYED", phPAYED));
            vlstParam.Add(new SqlParameter("hGetComm", phGetComm));
            vlstParam.Add(new SqlParameter("hDELIVERIES", phDELIVERIES));
            vlstParam.Add(new SqlParameter("hReturnOnDelivery", phReturnOnDelivery));
            vlstParam.Add(new SqlParameter("hGoodInvId", phGoodInvId));
            vlstParam.Add(new SqlParameter("hSetSaleRet", phSetSaleRet));
            vlstParam.Add(new SqlParameter("hRetOnDelyear", phRetOnDelyear));
            vlstParam.Add(new SqlParameter("hTableId", phTableId));
            vlstParam.Add(new SqlParameter("hVisitNo", phVisitNo));
            vlstParam.Add(new SqlParameter("hReqNo", phReqNo));
            vlstParam.Add(new SqlParameter("hSurgId", phSurgId));
            vlstParam.Add(new SqlParameter("hDebitType", phDebitType));
            vlstParam.Add(new SqlParameter("hInsurTrans", phInsurTrans));
            vlstParam.Add(new SqlParameter("hContNo", phContNo));
            vlstParam.Add(new SqlParameter("hInsurancePerc", phInsurancePerc));
            vlstParam.Add(new SqlParameter("hCmpAccId", phCmpAccId));
            vlstParam.Add(new SqlParameter("hSalesId", phSalesId));
            vlstParam.Add(new SqlParameter("hFromBranches", phFromBranches));
            vlstParam.Add(new SqlParameter("hInvIsWait", phInvIsWait));
            vlstParam.Add(new SqlParameter("hInvIsCancel", phInvIsCancel));
            vlstParam.Add(new SqlParameter("hPeriodId", phPeriodId));
            vlstParam.Add(new SqlParameter("hBranchCompId", clsBranch.vBranchId));
            vlstParam.Add(new SqlParameter("hBranchTransId", clsBranch.vBranchId));
            vlstParam.Add(new SqlParameter("hCompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UsedPoints", pUsedPoints));
            vlstParam.Add(new SqlParameter("MealPoints", pMealPoints));
            vlstParam.Add(new SqlParameter("hInvoiceIsActive", phInvoiceIsActive));
            vlstParam.Add(new SqlParameter("hIsDeleted", phIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", pCreatedBy));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", pLastUpdatedBy));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("dInvDTLId", pdInvDTLId));
            vlstParam.Add(new SqlParameter("dInvId", pdInvId));
            vlstParam.Add(new SqlParameter("dInvType", pdInvType));
            vlstParam.Add(new SqlParameter("dYEAR", pdYEAR));
            vlstParam.Add(new SqlParameter("dStoreId", pdStoreId));
            vlstParam.Add(new SqlParameter("dItemId", pdItemId));
            vlstParam.Add(new SqlParameter("dUnitId", pdUnitId));
            vlstParam.Add(new SqlParameter("dExpireDate", pdExpireDate));
            vlstParam.Add(new SqlParameter("dBackType", pdBackType));
            vlstParam.Add(new SqlParameter("dBackId", pdBackId));
            vlstParam.Add(new SqlParameter("dBackYear", pdBackYear));
            vlstParam.Add(new SqlParameter("dItemPrice", pdItemPrice));
            vlstParam.Add(new SqlParameter("dItemQty", pdItemQty));
            vlstParam.Add(new SqlParameter("dGuaranteeDate", pdGuaranteeDate));
            vlstParam.Add(new SqlParameter("dTotalItemCredit", pdTotalItemCredit));
            vlstParam.Add(new SqlParameter("dTotalItemDebit", pdTotalItemDebit));
            vlstParam.Add(new SqlParameter("dTotalBaseItemCredit", pdTotalBaseItemCredit));
            vlstParam.Add(new SqlParameter("dTotalBaseItemDebit", pdTotalBaseItemDebit));
            vlstParam.Add(new SqlParameter("dDiscType", pdDiscType));
            vlstParam.Add(new SqlParameter("dDiscValue", pdDiscValue));
            vlstParam.Add(new SqlParameter("dDiscAmtCredit", pdDiscAmtCredit));
            vlstParam.Add(new SqlParameter("dDiscAmtDebit", pdDiscAmtDebit));
            vlstParam.Add(new SqlParameter("dDiscBaseCredit", pdDiscBaseCredit));
            vlstParam.Add(new SqlParameter("dDiscBaseDebit", pdDiscBaseDebit));
            vlstParam.Add(new SqlParameter("dIsPosted", pdIsPosted));
            vlstParam.Add(new SqlParameter("dNotes", pdNotes));
            vlstParam.Add(new SqlParameter("dAccountId", pdAccountId));
            vlstParam.Add(new SqlParameter("dItemCostDebit", pdItemCostDebit));
            vlstParam.Add(new SqlParameter("dItemCostCredit", pdItemCostCredit));
            vlstParam.Add(new SqlParameter("dSellAccId", pdSellAccId));
            vlstParam.Add(new SqlParameter("dCostAccId", pdCostAccId));
            vlstParam.Add(new SqlParameter("dDiscAccId", pdDiscAccId));
            vlstParam.Add(new SqlParameter("dTaxAccId", pdTaxAccId));
            vlstParam.Add(new SqlParameter("dTaxDebit", pdTaxDebit));
            vlstParam.Add(new SqlParameter("dTaxBaseDebit", pdTaxBaseDebit));
            vlstParam.Add(new SqlParameter("dItemCost", pdItemCost));
            vlstParam.Add(new SqlParameter("dTaxBaseCredit", pdTaxBaseCredit));
            vlstParam.Add(new SqlParameter("dTaxCredit", pdTaxCredit));
            vlstParam.Add(new SqlParameter("dBackSellAccId", pdBackSellAccId));
            vlstParam.Add(new SqlParameter("dBackBuyAccId", pdBackBuyAccId));
            vlstParam.Add(new SqlParameter("dItemStoreCurValue", pdItemStoreCurValue));
            vlstParam.Add(new SqlParameter("dItemCurVALUE", pdItemCurVALUE));
            vlstParam.Add(new SqlParameter("dItemCur", pdItemCur));
            vlstParam.Add(new SqlParameter("dTotalItemSbaseCredit", pdTotalItemSbaseCredit));
            vlstParam.Add(new SqlParameter("dTotalItemSbaseDebit", pdTotalItemSbaseDebit));
            vlstParam.Add(new SqlParameter("dItemDefCur", pdItemDefCur));
            vlstParam.Add(new SqlParameter("dTransSeq", pdTransSeq));
            vlstParam.Add(new SqlParameter("dEmpAccId", pdEmpAccId));
            vlstParam.Add(new SqlParameter("dEmpAmt", pdEmpAmt));
            vlstParam.Add(new SqlParameter("dEmpBaseAmt", pdEmpBaseAmt));
            vlstParam.Add(new SqlParameter("dEmpRatio", pdEmpRatio));
            vlstParam.Add(new SqlParameter("dEmpCurValue", pdEmpCurValue));
            vlstParam.Add(new SqlParameter("dItemCostBase", pdItemCostBase));
            vlstParam.Add(new SqlParameter("dDelivId", pdDelivId));
            vlstParam.Add(new SqlParameter("dDelYear", pdDelYear));
            vlstParam.Add(new SqlParameter("dDelTransSeq", pdDelTransSeq));
            vlstParam.Add(new SqlParameter("dInStoreId", pdInStoreId));
            vlstParam.Add(new SqlParameter("dNonDescribe", pdNonDescribe));
            vlstParam.Add(new SqlParameter("dDate", pdDate));
            vlstParam.Add(new SqlParameter("dItemName", pdItemName));
            vlstParam.Add(new SqlParameter("dVatAMT", pdVatAMT));
            vlstParam.Add(new SqlParameter("dVatDebitAccId", pdVatDebitAccId));
            vlstParam.Add(new SqlParameter("dVatCreditAccId", pdVatCreditAccId));
            vlstParam.Add(new SqlParameter("dCompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("dInvIsActive", pdInvIsActive));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("InvLaterId", pInvLaterId));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("LInvId", pLInvId));
            vlstParam.Add(new SqlParameter("YEAR", pYEAR));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("LaterAmtCredit", pLaterAmtCredit));
            vlstParam.Add(new SqlParameter("LaterAmtDebit", pLaterAmtDebit));
            vlstParam.Add(new SqlParameter("LaterCurValue", pLaterCurValue));
            vlstParam.Add(new SqlParameter("LaterBaseAmtCredit", pLaterBaseAmtCredit));
            vlstParam.Add(new SqlParameter("LaterBaseAmtDebit", pLaterBaseAmtDebit));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("TransSeq", pTransSeq));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", branchId));
            vlstParam.Add(new SqlParameter("pType", ppType));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            // POS
            vlstParam.Add(new SqlParameter("SubSeq", pSubSeq));
            vlstParam.Add(new SqlParameter("PayTypeId", pPayTypeId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("InvStatus", pInvStatus));
            vlstParam.Add(new SqlParameter("OrderSeq", pOrderSeq));
            vlstParam.Add(new SqlParameter("Insurance", pInsurance));
            vlstParam.Add(new SqlParameter("InsurPerc", pInsurPerc));
            vlstParam.Add(new SqlParameter("Service", pService));
            vlstParam.Add(new SqlParameter("ServicePerc", pServicePerc));
            vlstParam.Add(new SqlParameter("Tax", pTax));
            vlstParam.Add(new SqlParameter("TaxPerc", pTaxPerc));
            vlstParam.Add(new SqlParameter("Discount", pDiscount));
            vlstParam.Add(new SqlParameter("DiscountPerc", pDiscountPerc));
            vlstParam.Add(new SqlParameter("PointId", pPointId));
            vlstParam.Add(new SqlParameter("Delivery", pDelivery));
            vlstParam.Add(new SqlParameter("DeliveryPerc", pDeliveryPerc));
            vlstParam.Add(new SqlParameter("InvMachine", pInvMachine));
            vlstParam.Add(new SqlParameter("PcIdentification", pPcIdentification));
            vlstParam.Add(new SqlParameter("OrderLocSeq", pOrderLocSeq));
            vlstParam.Add(new SqlParameter("OrederDaySeq", pOrederDaySeq));
            vlstParam.Add(new SqlParameter("InvPayType", pInvPayType));
            vlstParam.Add(new SqlParameter("DeliveryInvoice", pDeliveryInvoice));
            vlstParam.Add(new SqlParameter("DeliveryDate", pDeliveryDate));
            vlstParam.Add(new SqlParameter("DelLocSeq", pDelLocSeq));
            vlstParam.Add(new SqlParameter("InvPhoneNo", pInvPhoneNo));
            vlstParam.Add(new SqlParameter("IsPrepare", pIsPrepare));
            vlstParam.Add(new SqlParameter("IsTransPost", pIsTransPost));
            vlstParam.Add(new SqlParameter("PriceCat", pPriceCat));
            vlstParam.Add(new SqlParameter("SiteId", pSiteId));
            vlstParam.Add(new SqlParameter("LocAddressInvoice", pLocAddressInvoice));
            vlstParam.Add(new SqlParameter("AnotherInvId", pAnotherInvId));
            vlstParam.Add(new SqlParameter("CasherDiscount", pCasherDiscount));
            vlstParam.Add(new SqlParameter("DiscountSell", pDiscountSell));
            vlstParam.Add(new SqlParameter("CustomerName", pCustomerName));
            vlstParam.Add(new SqlParameter("AddAMT", pAddAMT));
            vlstParam.Add(new SqlParameter("DelSheepRemain", pDelSheepRemain));
            vlstParam.Add(new SqlParameter("DiscAmt", pDiscAmt));
            vlstParam.Add(new SqlParameter("ItemUnitId", pItemUnitId));
            vlstParam.Add(new SqlParameter("Price", pPrice));
            vlstParam.Add(new SqlParameter("Qty", pQty));
            vlstParam.Add(new SqlParameter("QtyPlate", pQtyPlate));
            vlstParam.Add(new SqlParameter("QtyTransfer", QtyTransfer));
            vlstParam.Add(new SqlParameter("QtyLastRemain", QtyLastRemain));
            vlstParam.Add(new SqlParameter("SheepRemainder", pSheepRemainder));
            vlstParam.Add(new SqlParameter("Tag", pTag));
            vlstParam.Add(new SqlParameter("VatPrice", pVatPrice));
            vlstParam.Add(new SqlParameter("VatTotal", pVatTotal));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));

            // Search Parameters
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("sGLVoucherNo", psGLVoucherNo));
            vlstParam.Add(new SqlParameter("sDateFrom", psDateFrom));
            vlstParam.Add(new SqlParameter("sDateTo", psDateTo));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("SearchDateFrom", pSearchDateFrom));
            vlstParam.Add(new SqlParameter("SearchDateTo", pSearchDateTo));
            vlstParam.Add(new SqlParameter("InvItemNameL1", pInvItemNameL1));
            vlstParam.Add(new SqlParameter("LstUnit", pLstUnit));
            vlstParam.Add(new SqlParameter("LstInvItemId", pLstInvItemId));

            var result = _clsADO.funExecuteScalar("INV.spINVInvoice", vlstParam, "Data GET");
            vData = result?.ToString();
            return vData;
        }

        public object CancelInvoice(int? phINVId, int? pLastUpdatedBy, int? pQueryTypeId)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("hInvId", phINVId));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", pLastUpdatedBy));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            return _clsADO.funExecuteScalar("[INV].[spINVInvoice]", vlstParam, "Data GET");
        }

        public DataTable TableManagmentGet(
        int? pQueryTypeId = null
       )
        {
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            return _clsADO.funFillDataTable("INV.spINVInvoice", vlstParam, "Data GET");
        }
        public DataTable funGetInvoicePaymentOrderReport(int? pInvId = null, bool? pIsActive = null, int? InvType = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("INV.spInvoicePaymentOrderReport", vlstParam, "Data GET");


            return vData;
        }

        public DataTable funGetInvoiceDamageProductReport(int? pInvId = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("INV.spInvoiceDamageProductReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetInvoiceBuyReport(int? pInvId = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("INV.spBuyInvoiceReport", vlstParam, "Data GET");


            return vData;
        }

        // Test Partial View
        public DataTable DtINVInvoiceGET(
        int? phInvId = null,
        int? phInvtype = null,
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
        int? phTableId = null,
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
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
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
        int? pdItemQty = null,
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
        float? pLaterAmtCredit = null,
        float? pLaterAmtDebit = null,
        float? pLaterCurValue = null,
        float? pLaterBaseAmtCredit = null,
        float? pLaterBaseAmtDebit = null,
        bool? pIsPosted = null,
        string pNotes = null,
        int? pStoreId = null,
        int? pCostCenterId = null,
        int? pTransSeq = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        float? pUsedPoints = null,
        int? pMealPoints = null,
        int? pBranchId = null,
        //POS
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
        float? pDiscount = null,
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
        int? pQtyPlate = null,
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
        int? ppType = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null,
        string pSearchDateFrom = null,
        string pSearchDateTo = null,
        string pInvItemNameL1 = null,
        string pLstUnit = null,
        string pLstInvItemId = null
        )
        {
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("hInvId", phInvId));
            vlstParam.Add(new SqlParameter("hInvtype", phInvtype));
            vlstParam.Add(new SqlParameter("hYEAR", phYEAR));
            vlstParam.Add(new SqlParameter("hInvRef", phInvRef));
            vlstParam.Add(new SqlParameter("hInvDate", phInvDate));
            vlstParam.Add(new SqlParameter("hSellerId", phSellerId));
            vlstParam.Add(new SqlParameter("hPayCash", phPayCash));
            vlstParam.Add(new SqlParameter("hPayCheck", phPayCheck));
            vlstParam.Add(new SqlParameter("hPayLater", phPayLater));
            vlstParam.Add(new SqlParameter("hInvBaseAmt", phInvBaseAmt));
            vlstParam.Add(new SqlParameter("hDiscPerc", phDiscPerc));
            vlstParam.Add(new SqlParameter("hIsPosted", phIsPosted));
            vlstParam.Add(new SqlParameter("hStoreId", phStoreId));
            vlstParam.Add(new SqlParameter("hDiscAmt", phDiscAmt));
            vlstParam.Add(new SqlParameter("hInvSubCost", phInvSubCost));
            vlstParam.Add(new SqlParameter("hNotes", phNotes));
            vlstParam.Add(new SqlParameter("hPermitId", phPermitId));
            vlstParam.Add(new SqlParameter("hPermitType", phPermitType));
            vlstParam.Add(new SqlParameter("hOrderType", phOrderType));
            vlstParam.Add(new SqlParameter("hOrderId", phOrderId));
            vlstParam.Add(new SqlParameter("hCustomerId", phCustomerId));
            vlstParam.Add(new SqlParameter("hSaleTax", phSaleTax));
            vlstParam.Add(new SqlParameter("hSaleTax2", phSaleTax2));
            vlstParam.Add(new SqlParameter("hPerson", phPerson));
            vlstParam.Add(new SqlParameter("hInvSeq", phInvSeq));
            vlstParam.Add(new SqlParameter("hInvRefDate", phInvRefDate));
            vlstParam.Add(new SqlParameter("hInvCurValue", phInvCurValue));
            vlstParam.Add(new SqlParameter("hInvCur", phInvCur));
            vlstParam.Add(new SqlParameter("hInvDisc", phInvDisc));
            vlstParam.Add(new SqlParameter("hPermitYear", phPermitYear));
            vlstParam.Add(new SqlParameter("hBankId", phBankId));
            vlstParam.Add(new SqlParameter("hBranchId", clsBranch.vBranchId));
            vlstParam.Add(new SqlParameter("hCardNo", phCardNo));
            vlstParam.Add(new SqlParameter("hAccountId", phAccountId));
            vlstParam.Add(new SqlParameter("hExpireDate", phExpireDate));
            vlstParam.Add(new SqlParameter("hCardType", phCardType));
            vlstParam.Add(new SqlParameter("hAMT", phAMT));
            vlstParam.Add(new SqlParameter("hCurValue", phCurValue));
            vlstParam.Add(new SqlParameter("hBaseAmt", phBaseAmt));
            vlstParam.Add(new SqlParameter("hBankSource", phBankSource));
            vlstParam.Add(new SqlParameter("hPayVisa", phPayVisa));
            vlstParam.Add(new SqlParameter("hAreaId", phAreaId));
            vlstParam.Add(new SqlParameter("hQutId", phQutId));
            vlstParam.Add(new SqlParameter("hQutType", phQutType));
            vlstParam.Add(new SqlParameter("hTypeId", phTypeId));
            vlstParam.Add(new SqlParameter("hPAYED", phPAYED));
            vlstParam.Add(new SqlParameter("hGetComm", phGetComm));
            vlstParam.Add(new SqlParameter("hDELIVERIES", phDELIVERIES));
            vlstParam.Add(new SqlParameter("hReturnOnDelivery", phReturnOnDelivery));
            vlstParam.Add(new SqlParameter("hGoodInvId", phGoodInvId));
            vlstParam.Add(new SqlParameter("hSetSaleRet", phSetSaleRet));
            vlstParam.Add(new SqlParameter("hRetOnDelyear", phRetOnDelyear));
            vlstParam.Add(new SqlParameter("hTableId", phTableId));
            vlstParam.Add(new SqlParameter("hVisitNo", phVisitNo));
            vlstParam.Add(new SqlParameter("hReqNo", phReqNo));
            vlstParam.Add(new SqlParameter("hSurgId", phSurgId));
            vlstParam.Add(new SqlParameter("hDebitType", phDebitType));
            vlstParam.Add(new SqlParameter("hInsurTrans", phInsurTrans));
            vlstParam.Add(new SqlParameter("hContNo", phContNo));
            vlstParam.Add(new SqlParameter("hInsurancePerc", phInsurancePerc));
            vlstParam.Add(new SqlParameter("hCmpAccId", phCmpAccId));
            vlstParam.Add(new SqlParameter("hSalesId", phSalesId));
            vlstParam.Add(new SqlParameter("hFromBranches", phFromBranches));
            vlstParam.Add(new SqlParameter("hInvIsWait", phInvIsWait));
            vlstParam.Add(new SqlParameter("hInvIsCancel", phInvIsCancel));
            vlstParam.Add(new SqlParameter("hPeriodId", phPeriodId));
            vlstParam.Add(new SqlParameter("hBranchCompId", phBranchCompId));
            vlstParam.Add(new SqlParameter("hBranchTransId", phBranchTransId));
            vlstParam.Add(new SqlParameter("hCompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UsedPoints", pUsedPoints));
            vlstParam.Add(new SqlParameter("MealPoints", pMealPoints));
            vlstParam.Add(new SqlParameter("hInvoiceIsActive", phInvoiceIsActive));
            vlstParam.Add(new SqlParameter("hIsDeleted", phIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("dInvDTLId", pdInvDTLId));
            vlstParam.Add(new SqlParameter("dInvId", pdInvId));
            vlstParam.Add(new SqlParameter("dInvType", pdInvType));
            vlstParam.Add(new SqlParameter("dYEAR", pdYEAR));
            vlstParam.Add(new SqlParameter("dStoreId", pdStoreId));
            vlstParam.Add(new SqlParameter("dItemId", pdItemId));
            vlstParam.Add(new SqlParameter("dUnitId", pdUnitId));
            vlstParam.Add(new SqlParameter("dExpireDate", pdExpireDate));
            vlstParam.Add(new SqlParameter("dBackType", pdBackType));
            vlstParam.Add(new SqlParameter("dBackId", pdBackId));
            vlstParam.Add(new SqlParameter("dBackYear", pdBackYear));
            vlstParam.Add(new SqlParameter("dItemPrice", pdItemPrice));
            vlstParam.Add(new SqlParameter("dItemQty", pdItemQty));
            vlstParam.Add(new SqlParameter("dGuaranteeDate", pdGuaranteeDate));
            vlstParam.Add(new SqlParameter("dTotalItemCredit", pdTotalItemCredit));
            vlstParam.Add(new SqlParameter("dTotalItemDebit", pdTotalItemDebit));
            vlstParam.Add(new SqlParameter("dTotalBaseItemCredit", pdTotalBaseItemCredit));
            vlstParam.Add(new SqlParameter("dTotalBaseItemDebit", pdTotalBaseItemDebit));
            vlstParam.Add(new SqlParameter("dDiscType", pdDiscType));
            vlstParam.Add(new SqlParameter("dDiscValue", pdDiscValue));
            vlstParam.Add(new SqlParameter("dDiscAmtCredit", pdDiscAmtCredit));
            vlstParam.Add(new SqlParameter("dDiscAmtDebit", pdDiscAmtDebit));
            vlstParam.Add(new SqlParameter("dDiscBaseCredit", pdDiscBaseCredit));
            vlstParam.Add(new SqlParameter("dDiscBaseDebit", pdDiscBaseDebit));
            vlstParam.Add(new SqlParameter("dIsPosted", pdIsPosted));
            vlstParam.Add(new SqlParameter("dNotes", pdNotes));
            vlstParam.Add(new SqlParameter("dAccountId", pdAccountId));
            vlstParam.Add(new SqlParameter("dItemCostDebit", pdItemCostDebit));
            vlstParam.Add(new SqlParameter("dItemCostCredit", pdItemCostCredit));
            vlstParam.Add(new SqlParameter("dSellAccId", pdSellAccId));
            vlstParam.Add(new SqlParameter("dCostAccId", pdCostAccId));
            vlstParam.Add(new SqlParameter("dDiscAccId", pdDiscAccId));
            vlstParam.Add(new SqlParameter("dTaxAccId", pdTaxAccId));
            vlstParam.Add(new SqlParameter("dTaxDebit", pdTaxDebit));
            vlstParam.Add(new SqlParameter("dTaxBaseDebit", pdTaxBaseDebit));
            vlstParam.Add(new SqlParameter("dItemCost", pdItemCost));
            vlstParam.Add(new SqlParameter("dTaxBaseCredit", pdTaxBaseCredit));
            vlstParam.Add(new SqlParameter("dTaxCredit", pdTaxCredit));
            vlstParam.Add(new SqlParameter("dBackSellAccId", pdBackSellAccId));
            vlstParam.Add(new SqlParameter("dBackBuyAccId", pdBackBuyAccId));
            vlstParam.Add(new SqlParameter("dItemStoreCurValue", pdItemStoreCurValue));
            vlstParam.Add(new SqlParameter("dItemCurVALUE", pdItemCurVALUE));
            vlstParam.Add(new SqlParameter("dItemCur", pdItemCur));
            vlstParam.Add(new SqlParameter("dTotalItemSbaseCredit", pdTotalItemSbaseCredit));
            vlstParam.Add(new SqlParameter("dTotalItemSbaseDebit", pdTotalItemSbaseDebit));
            vlstParam.Add(new SqlParameter("dItemDefCur", pdItemDefCur));
            vlstParam.Add(new SqlParameter("dTransSeq", pdTransSeq));
            vlstParam.Add(new SqlParameter("dEmpAccId", pdEmpAccId));
            vlstParam.Add(new SqlParameter("dEmpAmt", pdEmpAmt));
            vlstParam.Add(new SqlParameter("dEmpBaseAmt", pdEmpBaseAmt));
            vlstParam.Add(new SqlParameter("dEmpRatio", pdEmpRatio));
            vlstParam.Add(new SqlParameter("dEmpCurValue", pdEmpCurValue));
            vlstParam.Add(new SqlParameter("dItemCostBase", pdItemCostBase));
            vlstParam.Add(new SqlParameter("dDelivId", pdDelivId));
            vlstParam.Add(new SqlParameter("dDelYear", pdDelYear));
            vlstParam.Add(new SqlParameter("dDelTransSeq", pdDelTransSeq));
            vlstParam.Add(new SqlParameter("dInStoreId", pdInStoreId));
            vlstParam.Add(new SqlParameter("dNonDescribe", pdNonDescribe));
            vlstParam.Add(new SqlParameter("dDate", pdDate));
            vlstParam.Add(new SqlParameter("dItemName", pdItemName));
            vlstParam.Add(new SqlParameter("dVatAMT", pdVatAMT));
            vlstParam.Add(new SqlParameter("dVatDebitAccId", pdVatDebitAccId));
            vlstParam.Add(new SqlParameter("dVatCreditAccId", pdVatCreditAccId));
            vlstParam.Add(new SqlParameter("dCompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("dInvIsActive", pdInvIsActive));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("InvLaterId", pInvLaterId));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("LInvId", pLInvId));
            vlstParam.Add(new SqlParameter("YEAR", pYEAR));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("LaterAmtCredit", pLaterAmtCredit));
            vlstParam.Add(new SqlParameter("LaterAmtDebit", pLaterAmtDebit));
            vlstParam.Add(new SqlParameter("LaterCurValue", pLaterCurValue));
            vlstParam.Add(new SqlParameter("LaterBaseAmtCredit", pLaterBaseAmtCredit));
            vlstParam.Add(new SqlParameter("LaterBaseAmtDebit", pLaterBaseAmtDebit));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("TransSeq", pTransSeq));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("pType", ppType));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            // POS
            vlstParam.Add(new SqlParameter("SubSeq", pSubSeq));
            vlstParam.Add(new SqlParameter("PayTypeId", pPayTypeId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("InvStatus", pInvStatus));
            vlstParam.Add(new SqlParameter("OrderSeq", pOrderSeq));
            vlstParam.Add(new SqlParameter("Insurance", pInsurance));
            vlstParam.Add(new SqlParameter("InsurPerc", pInsurPerc));
            vlstParam.Add(new SqlParameter("Service", pService));
            vlstParam.Add(new SqlParameter("ServicePerc", pServicePerc));
            vlstParam.Add(new SqlParameter("Tax", pTax));
            vlstParam.Add(new SqlParameter("TaxPerc", pTaxPerc));
            vlstParam.Add(new SqlParameter("Discount", pDiscount));
            vlstParam.Add(new SqlParameter("DiscountPerc", pDiscountPerc));
            vlstParam.Add(new SqlParameter("PointId", pPointId));
            vlstParam.Add(new SqlParameter("Delivery", pDelivery));
            vlstParam.Add(new SqlParameter("DeliveryPerc", pDeliveryPerc));
            vlstParam.Add(new SqlParameter("InvMachine", pInvMachine));
            vlstParam.Add(new SqlParameter("PcIdentification", pPcIdentification));
            vlstParam.Add(new SqlParameter("OrderLocSeq", pOrderLocSeq));
            vlstParam.Add(new SqlParameter("OrederDaySeq", pOrederDaySeq));
            vlstParam.Add(new SqlParameter("InvPayType", pInvPayType));
            vlstParam.Add(new SqlParameter("DeliveryInvoice", pDeliveryInvoice));
            vlstParam.Add(new SqlParameter("DeliveryDate", pDeliveryDate));
            vlstParam.Add(new SqlParameter("DelLocSeq", pDelLocSeq));
            vlstParam.Add(new SqlParameter("InvPhoneNo", pInvPhoneNo));
            vlstParam.Add(new SqlParameter("IsPrepare", pIsPrepare));
            vlstParam.Add(new SqlParameter("IsTransPost", pIsTransPost));
            vlstParam.Add(new SqlParameter("PriceCat", pPriceCat));
            vlstParam.Add(new SqlParameter("SiteId", pSiteId));
            vlstParam.Add(new SqlParameter("LocAddressInvoice", pLocAddressInvoice));
            vlstParam.Add(new SqlParameter("AnotherInvId", pAnotherInvId));
            vlstParam.Add(new SqlParameter("CasherDiscount", pCasherDiscount));
            vlstParam.Add(new SqlParameter("DiscountSell", pDiscountSell));
            vlstParam.Add(new SqlParameter("CustomerName", pCustomerName));
            vlstParam.Add(new SqlParameter("AddAMT", pAddAMT));
            vlstParam.Add(new SqlParameter("DelSheepRemain", pDelSheepRemain));
            vlstParam.Add(new SqlParameter("DiscAmt", pDiscAmt));
            vlstParam.Add(new SqlParameter("ItemUnitId", pItemUnitId));
            vlstParam.Add(new SqlParameter("Price", pPrice));
            vlstParam.Add(new SqlParameter("Qty", pQty));
            vlstParam.Add(new SqlParameter("QtyPlate", pQtyPlate));
            vlstParam.Add(new SqlParameter("SheepRemainder", pSheepRemainder));
            vlstParam.Add(new SqlParameter("Tag", pTag));
            vlstParam.Add(new SqlParameter("VatPrice", pVatPrice));
            vlstParam.Add(new SqlParameter("VatTotal", pVatTotal));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));

            // Search Parameters
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("sGLVoucherNo", psGLVoucherNo));
            vlstParam.Add(new SqlParameter("sDateFrom", psDateFrom));
            vlstParam.Add(new SqlParameter("sDateTo", psDateTo));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("SearchDateFrom", pSearchDateFrom));
            vlstParam.Add(new SqlParameter("SearchDateTo", pSearchDateTo));
            vlstParam.Add(new SqlParameter("InvItemNameL1", pInvItemNameL1));
            vlstParam.Add(new SqlParameter("LstUnit", pLstUnit));
            vlstParam.Add(new SqlParameter("LstInvItemId", pLstInvItemId));

            vData = _clsADO.funFillDataTable("INV.spINVInvoice", vlstParam, "Data GET");
            return vData;
        }



        public object spInvoiceDtlInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? UserId = null, int? BranchId = null)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            return _clsADO.funExecuteScalar("[INV].[spInvoiceDtl_Bulk]", vlstParam, "Data GET");
        }
        public Object spInvoicePOSBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
            int? Invtype = null, bool? InvIsWait = null, string CardNo = null, DateTime? InvDate = null, int? PayTypeId = null, string Notes = null, int? CashDeskId = null, float? Insurance = null, int? Service = null, float? Tax = null, float? Discount = null, string InvMachine = null, bool? DeliveryInvoice = null, int? Delivery = null, DateTime? DeliveryDate = null, string InvPhoneNo = null, int? SiteId = null, string LocAddressInvoice = null, float? InvCurValue = null, string CustomerName = null, int? CustomerId = null, int? OrderType = null, int? UsedPoints = null, int? MealPoints = null, string CustomerAddress = null, string CustomerPhoneNumber = null,
            int? UserId = null, int? BranchId = null, int? TableId = null, int? InvStatus = null
          )
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("Invtype", Invtype));
            vlstParam.Add(new SqlParameter("InvIsWait", InvIsWait));
            vlstParam.Add(new SqlParameter("CardNo", CardNo));
            vlstParam.Add(new SqlParameter("InvDate", DateTime.Now));
            vlstParam.Add(new SqlParameter("PayTypeId", PayTypeId));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            vlstParam.Add(new SqlParameter("CashDeskId", CashDeskId));
            vlstParam.Add(new SqlParameter("Insurance", Insurance));
            vlstParam.Add(new SqlParameter("Service", Service));
            vlstParam.Add(new SqlParameter("Tax", Tax));
            vlstParam.Add(new SqlParameter("Discount", Discount));
            vlstParam.Add(new SqlParameter("InvMachine", InvMachine));
            vlstParam.Add(new SqlParameter("DeliveryInvoice", DeliveryInvoice));
            vlstParam.Add(new SqlParameter("DeliveryDate", DeliveryDate));
            vlstParam.Add(new SqlParameter("InvPhoneNo", InvPhoneNo));
            vlstParam.Add(new SqlParameter("SiteId", SiteId));
            vlstParam.Add(new SqlParameter("Delivery", Delivery));
            vlstParam.Add(new SqlParameter("LocAddressInvoice", LocAddressInvoice));
            vlstParam.Add(new SqlParameter("InvCurValue", InvCurValue));
            vlstParam.Add(new SqlParameter("CustomerName", CustomerName));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("CustomerAddress", CustomerAddress));
            vlstParam.Add(new SqlParameter("CustomerPhoneNumber", CustomerPhoneNumber));
            vlstParam.Add(new SqlParameter("OrderType", OrderType));
            vlstParam.Add(new SqlParameter("UsedPoints", UsedPoints));
            vlstParam.Add(new SqlParameter("MealPoints", MealPoints));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("TableId", TableId));
            vlstParam.Add(new SqlParameter("InvStatus", InvStatus));
            return _clsADO.funExecuteScalar("[INV].[spInvoicePOS_Bulk]", vlstParam, "Data GET");
        }
        public object spMovementBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
             int? InvStatus, int? CashDeskId, DateTime? InvDate = null, string InvPhoneNo = null, string CustomerName = null, float? InvCurValue = null, int? Delivery = null, float? Tax = null, string InvMachine = null, bool? DeliveryInvoice = null, string LocAddressInvoice = null, int? CustomerId = null, int? OrderId = null, int? UserId = null, int? BranchId = null, float? Discount = null, string Notes = null
       )
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("InvStatus", InvStatus));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("InvDate", InvDate));
            vlstParam.Add(new SqlParameter("CashDeskId", CashDeskId));
            vlstParam.Add(new SqlParameter("InvPhoneNo", InvPhoneNo));
            vlstParam.Add(new SqlParameter("CustomerName", CustomerName));
            vlstParam.Add(new SqlParameter("InvCurValue", InvCurValue));
            vlstParam.Add(new SqlParameter("Delivery", Delivery));
            vlstParam.Add(new SqlParameter("Tax", Tax));
            vlstParam.Add(new SqlParameter("InvMachine", InvMachine));
            vlstParam.Add(new SqlParameter("DeliveryInvoice", DeliveryInvoice));
            vlstParam.Add(new SqlParameter("LocAddressInvoice", LocAddressInvoice));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("OrderId", OrderId));
            vlstParam.Add(new SqlParameter("Discount", Discount));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            return _clsADO.funExecuteScalar("[INV].[spMovement_Bulk]", vlstParam, "Data GET");
        }
        public object spReturnBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
           int? InvRef = null, int? UserId = null, int? BranchId = null
    )
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("InvRef", InvRef));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));

            return _clsADO.funExecuteScalar("[INV].[spReturnPOS_Bulk]", vlstParam, "Data GET");
        }

        public object spReturnData(string psGLVoucherNo,
                   DateTime? psDateFrom = null, DateTime? psDateTo = null)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("sGLVoucherNo", psGLVoucherNo));
            vlstParam.Add(new SqlParameter("sDateFrom", psDateFrom));
            vlstParam.Add(new SqlParameter("sDateTo", psDateTo));

            return _clsADO.funExecuteScalar("[INV].[ReturnData]", vlstParam, "Data GET");
        }

        public object spInsuranceReturnBulk(ICollection<InvoiceDtl> InvoiceDtls, int CashDeskId, string Numbers, int BranchId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CashDeskId", CashDeskId));
            vlstParam.Add(new SqlParameter("Numbers", Numbers));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            return _clsADO.funExecuteScalar("[INV].[spInsurancReturn_Bulk]", vlstParam, "Data GET");
        }

        public object spItemBulk(ICollection<ItemUnit> ItemUnit, int ItemId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("ItemUnit", ItemUnit);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ItemId", ItemId));
            vlstParam.Add(new SqlParameter("ItemUnit", xml));
            return _clsADO.funExecuteScalar("[INV].[spItem_Bulk]", vlstParam, "Data GET");
        }

        public object spPaymentOrderInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            return _clsADO.funExecuteScalar("[INV].[spInvoicePaymentOrder_Bulk]", vlstParam, "Data GET");
        }
        public int getUserId()
        {
            string user = HttpContext.Current.Request.Cookies["UserId"].Value;
            return Convert.ToInt32(user);
        }
        public object spPaymentReciverInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId, DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId, int? BranchId, bool? PayCash = null, bool? PayCheck = null, bool? PayLater = null)
        {

            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("InvDate", InvDate));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            vlstParam.Add(new SqlParameter("InvRef", InvRef));
            vlstParam.Add(new SqlParameter("InvRefDate", InvRefDate));
            vlstParam.Add(new SqlParameter("InvIsCancel", InvIsCancel));
            vlstParam.Add(new SqlParameter("IsDeleted", IsDeleted));
            vlstParam.Add(new SqlParameter("PayCheck", PayCheck));
            vlstParam.Add(new SqlParameter("PayCash", PayCash));
            vlstParam.Add(new SqlParameter("PayLater", PayLater));
            return _clsADO.funExecuteScalar("[INV].[spInvoiceReciverOrder_Bulk]", vlstParam, "Data GET");
        }
        public object spMealBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId, DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId = null, int? BranchId = null)
        {

            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("InvDate", InvDate));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            vlstParam.Add(new SqlParameter("InvRef", InvRef));
            vlstParam.Add(new SqlParameter("InvRefDate", InvRefDate));
            vlstParam.Add(new SqlParameter("InvIsCancel", InvIsCancel));
            vlstParam.Add(new SqlParameter("IsDeleted", IsDeleted));
            // vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));

            //vlstParam.Add(new SqlParameter("IsDeleted", IsDeleted));
            return _clsADO.funExecuteScalar("[INV].[spInvoiceMealOfEmployee_Bulk]", vlstParam, "Data GET");
        }
        public object spPaymentInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId, DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId, int? BranchId, bool? PayCash = null, bool? PayCheck = null, bool? PayLater = null)
        {


            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("InvDate", DateTime.Now));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            vlstParam.Add(new SqlParameter("InvRef", InvRef));
            vlstParam.Add(new SqlParameter("InvRefDate", InvRefDate));
            vlstParam.Add(new SqlParameter("InvIsCancel", InvIsCancel));
            vlstParam.Add(new SqlParameter("IsDeleted", IsDeleted));
            vlstParam.Add(new SqlParameter("PayCheck", PayCheck));
            vlstParam.Add(new SqlParameter("PayCash", PayCash));
            vlstParam.Add(new SqlParameter("PayLater", PayLater));
            return _clsADO.funExecuteScalar("[INV].[spInvoicePaymentOrder_Bulk]", vlstParam, "Data GET");
        }
        public object spProductionTransInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? ProductionId, int? UserId, int? BranchId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("ProductionId", ProductionId));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            return _clsADO.funExecuteScalar("[INV].[spProductionTrans_Bulk]", vlstParam, "Data GET");
        }
        public DataTable POSData(string InvCode, DateTime? DateFrom = null, DateTime? DateTo = null, int? BranchId = null)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvCode", InvCode));
            vlstParam.Add(new SqlParameter("DateFrom", DateFrom));
            vlstParam.Add(new SqlParameter("DateTo", DateTo));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            return _clsADO.funFillDataTable("inv.POSSearch", vlstParam, "Data GET");
        }

        #region spInvoiceOrderOrPOS
        
        private List<SqlParameter> SetParam_spInvoiceOrderOrPOS(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 400
            , string pZatcaResponse = null, bool? pIsPassed = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pInvType = null, int? pBranchId = null, string pInvCode = null)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("orderId", pOrderId));
            vlstParam.Add(new SqlParameter("InvCode", pInvCode));
            vlstParam.Add(new SqlParameter("IsPassed", pIsPassed));
            vlstParam.Add(new SqlParameter("ZatcaResponse", pZatcaResponse));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            return vlstParam;
        }
        private string getProcName_spInvoiceOrderOrPOS => "RES.spInvoiceOrderOrPOS";
        
        // يستدعي إجراء مخزن مشترك للفواتير التابعة للكاشير والطلبات بحيث يكون فيه ثلاث دوال او وظائف
        public object funInvoiceOrderOrPOS(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 400
            , string pZatcaResponse = null, bool? pIsPassed = null, DateTime? pDateFrom = null, DateTime? pDateTo = null,int? pInvType=null, int? pBranchId = null, string pInvCode=null)
        {
            // Declaration 
            //DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = SetParam_spInvoiceOrderOrPOS(pInvId: pInvId, pOrderId: pOrderId, pInvCode: pInvCode,
                pIsPassed: pIsPassed, pZatcaResponse: pZatcaResponse, pDateFrom: pDateFrom, pDateTo: pDateTo, pInvType: pInvType
                , pBranchId: pBranchId, pQueryTypeId: pQueryTypeId);

            // vData = _clsADO.funFillDataTable("RES.spInvoiceOrderOrPOS", vlstParam, "Data GET");
            // return vData;
            return _clsADO.funExecuteScalar(getProcName_spInvoiceOrderOrPOS, vlstParam, "Data GET");

        }

        public DataTable funInvoiceOrderOrPOSDT(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 402
            , string pZatcaResponse = null, bool? pIsPassed = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pInvType = null, int? pBranchId = null, string pInvCode = null)
        {
            List<SqlParameter> vlstParam = SetParam_spInvoiceOrderOrPOS(pInvId: pInvId, pOrderId: pOrderId, pInvCode: pInvCode,
                pIsPassed: pIsPassed, pZatcaResponse: pZatcaResponse, pDateFrom: pDateFrom, pDateTo: pDateTo, pInvType: pInvType
                , pBranchId: pBranchId, pQueryTypeId: pQueryTypeId);

            DataTable vData = _clsADO.funFillDataTable(getProcName_spInvoiceOrderOrPOS, vlstParam, "Data GET");
            return vData;

        }

        #endregion

    }
}