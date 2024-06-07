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
    public class SiteController : Controller
    {
        private IdbSite _dbSite;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SiteController(IdbSite dbSite, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSite = dbSite;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: Site
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbSite = _dbSite;

            // API Path
            string vPath = appAPIDirectory.vAPISite;
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
            SiteModel vSiteModel = new SiteModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISite;
                string vParameters = "?pSiteId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSiteModel.SiteId = Convert.ToInt32(vDtData.Rows[0]["SiteId"]);
                vSiteModel.SiteNameL1 = vDtData.Rows[0]["SiteNameL1"].ToString();
                vSiteModel.SiteNameL2 = vDtData.Rows[0]["SiteNameL2"].ToString();
                vSiteModel.SiteLat = Convert.ToInt32(vDtData.Rows[0]["SiteLat"]);
                vSiteModel.SiteLng = Convert.ToInt32(vDtData.Rows[0]["SiteLng"]);
                vSiteModel.SiteIsActive = Convert.ToBoolean(vDtData.Rows[0]["SiteIsActive"]);
            }

            // Return Result
            return View(vSiteModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SiteModel pSiteModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISite;
                string vParameters =
                    "?pSiteId=" + id +
                    "&pSiteNameL1=" + pSiteModel.SiteNameL1 +
                    "&pSiteNameL2= " + pSiteModel.SiteNameL2 +
                    "&pSiteLat=" + pSiteModel.SiteLat +
                    "&pSiteLng= " + pSiteModel.SiteLng +
                    "&pSiteIsActive=" + pSiteModel.SiteIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSite.vSQLResult = vDrwResult[0].ToString();
                _dbSite.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
     
        public ActionResult SiteSearch()
        {
            return View();
        }
        public string SearchSiteByCode(string pSiteCode = null)
        {
            // API Path
            string vPath = appAPIDirectory.vAPISite;
            string vParameters = "?pSiteCode=" + pSiteCode +"&&pQueryTypeId=" + 400;
            string vAPIPath = vPath + vParameters;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public void ShowSimple()
        {
            DataTable DT = _dbSite.funGetSiteReport();
            string vReportPath = Server.MapPath("~/Reports") + "//SiteReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult SiteReport()
        {

            return View();
        }

    }
}