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
    public class SiteDetailController : Controller
    {
        private IdbSiteDetail _dbSiteDetail;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SiteDetailController(IdbSiteDetail dbSiteDetail, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSiteDetail = dbSiteDetail;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }


        // GET: SiteDetail
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbSiteDetail = _dbSiteDetail;

            // API Path
            string vPath = appAPIDirectory.vAPISiteDetail;
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
            SiteDetailModel vSiteDetailModel = new SiteDetailModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISiteDetail;
                string vParameters = "?pSiteDetailId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSiteDetailModel.SiteDetailId = Convert.ToInt32(vDtData.Rows[0]["SiteDetailId"]);
                vSiteDetailModel.SiteDetailNameL1 = vDtData.Rows[0]["SiteDetailNameL1"].ToString();
                vSiteDetailModel.SiteDetailNameL2 = vDtData.Rows[0]["SiteDetailNameL2"].ToString();
                vSiteDetailModel.SiteDetailLat = Convert.ToInt32(vDtData.Rows[0]["SiteDetailLat"]);
                vSiteDetailModel.SiteDetailLng = Convert.ToInt32(vDtData.Rows[0]["SiteDetailLng"]);
                vSiteDetailModel.SiteId = Convert.ToInt32(vDtData.Rows[0]["SiteId"]);
                vSiteDetailModel.SiteDetailIsActive = Convert.ToBoolean(vDtData.Rows[0]["SiteDetailIsActive"]);
            }

            // Return Result
            return View(vSiteDetailModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SiteDetailModel pSiteDetailModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
          
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISiteDetail;
                string vParameters =
                    "?pSiteDetailId=" + id +
                    "&pSiteDetailNameL1=" + pSiteDetailModel.SiteDetailNameL1 +
                    "&pSiteDetailNameL2=" + pSiteDetailModel.SiteDetailNameL2 +
                    "&pSiteDetailLat=" + pSiteDetailModel.SiteDetailLat +
                    "&pSiteDetailLng=" + pSiteDetailModel.SiteDetailLng +
                    "&pSiteId=" + pSiteDetailModel.SiteId +
                    "&pSiteDetailIsActive=" + pSiteDetailModel.SiteDetailIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSiteDetail.vSQLResult = vDrwResult[0].ToString();
                _dbSiteDetail.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbSiteDetail.funGetSiteDetailReport();
            string vReportPath = Server.MapPath("~/Reports") + "//SiteDetailReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult SiteDetailReport()
        {

            return View();
        }
    }
}