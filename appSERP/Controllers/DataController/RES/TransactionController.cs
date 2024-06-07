using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.Logger;
using appSERP.Reports;
using appSERP.Reports.POS;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class TransactionController : Controller
    {
        private ILog _ILog;
        private IdbGLTransaction _dbGLTransaction;
        private IdbPeriod _dbPeriod;
        private IDevCompanySetting _DevCompanySetting;
        public TransactionController(ILog log, IdbGLTransaction dbGLTransaction, IdbPeriod dbPeriod, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbGLTransaction = dbGLTransaction;
            _dbPeriod = dbPeriod;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Transaction
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];
            return View();
        }
        public ActionResult Report(int? ItemId=null,DateTime?DateFrom=null,DateTime?DateTo=null, int? InvTypeId = null,
          int? StoreId = null)
        {
            
            ItemMovement1 rpt = new ItemMovement1();

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
              FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
              rpt.Parameters["ItemId"].Value = ItemId;
              rpt.Parameters["DateFrom"].Value = DateFrom;
              rpt.Parameters["DateTo"].Value = DateTo;
              rpt.Parameters["InvTypeId"].Value = InvTypeId;
              rpt.Parameters["StoreId"].Value = StoreId;
              rpt.CNameL1.Text = clsCompany.vCompanyLanguage1NameL1;
              rpt.CNameL2.Text = clsCompany.vCompanyLanguage1NameL1;
              rpt.mobile.Text = clsCompany.vCompanyPhone1;
              rpt.Brnch.Text = clsBranch.vBranchName;

              rpt.RequestParameters = false;
              using (MemoryStream ms = new MemoryStream())
              {
                  rpt.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                  return File(ms.ToArray(), "application/pdf");
              }
        }
        public ActionResult TransactionHtmlReport(
          int? ItemId = null, DateTime? DateFrom = null, DateTime? DateTo = null, int? InvTypeId = null,
          int? StoreId = null,int? reportTypeId= null)
        {

            DataTable vDT = _dbGLTransaction.funTransactionReport(ItemId,DateFrom,DateTo,InvTypeId,
          StoreId, reportTypeId);

            //if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows.Count > 0 ? vDT.Rows[0]:null;
                //DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة المخزون";
                ViewBag.DateTo = DateTo;
                ViewBag.DateFrom = DateFrom;
                ViewBag.CompanyBranchNameL2 = clsCompany.vCompanyNameL2;
                ViewBag.CompanyBranchNameL1 = clsCompany.vCompanyNameL1;
                ViewBag.CompanyBranchTel = clsCompany.vCompanyPhone1;
            }
            return View();
        }
        public ActionResult TransactionDtlReport(int? ItemId = null, DateTime? DateFrom = null, DateTime? DateTo = null, int? InvTypeId = null,
          int? StoreId = null)
        {
            ItemMovementdtl rpt = new ItemMovementdtl();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            rpt.Parameters["ItemId"].Value = ItemId;
            rpt.Parameters["DateFrom"].Value = DateFrom;
            rpt.Parameters["DateTo"].Value = DateTo;
            rpt.Parameters["InvTypeId"].Value = InvTypeId;
            rpt.Parameters["StoreId"].Value = StoreId;

            rpt.CNameL1.Text = clsCompany.vCompanyLanguage1NameL1;
            rpt.CNameL2.Text = clsCompany.vCompanyLanguage1NameL1;
            rpt.mobile.Text = clsCompany.vCompanyPhone1;
            rpt.Brnch.Text = clsBranch.vBranchName;

            rpt.RequestParameters = false;
            using (MemoryStream ms = new MemoryStream())
            {
                rpt.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                return File(ms.ToArray(), "application/pdf");
            }
        }
    }
}