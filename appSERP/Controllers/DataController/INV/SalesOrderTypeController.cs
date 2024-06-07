using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
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
    public class SalesOrderTypeController : Controller
    {

        private IdbSalesOrderType _dbSalesOrderType;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SalesOrderTypeController(IdbSalesOrderType dbSalesOrderType, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSalesOrderType = dbSalesOrderType;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: SalesOrderType
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbSalesOrderType = _dbSalesOrderType;

            // API Path
            string vPath = appAPIDirectory.vAPISalesOrderType;
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
            SalesOrderTypeModel vSalesOrderTypeModel = new SalesOrderTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISalesOrderType;
                string vParameters = "?pSalesOrderTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSalesOrderTypeModel.SalesOrderTypeId = Convert.ToInt32(vDtData.Rows[0]["SalesOrderTypeId"]);
                vSalesOrderTypeModel.SalesOrderTypeCode = vDtData.Rows[0]["SalesOrderTypeCode"].ToString();
                vSalesOrderTypeModel.SalesOrderTypeNameL1 = vDtData.Rows[0]["SalesOrderTypeNameL1"].ToString();
                vSalesOrderTypeModel.SalesOrderTypeNameL2 = vDtData.Rows[0]["SalesOrderTypeNameL2"].ToString();
                vSalesOrderTypeModel.Abbr = vDtData.Rows[0]["Abbr"].ToString();
                vSalesOrderTypeModel.IsDefault = Convert.ToBoolean(vDtData.Rows[0]["IsDefault"]);
                vSalesOrderTypeModel.SalesOrderTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["SalesOrderTypeIsActive"]);

            }

            // Return Result
            return View(vSalesOrderTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SalesOrderTypeModel pSalesOrderTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISalesOrderType;
                string vParameters =
                    "?pSalesOrderTypeId=" + id +
                     "&pSalesOrderTypeCode=" + pSalesOrderTypeModel.SalesOrderTypeCode +
                    "&pSalesOrderTypeNameL1=" + pSalesOrderTypeModel.SalesOrderTypeNameL1 +
                    "&pSalesOrderTypeNameL2=" + pSalesOrderTypeModel.SalesOrderTypeNameL2 +
                    "&pAbbr=" + pSalesOrderTypeModel.Abbr +
                    "&pIsDefault=" + pSalesOrderTypeModel.IsDefault +
                    "&pSalesOrderTypeIsActive=" + pSalesOrderTypeModel.SalesOrderTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSalesOrderType.vSQLResult = vDrwResult[0].ToString();
                _dbSalesOrderType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbSalesOrderType.funGetSalesOrderTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//SalesOrderTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult SalesOrderTypeReport()
        {

            return View();
        }
    }
}