using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
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
    [NoDirectAccess]
    [Authorize]
    public class LookupController : Controller
    {
        // GET: Lookup
        private ILog _ILog;
        private IdbLookup _dbLookup;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public LookupController(ILog log, IdbLookup dbLookup, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbLookup = dbLookup;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

       


        public string LookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        string pdDate1 = null,
        string pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = clsQueryType.qSelect,
        string pSelectList = null
        )
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APILookup/LookupGet";
            // Praremeter
            string vParameters =
           "?pLookupId=" + pLookupId +
            "&pLookupParentId=" + pLookupParentId +
            "&pLookupCode=" + pLookupCode +
            "&pLookupSeq=" + pLookupSeq +
            "&pLookupDescL1=" + pLookupDescL1 +
            "&pLookupDescL2=" + pLookupDescL2 +
            "&pParentId=" + pParentId +
            "&pLookupGroup=" + pLookupGroup +
            "&pLookupStatus=" + pLookupStatus +
            "&pHC=" + pHC +
            "&pNotes=" + pNotes +
            "&pUserPriv=" + pUserPriv +
            "&pParentIdDtl=" + pParentIdDtl +
            "&pIsDeleted=" + pIsDeleted +
            "&pLookupDtlId=" + pLookupDtlId +
            "&pdLookupDtlCode=" + pdLookupDtlCode +
            "&pdLookupDtlDesc=" + pdLookupDtlDesc +
            "&pdLookupDtlDescL=" + pdLookupDtlDescL +
            "&pdLookupDtlDescShort=" + pdLookupDtlDescShort +
            "&pdLookupDtlDescShortL=" + pdLookupDtlDescShortL +
            "&pdLookupDtlDesc2=" + pdLookupDtlDesc2 +
            "&pdLookupDtlDesc2L=" + pdLookupDtlDesc2L +
            "&pdLookupDtlSeq=" + pdLookupDtlSeq +
            "&pdTypeSeq=" + pdTypeSeq +
            "&pdORD=" + pdORD +
            "&pdDflt=" + pdDflt +
            "&pdLookupDtlStatus=" + pdLookupDtlStatus +
            "&pdNotes=" + pdNotes +
            "&pdValue1=" + pdValue1 +
            "&pdValue2=" + pdValue2 +
            "&pdValue3=" + pdValue3 +
            "&pdValLink=" + pdValLink +
            "&pdDate1=" + pdDate1 +
            "&pdDate2=" + pdDate2 +
            "&pdText=" + pdText +
            "&pdAccountId=" + pdAccountId +
            "&pdAccountId2=" + pdAccountId2 +
            "&pdIsDeleted=" + pdIsDeleted +
            "&pIsDetail=" + pIsDetail +
            "&pQueryTypeId=" + pQueryTypeId +
            "&pSelectList=" + pSelectList;
            if (pQueryTypeId == 300)
            {
                vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            }
            else
            {
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

                // JSON
                vResult = JsonConvert.SerializeObject(vDtData);
            }

        

            // Return Result
            return vResult;


        }

        // Lookup DEsc Modal
        public ActionResult MenuSearch()
        {

            return View();
        }
        // Lookup DEsc Modal
        public ActionResult LookupSearch()
        {

            return View();
        }
        public void ShowSimple()
        {
            DataTable DT = _dbLookup.funGetLookupReport();
            string vReportPath = Server.MapPath("~/Reports") + "//LookupReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult LookupReport()
        {

            return View();
        }

       


    }
}