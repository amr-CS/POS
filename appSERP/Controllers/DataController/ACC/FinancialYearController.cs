using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{   ///  BELAL    22/1/2018 
    [NoDirectAccess]
    [Authorize]
    public class FinancialYearController : Controller
    {

        private IdbFinancialYear _dbFinancialYear;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FinancialYearController(IdbFinancialYear dbFinancialYear, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFinancialYear = dbFinancialYear;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: FinancialYear
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFinancialYear = _dbFinancialYear;
            // API Path
            string vPath = appAPIDirectory.vAPIFinancialYear;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);


        }


        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            FinancialYearModel vFinancialYearModel = new FinancialYearModel();
            if (id == 0)
            {
                ViewBag.vbcFinancialYearStatusId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFinancialYear;
                string vParameters = "?pFinancialYearId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcFinancialYearStatusId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearStatusId"]);
                // Set Model Data
                vFinancialYearModel.FinancialYearId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearId"]);
                vFinancialYearModel.FinancialYear = vDtData.Rows[0]["FinancialYear"].ToString();
                vFinancialYearModel.FinancialYearStart = Convert.ToDateTime(vDtData.Rows[0]["FinancialYearStart"]);
                vFinancialYearModel.FinancialYearEnd = Convert.ToDateTime(vDtData.Rows[0]["FinancialYearEnd"]);
                vFinancialYearModel.FinancialYearStatusId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearStatusId"]);
                vFinancialYearModel.FinancialYearIsActive = Convert.ToBoolean(vDtData.Rows[0]["FinancialYearIsActive"]);
            }

            // Return Result
            return View(vFinancialYearModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FinancialYearModel pFinancialYearModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFinancialYear;
                string vParameters =
                    "?pFinancialYearId=" + id +
                     "&pFinancialYear=" + pFinancialYearModel.FinancialYear +
                    "&pFinancialYearStart=" + pFinancialYearModel.FinancialYearStart.Date.ToString("yyyy-MM-dd") +
                    "&pFinancialYearEnd=" + pFinancialYearModel.FinancialYearEnd.Date.ToString("yyyy-MM-dd") +
                     "&pFinancialYearStatusId=" + pFinancialYearModel.FinancialYearStatusId +
                    "&pFinancialYearIsActive=" + pFinancialYearModel.FinancialYearIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFinancialYear.vSQLResult = vDrwResult[0].ToString();
                _dbFinancialYear.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                if (Convert.ToBoolean(pIsDelete)) { return null; }
                else
                { // Go To Index
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public void ShowSimple()
        {
            DataTable DT = _dbFinancialYear.funGetFinancialYearReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FinancialYearReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FinancialYearReport()
        {

            return View();
        }
    }
}