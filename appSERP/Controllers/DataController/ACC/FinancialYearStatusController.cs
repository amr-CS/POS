using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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
    public class FinancialYearStatusController : Controller
    {
        private IdbFinancialYearStatus _dbFinancialYearStatus;
        private IclsAPI _clsAPI;
        public FinancialYearStatusController(IdbFinancialYearStatus dbFinancialYearStatus, IclsAPI clsAPI)
        {
            _dbFinancialYearStatus = dbFinancialYearStatus;
            _clsAPI = clsAPI;
        }

        // GET: FinancialYearStatus
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIFinancialYearStatus;
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
            FinancialYearStatusModel vFinancialYearStatusModel = new FinancialYearStatusModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFinancialYearStatus;
                string vParameters = "?pFinancialYearStatusId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFinancialYearStatusModel.FinancialYearStatusId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearStatusId"]);
                vFinancialYearStatusModel.FinancialYearStatusNameL1 = vDtData.Rows[0]["FinancialYearStatusNameL1"].ToString();
                vFinancialYearStatusModel.FinancialYearStatusNameL2 = vDtData.Rows[0]["FinancialYearStatusNameL2"].ToString();
                vFinancialYearStatusModel.FinancialYearStatusIsActive = Convert.ToBoolean(vDtData.Rows[0]["FinancialYearStatusIsActive"]);
               


            }

            // Return Result
            return View(vFinancialYearStatusModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FinancialYearStatusModel pFinancialYearStatusModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFinancialYearStatus;
                string vParameters =
                    "?pFinancialYearStatusId=" + id +
                    "&pFinancialYearStatusNameL1=" + pFinancialYearStatusModel.FinancialYearStatusNameL1 +
                    "&pFinancialYearStatusNameL2=" + pFinancialYearStatusModel.FinancialYearStatusNameL2 +
                    "&pFinancialYearStatusIsActive=" + pFinancialYearStatusModel.FinancialYearStatusIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFinancialYearStatus.vSQLResult = vDrwResult[0].ToString();
                _dbFinancialYearStatus.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
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
            DataTable DT = _dbFinancialYearStatus.funGetFinancialYearStatusReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FinancialYearStatusReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FinancialYearStatusReport()
        {

            return View();
        }
    }
}