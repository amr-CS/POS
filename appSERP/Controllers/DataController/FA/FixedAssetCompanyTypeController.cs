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
    public class FixedAssetCompanyTypeController : Controller
    {

        private IdbFixedAssetCompanyType _dbFixedAssetCompanyType;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FixedAssetCompanyTypeController(IdbFixedAssetCompanyType dbFixedAssetCompanyType, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFixedAssetCompanyType = dbFixedAssetCompanyType;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: FixedAssetCompanyType
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFixedAssetCompanyType = _dbFixedAssetCompanyType;

            // API Path
            string vPath = appAPIDirectory.vAPIFixedAssetCompanyType;
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
            FixedAssetCompanyTypeModel vFixedAssetCompanyTypeModel = new FixedAssetCompanyTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetCompanyType;
                string vParameters = "?pFixedAssetCompanyTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFixedAssetCompanyTypeModel.FixedAssetCompanyTypeId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetCompanyTypeId"]);
                vFixedAssetCompanyTypeModel.FixedAssetCompanyTypeCode = vDtData.Rows[0]["FixedAssetCompanyTypeCode"].ToString();
                vFixedAssetCompanyTypeModel.FixedAssetCompanyTypeNameL1 = vDtData.Rows[0]["FixedAssetCompanyTypeNameL1"].ToString();
                vFixedAssetCompanyTypeModel.FixedAssetCompanyTypeNameL2 = vDtData.Rows[0]["FixedAssetCompanyTypeNameL2"].ToString();
                vFixedAssetCompanyTypeModel.FixedAssetCompanyTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["FixedAssetCompanyTypeIsActive"]);
            }

            // Return Result
            return View(vFixedAssetCompanyTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FixedAssetCompanyTypeModel pFixedAssetCompanyTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetCompanyType;
                string vParameters =
                    "?pFixedAssetCompanyTypeId=" + id +
                    "&pFixedAssetCompanyTypeCode=" + pFixedAssetCompanyTypeModel.FixedAssetCompanyTypeCode +
                    "&pFixedAssetCompanyTypeNameL1=" + pFixedAssetCompanyTypeModel.FixedAssetCompanyTypeNameL1 +
                    "&pFixedAssetCompanyTypeNameL2= " + pFixedAssetCompanyTypeModel.FixedAssetCompanyTypeNameL2 +
                    "&pFixedAssetCompanyTypeIsActive=" + pFixedAssetCompanyTypeModel.FixedAssetCompanyTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFixedAssetCompanyType.vSQLResult = vDrwResult[0].ToString();
                _dbFixedAssetCompanyType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbFixedAssetCompanyType.funGetFixedAssetCompanyTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FixedAssetCompanyTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FixedAssetCompanyTypeReport()
        {

            return View();
        }
    }
}