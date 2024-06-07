using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
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
    public class CurrencyController : Controller
    {
        private IdbCurrency _dbCurrency;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public CurrencyController(IdbCurrency dbCurrency, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbCurrency = dbCurrency;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: Currency
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbCurrency = _dbCurrency;
            // API Path
            string vPath = appAPIDirectory.vAPICurrency;
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
            CurrencyModel vCurrencyModel = new CurrencyModel();

            if (id == 0)
            {
                ViewBag.vbcCurrencyFactorId = 0;
                ViewBag.vbcCurrencyGenderId = 0;
            }
            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPICurrency;
                string vParameters = "?pCurrencyId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcCurrencyFactorId = Convert.ToInt32(vDtData.Rows[0]["CurrencyFactorId"].ToString());
                ViewBag.vbcCurrencyGenderId = Convert.ToInt32(vDtData.Rows[0]["CurrencyGenderId"].ToString());
                // Set Model Data
                vCurrencyModel.CurrencyId = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"]);
                vCurrencyModel.CurrencyNameL1 = vDtData.Rows[0]["CurrencyNameL1"].ToString();
                vCurrencyModel.CurrencyNameL2 = vDtData.Rows[0]["CurrencyNameL2"].ToString();
                vCurrencyModel.CurrencyIsDefault = Convert.ToBoolean(vDtData.Rows[0]["CurrencyIsDefault"]);
                vCurrencyModel.CurrencyDecimal = Convert.ToInt32(vDtData.Rows[0]["CurrencyDecimal"].ToString());
                vCurrencyModel.CurrencyExchange = Convert.ToDecimal(vDtData.Rows[0]["CurrencyExchange"].ToString());
                vCurrencyModel.CurrencyFactorId = Convert.ToInt32(vDtData.Rows[0]["CurrencyFactorId"].ToString());
                vCurrencyModel.CurrencyGenderId = Convert.ToInt32(vDtData.Rows[0]["CurrencyGenderId"].ToString());
                vCurrencyModel.CurrencyIsActive = Convert.ToBoolean(vDtData.Rows[0]["CurrencyIsActive"]);
                
            }
            // Return Result
            return View(vCurrencyModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CurrencyModel pCurrencyModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICurrency;
                string vParameters =
                    "?pCurrencyId=" + id +
                    "&pCurrencyNameL1=" + pCurrencyModel.CurrencyNameL1 +
                    "&pCurrencyNameL2=" + pCurrencyModel.CurrencyNameL2 +
                    "&pCurrencyIsDefault=" + pCurrencyModel.CurrencyIsDefault +
                    "&pCurrencyDecimal=" + pCurrencyModel.CurrencyDecimal +
                    "&pCurrencyExchange=" + pCurrencyModel.CurrencyExchange +
                    "&pCurrencyFactorId=" + pCurrencyModel.CurrencyFactorId +
                    "&pCurrencyGenderId=" + pCurrencyModel.CurrencyGenderId +
                    "&pCurrencyIsActive=" + pCurrencyModel.CurrencyIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCurrency.vSQLResult = vDrwResult[0].ToString();
                _dbCurrency.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        public ActionResult SearchCurrency()
        {
            return View();
        }
        public string SearchCurrencyByCode(string pCurrencyCode = null)
        {
            string vPath = appAPIDirectory.vAPICurrency;
            string vParameters =
                "?pCurrencyCode=" + pCurrencyCode +
                "&pQueryTypeId=" + 400;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public void ShowSimple()
        {


            DataTable DT = _dbCurrency.funGetCurrencyReport();
            string vReportPath = Server.MapPath("~/Reports") + "//CurrencyReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult CurrencyReport()
        {

            return View();
        }


    }
}