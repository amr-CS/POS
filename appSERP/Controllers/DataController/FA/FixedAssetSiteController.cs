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
    public class FixedAssetSiteController : Controller
    {
        private IdbFixedAssetSite _dbFixedAssetSite;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public FixedAssetSiteController(IdbFixedAssetSite dbFixedAssetSite, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbFixedAssetSite = dbFixedAssetSite;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: FixedAssetSite
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbFixedAssetSite = _dbFixedAssetSite;
            // API Path
            string vPath = appAPIDirectory.vAPIFixedAssetSite;
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
            FixedAssetSiteModel vFixedAssetSiteModel = new FixedAssetSiteModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetSite;
                string vParameters = "?pFixedAssetSiteId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFixedAssetSiteModel.FixedAssetSiteId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetSiteId"]);
                vFixedAssetSiteModel.FixedAssetSiteQty = Convert.ToInt32(vDtData.Rows[0]["FixedAssetSiteQty"]);
                vFixedAssetSiteModel.FixedAssetSiteTransDate  = Convert.ToDateTime(vDtData.Rows[0]["FixedAssetSiteTransDate"]);
                vFixedAssetSiteModel.AssetId = Convert.ToInt32(vDtData.Rows[0]["AssetId"]);
                vFixedAssetSiteModel.SiteDetailId     = Convert.ToInt32(vDtData.Rows[0]["SiteDetailId"]);
                vFixedAssetSiteModel.TransactionTypeId  = Convert.ToInt32(vDtData.Rows[0]["TransactionTypeId"]);
                vFixedAssetSiteModel.FixedAssetSiteIsActive = Convert.ToBoolean(vDtData.Rows[0]["FixedAssetSiteIsActive"]);
            }

            // Return Result
            return View(vFixedAssetSiteModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, FixedAssetSiteModel pFixedAssetSiteModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFixedAssetSite;
                string vParameters =
                    "?pFixedAssetSiteId=" + id +
                    "&pFixedAssetSiteQty=" + pFixedAssetSiteModel.FixedAssetSiteQty +
                    "&pFixedAssetSiteTransDate=" + pFixedAssetSiteModel.FixedAssetSiteTransDate.Date.ToString("yyyy-MM-dd") +
                    "&pAssetId=" + pFixedAssetSiteModel.AssetId +
                    "&pSiteDetailId=" + pFixedAssetSiteModel.SiteDetailId +
                    "&pTransactionTypeId=" + pFixedAssetSiteModel.TransactionTypeId +
                    "&pFixedAssetSiteIsActive=" + pFixedAssetSiteModel.FixedAssetSiteIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFixedAssetSite.vSQLResult = vDrwResult[0].ToString();
                _dbFixedAssetSite.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbFixedAssetSite.funGetFixedAssetSiteReport();
            string vReportPath = Server.MapPath("~/Reports") + "//FixedAssetSiteReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult FixedAssetSiteReport()
        {

            return View();
        }
    }
}