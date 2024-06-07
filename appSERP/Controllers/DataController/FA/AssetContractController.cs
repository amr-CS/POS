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
    public class AssetContractController : Controller
    {
        private IdbAssetContract _dbAssetContract;
        private IclsAPI _clsAPI;

        public AssetContractController(IdbAssetContract dbAssetContract, IclsAPI clsAPI)
        {
            _dbAssetContract = dbAssetContract;
            _clsAPI = clsAPI;
        }

        // GET: AssetContract
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetContract;
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
            AssetContractModel vAssetContractModel = new AssetContractModel();
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContract;
                string vParameters = "?pAssetContractId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetContractModel.AssetContractId = Convert.ToInt32(vDtData.Rows[0]["AssetContractId"]);
                vAssetContractModel.AssetContractDate =Convert.ToDateTime(vDtData.Rows[0]["AssetContractDate"].ToString());
                vAssetContractModel.AssetContractPeriod = Convert.ToInt32(vDtData.Rows[0]["AssetContractPeriod"].ToString());
                vAssetContractModel.AssetContractNo = Convert.ToInt32(vDtData.Rows[0]["AssetContractNo"].ToString());
                vAssetContractModel.AssetContractValue = Convert.ToInt32(vDtData.Rows[0]["AssetContractValue"].ToString());
                vAssetContractModel.CurrencyId = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"].ToString());
                vAssetContractModel.AssetContractNote =vDtData.Rows[0]["AssetContractNote"].ToString();
                vAssetContractModel.AssetContractNo = Convert.ToInt32(vDtData.Rows[0]["AssetContractNo"].ToString());
                vAssetContractModel.AssetContractPayTypeId = Convert.ToInt32(vDtData.Rows[0]["AssetContractPayTypeId"].ToString());
                vAssetContractModel.AssetContractIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetContractIsActive"]);
            }
            // Return Result
            return View(vAssetContractModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetContractModel pAssetContractModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                string vDate = pAssetContractModel.AssetContractDate.ToString();
                // API Path
                string vPath = appAPIDirectory.vAPIAssetContract;
                string vParameters =
                    "?pAssetContractId=" + id +
                    //"&pAssetContractDate=" + pAssetContractModel.AssetContractDate.ToString("dd-MM-yyyy") +
                     "&pAssetContractDate=" + pAssetContractModel.AssetContractDate.ToString("yyyy-MM-dd") +
                    "&pAssetContractPeriod= " + pAssetContractModel.AssetContractPeriod +
                    "&pAssetContractNo=" + pAssetContractModel.AssetContractNo +
                    "&pAssetContractValue=" + pAssetContractModel.AssetContractValue +
                    "&pCurrencyId=" + pAssetContractModel.CurrencyId +
                    "&pAssetContractNote=" + pAssetContractModel.AssetContractNote +
                    "&pAssetContractNo=" + pAssetContractModel.AssetContractNo +
                    "&pAssetContractPayTypeId=" + pAssetContractModel.AssetContractPayTypeId +
                    "&pAssetContractIsActive=" + pAssetContractModel.AssetContractIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetContract.vSQLResult = vDrwResult[0].ToString();
                _dbAssetContract.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbAssetContract.funGetAssetContractReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetContractReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult AssetContractReport()
        {

            return View();
        }
    }
}