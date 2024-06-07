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
    public class FixedAssetMethodController : Controller
    {
        private IdbFixedAssetMethod _dbFixedAssetMethod;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FixedAssetMethodController(IdbFixedAssetMethod dbFixedAssetMethod, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFixedAssetMethod = dbFixedAssetMethod;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: FixedAssetMethod
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFixedAssetMethod = _dbFixedAssetMethod;

            // API Path
            string vPath = appAPIDirectory.vAPIFixedAssetMethod;
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
            FixedAssetMethodModel vFixedAssetMethodModel = new FixedAssetMethodModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetMethod;
                string vParameters = "?pFixedAssetMethodId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFixedAssetMethodModel.FixedAssetMethodId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetMethodId"]);
                vFixedAssetMethodModel.FixedAssetMethodNameL1 = vDtData.Rows[0]["FixedAssetMethodNameL1"].ToString();
                vFixedAssetMethodModel.FixedAssetMethodNameL2 = vDtData.Rows[0]["FixedAssetMethodNameL2"].ToString();
                vFixedAssetMethodModel.FixedAssetMethodIsActive = Convert.ToBoolean(vDtData.Rows[0]["FixedAssetMethodIsActive"]);
            }

            // Return Result
            return View(vFixedAssetMethodModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FixedAssetMethodModel pFixedAssetMethodModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetMethod;
                string vParameters =
                    "?pFixedAssetMethodId=" + id +
                    "&pFixedAssetMethodNameL1=" + pFixedAssetMethodModel.FixedAssetMethodNameL1 +
                    "&pFixedAssetMethodNameL2= " + pFixedAssetMethodModel.FixedAssetMethodNameL2 +
                    "&pFixedAssetMethodIsActive=" + pFixedAssetMethodModel.FixedAssetMethodIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFixedAssetMethod.vSQLResult = vDrwResult[0].ToString();
                _dbFixedAssetMethod.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbFixedAssetMethod.funGetFixedAssetMethodReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FixedAssetMethodReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FixedAssetMethodReport()
        {

            return View();
        }
    }
}