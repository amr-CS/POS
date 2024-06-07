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
    public class AssetReleaseDetailController : Controller
    {
        private IdbAssetReleaseDetail _dbAssetReleaseDetail;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public AssetReleaseDetailController(IdbAssetReleaseDetail dbAssetReleaseDetail, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbAssetReleaseDetail = dbAssetReleaseDetail;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: AssetReleaseDetail
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbAssetReleaseDetail = _dbAssetReleaseDetail;
            // API Path
            string vPath = appAPIDirectory.vAPIAssetReleaseDetail;
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
            AssetReleaseDetailModel vAssetReleaseDetailModel = new AssetReleaseDetailModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetReleaseDetail;
                string vParameters = "?pAssetReleaseDetailId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

                // Set Model Data
                vAssetReleaseDetailModel.AssetReleaseDetailId = Convert.ToInt32(vDtData.Rows[0]["AssetReleaseDetailId"]);
                vAssetReleaseDetailModel.AssetReleaseDetailNameL1 = vDtData.Rows[0]["AssetReleaseDetailNameL1"].ToString();
                vAssetReleaseDetailModel.AssetReleaseDetailNameL2 = vDtData.Rows[0]["AssetReleaseDetailNameL2"].ToString();
                vAssetReleaseDetailModel.AssetReleaseDetailCode = vDtData.Rows[0]["AssetReleaseDetailCode"].ToString();
                vAssetReleaseDetailModel.AssetReleaseQty = Convert.ToInt32(vDtData.Rows[0]["AssetReleaseQty"].ToString());
                vAssetReleaseDetailModel.AssetReleaseSeq = Convert.ToInt32(vDtData.Rows[0]["AssetReleaseSeq"].ToString());
                vAssetReleaseDetailModel.AssetReleaseId = Convert.ToInt32(vDtData.Rows[0]["AssetReleaseId"].ToString());
                vAssetReleaseDetailModel.AssetId = Convert.ToInt32(vDtData.Rows[0]["AssetId"].ToString());
                vAssetReleaseDetailModel.AssetReleaseDetailIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetReleaseDetailIsActive"]);
            }

            // Return Result
            return View(vAssetReleaseDetailModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetReleaseDetailModel pAssetReleaseDetailModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetReleaseDetail;
                string vParameters =
                    "?pAssetReleaseDetailId=" + id +
                    "&pAssetReleaseDetailNameL1=" + pAssetReleaseDetailModel.AssetReleaseDetailNameL1 +
                    "&pAssetReleaseDetailNameL2= " + pAssetReleaseDetailModel.AssetReleaseDetailNameL2 +
                    "&pAssetReleaseDetailCode=" + pAssetReleaseDetailModel.AssetReleaseDetailCode +
                    "&pAssetReleaseQty= " + pAssetReleaseDetailModel.AssetReleaseQty +
                    "&pAssetReleaseSeq= " + pAssetReleaseDetailModel.AssetReleaseSeq +
                    "&pAssetReleaseId= " + pAssetReleaseDetailModel.AssetReleaseId +
                    "&pAssetId= " + pAssetReleaseDetailModel.AssetId +
                    "&pAssetReleaseDetailIsActive=" + pAssetReleaseDetailModel.AssetReleaseDetailIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetReleaseDetail.vSQLResult = vDrwResult[0].ToString();
                _dbAssetReleaseDetail.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetReleaseDetail.funGetAssetReleaseDetailReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetReleaseDetailReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetReleaseDetailReport()
        {

            return View();
        }
    }
}