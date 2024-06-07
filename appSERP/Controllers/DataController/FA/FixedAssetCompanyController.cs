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
    public class FixedAssetCompanyController : Controller
    {

        private IdbFixedAssetCompany _dbFixedAssetCompany;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FixedAssetCompanyController(IdbFixedAssetCompany dbFixedAssetCompany, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFixedAssetCompany = dbFixedAssetCompany;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        // GET: FixedAssetCompany
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFixedAssetCompany = _dbFixedAssetCompany;

            // API Path
            string vPath = appAPIDirectory.vAPIFixedAssetCompany;
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
            FixedAssetCompanyModel vFixedAssetCompanyModel = new FixedAssetCompanyModel();
            string vFixedAssetCompanyTypePath = @"/APIFixedAssetCompanyType/FixedAssetCompanyTypeGet";
            string vFixedAssetCompanyTypeParameters = "?pFixedAssetCompanyTypeIsActive=True";
            DataTable dtFixedAssetCompanyType = _clsAPI.funResultGet(vFixedAssetCompanyTypePath + vFixedAssetCompanyTypeParameters);
            if (id == 0)
            {
                ViewBag.vbFixedAssetCompanyTypeId = new SelectList(dtFixedAssetCompanyType.AsDataView(), "FixedAssetCompanyTypeId", "FixedAssetCompanyTypeNameL1");
                ViewBag.vbcFixedAssetCompanyTypeId = 0;

            }

            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetCompany;
                string vParameters = "?pFixedAssetCompanyId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcFixedAssetCompanyTypeId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetCompanyTypeId"].ToString());
                // Set Model Data
                vFixedAssetCompanyModel.FixedAssetCompanyId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetCompanyId"]);
                vFixedAssetCompanyModel.FixedAssetCompanyCode = vDtData.Rows[0]["FixedAssetCompanyCode"].ToString();
                vFixedAssetCompanyModel.FixedAssetCompanyNameL1 = vDtData.Rows[0]["FixedAssetCompanyNameL1"].ToString();
                vFixedAssetCompanyModel.FixedAssetCompanyNameL2 = vDtData.Rows[0]["FixedAssetCompanyNameL2"].ToString();
                vFixedAssetCompanyModel.FixedAssetCompanyTypeId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetCompanyTypeId"]);
                vFixedAssetCompanyModel.FixedAssetCompanyIsActive = Convert.ToBoolean(vDtData.Rows[0]["FixedAssetCompanyIsActive"]);
            }

            // Return Result
            return View(vFixedAssetCompanyModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FixedAssetCompanyModel pFixedAssetCompanyModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetCompany;
                string vParameters =
                    "?pFixedAssetCompanyId=" + id +
                    "&pFixedAssetCompanyCode=" + pFixedAssetCompanyModel.FixedAssetCompanyCode +
                    "&pFixedAssetCompanyNameL1=" + pFixedAssetCompanyModel.FixedAssetCompanyNameL1 +
                    "&pFixedAssetCompanyNameL2= " + pFixedAssetCompanyModel.FixedAssetCompanyNameL2 +
                    "&pFixedAssetCompanyTypeId=" + pFixedAssetCompanyModel.FixedAssetCompanyTypeId +
                    "&pFixedAssetCompanyIsActive=" + pFixedAssetCompanyModel.FixedAssetCompanyIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFixedAssetCompany.vSQLResult = vDrwResult[0].ToString();
                _dbFixedAssetCompany.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                if (Convert.ToBoolean(pIsDelete)) { return null; }
                else
                { // Go To Index
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void ShowSimple()
        {
            DataTable DT = _dbFixedAssetCompany.funGetFixedAssetCompanyReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FixedAssetCompanyReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FixedAssetCompanyReport()
        {

            return View();
        }
    }
}