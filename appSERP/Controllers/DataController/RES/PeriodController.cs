using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    public class PeriodController : Controller
    {
        private ILog _ILog;
        private IdbPeriod _dbPeriod;
        private IDevCompanySetting _DevCompanySetting;
        public PeriodController(ILog log, IdbPeriod dbPeriod, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbPeriod = dbPeriod;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Pdriod
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            FillPeriod();
            DataRow LastDT = _dbPeriod.funPeriodGET(pIsPosted: true, pIsDeleted: false, pFromDate: DateTime.Now, pQueryTypeId: 401).Rows[0];
            ViewBag.LastPeriodId = LastDT["PeriodId"];
            ViewBag.LastDateFrom = LastDT["FromDate"];
            ViewBag.LastDateTo = LastDT["ToDate"];

            return View();
        }
        public ActionResult Period()
        {
            FillPeriod();

            return View();
        }
        [HttpPost]
        public string PostSorePeriod(DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            string message = _dbPeriod.PostStorePeriodGET(DateFrom: DateFrom, DateTo: DateTo);
            return message;
        }
        [HttpPost]
        public string PostInvoice(int? InvId)
        {
            string message = _dbPeriod.PostInvoice(InvId);
            return message;
        }


        public void FillPeriod()
        {
            DataTable data = _dbPeriod.funPeriodGET(pIsPosted: false, pIsDeleted: false, pFromDate: DateTime.Now, pQueryTypeId: 401);
            if (data.Rows.Count > 0)
            {
                DataRow DT = data.Rows[0];
                ViewBag.PeriodId = DT["PeriodId"];
                ViewBag.DateFrom = DT["FromDate"];
                ViewBag.DateTo = DT["ToDate"];

                // Add Day To Period
                DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);
                DateTime OpenDateTo = OpenDateFrom.AddDays(1);

                // ViewBag
                ViewBag.OpenDateFrom = OpenDateFrom;
                ViewBag.OpenDateTo = OpenDateTo;


            }


        }

        [HttpPost]
        public string SavePeriod(int? PeriodId = null, DateTime? DateFrom = null, DateTime? DateTo = null, bool? IsPosted = null, int? pQueryTypeId = 101)
        {
            DataRow DT = _dbPeriod.funPeriodGET(pPeriodId: PeriodId, pFromDate: DateFrom, pToDate: DateTo, pIsPosted: IsPosted, pIsDeleted: false, pQueryTypeId: pQueryTypeId).Rows[0];
            ViewBag.row = DT;

            string JSONString = JsonConvert.SerializeObject(DT);
            return JSONString;
            // return RedirectToAction("Period");
        }

        public ActionResult CancelPeriod()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            FillPeriod();

            return View();

        }
        public ActionResult PartialCancelPeriod()
        {
            FillPeriod();

            return View();

        }
    }
}