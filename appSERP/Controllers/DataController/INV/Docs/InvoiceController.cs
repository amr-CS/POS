using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models;
using appSERP.Models.LinkPro;
using appSERP.Utils;
using appSERP.ZatcaEInvoicing;
using appSERP.ZatcaEInvoicing.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV.Docs
{
    [NoDirectAccess]
    [Authorize]
    public class InvoiceController : Controller
    {
        private ILog _ILog;
        private IdbINVInvoice _dbINVInvoice;
        private IdbPeriod _dbPeriod;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        private IdbResOrder _dbResOrder;
        private IdbResOrderDtl _dbResOrderDtl;
        private PrepareInvoiceBeforeSendingToZatca _prepareInvoiceBeforeSendingToZatca;
        public InvoiceController(ILog log, IdbINVInvoice dbINVInvoice, IdbPeriod dbPeriod, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting
            , IdbResOrder dbResOrder, IdbResOrderDtl dbResOrderDtl, PrepareInvoiceBeforeSendingToZatca prepareInvoiceBeforeSendingToZatca)
        {
            _ILog = log;
            _dbINVInvoice = dbINVInvoice;
            _dbPeriod = dbPeriod;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
            _dbResOrder = dbResOrder;
            _dbResOrderDtl = dbResOrderDtl;
            _prepareInvoiceBeforeSendingToZatca = prepareInvoiceBeforeSendingToZatca;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            //test 
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }

        // GET: Invoices
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];
            return View();
        }

        public ActionResult InvoiceReturn()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];
            return View();
        }
        // Fun Get API
        public string funINVInvoice(
          int? phInvId = null,
          int? phInvtype = null,
          int? UserId = null,
          int? phYEAR = null,
          int? phInvRef = null,
          string phInvDate = null,
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
          string phInvRefDate = null,
          float? phInvCurValue = null,
          int? phInvCur = null,
          float? phInvDisc = null,
          float? phPermitYear = null,
          int? phBankId = null,
          int? phBranchId = null,
          int? phCardNo = null,
          int? phAccountId = null,
          string phExpireDate = null,
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
          float? pUsedPoints = null,
          int? pMealPoints = null,
          bool? phInvoiceIsActive = null,
          bool? phIsDeleted = null,
          int? pdInvDTLId = null,
          int? pdInvId = null,
          int? pdInvType = null,
          int? pdYEAR = null,
          int? pdStoreId = null,
          int? pdItemId = null,
          int? pdUnitId = null,
          string pdExpireDate = null,
          int? pdBackType = null,
          int? pdBackId = null,
          int? pdBackYear = null,
          int? pdItemPrice = null,
          int? pdItemQty = null,
          string pdGuaranteeDate = null,
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
          string pdDate = null,
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
        //POS
        int? pSubSeq = null,
        int? pPayTypeId = null,
        int? pCashDeskId = null,
        int? pInvStatus = null,
        int? pOrderSeq = null,
        int? pInsurance = null,
        int? pInsurPerc = null,
        int? pService = null,
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
        string pDeliveryDate = null,
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
        float? QtyTransfer = null,
        float? QtyLastRemain = null,
        int? pSheepRemainder = null,
        int? pTag = null,
        int? pVatPrice = null,
        float? pVatTotal = null,
        int? pItemType = null,
          bool? pIsDeleted = null,
          int? ppType = null,
          int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APIINVInvoice/INVInvoiceGET";
            // Paramter
            string vParameters =
            // Head
            "?phInvId=" + phInvId +
            "?UserId=" + UserId +
            "&phInvIsWait=" + phInvIsWait +
            "&phInvtype=" + phInvtype +
            "&phInvRef=" + phInvRef +
            "&phInvRefDate=" + phInvRefDate +
            "&phInvDate=" + phInvDate +
            "&phStoreId=" + phStoreId +
            "&phNotes=" + phNotes +
            "&phPayCash=" + phPayCash +
            "&phPayCheck=" + phPayCheck +
            "&phPayLater=" + phPayLater +
            "&phDiscPerc=" + phDiscPerc +
            "&phInvDisc=" + phInvDisc +
            "&phCardNo=" + phCardNo +
            "&phInvBaseAmt=" + phInvBaseAmt +
            "&phCustomerId=" + phCustomerId +
            "&phInvIsCancel=" + phInvIsCancel +
            "&phIsDeleted=" + phIsDeleted +
            "&phOrderType=" + phOrderType +
            "&phInvCurValue=" + phInvCurValue +
            "&pUsedPoints=" + pUsedPoints +
            "&pMealPoints=" + pMealPoints +
            // DTL
            "&pdInvDTLId=" + pdInvDTLId +
            "&pdInvId=" + pdInvId +
            "&pdItemId=" + pdItemId +
            "&pdUnitId=" + pdUnitId +
            "&pdItemPrice=" + pdItemPrice +
            "&pdItemQty=" + pdItemQty +
            "&pdExpireDate=" + pdExpireDate +
            "&pdDiscType=" + pdDiscType +
            "&pdDiscValue=" + pdDiscValue +
            "&pdItemCurVALUE=" + pdItemCurVALUE +
            "&pdNotes=" + pdNotes +
            "&pdIsDeleted=" + pdIsDeleted +
            "&pdTotalItemSbaseCredit=" + pdTotalItemSbaseCredit +
            "&pdTotalItemCredit=" + pdTotalItemCredit +
           "&pdTotalItemDebit=" + pdTotalItemDebit +
            "&pdTotalBaseItemCredit=" + pdTotalBaseItemCredit +
            "&pdTotalBaseItemDebit=" + pdTotalBaseItemDebit +
            "&pdVatAMT=" + pdVatAMT +
            // POS
            "&pPayTypeId=" + pPayTypeId +
            "&pCashDeskId=" + pCashDeskId +
            "&pInvStatus=" + pInvStatus +
            "&pOrderSeq=" + pOrderSeq +
            "&pInsurance=" + pInsurance +
            "&pInsurPerc=" + pInsurPerc +
            "&pService=" + pService +
            "&pServicePerc=" + pServicePerc +
            "&pTax=" + pTax +
            "&pTaxPerc=" + pTaxPerc +
            "&pDiscount=" + pDiscount +
            "&pDiscountPerc=" + pDiscountPerc +
            "&pPointId=" + pPointId +
            "&pDelivery=" + pDelivery +
            "&pDeliveryPerc=" + pDeliveryPerc +
            "&pInvMachine=" + pInvMachine +
            "&pPcIdentification=" + pPcIdentification +
            "&pOrderLocSeq=" + pOrderLocSeq +
            "&pOrederDaySeq=" + pOrederDaySeq +
            "&pInvPayType=" + pInvPayType +
            "&pDeliveryInvoice=" + pDeliveryInvoice +
            "&pDeliveryDate=" + pDeliveryDate +
            "&pDelLocSeq=" + pDelLocSeq +
            "&pInvPhoneNo=" + pInvPhoneNo +
            "&pIsPrepare=" + pIsPrepare +
            "&pIsTransPost=" + pIsTransPost +
            "&pPriceCat=" + pPriceCat +
            "&pSiteId=" + pSiteId +
            "&pLocAddressInvoice=" + pLocAddressInvoice +
            "&pAnotherInvId=" + pAnotherInvId +
            "&pCasherDiscount=" + pCasherDiscount +
            "&pDiscountSell=" + pDiscountSell +
            "&pCustomerName=" + pCustomerName +
            "&pAddAMT=" + pAddAMT +
            "&pDelSheepRemain=" + pDelSheepRemain +
            "&pDiscAmt=" + pDiscAmt +
            "&pItemUnitId=" + pItemUnitId +
            "&pPrice=" + pPrice +
            "&pQty=" + pQty +
            "&pQtyPlate=" + pQtyPlate +
            "&QtyTransfer=" + QtyTransfer +
            "&QtyLastRemain=" + QtyLastRemain +
            "&pSheepRemainder=" + pSheepRemainder +
            "&pTag=" + pTag +
            "&pVatPrice=" + pVatPrice +
            "&pVatTotal=" + pVatTotal +
            "&pItemType=" + pItemType +

              "&pNotes=" + pNotes +
              "&pCostCenterId=" + pCostCenterId +
              "&pIsDeleted=" + pIsDeleted +
              "&ppType=" + ppType +
              "&pQueryTypeId=" + pQueryTypeId;


            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }
        public void ShowSimple()
        {
            int vInvId = Convert.ToInt32(Session["BuyInvId"]);
            DataTable DT = _dbINVInvoice.funGetInvoiceBuyReport(pInvId: vInvId);
            string vReportPath = Server.MapPath("~/Reports") + "//BuyInvoiceReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult InvoiceHtmlReport(int? pInvId = null, int? InvType = null)
        {

            DataTable DT = _dbINVInvoice.funGetInvoicePaymentOrderReport(pInvId: pInvId, InvType: InvType);

            if (DT.Rows.Count > 0)
            {
                DataRow dataRow = DT.Rows[0];
                ViewBag.vDT = DT;
                ViewBag.ReportName = dataRow["InvType"];
                ViewBag.DateTo = dataRow["InvDate"];
                ViewBag.DateFrom = dataRow["InvDate"];
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult InvoiceReturnHtmlReport(int? pInvId = null, int? InvType = null)
        {

            DataTable DT = _dbINVInvoice.funGetInvoicePaymentOrderReport(pInvId: pInvId, InvType: InvType);

            if (DT.Rows.Count > 0)
            {
                DataRow dataRow = DT.Rows[0];
                ViewBag.vDT = DT;
                ViewBag.ReportName = dataRow["InvType"];
                ViewBag.DateTo = dataRow["InvDate"];
                ViewBag.DateFrom = dataRow["InvDate"];
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }

       
        public ActionResult InvoiceBuyReport(int? pInvId = null)
        {
            ViewBag.vbInvId = pInvId;
            Session["BuyInvId"] = ViewBag.vbInvId;
            return View();
        }

        public JsonResult InsertInvoiceDtlBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? UserId = null, int? BranchId = null)
        {

            return Json(_dbINVInvoice.spInvoiceDtlInsertBulk(InvoiceDtls, InvId, UserId, BranchId));

        }

        public JsonResult InsertPOSBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
           int? Invtype = null, bool? InvIsWait = null, string CardNo = null, DateTime? InvDate = null, int? PayTypeId = null, string Notes = null, int? CashDeskId = null, float? Insurance = null, int? Service = null, float? Tax = null, float? Discount = null, string InvMachine = null, bool? DeliveryInvoice = null, int? Delivery = 0, DateTime? DeliveryDate = null, string InvPhoneNo = null, int? SiteId = null, string LocAddressInvoice = null, float? InvCurValue = null, string CustomerName = null, int? CustomerId = null, int? OrderType = null, int? UsedPoints = null, int? MealPoints = null, string CustomerAddress = null, string CustomerPhoneNumber = null, int? UserId = null, int? BranchId = null)
        {
            return Json(_dbINVInvoice.spInvoicePOSBulk(InvoiceDtls, InvId, Invtype, InvIsWait, CardNo, InvDate, PayTypeId, Notes, CashDeskId, Insurance, Service, Tax, Discount, InvMachine, DeliveryInvoice, Delivery, DeliveryDate, InvPhoneNo, SiteId, LocAddressInvoice, InvCurValue, CustomerName, CustomerId, OrderType, UsedPoints, MealPoints, CustomerAddress, CustomerPhoneNumber, UserId, BranchId));
        }
        public JsonResult InsertMovementBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
            int? InvStatus = null, DateTime? InvDate = null, int? CashDeskId = null, string InvPhoneNo = null, 
            string CustomerName = null, float? InvCurValue = null, int? Delivery = null, float? Tax = null, string InvMachine = null,
            bool? DeliveryInvoice = null, string LocAddressInvoice = null, int? CustomerId = null, int? OrderId = null, int? UserId = null, int? BranchId = null, float? Discount = null, string Notes = null
            , DateTime? DeliveryDate = null)
        {
            //DELIVERY_DATE,CUST_SEQ,NOTES
            Notes = Notes.Trim();
            var dtOrder = _dbResOrder.GetOrderById((int)OrderId);
            if (DeliveryDate != Convert.ToDateTime(dtOrder.Rows[0]["DELIVERY_DATE"].ToString())
                || CustomerId != Convert.ToInt32(dtOrder.Rows[0]["CUST_SEQ"].ToString())  || Notes != dtOrder.Rows[0]["NOTES"].ToString().Trim())
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError("بيانات الطلب مختلفة عن السابقة احفظ التعديلات اولا")));

            // فحص تفاصيل الطلب قبل الاصدار والتوصيل واذا في اختلاف يوقف الاصدار للفاتورة                     
            var dtDetails = _dbResOrderDtl.GetOrderDetails((int)OrderId);
            if(InvoiceDtls.Count != dtDetails.Rows.Count)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError("تفاصيل الإصدار غير مساوية مع تفاصيل الطلب احفظ التعديلات اولا")));
            string message = "";
            
            int index = 0;
            foreach (var mdl in InvoiceDtls)
            {
                if (mdl.ItemId == null || mdl.UnitId == null || mdl.ItemQty == null || mdl.ItemQty <= 0)
                    message += mdl.ItemId + " للآسف بيانات تفاصيل الطلب فارغة \n";

                if (mdl.ItemId != dtDetails.Rows[index]["ITEM_UNIT_SEQ"].ToString()
                    || mdl.UnitId != Convert.ToInt32(dtDetails.Rows[index]["UnitId"].ToString())
                    || mdl.ItemQty != Convert.ToInt32(dtDetails.Rows[index]["QTY"].ToString()))
                {
                    message += mdl.ItemId + " للآسف بيانات تفاصيل سجل الطلب الحالي مختلف عن السابق احفظ التعديلات اولا \n";
                }
                index += 1;
            }

            message = message.Trim();
            if (string.IsNullOrWhiteSpace(message) == false || message.Length > 0)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError(message)));
            
            var data = Json(_dbINVInvoice.spMovementBulk(InvoiceDtls, InvId, InvStatus, CashDeskId, InvDate, InvPhoneNo, CustomerName, InvCurValue, Delivery, Tax, InvMachine, DeliveryInvoice, LocAddressInvoice, CustomerId, OrderId, UserId, BranchId, Discount, Notes));


            dynamic stuff = JsonConvert.DeserializeObject(data.Data.ToString());
            var result = "";
            foreach (var s in stuff)
            {
                result = s.c;
            }
            //if (result == "1" && InvStatus != 1 && InvStatus != null)
            if (result == "1" && InvStatus == 2)
            {
                Task.Run(() => 
                {
                    _prepareInvoiceBeforeSendingToZatca.SendToZatcaOrder((int)OrderId);
                });
            }

            return data;

            //return Json(result);
        }
        public JsonResult InsertReturnBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
             int? InvRef = null, int? UserId = null, int? BranchId = null)
        {
            return Json(_dbINVInvoice.spReturnBulk(InvoiceDtls, InvId, InvRef, UserId, BranchId));
        }

        [HttpPost]
        public JsonResult InsertInsuranceReturnBulk(ICollection<InvoiceDtl> InvoiceDtls, int CashDeskId, string Numbers, int BranchId)
        {
            // تستدعاء عند سداد او ارجاع التأمين
            return Json(_dbINVInvoice.spInsuranceReturnBulk(InvoiceDtls, CashDeskId, Numbers, BranchId));

        }
        //[HttpPost]
        //public JsonResult InsertPaymentOrderDtlBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId)
        //{

        //    return Json(dbINVInvoice.spPaymentOrderInsertBulk(InvoiceDtls, InvId));

        //}
        [HttpPost]
        public JsonResult InsertReciverOrderDtlBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId, DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId, int? BranchId, bool? PayCash = null, bool? PayCheck = null, bool? PayLater = null)
        {
            // امر صرف مخزني صنف - فاتورة المردودات
            //clsUser.vUserId = Convert.ToInt32(Request.Cookies["UserId"].Value);

            return Json(_dbINVInvoice.spPaymentReciverInsertBulk(InvoiceDtls, InvId, InvType, CustomerId, StoreId, InvDate, Notes, InvRef, InvRefDate, InvIsCancel, IsDeleted, UserId, BranchId, PayCash, PayCheck, PayLater));

        }
        public JsonResult InsertMealBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId, DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId = null, int? BranchId = null)
        {

            //clsUser.vUserId = Convert.ToInt32(Request.Cookies["UserId"].Value);

            return Json(_dbINVInvoice.spMealBulk(InvoiceDtls, InvId, InvType, CustomerId, StoreId, InvDate, Notes, InvRef, InvRefDate, InvIsCancel, IsDeleted, UserId, BranchId));

        }
        private Tuple<bool, string> CheckInvoiceEntries(ICollection<InvoiceDtl> InvoiceDtls)
        {
            // امر شراء - امر توريد مخزني
            if (InvoiceDtls==null || InvoiceDtls.Count<1)
                return Tuple.Create(false, "للآسف لا يوجد تفاصيل للفاتورة");
            string message = "";
            foreach (var mdl in InvoiceDtls)
            {
                if (mdl.UnitId == null || mdl.UnitId == 0 || mdl.ItemQty == null || mdl.ItemQty <= 0
                    || mdl.ItemId == null || mdl.ItemPrice <= 0)
                {
                    message += mdl.ItemId + " للآسف بيانات تفاصيل الفاتورة غير مكتملة \n";
                }
            }
            message = message.Trim();
            if (string.IsNullOrWhiteSpace(message) == false || message.Length > 0)
                return Tuple.Create(false, message);

            return Tuple.Create(true, "");
        }
        public JsonResult InsertPaymentOrderDtlBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? CustomerId, int? StoreId
            , DateTime? InvDate, string Notes, int? InvRef, DateTime? InvRefDate, bool? InvIsCancel, bool? IsDeleted, int? UserId, int? branchId,bool? PayCash=null,bool? PayCheck = null,bool? PayLater = null)
        {
            // امر توريد مخزني منتج - امر توريد مخزني صنف - فاتورة الشراء
            var tupe = CheckInvoiceEntries(InvoiceDtls);
            if (tupe.Item1 == false)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError(tupe.Item2)));
           
            var data = _dbINVInvoice.spPaymentInsertBulk(InvoiceDtls, InvId, InvType, CustomerId, StoreId, InvDate, Notes, InvRef, InvRefDate, InvIsCancel, IsDeleted, UserId, branchId, PayCash, PayCheck, PayLater);
            return Json(data);
        }
        [HttpPost]
        public JsonResult InsertProductionTransInsertBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? ProductionId, int? UserId, int? branchId)
        {

            return Json(_dbINVInvoice.spProductionTransInsertBulk(InvoiceDtls, InvId, ProductionId, UserId, branchId));

        }
        [HttpPost]
        public string SaveMovementOrder(int? phINVId = null,
              int? phInvtype = null, int? ppType = null, bool? phInvIsWait = null, DateTime? phInvDate = null, string NOTES = null, int? pCashDeskId = null,
           int? pInvStatus = null, int? phStoreId = null, int? phOrderType = null,
           float? phInvCurValue = null, int? pDelivery = null,
               float? pTax = null, bool? phInvIsCancel = null, bool? pDeliveryInvoice = null,
               bool? phIsDeleted = null,
               string pLocAddressInvoice = null, int? phCustomerId = null,
             string pInvPhoneNo = null,
              string pCustomerName = null,
               int? phOrderId = null, int? pQueryTypeId = null)
        {

            DataTable dt = _dbINVInvoice.DtINVInvoiceGET(
                    phInvId: 0,
                    phInvtype: phInvtype,
                    ppType: ppType,
                    phInvIsWait: phInvIsWait,
                    phInvDate: phInvDate,
                    phNotes: NOTES,
                    pInvPhoneNo: pInvPhoneNo,
                    pCustomerName: pCustomerName,
                    pCashDeskId: pCashDeskId,
                    pInvStatus: pInvStatus,
                    phStoreId: phStoreId,
                    phOrderType: phOrderType,
                    phInvCurValue: phInvCurValue,
                    pDelivery: pDelivery,
                    pTax: pTax,
                    phInvIsCancel: false,
                    pDeliveryInvoice: pDeliveryInvoice,
                    phIsDeleted: false,
                    pLocAddressInvoice: pLocAddressInvoice,
                    phCustomerId: phCustomerId,
                    phOrderId: phOrderId,
                    pQueryTypeId: 100);
            string x = dt.Rows[0][0].ToString();
            return x;


        }

    }
}