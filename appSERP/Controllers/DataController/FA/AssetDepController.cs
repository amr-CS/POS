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
    public class AssetDepController : Controller
    {
        private IdbAssetDep _dbAssetDep;
        private IclsAPI _clsAPI;
        public AssetDepController(IdbAssetDep dbAssetDep, IclsAPI clsAPI)
        {
            _dbAssetDep = dbAssetDep;
            _clsAPI = clsAPI;
        }
        // GET: AssetDep
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetDep;
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
            AssetDepModel vAssetDepModel = new AssetDepModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetDep;
                string vParameters = "?pAssetDepId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetDepModel.AssetDepId = Convert.ToInt32(vDtData.Rows[0]["AssetDepId"]);
                vAssetDepModel.AssetDepDate = Convert.ToDateTime(vDtData.Rows[0]["AssetDepDate"].ToString());
                vAssetDepModel.AssetLastDepDate = Convert.ToDateTime(vDtData.Rows[0]["AssetLastDepDate"].ToString());
                vAssetDepModel.AssetDepIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetDepIsActive"]);
            }

            // Return Result
            return View(vAssetDepModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetDepModel pAssetDepModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            string vUnDepDate = pAssetDepModel.AssetDepDate.ToString("dd-MM-yyyy");
            string vLastDate = pAssetDepModel.AssetLastDepDate.ToString("dd-MM-yyyy");
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete;
                vUnDepDate = pAssetDepModel.AssetDepDate.ToString();
                vLastDate = pAssetDepModel.AssetLastDepDate.ToString();
            }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetDep;
                string vParameters =
                    "?pAssetDepId=" + id +
                    "&pAssetDepDate=" + vUnDepDate +
                    "&pAssetLastDepDate= " + vLastDate +
                    "&pAssetDepIsActive= " + pAssetDepModel.AssetDepIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetDep.vSQLResult = vDrwResult[0].ToString();
                _dbAssetDep.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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

        public ActionResult AssetDep()
        {



            return View();
        }

        public ActionResult SingleAssetDep()
        {

            return View();
        }
        public void ShowSimple()
        {
            DataTable DT = _dbAssetDep.funGetAssetDepReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetDepReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult AssetDepReport()
        {

            return View();
        }


    }
}