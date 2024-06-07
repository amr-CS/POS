using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models.INV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class StoreDepartmentController : Controller
    {
        
        private ILog _ILog;
        private IdbStoreDepartment _dbStoreDepartment;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public StoreDepartmentController(ILog log, IdbStoreDepartment dbStoreDepartment, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbStoreDepartment = dbStoreDepartment;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: StoreDepartment
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbStoreDepartment = _dbStoreDepartment;

            // API Path
            string vPath = appAPIDirectory.vAPIStoreDepartment;
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
            StoreDepartmentModel vStoreDepartmentModel = new StoreDepartmentModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIStoreDepartment;
                string vParameters = "?pStoreDepartmentId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vStoreDepartmentModel.StoreDepartmentId = Convert.ToInt32(vDtData.Rows[0]["StoreDepartmentId"]);
                vStoreDepartmentModel.StoreDepartmentCode = vDtData.Rows[0]["StoreDepartmentCode"].ToString();
                vStoreDepartmentModel.StoreDepartmentNameL1 = vDtData.Rows[0]["StoreDepartmentNameL1"].ToString();
                vStoreDepartmentModel.StoreDepartmentNameL2 = vDtData.Rows[0]["StoreDepartmentNameL2"].ToString();
                vStoreDepartmentModel.StoreDepartmentIsActive = Convert.ToBoolean(vDtData.Rows[0]["StoreDepartmentIsActive"]);

            }

            // Return Result
            return View(vStoreDepartmentModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, StoreDepartmentModel pStoreDepartmentModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIStoreDepartment;
                string vParameters =
                    "?pStoreDepartmentId=" + id +
                     "&pStoreDepartmentCode=" + pStoreDepartmentModel.StoreDepartmentCode +
                    "&pStoreDepartmentNameL1=" + pStoreDepartmentModel.StoreDepartmentNameL1 +
                    "&pStoreDepartmentNameL2=" + pStoreDepartmentModel.StoreDepartmentNameL2 +
                    "&pStoreDepartmentIsActive=" + pStoreDepartmentModel.StoreDepartmentIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbStoreDepartment.vSQLResult = vDrwResult[0].ToString();
                _dbStoreDepartment.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbStoreDepartment.funGetStoreDepartmentReport();
            string vReportPath = Server.MapPath("~/Reports") + "//StoreDepartmentReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult StoreDepartmentReport()
        {

            return View();
        }
    }
}