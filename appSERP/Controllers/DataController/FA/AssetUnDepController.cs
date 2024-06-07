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
    public class AssetUnDepController : Controller
    {

        private IdbAssetUnDep _dbAssetUnDep;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public AssetUnDepController(IdbAssetUnDep dbAssetUnDep, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbAssetUnDep = dbAssetUnDep;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: AssetUnDep
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbAssetUnDep = _dbAssetUnDep;
            // API Path
            string vPath = appAPIDirectory.vAPIAssetUnDep;
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
            AssetUnDepModel vAssetUnDepModel = new AssetUnDepModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetUnDep;
                string vParameters = "?pAssetUnDepId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetUnDepModel.AssetUnDepId = Convert.ToInt32(vDtData.Rows[0]["AssetUnDepId"]);
                vAssetUnDepModel.AssetUnDepDate = Convert.ToDateTime(vDtData.Rows[0]["AssetUnDepDate"].ToString());
                vAssetUnDepModel.AssetLastDepDate = Convert.ToDateTime(vDtData.Rows[0]["AssetLastDepDate"].ToString());
                vAssetUnDepModel.AssetUnDepIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetUnDepIsActive"]);
            }

            // Return Result
            return View(vAssetUnDepModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetUnDepModel pAssetUnDepModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            string vUnDepDate = pAssetUnDepModel.AssetUnDepDate.ToString("dd-MM-yyyy");
            string vLastDate = pAssetUnDepModel.AssetLastDepDate.ToString("dd-MM-yyyy");
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete;
                vUnDepDate = pAssetUnDepModel.AssetUnDepDate.ToString();
                vLastDate = pAssetUnDepModel.AssetLastDepDate.ToString();
            }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetUnDep;
                string vParameters =
                    "?pAssetUnDepId=" + id +
                    "&pAssetUnDepDate=" + vUnDepDate +
                    "&pAssetLastDepDate= " + vLastDate +
                    "&pAssetUnDepIsActive= " + pAssetUnDepModel.AssetUnDepIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetUnDep.vSQLResult = vDrwResult[0].ToString();
                _dbAssetUnDep.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbAssetUnDep.funGetAssetUnDepReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetUnDepReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetUnDepReport()
        {

            return View();
        }
    }
}