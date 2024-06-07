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
    public class AssetTransController : Controller
    {

        private IdbAssetTrans _dbAssetTrans;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public AssetTransController(IdbAssetTrans dbAssetTrans, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbAssetTrans = dbAssetTrans;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: AssetTrans
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbAssetTrans = _dbAssetTrans;

            // API Path
            string vPath = appAPIDirectory.vAPIAssetTrans;
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
            AssetTransModel vAssetTransModel = new AssetTransModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetTrans;
                string vParameters = "?pAssetTransId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetTransModel.AssetTransId = Convert.ToInt32(vDtData.Rows[0]["AssetTransId"]);
                vAssetTransModel.AssetTransDate = Convert.ToDateTime(vDtData.Rows[0]["AssetTransDate"].ToString());
                vAssetTransModel.AssetTransValue = Convert.ToDecimal(vDtData.Rows[0]["AssetTransValue"].ToString());
                vAssetTransModel.AssetTransValueBase = Convert.ToDecimal(vDtData.Rows[0]["AssetTransValueBase"]);
                vAssetTransModel.CurrencyId = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"]);
                vAssetTransModel.AssetReasonTypeNote = vDtData.Rows[0]["AssetReasonTypeNote"].ToString();
                vAssetTransModel.AssetId = Convert.ToInt32(vDtData.Rows[0]["AssetId"]);
                vAssetTransModel.TransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["TransactionTypeId"]);
                vAssetTransModel.AssetReasonTypeId = Convert.ToInt32(vDtData.Rows[0]["AssetReasonTypeId"]);
                vAssetTransModel.AssetTransIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetTransIsActive"]);
            }

            // Return Result
            return View(vAssetTransModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetTransModel pAssetTransModel = null, bool? pIsDelete = false)
        {
            // Check Operation dd-MM-yyyy 
            int vQueryTypeId = clsQueryType.qInsert;
            string vUnDepDate = pAssetTransModel.AssetTransDate.ToString("yyyy - MM - dd");
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete))
            {
                vQueryTypeId = clsQueryType.qDelete;
                vUnDepDate = pAssetTransModel.AssetTransDate.ToString();
            }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetTrans;
                string vParameters =
                    "?pAssetTransId=" + id +
                    "&pAssetTransDate=" + vUnDepDate +
                    "&pAssetTransValue= " + pAssetTransModel.AssetTransValue +
                    "&pAssetTransValueBase= " + pAssetTransModel.AssetTransValueBase +
                    "&pCurrencyId= " + pAssetTransModel.CurrencyId +
                    "&pAssetReasonTypeNote= " + pAssetTransModel.AssetReasonTypeNote +
                    "&pAssetId= " + pAssetTransModel.AssetId +
                    "&pTransactionTypeId= " + pAssetTransModel.TransactionTypeId +
                    "&pAssetReasonTypeId= " + pAssetTransModel.AssetReasonTypeId +
                    "&pAssetTransIsActive= " + pAssetTransModel.AssetTransIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetTrans.vSQLResult = vDrwResult[0].ToString();
                _dbAssetTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetTrans.funGetAssetTransReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetTransReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetTransReport()
        {

            return View();
        }

    }
}