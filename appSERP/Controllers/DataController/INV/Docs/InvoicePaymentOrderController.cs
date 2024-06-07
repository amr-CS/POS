using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV.Docs
{
    [NoDirectAccess]
    [Authorize]
    public class InvoicePaymentOrderController : Controller
    {
        private ILog _ILog;
        private IdbINVInvoice _dbINVInvoice;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public InvoicePaymentOrderController(ILog log, IdbINVInvoice dbINVInvoice, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbINVInvoice = dbINVInvoice;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: InvoicePaymentOrder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult hospitality()
        {
            return View();
        }
        public ActionResult InvoicePaymentOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        } 
        public ActionResult OpeneingBalanceOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        public ActionResult InvoicePaymentOrderProduct()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult InvoiceReceiveOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }  
        public ActionResult InvoiceMealOfEmployee()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult InvoiceReceiveOrderProduct()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }



        public ActionResult InvoiceDamageProduct()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }  
        public ActionResult InvoicePurchase()
        {

            return View();
        }

        
        public ActionResult InvoiceDamageProductReport(int? pInvId = null)
        {
            ViewBag.vbInvId = pInvId;
            Session["InvId"] = pInvId;

            return View();
        }
        public void ShowDamageProductReport()
        {
            int vInvId = Convert.ToInt32(Session["InvId"].ToString());
            DataTable DT = _dbINVInvoice.funGetInvoiceDamageProductReport(pInvId: vInvId);
            string vReportPath = Server.MapPath("~/Reports") + "//rptDamageProduct.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }



        [HttpPost]
      // Fun Get API
      public string funINVInvoice(
        int? phInvId = null,
        int? phInvtype = null,
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
        float? pdItemQty = null,
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
        float? pQty = null,
        float? pLaterAmtCredit = null,
        float? pLaterAmtDebit = null,
        float? pLaterCurValue = null,
        float? pLaterBaseAmtCredit = null,
        float? pLaterBaseAmtDebit = null,
        bool? pIsPosted = null,
        string pNotes = null,
        int? pStoreId = null,
        int? pCreatedBy = null,
        int? pLastUpdatedBy = null,
        int? pCostCenterId = null,
        int? pTransSeq = null,
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
          "&phInvtype=" + phInvtype+
          "&pCreatedBy=" + pCreatedBy +
          "&pLastUpdatedBy=" + pLastUpdatedBy +
          "&phInvRef=" + phInvRef +
          "&phInvRefDate="+ phInvRefDate+
          "&phInvDate=" + phInvDate +
          "&phStoreId=" + phStoreId +
          "&phNotes=" + phNotes +
          "&phPayCash=" + phPayCash +
          "&phPayCheck=" + phPayCheck +
          "&phPayLater=" + phPayLater +
          "&phDiscPerc="+ phDiscPerc+
          "&phInvDisc="+ phInvDisc+
          "&phInvBaseAmt="+ phInvBaseAmt+

          "&phCustomerId=" + phCustomerId +
          "&phInvIsCancel=" + phInvIsCancel +
          "&phIsDeleted=" + phIsDeleted+

          // DTL
          "&pdInvDTLId=" + pdInvDTLId +
          "&pdInvId=" + pdInvId +
          "&pdItemId=" + pdItemId +
          "&pdUnitId=" + pdUnitId +
          "&pdItemPrice=" + pdItemPrice +
          "&pdItemQty=" + pdItemQty +
          "&pdExpireDate="+ pdExpireDate+
          "&pdDiscType=" + pdDiscType +
          "&pdDiscValue=" + pdDiscValue +
          "&pdItemCurVALUE=" + pdItemCurVALUE +
          "&pdNotes=" + pdNotes +
          "&pdIsDeleted=" + pdIsDeleted +
          "&pdTotalItemSbaseCredit="+ pdTotalItemSbaseCredit+
          "&pdTotalItemCredit=" + pdTotalItemCredit +
         "&pdTotalItemDebit=" + pdTotalItemDebit +
          "&pdTotalBaseItemCredit=" + pdTotalBaseItemCredit +
          "&pdTotalBaseItemDebit=" + pdTotalBaseItemDebit +
          "&pdVatAMT="+ pdVatAMT+
           "&pdDiscAmtCredit="+ pdDiscAmtCredit+
            //Later
            "&pInvLaterId=" + pInvLaterId +
            "&pLInvId=" + pLInvId +
            "&pAccountId=" + pAccountId +
            "&pQty=" + pQty +
            "&pLaterAmtCredit=" + pLaterAmtCredit +
            "&pLaterCurValue=" + pLaterCurValue +
            "&pLaterBaseAmtCredit=" + pLaterBaseAmtCredit +
            "&pNotes=" + pNotes +
            "&pCostCenterId=" + pCostCenterId +
            "&pIsDeleted=" + pIsDeleted +
            "&ppType=" + ppType +
            "&pQueryTypeId=" + pQueryTypeId;

       
            //"&phYEAR="+ phYEAR+
            //"&phSellerId="+ phSellerId+
            
           
            //"&phIsPosted="+ phIsPosted+
            //"&phDiscAmt="+ phDiscAmt+
            //"&phInvSubCost="+ phInvSubCost+
            //"&phPermitId="+ phPermitId+
            //"&phPermitType="+ phPermitType+
            //"&phOrderType="+ phOrderType+
            //"&phOrderId="+ phOrderId+
            //"&phSaleTax="+ phSaleTax+
            //"&phSaleTax2="+ phSaleTax2+
            //"&phPerson="+ phPerson+
            //"&phInvSeq="+ phInvSeq+
         
            //"&phInvCurValue="+ phInvCurValue+
            //"&phInvCur="+ phInvCur+
       
            //"&phPermitYear="+ phPermitYear+
            //"&phBankId="+ phBankId+
            //"&phBranchId="+ phBranchId+
            //"&phCardNo="+ phCardNo+
            //"&phAccountId="+ phAccountId+
            //"&phExpireDate="+ phExpireDate+
            //"&phCardType="+ phCardType+
            //"&phAMT="+ phAMT+
            //"&phCurValue="+ phCurValue+
            //"&phBaseAmt="+ phBaseAmt+
            //"&phBankSource="+ phBankSource+
            //"&phPayVisa="+ phPayVisa+
            //"&phAreaId="+ phAreaId+
            //"&phQutId="+ phQutId+
            //"&phQutType="+ phQutType+
            //"&phTypeId="+ phTypeId+
            //"&phPAYED="+ phPAYED+
            //"&phGetComm="+ phGetComm+
            //"&phDELIVERIES="+ phDELIVERIES+
            //"&phReturnOnDelivery="+ phReturnOnDelivery+
            //"&phGoodInvId="+ phGoodInvId+
            //"&phSetSaleRet="+ phSetSaleRet+
            //"&phRetOnDelyear="+ phRetOnDelyear+
            //"&phPatId="+ phPatId+
            //"&phVisitNo="+ phVisitNo+
            //"&phReqNo="+ phReqNo+
            //"&phSurgId="+ phSurgId+
            //"&phDebitType="+ phDebitType+
            //"&phInsurTrans="+ phInsurTrans+
            //"&phContNo="+ phContNo+
            //"&phInsurancePerc="+ phInsurancePerc+
            //"&phCmpAccId="+ phCmpAccId+
            //"&phSalesId="+ phSalesId+
            //"&phFromBranches="+ phFromBranches+
            //"&phInvIsWait="+ phInvIsWait+
            //"&phPeriodId="+ phPeriodId+
            //"&phBranchCompId="+ phBranchCompId+
            //"&phBranchTransId="+ phBranchTransId+
            //"&phCompanyId="+ phCompanyId+
            //"&phInvoiceIsActive="+ phInvoiceIsActive+
            //"&pdInvType="+ pdInvType+
            //"&pdYEAR="+ pdYEAR+
            //"&pdStoreId="+ pdStoreId+
            
            //"&pdBackType="+ pdBackType+
            //"&pdBackId="+ pdBackId+
            //"&pdBackYear="+ pdBackYear+
            //"&pdGuaranteeDate="+ pdGuaranteeDate+
          
           
            //"&pdDiscAmtDebit="+ pdDiscAmtDebit+
            //"&pdDiscBaseCredit="+ pdDiscBaseCredit+
            //"&pdDiscBaseDebit="+ pdDiscBaseDebit+
            //"&pdIsPosted="+ pdIsPosted+
            //"&pdAccountId="+ pdAccountId+
            //"&pdItemCostDebit="+ pdItemCostDebit+
            //"&pdItemCostCredit="+ pdItemCostCredit+
            //"&pdSellAccId="+ pdSellAccId+
            //"&pdCostAccId="+ pdCostAccId+
            //"&pdDiscAccId="+ pdDiscAccId+
            //"&pdTaxAccId="+ pdTaxAccId+
            //"&pdTaxDebit="+ pdTaxDebit+
            //"&pdTaxBaseDebit="+ pdTaxBaseDebit+
            //"&pdItemCost="+ pdItemCost+
            //"&pdTaxBaseCredit="+ pdTaxBaseCredit+
            //"&pdTaxCredit="+ pdTaxCredit+
            //"&pdBackSellAccId="+ pdBackSellAccId+
            //"&pdBackBuyAccId="+ pdBackBuyAccId+
            //"&pdItemStoreCurValue="+ pdItemStoreCurValue+
            //"&pdItemCur="+ pdItemCur+
            
            //"&pdTotalItemSbaseDebit="+ pdTotalItemSbaseDebit+
            //"&pdItemDefCur="+ pdItemDefCur+
            //"&pdTransSeq="+ pdTransSeq+
            //"&pdEmpAccId="+ pdEmpAccId+
            //"&pdEmpAmt="+ pdEmpAmt+
            //"&pdEmpBaseAmt="+ pdEmpBaseAmt+
            //"&pdEmpRatio="+ pdEmpRatio+
            //"&pdEmpCurValue="+ pdEmpCurValue+
            //"&pdItemCostBase="+ pdItemCostBase+
            //"&pdDelivId="+ pdDelivId+
            //"&pdDelYear="+ pdDelYear+
            //"&pdDelTransSeq="+ pdDelTransSeq+
            //"&pdInStoreId="+ pdInStoreId+
            //"&pdNonDescribe="+ pdNonDescribe+
            //"&pdDate="+ pdDate+
            //"&pdItemName="+ pdItemName+
         
            //"&pdVatDebitAccId="+ pdVatDebitAccId+
            //"&pdVatCreditAccId="+ pdVatCreditAccId+
            //"&pdInvIsActive="+ pdInvIsActive+
            //"&pInvType="+ pInvType+
            //"&pYEAR=" + pYEAR+
            //"&pLaterAmtDebit="+ pLaterAmtDebit+
            //"&pLaterBaseAmtDebit="+ pLaterBaseAmtDebit+
            //"&pIsPosted="+ pIsPosted+
            //"&pStoreId="+ pStoreId+
            //"&pTransSeq="+ pTransSeq+

            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }


       public ActionResult StoreSearch()
        {
            return View();
        }
        public ActionResult BranchSearch()
        {
            return View();
        }
        public ActionResult UnitSearch()
        {
            return View();
        }
        public ActionResult UnitSearchProduct()
        {
            return View();
        }
        public ActionResult InvoiceSearch()
        {
            return View();
        }

        public void ShowSimple()
        {
            int vInvId = Convert.ToInt32( Session["InvId"]);
            int InvType = Convert.ToInt32( Session["InvType"]);
            DataTable DT = _dbINVInvoice.funGetInvoicePaymentOrderReport(pInvId: vInvId,InvType: InvType);
            string vReportPath = Server.MapPath("~/Reports") + "//InvoicePaymentOrderReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult InvoicePaymentOrderHtmlReport(int? pInvId = null, int? InvType = null)
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
        public ActionResult InvoicePaymentOrderReport(int? pInvId = null,int?InvType=null)
        {
            ViewBag.vbInvId = pInvId;
            ViewBag.vbInvType = InvType;
            Session["InvId"] = ViewBag.vbInvId;
            Session["InvType"] = ViewBag.vbInvType;
            return View();
        }
    }
}