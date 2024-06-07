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
    public class AssetContractPayTypeController : Controller
    {
        private IdbAssetContractPayType _dbAssetContractPayType;
        private IclsAPI _clsAPI;
        public AssetContractPayTypeController(IdbAssetContractPayType dbAssetContractPayType, IclsAPI clsAPI)
        {
            _dbAssetContractPayType = dbAssetContractPayType;
            _clsAPI = clsAPI;
        }
        // GET: AssetContractPayType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetContractPayType;
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
            AssetContractPayTypeModel vAssetContractPayTypeModel = new AssetContractPayTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContractPayType;
                string vParameters = "?pAssetContractPayTypeId=" + id;

                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetContractPayTypeModel.AssetContractPayTypeId = Convert.ToInt32(vDtData.Rows[0]["AssetContractPayTypeId"]);
                vAssetContractPayTypeModel.AssetContractPayTypeNameL1 = vDtData.Rows[0]["AssetContractPayTypeNameL1"].ToString();
                vAssetContractPayTypeModel.AssetContractPayTypeNameL2 = vDtData.Rows[0]["AssetContractPayTypeNameL2"].ToString();
                vAssetContractPayTypeModel.AssetContractPayTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetContractPayTypeIsActive"]);

            }

            // Return Result
            return View(vAssetContractPayTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetContractPayTypeModel pAssetContractPayTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContractPayType;
                string vParameters =
                    "?pAssetContractPayTypeId=" + id +
                    "&pAssetContractPayTypeNameL1=" + pAssetContractPayTypeModel.AssetContractPayTypeNameL1 +
                    "&pAssetContractPayTypeNameL2= " + pAssetContractPayTypeModel.AssetContractPayTypeNameL2 +
                    "&pAssetContractPayTypeIsActive=" + pAssetContractPayTypeModel.AssetContractPayTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetContractPayType.vSQLResult = vDrwResult[0].ToString();
                _dbAssetContractPayType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbAssetContractPayType.funGetAssetContractPayTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetContractPayTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult AssetContractPayTypeReport()
        {

            return View();
        }
    }
}