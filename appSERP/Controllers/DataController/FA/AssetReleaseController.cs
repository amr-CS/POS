using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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
    public class AssetReleaseController : Controller
    {
        private IdbAssetRelease _dbAssetRelease;
        private IclsAPI _clsAPI;
        public AssetReleaseController(IdbAssetRelease dbAssetRelease, IclsAPI clsAPI)
        {
            _dbAssetRelease = dbAssetRelease;
            _clsAPI = clsAPI;
        }

        // GET: AssetRelease
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetRelease;
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
            AssetReleaseModel vAssetReleaseModel = new AssetReleaseModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetRelease;
                string vParameters = "?pAssetReleaseId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

                // Set Model Data
                vAssetReleaseModel.AssetReleaseId = Convert.ToInt32(vDtData.Rows[0]["AssetReleaseId"]);
                vAssetReleaseModel.AssetReleaseNameL1 = vDtData.Rows[0]["AssetReleaseNameL1"].ToString();
                vAssetReleaseModel.AssetReleaseNameL2 = vDtData.Rows[0]["AssetReleaseNameL2"].ToString();
                vAssetReleaseModel.AssetReleaseCode = vDtData.Rows[0]["AssetReleaseCode"].ToString();
                vAssetReleaseModel.TrustId = Convert.ToInt32(vDtData.Rows[0]["TrustId"].ToString());
                vAssetReleaseModel.AssetReleaseIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetReleaseIsActive"]);
                vAssetReleaseModel.TransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["TransactionTypeId"].ToString());
                vAssetReleaseModel.Note = vDtData.Rows[0]["Note"].ToString();
            }

            // Return Result
            return View(vAssetReleaseModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetReleaseModel pAssetReleaseModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetRelease;
                string vParameters =
                    "?pAssetReleaseId=" + id +
                    "&pAssetReleaseNameL1=" + pAssetReleaseModel.AssetReleaseNameL1 +
                    "&pAssetReleaseNameL2= " + pAssetReleaseModel.AssetReleaseNameL2 +
                    "&pAssetReleaseCode=" + pAssetReleaseModel.AssetReleaseCode +
                    "&pTrustId= " + pAssetReleaseModel.TrustId +
                    "&pAssetReleaseIsActive=" + pAssetReleaseModel.AssetReleaseIsActive +
                    "&pNote= " + pAssetReleaseModel.Note +
                    "&pTransactionTypeId=" + pAssetReleaseModel.TransactionTypeId +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetRelease.vSQLResult = vDrwResult[0].ToString();
                _dbAssetRelease.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetRelease.funGetAssetReleaseReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetReleaseReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetReleaseReport()
        {

            return View();
        }
    }
}