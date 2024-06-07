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
    public class AccountTypeController : Controller
    {
        private IdbAccountType _dbAccountType;
        private IclsAPI _clsAPI;
        public AccountTypeController(IdbAccountType dbAccountType, IclsAPI clsAPI)
        {
            _dbAccountType = dbAccountType;
            _clsAPI = clsAPI;
        }

        // GET: AccountType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAccountType;
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
            AccountTypeModel vAccountTypeModel = new AccountTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAccountType;
                string vParameters = "?pAccountTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAccountTypeModel.AccountTypeId = Convert.ToInt32(vDtData.Rows[0]["AccountTypeId"]);
                vAccountTypeModel.AccountTypeCode = vDtData.Rows[0]["AccountTypeCode"].ToString();
                vAccountTypeModel.AccountTypeNameL1 = vDtData.Rows[0]["AccountTypeNameL1"].ToString();
                vAccountTypeModel.AccountTypeNameL2 = vDtData.Rows[0]["AccountTypeNameL2"].ToString();
                vAccountTypeModel.AccountTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["AccountTypeIsActive"]);

            }

            // Return Result
            return View(vAccountTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AccountTypeModel pAccountTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAccountType;
                string vParameters =
                    "?pAccountTypeId=" + id +
                     "&pAccountTypeCode=" + pAccountTypeModel.AccountTypeCode +
                    "&pAccountTypeNameL1=" + pAccountTypeModel.AccountTypeNameL1 +
                    "&pAccountTypeNameL2=" + pAccountTypeModel.AccountTypeNameL2 +
                    "&pAccountTypeIsActive=" + pAccountTypeModel.AccountTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAccountType.vSQLResult = vDrwResult[0].ToString();
                _dbAccountType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        public ActionResult ShowSimple()
        {


            DataTable DT = _dbAccountType.funGetAccountTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AccountTypeReport.rpt";
            ViewBag.vReportPath = vReportPath;
            ClsReport.Printreport(DT, vReportPath);

            return View("AccountTypeReport");
        }
        public ActionResult AccountTypeReport()
        {

            return View();
        }




    }
}