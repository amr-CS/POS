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
{   ///  BELAL    22/1/2018 
    [NoDirectAccess]
    [Authorize]
    public class CurrencyGenderController : Controller
    {

        private IdbCurrencyGender _dbCurrencyGender;
        private IclsAPI _clsAPI;
        public CurrencyGenderController(IdbCurrencyGender dbCurrencyGender, IclsAPI clsAPI)
        {
            _dbCurrencyGender = dbCurrencyGender;
            _clsAPI = clsAPI;
        }

        // GET: CurrencyGender
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICurrencyGender;
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
            CurrencyGenderModel vCurrencyGenderModel = new CurrencyGenderModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICurrencyGender;
                string vParameters = "?pCurrencyGenderId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCurrencyGenderModel.CurrencyGenderId = Convert.ToInt32(vDtData.Rows[0]["CurrencyGenderId"]);
                vCurrencyGenderModel.CurrencyGenderCode = vDtData.Rows[0]["CurrencyGenderCode"].ToString();
                vCurrencyGenderModel.CurrencyGenderNameL1 = vDtData.Rows[0]["CurrencyGenderNameL1"].ToString();
                vCurrencyGenderModel.CurrencyGenderNameL2 = vDtData.Rows[0]["CurrencyGenderNameL2"].ToString();
                vCurrencyGenderModel.CurrencyGenderIsActive = Convert.ToBoolean(vDtData.Rows[0]["CurrencyGenderIsActive"]);
                


            }

            // Return Result
            return View(vCurrencyGenderModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CurrencyGenderModel pCurrencyGenderModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICurrencyGender;
                string vParameters =
                    "?pCurrencyGenderId=" + id +
                     "&pCurrencyGenderCode=" + pCurrencyGenderModel.CurrencyGenderCode +
                    "&pCurrencyGenderNameL1=" + pCurrencyGenderModel.CurrencyGenderNameL1 +
                    "&pCurrencyGenderNameL2=" + pCurrencyGenderModel.CurrencyGenderNameL2 +
                    "&pCurrencyGenderIsActive=" + pCurrencyGenderModel.CurrencyGenderIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCurrencyGender.vSQLResult = vDrwResult[0].ToString();
                _dbCurrencyGender.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbCurrencyGender.funGetCurrencyGenderReport();
            string vReportPath = Server.MapPath("~/Reports") + "//CurrencyGenderReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult CurrencyGenderReport()
        {

            return View();
        }
    }
}