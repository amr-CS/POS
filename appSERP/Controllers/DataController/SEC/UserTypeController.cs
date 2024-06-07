using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.SEC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SEC
{    ///  AMR    21/1/2018   
    public class UserTypeController : Controller
    {
        private IdbUserType _dbUserType;
        private IclsAPI _clsAPI;
        public UserTypeController(IdbUserType dbUserType, IclsAPI clsAPI)
        {
            _dbUserType = dbUserType;
            _clsAPI = clsAPI;
        }

        // GET: UserTypeType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserType;
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
            UserTypeModel vUserTypeModel = new UserTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserType;
                string vParameters = "?pUserTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vUserTypeModel.UserTypeId = Convert.ToInt32(vDtData.Rows[0]["UserTypeId"]);
                vUserTypeModel.UserTypeCode = vDtData.Rows[0]["UserTypeCode"].ToString();
                vUserTypeModel.UserTypeNameL1 = vDtData.Rows[0]["UserTypeNameL1"].ToString();
                vUserTypeModel.UserTypeNameL2 = vDtData.Rows[0]["UserTypeNameL2"].ToString();
                vUserTypeModel.UserTypeMaxDis = Convert.ToInt32(vDtData.Rows[0]["UserTypeMaxDis"].ToString());
                vUserTypeModel.UserTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["UserTypeIsActive"].ToString());

            }

            // Return Result
            return View(vUserTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UserTypeModel pUserTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserType;
                string vParameters =
                        "?pUserTypeId=" + id +
                        "&pUserTypeCode=" + pUserTypeModel.UserTypeCode +
                        "&pUserTypeNameL1=" + pUserTypeModel.UserTypeNameL1 +
                        "&pUserTypeNameL2=" + pUserTypeModel.UserTypeNameL2 +
                        "&pUserTypeMaxDis=" + pUserTypeModel.UserTypeMaxDis +
                        "&pUserTypeIsActive=" + pUserTypeModel.UserTypeIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUserType.vSQLResult = vDrwResult[0].ToString();
                _dbUserType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbUserType.funGetUserTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//UserTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult UserTypeReport()
        {

            return View();
        }


    }
}