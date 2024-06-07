using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController
{
    [NoDirectAccess]
    [Authorize]
    public class PrintersController : Controller
    {
        private ILog _ILog;
        private IdbPrinter _dbPrinter;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public PrintersController(ILog log, IdbPrinter dbPrinter, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbPrinter = dbPrinter;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Printers
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        public string SavePrinter(int? pPrinterId = null, string pReportNameL1 = null, string pReportNameL2 = null, string pPrinterDescL1 = null, string pPrinterDescL2 = null, bool? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pPrinterId=" + pPrinterId + "&&pReportNameL1=" + pReportNameL1 + "&&pReportNameL2=" + pReportNameL2 + "&&pPrinterDescL1=" + pPrinterDescL1 + "&&pPrinterDescL2=" + pPrinterDescL2 + "&&pPrinterIsActive=" + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        
        public string SavePrinterDTL(int? pPrinterDTLId = null,string pPrinterDTLCode = null,int? pPrinterDTLSeq = null,int? pInvTypeId = null, string pPrinterName = null,string pPrinterIP = null,int? pPortTypeId = null,int? pPortNo = null,int? pDirectPrintId = null,int? pPrintNum = null, int? pPrinterId = null, bool? pPrinterDTLIsActive = null)
        {
            string vAPIPath = "/APIPrinterDTL/PrinterDTLGET?pPrinterDTLId=" + pPrinterDTLId + "&&pPrinterDTLCode=" + pPrinterDTLCode + "&&pPrinterDTLSeq=" + pPrinterDTLSeq + "&&pInvTypeId=" + pInvTypeId + "&&pPrinterName=" + pPrinterName + "&&pPrinterIP=" + pPrinterIP + "&&pPortTypeId=" + pPortTypeId + "&&pPortNo=" + pPortNo + "&&pDirectPrintId=" + pDirectPrintId + "&&pPrintNum=" + pPrintNum + "&&pPrinterId=" + pPrinterId + "&&pPrinterDTLIsActive=" + pPrinterDTLIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;

        }
        public string DeletePrinter(int? pPrinterId = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pPrinterId=" + pPrinterId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeletePrinterDTL(int? pPrinterDTLId = null)
        {
            string vAPIPath = "/APIPrinterDTL/PrinterDTLGET?pPrinterDTLId=" + pPrinterDTLId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string GetPrinter(int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pPrinterIsActive=" + pPrinterIsActive +"&&pIsDeleted="+false+"&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string GetPrinterDTL(int? pPrinterId = 0, int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIPrinterDTL/PrinterDTLGET?pPrinterId=" + pPrinterId + "&&pPrinterDTLIsActive=" + pPrinterIsActive + "&&pIsDeleted="+false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        //public string DeletePrinter()
        //{
        //    string vAPIPath = "/APIPrinter/PrinterGET?pIsDeleted =1" + "&&pQueryTypeId=" + 300;
        //    string vJSONResult = clsAPI.funResultGetJSON(vAPIPath);

        //    return vJSONResult;
        //}
        //public string DeletePrinterDTL()
        //{
        //    string vAPIPath = "/APIPrinterDTL/PrinterDTLGET?pIsDeleted =1" + "&&pQueryTypeId=" + 300;
        //    string vJSONResult = clsAPI.funResultGetJSON(vAPIPath);

        //    return vJSONResult;
        //}
        public string GetPortType(int? pPortTypeIsActive = null)
        {
            string vAPIPath = "/APIPortType/PortTypeGET?pPortTypeIsActive=" + pPortTypeIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetDirectPrint(int? pDirectPrintIsActive = null)
        {
            string vAPIPath = "/APIDirectPrint/DirectPrintGET?pDirectPrintIsActive=" + pDirectPrintIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetFirstDirectPrint(int? pDirectPrintIsActive = null)
        {
            string vAPIPath = "/APIDirectPrint/DirectPrintGET?pDirectPrintIsActive=" + pDirectPrintIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 402;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetLastDirectPrint(int? pDirectPrintIsActive = null)
        {
            string vAPIPath = "/APIDirectPrint/DirectPrintGET?pDirectPrintIsActive=" + pDirectPrintIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 403;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetPreviousDirectPrint(int? pDirectPrintIsActive = null, int? pPrinterId = null)
        {
            string vAPIPath = "/APIDirectPrint/DirectPrintGET?pPrinterId="+ pPrinterId + "&&pDirectPrintIsActive=" + pDirectPrintIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 404;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetNextDirectPrint(int? pDirectPrintIsActive = null, int? pPrinterId = 0)
        {
            string vAPIPath = "/APIDirectPrint/DirectPrintGET?pPrinterId=" + pPrinterId + "&&pDirectPrintIsActive=" + pDirectPrintIsActive + "&&pIsDeleted =0" + "&&pQueryTypeId=" + 405;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetAllPrinters(int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pPrinterIsActive=" + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 406;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetSelectLists()
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pQueryTypeId=" + 407;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult SearchPrinter()
        {
            return View();
        }

        public string FilterPrinters( string pPrinterCode = null, string pPrinterDescL1 = null, string pPrinterDescL2 = null, bool? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pPrinterCode="+ pPrinterCode + "&&pPrinterDescL1=" + pPrinterDescL1 + "&&pPrinterDescL2=" + pPrinterDescL2 + "&&pPrinterIsActive=" + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 408;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string GetPrintersList(string pPrintersList = null)
        {
            string vAPIPath = "/APIPrinter/PrinterGET?pQueryTypeId=" + 409 + "&&pPrintersList=" + pPrintersList ;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public void ShowSimple()
        {

            //int vCompany = Convert.ToInt32(Session["SCompany"]);
            DataTable DT = _dbPrinter.funGetPrinterReport();
            string vReportPath = Server.MapPath("~/Reports") + "//PrintersReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult PrintersReport(int? pCompanyId = null)
        {
            //ViewBag.vbCompanyId = pCompanyId;
            //Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }
        public ActionResult SearchPrinterDTL()
        {
            return View();
        }

    }
}