using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.FA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    ///  Belal    3/3/2018
    public class FixedAssetUnitController : Controller
    {


        private IdbFixedAssetUnit _dbFixedAssetUnit;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FixedAssetUnitController(IdbFixedAssetUnit dbFixedAssetUnit, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFixedAssetUnit = dbFixedAssetUnit;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: FixedAssetUnit
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFixedAssetUnit = _dbFixedAssetUnit;
            // API Path
            string vPath = appAPIDirectory.vAPIFixedAssetUnit;
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
            FixedAssetUnitModel vFixedAssetUnitModel = new FixedAssetUnitModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetUnit;
                string vParameters = "?pFixedAssetUnitId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFixedAssetUnitModel.FixedAssetUnitId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetUnitId"]);
                vFixedAssetUnitModel.FixedAssetUnitNameL1 = vDtData.Rows[0]["FixedAssetUnitNameL1"].ToString();
                vFixedAssetUnitModel.FixedAssetUnitNameL2 = vDtData.Rows[0]["FixedAssetUnitNameL2"].ToString();
                vFixedAssetUnitModel.FixedAssetUnitIsActive = Convert.ToBoolean(vDtData.Rows[0]["FixedAssetUnitIsActive"]);
            }

            // Return Result
            return View(vFixedAssetUnitModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FixedAssetUnitModel pFixedAssetUnitModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetUnit;
                string vParameters =
                    "?pFixedAssetUnitId=" + id +
                    "&pFixedAssetUnitNameL1=" + pFixedAssetUnitModel.FixedAssetUnitNameL1 +
                    "&pFixedAssetUnitNameL2= " + pFixedAssetUnitModel.FixedAssetUnitNameL2 +
                    "&pFixedAssetUnitIsActive=" + pFixedAssetUnitModel.FixedAssetUnitIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFixedAssetUnit.vSQLResult = vDrwResult[0].ToString();
                _dbFixedAssetUnit.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbFixedAssetUnit.funGetFixedAssetUnitReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FixedAssetUnitReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult FixedAssetUnitReport()
        {

            return View();
        }
    }
}