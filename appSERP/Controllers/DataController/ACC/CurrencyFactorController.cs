using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{    ///  BELAL    22/1/2018 
    [NoDirectAccess]
    [Authorize]
    public class CurrencyFactorController : Controller
    {
        private IdbCurrencyFactor _dbCurrencyFactor;
        private IclsAPI _clsAPI;
        public CurrencyFactorController(IdbCurrencyFactor dbCurrencyFactor, IclsAPI clsAPI)
        {
            _dbCurrencyFactor = dbCurrencyFactor;
            _clsAPI = clsAPI;
        }

        // GET: CurrencyFactor
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICurrencyFactor;
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
            CurrencyFactorModel vCurrencyFactorModel = new CurrencyFactorModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICurrencyFactor;
                string vParameters = "?pCurrencyFactorId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCurrencyFactorModel.CurrencyFactorId = Convert.ToInt32(vDtData.Rows[0]["CurrencyFactorId"]);
                vCurrencyFactorModel.CurrencyFactorCode = vDtData.Rows[0]["CurrencyFactorCode"].ToString();
                vCurrencyFactorModel.CurrencyFactorNameL1 = vDtData.Rows[0]["CurrencyFactorNameL1"].ToString();
                vCurrencyFactorModel.CurrencyFactorNameL2 = vDtData.Rows[0]["CurrencyFactorNameL2"].ToString();
                vCurrencyFactorModel.CurrencyFactorIsActive = Convert.ToBoolean(vDtData.Rows[0]["CurrencyFactorIsActive"]);
                vCurrencyFactorModel.CurrencyFactorValue = Convert.ToDecimal(vDtData.Rows[0]["CurrencyFactorValue"].ToString());
                

            }

            // Return Result
            return View(vCurrencyFactorModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CurrencyFactorModel pCurrencyFactorModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICurrencyFactor;
                string vParameters =
                    "?pCurrencyFactorId=" + id +
                     "&pCurrencyFactorCode=" + pCurrencyFactorModel.CurrencyFactorCode +
                    "&pCurrencyFactorNameL1=" + pCurrencyFactorModel.CurrencyFactorNameL1 +
                    "&pCurrencyFactorNameL2=" + pCurrencyFactorModel.CurrencyFactorNameL2 +
                     "&pCurrencyFactorValue=" + pCurrencyFactorModel.CurrencyFactorValue +
                    "&pCurrencyFactorIsActive=" + pCurrencyFactorModel.CurrencyFactorIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCurrencyFactor.vSQLResult = vDrwResult[0].ToString();
                _dbCurrencyFactor.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbCurrencyFactor.funGetCurrencyFactorReport();
            string vReportPath = Server.MapPath("~/Reports") + "//CurrencyFactorReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult CurrencyFactorReport()
        {

            return View();
        }
    }
}