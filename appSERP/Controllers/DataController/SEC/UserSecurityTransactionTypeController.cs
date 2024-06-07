using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.SEC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SEC
{   ///  AMR    21/1/2018   
    public class UserSecurityTransactionTypeController : Controller
    {

        private IdbUserSecurityTransactionType _dbUserSecurityTransactionType;
        private IclsAPI _clsAPI;
        public UserSecurityTransactionTypeController(IdbUserSecurityTransactionType dbUserSecurityTransactionType, IclsAPI clsAPI)
        {
            _dbUserSecurityTransactionType = dbUserSecurityTransactionType;
            _clsAPI = clsAPI;
        }

        // GET: UserSecurityTransactionType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserSecurityTransactionType;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);

            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            // Return View
            return View(vDtData);
        }

        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            UserSecurityTransactionTypeModel vUserSecurityTransactionTypeModel = new UserSecurityTransactionTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserSecurityTransactionType;
                string vParameters = "?pUserSecurityTransactionTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["UserSecurityTransactionTypeId"]);
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL1 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL1"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL2 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL2"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL3 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL3"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL4 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL4"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL5 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL5"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL6 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL6"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL7 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL7"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL8 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL8"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL9 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL9"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL10 = vDtData.Rows[0]["UserSecurityTransactionTypeNameL10"].ToString();
                vUserSecurityTransactionTypeModel.UserSecurityTransactionTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["UserSecurityTransactionTypeIsActive"]);
            }

            // Return Result
            return View(vUserSecurityTransactionTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UserSecurityTransactionTypeModel pUserSecurityTransactionTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPIUserSecurityTransactionType;
                string vParameters =
                    "?pUserSecurityTransactionTypeId=" + id +
                    "&pUserSecurityTransactionTypeNameL1=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL1 +
                    "&pUserSecurityTransactionTypeNameL2=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL2 +
                    "&pUserSecurityTransactionTypeNameL3=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL3 +
                    "&pUserSecurityTransactionTypeNameL4=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL4 +
                    "&pUserSecurityTransactionTypeNameL5=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL5 +
                    "&pUserSecurityTransactionTypeNameL6=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL6 +
                    "&pUserSecurityTransactionTypeNameL7=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL7 +
                    "&pUserSecurityTransactionTypeNameL8=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL8 +
                    "&pUserSecurityTransactionTypeNameL9=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL9 +
                    "&pUserSecurityTransactionTypeNameL10=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeNameL10 +
                    "&pUserSecurityTransactionTypeIsActive=" + pUserSecurityTransactionTypeModel.UserSecurityTransactionTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUserSecurityTransactionType.vSQLResult = vDrwResult[0].ToString();
                _dbUserSecurityTransactionType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbUserSecurityTransactionType.funGetUserSecurityTransactionTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//UserSecurityTransactionTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult UserSecurityTransactionTypeReport()
        {

            return View();
        }
    
}
}