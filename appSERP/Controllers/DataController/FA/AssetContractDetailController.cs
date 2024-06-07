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
    public class AssetContractDetailController : Controller
    {

        private IdbAssetContractDetail _dbAssetContractDetail;
        private IclsAPI _clsAPI;
        public AssetContractDetailController(IdbAssetContractDetail dbAssetContractDetail, IclsAPI clsAPI)
        {
            _dbAssetContractDetail = dbAssetContractDetail;
            _clsAPI = clsAPI;
        }

        // GET: AssetContractDetail
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetContractDetail;
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
            AssetContractDetailModel vAssetContractDetailModel = new AssetContractDetailModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContractDetail;
                string vParameters = "?pAssetContractDetailId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetContractDetailModel.AssetContractDetailId = Convert.ToInt32(vDtData.Rows[0]["AssetContractDetailId"]);
                vAssetContractDetailModel.AssetContractDetailSeq = Convert.ToInt32(vDtData.Rows[0]["AssetContractDetailSeq"].ToString());
                vAssetContractDetailModel.AssetContractDetailQty = Convert.ToInt32(vDtData.Rows[0]["AssetContractDetailQty"].ToString());
                vAssetContractDetailModel.AssetContractId = Convert.ToInt32(vDtData.Rows[0]["AssetContractId"].ToString());
                vAssetContractDetailModel.AssetId = Convert.ToInt32(vDtData.Rows[0]["AssetId"].ToString());
                vAssetContractDetailModel.AssetContractDetailIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetContractDetailIsActive"]);
            }

            // Return Result
            return View(vAssetContractDetailModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetContractDetailModel pAssetContractDetailModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContractDetail;
                string vParameters =
                    "?pAssetContractDetailId=" + id +
                    "&pAssetContractDetailSeq=" + pAssetContractDetailModel.AssetContractDetailSeq +
                    "&pAssetContractDetailQty= " + pAssetContractDetailModel.AssetContractDetailQty +
                    "&pAssetContractId= " + pAssetContractDetailModel.AssetContractId +
                    "&pAssetId= " + pAssetContractDetailModel.AssetId +
                    "&pAssetContractDetailIsActive= " + pAssetContractDetailModel.AssetContractDetailIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetContractDetail.vSQLResult = vDrwResult[0].ToString();
                _dbAssetContractDetail.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetContractDetail.funGetAssetContractDetailReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetContractDetailReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetContractDetailReport()
        {

            return View();
        }

    }
}