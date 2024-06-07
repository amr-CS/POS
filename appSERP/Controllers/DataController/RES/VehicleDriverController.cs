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

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class VehicleDriverController : Controller
    {
        private object clReporting;
        private ILog _ILog;
        private IdbVehicleDriver _dbVehicleDriver;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public VehicleDriverController(ILog log, IdbVehicleDriver dbVehicleDriver, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbVehicleDriver = dbVehicleDriver;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: VehicleDriver
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public string GetVehicleDriver(int? pVehicleIsActive = null)
        {
            string vAPIPath = "/APIVehicleDriver/VehicleDriverGET?pVehicleIsActive=" + pVehicleIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveVehicleDriver( int? pVehicleDriverId = null,string pVehicleDriverCode = null,int? pVehicleId = null,int? pDriverId = null,DateTime? pTransactionDate = null,decimal? pCounter = null,string pNotes = null,bool? pVehicleDriverIsActive = null)
        {
            string vAPIPath = "/APIVehicleDriver/VehicleDriverGET?pVehicleDriverId=" + pVehicleDriverId + "&&pVehicleDriverCode=" + pVehicleDriverCode + "&&pVehicleId=" + pVehicleId + "&&pDriverId=" + pDriverId + "&&pTransactionDate=" + Convert.ToDateTime(pTransactionDate).ToString("yyyy-MM-dd") + "&&pCounter=" + pCounter + "&&pNotes=" + pNotes + "&&pVehicleDriverIsActive=" + pVehicleDriverIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteVehicleDriver(int? pVehicleDriverId = null)
        {
            string vAPIPath = "/APIVehicleDriver/VehicleDriverGET?pVehicleDriverId="+ pVehicleDriverId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult SearchVehicle()
        {


            return View();
        }
        public void ShowSimple()
        {
   
                //int vCompany = Convert.ToInt32(Session["SCompany"]);
                DataTable DT = _dbVehicleDriver.funGetVehicleDriverReport();
                string vReportPath = Server.MapPath("~/Reports") + "//VehicleDriverReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
              

        }
        public ActionResult VehicleDriverReport(int? pCompanyId = null)
        {
            //ViewBag.vbCompanyId = pCompanyId;
            //Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }
        public ActionResult SearchVehicleDriver()
        {


            return View();
        }
        //public string FilterVehicleDriver(string pVehicleDriverCode = null, string pVecDescL1 = null, string pResEmployeeNameL1 = null, string pTransactionDate = null)
              public string FilterVehicleDriver(string pVehicleDriverCode = null, string pVehicleCode = null, string pResEmployeeCode = null, string pSearchedDate = null, string pList = null)
        {
            string vAPIPath;
            if (pVehicleCode.Contains(',')  && pResEmployeeCode.Contains(','))
            {
                vAPIPath =
           "/APIVehicleDriver/VehicleDriverGET?pVehicleDriverCode=" + pVehicleDriverCode +
           "&&pLstVehicles=" + pVehicleCode +
           "&&pLstDrivers=" + pResEmployeeCode +
           "&&pSearchedDate=" + pSearchedDate +
           "&&pIsDeleted=" + false +
           "&&pQueryTypeId=" + 401;
            }
            else if (pVehicleCode.Contains(',') && pResEmployeeCode.Contains(',') == false)
            {
                vAPIPath =
   "/APIVehicleDriver/VehicleDriverGET?pVehicleDriverCode=" + pVehicleDriverCode +
   "&&pLstVehicles=" + pVehicleCode +
   "&&pResEmployeeCode=" + pResEmployeeCode +
   "&&pSearchedDate=" + pSearchedDate +
   "&&pIsDeleted=" + false +
   "&&pQueryTypeId=" + 401;
            }
            else if (pVehicleCode.Contains(',') == false&& pResEmployeeCode.Contains(',') )
            {
                vAPIPath =
"/APIVehicleDriver/VehicleDriverGET?pVehicleDriverCode=" + pVehicleDriverCode +
"&&pVehicleCode=" + pVehicleCode +
"&&pLstDrivers=" + pResEmployeeCode +
"&&pSearchedDate=" + pSearchedDate +
"&&pIsDeleted=" + false +
"&&pQueryTypeId=" + 401;
            }
            else
            {
                vAPIPath =
        "/APIVehicleDriver/VehicleDriverGET?pVehicleDriverCode=" + pVehicleDriverCode +
        "&&pVehicleCode=" + pVehicleCode +
        "&&pResEmployeeCode=" + pResEmployeeCode +
        "&&pSearchedDate=" + pSearchedDate +
        "&&pIsDeleted=" + false +
        "&&pQueryTypeId=" + 401;
            }
        
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehicleDriverList(string pLstVehicleDriver = null)
        {
            string vAPIPath = "/APIVehicleDriver/VehicleDriverGET?pLstVehicleDriver="+ pLstVehicleDriver + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 403;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehiclesAndDrivers()
        {
            string vAPIPath = "/APIVehicleDriver/VehicleDriverGET?pQueryTypeId=" + 404;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

    }
}