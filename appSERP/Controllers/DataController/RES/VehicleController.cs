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
    public class VehicleController : Controller
    {
        private ILog _ILog;
        private IdbVehicle _dbVehicle;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public VehicleController(ILog log, IdbVehicle dbVehicle, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbVehicle = dbVehicle;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Vehicle
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public string GetVehicle(int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleIsActive=" + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string GetVehicleByLst(string pListVehicles = null, int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pListVehicles=" + pListVehicles + "&&pVehicleIsActive = " + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 406;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetFirstVehicle(int? pVehicleIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleIsActive=" + pVehicleIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 402;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetLastVehicle(int? pVehicleIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleIsActive=" + pVehicleIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 403;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string SaveVehicle(int? pVehicleId = null, int? pVecStatus = null, string pVehicleCode = null, string pVecDescL1 = null, string pVecDescL2 = null, DateTime? pInitialDate = null, string pPanelNumber = null, int? pVecModelId = null, string pVecVINNO = null, int? pVecTypeId = null, int? pBrandId = null, int? pVecColorId = null, string pComments = null, string pVehicleImage = null, bool? pVehicleIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleId=" + pVehicleId + "&&pVecStatus=" + pVecStatus + "&&pVehicleCode=" + pVehicleCode + "&&pVehicleCode=" + pVehicleCode + "&&pVecDescL1=" + pVecDescL1 + "&&pVecDescL2=" + pVecDescL2 + "&&pInitialDate=" + Convert.ToDateTime(pInitialDate).ToString("yyyy-MM-dd") + "&&pPanelNumber=" + pPanelNumber + "&&pVecModelId=" + pVecModelId + "&&pVecVINNO=" + pVecVINNO + "&&pVecTypeId=" + pVecTypeId + "&&pBrandId=" + pBrandId + "&&pVecColorId=" + pVecColorId + "&&pComments=" + pComments + "&&pVehicleIsActive=" + pVehicleIsActive + "&&pVehicleImage=" + pVehicleImage + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteVehicle(int? pVehicleId = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleId=" + pVehicleId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehicleById(int? pVehicleId = null, int? pPrinterIsActive = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET??pVehicleId=" + pVehicleId + "&&pVehicleIsActive = " + pPrinterIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVecStatus()
        {
            string vAPIPath = "/APIVehStatus/VehStatusGET?pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehType(int? pCodeId = null)
        {
            string vAPIPath = "/APIVehType/VehTypeGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehBrand(int? pCodeId = null)
        {
            string vAPIPath = "/APIVehBrand/VehBrandGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehColor(int? pCodeId = null)
        {
            string vAPIPath = "/APIVehColor/VehColorGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetVehModel(int? pCodeId = null)
        {
            string vAPIPath = "/APIVehModel/VehModelGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult SearchVehModel()
        {
            return View();
        }
        public ActionResult SearchVehType()
        {
            return View();
        }
        public ActionResult SearchVehBrand()
        {
            return View();
        }
        public ActionResult SearchVehColor()
        {
            return View();
        }
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                string fileName = file.FileName;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Image/DataImage/") + fileName); //File will be saved in application root
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }
        public ActionResult VehicleSearch()
        {
            return View();
        }
        // GET: ConfirmDelete
        [HttpGet]
        public ActionResult ShowComment()
        {
            

            return View();
        }
        public string GetVehicleByCode(int? pVehicleCode = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleCode=" + pVehicleCode + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SearchVehicleByCode(int? pVehicleCode = null)
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleCode=" + pVehicleCode + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 407;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetSelectLists()
        {
            string vAPIPath = "/APIVehicle/VehicleGET?pQueryTypeId=" + 408;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        //function funGetVehiclesBySearch(pVehicleCode, pStatus, pType, pBrand, pColor, pDate)
        public string FilterVehicles(string pVehicleCode = null, string pStatus = null,string pType = null, string pBrand = null, string pColor = null, string pDate = null)
        {
      
            string vAPIPath = "/APIVehicle/VehicleGET?pVehicleCode="+ pVehicleCode + "&&pLstStatus=" + pStatus + "&&pLstType=" + pType + "&&pLstBrand=" + pBrand+ "&&pLstColor=" + pColor+ "&&pSearchDate=" + pDate + "&&pQueryTypeId=" + 409;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public void ShowSimple()
        {

            //int vCompany = Convert.ToInt32(Session["SCompany"]);
            DataTable DT = _dbVehicle.funGetVehicleReport();
            string vReportPath = Server.MapPath("~/Reports") + "//VehiclesReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult VehicleReport(int? pCompanyId = null)
        {
            //ViewBag.vbCompanyId = pCompanyId;
            //Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }

    }
}