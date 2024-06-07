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
    public class AssetReasonTypeController : Controller
    {
        private IdbAssetReasonType _dbAssetReasonType;
        private IclsAPI _clsAPI;
        public AssetReasonTypeController(IdbAssetReasonType dbAssetReasonType, IclsAPI clsAPI)
        {
            _dbAssetReasonType = dbAssetReasonType;
            _clsAPI = clsAPI;
        }

        // GET: AssetReasonType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetReasonType;
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
            AssetReasonTypeModel vAssetReasonTypeModel = new AssetReasonTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetReasonType;
                string vParameters = "?pAssetReasonTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetReasonTypeModel.AssetReasonTypeId = Convert.ToInt32(vDtData.Rows[0]["AssetReasonTypeId"]);
                vAssetReasonTypeModel.AssetReasonTypeNameL1 = vDtData.Rows[0]["AssetReasonTypeNameL1"].ToString();
                vAssetReasonTypeModel.AssetReasonTypeNameL2 = vDtData.Rows[0]["AssetReasonTypeNameL2"].ToString();
                vAssetReasonTypeModel.AssetReasonTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetReasonTypeIsActive"]);
            }

            // Return Result
            return View(vAssetReasonTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetReasonTypeModel pAssetReasonTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetReasonType;
                string vParameters =
                    "?pAssetReasonTypeId=" + id +
                    "&pAssetReasonTypeNameL1=" + pAssetReasonTypeModel.AssetReasonTypeNameL1 +
                    "&pAssetReasonTypeNameL2= " + pAssetReasonTypeModel.AssetReasonTypeNameL2 +
                    "&pAssetReasonTypeIsActive=" + pAssetReasonTypeModel.AssetReasonTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetReasonType.vSQLResult = vDrwResult[0].ToString();
                _dbAssetReasonType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetReasonType.funGetAssetReasonTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetReasonTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetReasonTypeReport()
        {

            return View();

        }
    }
    }