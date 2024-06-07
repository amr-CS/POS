using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class StoreEmployeeController : Controller
    {

        private IdbStoreEmployee _dbStoreEmployee;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public StoreEmployeeController(IdbStoreEmployee dbStoreEmployee, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbStoreEmployee = dbStoreEmployee;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: StoreEmployee
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        // UNIT GET
        public string StoreEmployeeGET(
             int? pStoreEmployeeId = null,
     string pStoreEmployeeCode = null,
   string pStoreEmployeeName = null,
   int? pGeneralNumber = null,
   string pJob = null,
  decimal? pProfit = null,
 DateTime? pEmployeeStartDate = null,
 DateTime? pEmployeeEndDate = null,
 string pNotes = null,
 bool? pStoreEmployeeIsActive = null,
 bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {

            string vParameters = "";
           
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIStoreEmployee;
            // Praremeter
            if (pEmployeeStartDate == null || pEmployeeEndDate == null)
            {
                vParameters =
               "?pStoreEmployeeId=" + pStoreEmployeeId +
               "&pStoreEmployeeCode=" + pStoreEmployeeCode +
               "&pStoreEmployeeName=" + pStoreEmployeeName +
               "&pGeneralNumber=" + pGeneralNumber +
               "&pJob=" + pJob +
               "&pProfit=" + pProfit +
               "&pEmployeeStartDate=" + pEmployeeStartDate +
               "&pEmployeeEndDate=" + pEmployeeEndDate +
               "&pNotes=" + pNotes +
               "&pStoreEmployeeIsActive=" + pStoreEmployeeIsActive +
               "&pIsDeleted=" + pIsDeleted +
               "&pQueryTypeId=" + pQueryTypeId;
            }
            else
            {
                vParameters =
             "?pStoreEmployeeId=" + pStoreEmployeeId +
             "&pStoreEmployeeCode=" + pStoreEmployeeCode +
             "&pStoreEmployeeName=" + pStoreEmployeeName +
             "&pGeneralNumber=" + pGeneralNumber +
             "&pJob=" + pJob +
             "&pProfit=" + pProfit +
             "&pEmployeeStartDate=" + pEmployeeStartDate.Value.Date.ToString("yyyy-MM-dd") +
             "&pEmployeeEndDate=" + pEmployeeEndDate.Value.Date.ToString("yyyy-MM-dd") +
             "&pNotes=" + pNotes +
             "&pStoreEmployeeIsActive=" + pStoreEmployeeIsActive +
             "&pIsDeleted=" + pIsDeleted +
             "&pQueryTypeId=" + pQueryTypeId;
            }
         
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }

        public string GetFilterEmployee(
             bool? pIsDeleted = false,
           string pList = null  )
        {

            string vParameters = "";

            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIStoreEmployee;
            // Praremeter

            vParameters =
           "?pIsDeleted=" + pIsDeleted +
               "&pQueryTypeId=" + 401 +
               "&pList=" + pList;


            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }


        public void ShowSimple()
        {

            DataTable DT = _dbStoreEmployee.funGetStoreEmployeeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//StoreEmployeeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult StoreEmployeeReport(int? pCompanyId = null)
        {

            return View();
        }
        public ActionResult StoreEmployeeSearch(int? pCompanyId = null)
        {

            return View();
        }
    }
}