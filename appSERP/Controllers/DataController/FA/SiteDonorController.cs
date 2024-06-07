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
    ///  Belal    3/3/2018
    public class SiteDonorController : Controller
    {

        private IdbSiteDonor _dbSiteDonor;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SiteDonorController(IdbSiteDonor dbSiteDonor, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSiteDonor = dbSiteDonor;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: SiteDonor
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbSiteDonor = _dbSiteDonor;

            // API Path
            string vPath = appAPIDirectory.vAPISiteDonor;
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
            SiteDonorModel vSiteDonorModel = new SiteDonorModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISiteDonor;
                string vParameters = "?pSiteDonorId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSiteDonorModel.SiteDonorId = Convert.ToInt32(vDtData.Rows[0]["SiteDonorId"]);
                vSiteDonorModel.SiteDonorNameL1 = vDtData.Rows[0]["SiteDonorNameL1"].ToString();
                vSiteDonorModel.SiteDonorNameL2 = vDtData.Rows[0]["SiteDonorNameL2"].ToString();
                vSiteDonorModel.SiteDonorIsActive = Convert.ToBoolean(vDtData.Rows[0]["SiteDonorIsActive"]);
            }

            // Return Result
            return View(vSiteDonorModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SiteDonorModel pSiteDonorModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISiteDonor;
                string vParameters =
                    "?pSiteDonorId=" + id +
                    "&pSiteDonorNameL1=" + pSiteDonorModel.SiteDonorNameL1 +
                    "&pSiteDonorNameL2= " + pSiteDonorModel.SiteDonorNameL2 +
                    "&pSiteDonorIsActive=" + pSiteDonorModel.SiteDonorIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSiteDonor.vSQLResult = vDrwResult[0].ToString();
                _dbSiteDonor.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbSiteDonor.funGetSiteDonorReport();
            string vReportPath = Server.MapPath("~/Reports") + "//SiteDonorReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult SiteDonorReport()
        {

            return View();
        }

    }
}