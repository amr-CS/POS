using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.User;
using appSERP.Models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC.Doc
{
    public class GLVoucherController : Controller
    {
        int vvGLVoucherId;
        private IdbGLVoucherOld _dbGLVoucherOld;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public GLVoucherController(IdbGLVoucherOld dbGLVoucherOld, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbGLVoucherOld = dbGLVoucherOld;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        // GET: GLVoucher
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
     

        //Save Voucher Box Check MAster
        [HttpPost]
        public string funSaveVoucherBoxCheck(
           string pVoucherBoxCheckId = null,
           string pGLVoucherId = null,
           string pCashDeskId = null,
           string pCurrencyId = null,
           string pAccountId = null,
           string pPayDebit = null,
           string pPayCurrencyValue = null,
           string pDebit = null,
           string pBaseCurrencyValue = null,
           string pBaseDebit = null,
           string pCredit = null,
           string pBaseCredit = null,
           string pNote = null,
           string pCostCenterId = null,
           string pVoucherIsCheck = null,
           string pCheckBankId = null,
           string pCheckNo = null,
           string pCheckDate = null,
           string pCheckDebit = null,
           string pCheckCurrencyValue = null,
           string pCheckBaseDebit = null,
           string pCheckNote = null,
           string pCheckCostCenterId = null,
           string pCheckBankBranchId = null,
           string pPayTypeId = null,
           string pEPayTypeId = null,
           string pIsDeleted = null,
           string pQueryTypeId = null)
        {
            // Path
            string vPath = "/APIVoucherBoxCheck/VoucherBoxCheckGET";
            // Paramter
            string vParameters = "?pVoucherBoxCheckId=" + pVoucherBoxCheckId +
                        "&pGLVoucherId=" + pGLVoucherId +
                        "&pCashDeskId=" + pCashDeskId +
                        "&pCurrencyId=" + pCurrencyId +
                        "&pAccountId=" + pAccountId +
                        "&pPayDebit=" + pPayDebit +
                        "&pPayCurrencyValue=" + pPayCurrencyValue +
                        "&pDebit=" + pDebit +
                        "&pBaseCurrencyValue=" + pBaseCurrencyValue +
                        "&pBaseDebit=" + pBaseDebit +
                        "&pCredit=" + pCredit +
                        "&pBaseCredit=" + pBaseCredit +
                        "&pNote=" + pNote +
                        "&pCostCenterId=" + pCostCenterId +
                        "&pVoucherIsCheck=" + pVoucherIsCheck +
                        "&pCheckBankId=" + pCheckBankId +
                        "&pCheckNo=" + pCheckNo +
                        "&pCheckDate=" + pCheckDate +
                        "&pCheckDebit=" + pCheckDebit +
                        "&pCheckCurrencyValue=" + pCheckCurrencyValue +
                        "&pCheckBaseDebit=" + pCheckBaseDebit +
                        "&pCheckNote=" + pCheckNote +
                        "&pCheckCostCenterId=" + pCheckCostCenterId +
                        "&pCheckBankBranchId=" + pCheckBankBranchId +
                        "&pPayTypeId=" + pPayTypeId +
                        "&pEPayTypeId=" + pEPayTypeId +
                        "&pIsDeleted=" + pIsDeleted +
                        "&pQueryTypeId=" + pQueryTypeId;
            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }


        // GL VOUCHER POST
        [HttpPost]
        public string funSaveGLVoucher(
         // Head Parameters
         string phGLVoucherId = null,
         string phVoucherTypeId = null,
         string phFinancialYearId = null,
         string phSystemId = null,
         string phCashDeskId = null,
         string phGLVoucherDate = null,
         string phGLVoucherTime = null,
         string phGLVoucherRef = null,
         string phGLVoucherRefDate = null,
         string phPaymentTypeId = null,
         string phIsPosted = null,
         string phIsIssued = null,
         string phIsOpps = null,
         string phGLVoucherNote = null,
         string phUserId = null,
         string phDocIsCancelled = null,
         string phDocIsWait = null,
         string phGLVoucherIsRepeated = null,
         string phGLIdPayType = null,
         string phGLVoucherCategoryId = null,
         string phGLOppsVoucherValue = null,
         string phGLOppsVoucherId = null,
         string phGLOppsVoucherYearId = null,
         string phStoreId = null,
         string phInvTransactionTypeId = null,
         string phCSId = null,
         string phVoucherSeq = null,
         string phPerson = null,
         string phSalesId = null,
         string phGLVoucherIsActive = null,
         string phIsDeleted = null,
         string phNumbers = null,
         // Detail Parameters
         string pdGLVoucherDtlId = null,
         string pdGLVoucherId = null,
         string pdGLVoucherTypeId = null,
         string pdFinancialYearId = null,
         string pdAccountId = null,
         string pdCashDeskId = null,
         string pdCurrencyId = null,
         string pdGLVoucherDtlDebit = null,
         string pdGLVoucherDtlCredit = null,
         string pdGLVoucherDtlDebitBase = null,
         string pdGLVoucherDtlCreditBase = null,
         string pdBaseCurrencyValue = null,
         string pdGLVoucherDtlPayDebit = null,
         string pdGLVoucherDtlPayCredit = null,
         string pdPayCurrencyValue = null,
         string pdGLVoucherDtlNote = null,
         string pdCostCenterId = null,
         string pdIsPosted = null,
         string pdUserId = null,
         string pdGLVoucherDtlTransSeq = null,
         string pdIsDeleted = null,
         // Search Parameters
         string psGLVoucherNo = null,
         string psDateFrom = null,
         string psDateTo = null,
         // Main Parameters
         string pIsGLVoucherDetail = null,
         string pQueryTypeId = null)
        {
            // Path
            string vPath = "/APIGLVoucher/GLVoucherGET";
            // Head Parameters
            string vParameters = "?phGLVoucherId=" + phGLVoucherId +
                                "&phVoucherTypeId=" + phVoucherTypeId +
                                "&phFinancialYearId=" + phFinancialYearId +
                                "&phSystemId=" + phSystemId +
                                "&phCashDeskId=" + phCashDeskId +
                                "&phGLVoucherDate=" + phGLVoucherDate +
                                "&phGLVoucherTime=" + phGLVoucherTime +
                                "&phGLVoucherRef=" + phGLVoucherRef +
                                "&phGLVoucherRefDate=" + phGLVoucherRefDate +
                                "&phPaymentTypeId=" + phPaymentTypeId +
                                "&phIsPosted=" + phIsPosted +
                                "&phIsIssued=" + phIsIssued +
                                "&phIsOpps=" + phIsOpps +
                                "&phUserId=" + phUserId +
                                "&phGLVoucherNote=" + phGLVoucherNote +
                                "&phDocIsCancelled=" + phDocIsCancelled +
                                "&phDocIsWait=" + phDocIsWait +
                                "&phGLVoucherIsRepeated=" + phGLVoucherIsRepeated +
                                "&phGLIdPayType=" + phGLIdPayType +
                                "&phGLVoucherCategoryId=" + phGLVoucherCategoryId +
                                "&phGLOppsVoucherValue=" + phGLOppsVoucherValue +
                                "&phGLOppsVoucherId=" + phGLOppsVoucherId +
                                "&phGLOppsVoucherYearId=" + phGLOppsVoucherYearId +
                                "&phStoreId=" + phStoreId +
                                "&phInvTransactionTypeId=" + phInvTransactionTypeId +
                                "&phCSId=" + phCSId +
                                "&phVoucherSeq=" + phVoucherSeq +
                                "&phGLVoucherIsActive=" + phGLVoucherIsActive +
                                "&phPerson=" + phPerson +
                                "&phSalesId=" + phSalesId +
                                "&phIsDeleted=" + phIsDeleted +
                                //Detail
                                "&phNumbers=" + phNumbers +
                                // Detail Parameters
                                "&pdGLVoucherDtlId=" + pdGLVoucherDtlId +
                                "&pdGLVoucherId=" + pdGLVoucherId +
                                "&pdGLVoucherTypeId=" + pdGLVoucherTypeId +
                                "&pdFinancialYearId=" + pdFinancialYearId +
                                "&pdAccountId=" + pdAccountId +
                                "&pdCashDeskId=" + pdCashDeskId +
                                "&pdCurrencyId=" + pdCurrencyId +
                                "&pdGLVoucherDtlDebit=" + pdGLVoucherDtlDebit +
                                "&pdGLVoucherDtlCredit=" + pdGLVoucherDtlCredit +
                                "&pdGLVoucherDtlDebitBase=" + pdGLVoucherDtlDebitBase +
                                "&pdGLVoucherDtlCreditBase=" + pdGLVoucherDtlCreditBase +
                                "&pdBaseCurrencyValue=" + pdBaseCurrencyValue +
                                "&pdGLVoucherDtlPayDebit=" + pdGLVoucherDtlPayDebit +
                                "&pdGLVoucherDtlPayCredit=" + pdGLVoucherDtlPayCredit +
                                "&pdPayCurrencyValue=" + pdPayCurrencyValue +
                                "&pdGLVoucherDtlNote=" + pdGLVoucherDtlNote +
                                "&pdCostCenterId=" + pdCostCenterId +
                                "&pdIsPosted=" + pdIsPosted +
                                "&pdUserId=" + pdUserId +
                                "&pdGLVoucherDtlTransSeq=" + pdGLVoucherDtlTransSeq +
                                "&pdIsDeleted=" + pdIsDeleted +
                                // Search Parameters
                                "&psGLVoucherNo=" + psGLVoucherNo +
                                "&psDateFrom=" + psDateFrom +
                                "&psDateTo=" + psDateTo +
                                // Query Type Id
                                "&pIsGLVoucherDetail=" + pIsGLVoucherDetail +
                                "&pQueryTypeId=" + pQueryTypeId;
            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }
     

        

        
        // financial Year Check
        public string funFinancialDateCheckGET(string pDate)
        {
            var vPath = "/APIGLVoucher/FinancialDateCheckGET";
            var vParameters = "?pDate=" + pDate;
            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }
            // Account Search
            public ActionResult AccountSearch()
                {
                    return View();
                }
           
        // Account Cost Center
        public ActionResult AccountCostCenter(int? pAccountId)
        {
            // View Bag - Account Id
            ViewBag.vbAccountId = pAccountId;

            // Return View
            return View();
        }
        // Account Cost Center
        public ActionResult OpenJournal()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            // Return View
            return View();
        }
        public ActionResult Debit()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        public ActionResult Credit()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult ReceiptVoucher()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult PaymentVoucher()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult GLVoucherSearch()
        {

            return View();
        }
        public ActionResult CustomerSupplierSearch()
        {

            return View();
        }
      
        public ActionResult Customers()
        {

            return View();
        }
        public ActionResult CurrencySearch()
        {

            return View();
        }
        public ActionResult CashDeskSearch()
        {

            return View();
        }

        public ActionResult BankSearch()
        {

            return View();
        }
        public ActionResult VoucherCategorySearch()
        {

            return View();
        }
        public ActionResult MainBankSearch()
        {

            return View();
        }

        public ActionResult EPaymentTypeSearch()
        {

            return View();
        }
        public ActionResult Download_PDF(int? pGLVoucherId = null)
        {
            //empEntities context = new empEntities();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "GlVoucherReport.rpt"));
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: pGLVoucherId);
            //rd.SetDataSource(context.emp_table.Select(c => new
            //{
            //    id = c.id,
            //    name = c.name
            //}).ToList());
            //List<Student> studentDetails = new List<Student>();
            rd.SetDataSource(DT);
            rd.SetParameterValue("@GLVoucherId", pGLVoucherId);
            rd.SetParameterValue("@UserId", clsUser.vUserId);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }
        public void ShowSimple()
        {
            using (ReportClass rp = new ReportClass())
            {
                int vGl = Convert.ToInt32( Session["SGlVoucher"]);
                DataTable DT = _dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId:2);
                rp.FileName = Server.MapPath("~/Reports") + "//GlVoucherReport.rpt";
                rp.Load();
                /*Get data from detatbase using Data layer via business layer*/
                rp.SetDataSource(DT);
                rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat,
 System.Web.HttpContext.Current.Response, false, "crReport");
            }
        }
        public void ShowSimpleOpeningReport()
        {
            int vGl = Convert.ToInt32(Session["SOpeningBalance"]);
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 1);
            string vFullPath = Server.MapPath("~/Reports") + "//GlOpeningReport.rpt";
            ClsReport.Printreport( DT, vFullPath);
        }
            //txtDocId
            public ActionResult GlVoucherReport(int? pGLVoucherId = null)
        {
         
            ViewBag.vbGLVoucherId = pGLVoucherId;
            vvGLVoucherId = ViewBag.vbGLVoucherId;
            Session["SGlVoucher"] = ViewBag.vbGLVoucherId;

            return View();
        }
        //txtDocId
        public ActionResult GlOpeningReport(int? pGLVoucherId = null)
        {
          
            ViewBag.vbGLOpeningId = pGLVoucherId;
            Session["SOpeningBalance"] = ViewBag.vbGLOpeningId;

            return View();
        }
        public void ShowDNReport()
        {
            int vGl = Convert.ToInt32(Session["SDN"]);
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 6);
            string vFullPath = Server.MapPath("~/Reports") + "//DNReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult DNReport(int? pGLVoucherId = null)
        {

            ViewBag.vbCNVoucherId = pGLVoucherId;
            Session["SDN"] = ViewBag.vbCNVoucherId;

            return View();
        }
        public void ShowCNReport()
        {
            int vGl = Convert.ToInt32(Session["SCN"]);
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 5);
            string vFullPath = Server.MapPath("~/Reports") + "//CNReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult CNReport(int? pGLVoucherId = null)
        {

            ViewBag.vbCNVoucherId = pGLVoucherId;
            Session["SCN"] = ViewBag.vbCNVoucherId;

            return View();
        }
        public void ShowGlVoucherReceiptReport()
        {
            String vVoucherNo = Session["Receipt"].ToString();
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherReceiptReport(pGLVoucherNo: vVoucherNo);
            string vFullPath = Server.MapPath("~/Reports") + "//GLVoucherReceiptReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult GlVoucherReceiptReport(String pGLVoucherNo = null)
        {

            ViewBag.vbReceiptVoucherId = pGLVoucherNo;
            Session["Receipt"] = ViewBag.vbReceiptVoucherId;

            return View();
        }
        public void ShowGlVoucherPaymentReport()
        {
            String vVoucherNo = Session["Payment"].ToString();
            DataTable DT = _dbGLVoucherOld.funGetGlVoucherPaymentReport(pGLVoucherNo: vVoucherNo);
            string vFullPath = Server.MapPath("~/Reports") + "//GLVoucherPaymentReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult GlVoucherPaymentReport(String pGLVoucherNo = null)
        {

            ViewBag.vbPaymentVoucherId = pGLVoucherNo;
            Session["Payment"] = ViewBag.vbPaymentVoucherId;

            return View();
        }





    }

}