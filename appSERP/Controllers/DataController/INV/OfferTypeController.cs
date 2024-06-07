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
    public class OfferTypeController : Controller
    {

        private IdbOfferType _dbOfferType;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public OfferTypeController(IdbOfferType dbOfferType, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbOfferType = dbOfferType;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: OfferType
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbOfferType = _dbOfferType;
            // API Path
            string vPath = appAPIDirectory.vAPIOfferType;
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
            OfferTypeModel vOfferTypeModel = new OfferTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIOfferType;
                string vParameters = "?pOfferTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vOfferTypeModel.OfferTypeId = Convert.ToInt32(vDtData.Rows[0]["OfferTypeId"]);
                vOfferTypeModel.OfferTypeCode = vDtData.Rows[0]["OfferTypeCode"].ToString();
                vOfferTypeModel.OfferTypeNameL1 = vDtData.Rows[0]["OfferTypeNameL1"].ToString();
                vOfferTypeModel.OfferTypeNameL2 = vDtData.Rows[0]["OfferTypeNameL2"].ToString();
                vOfferTypeModel.Abbr = vDtData.Rows[0]["Abbr"].ToString();
                vOfferTypeModel.IsDefault = Convert.ToBoolean(vDtData.Rows[0]["IsDefault"]);
                vOfferTypeModel.OfferTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["OfferTypeIsActive"]);

            }

            // Return Result
            return View(vOfferTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, OfferTypeModel pOfferTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIOfferType;
                string vParameters =
                    "?pOfferTypeId=" + id +
                     "&pOfferTypeCode=" + pOfferTypeModel.OfferTypeCode +
                    "&pOfferTypeNameL1=" + pOfferTypeModel.OfferTypeNameL1 +
                    "&pOfferTypeNameL2=" + pOfferTypeModel.OfferTypeNameL2 +
                    "&pAbbr=" + pOfferTypeModel.Abbr +
                    "&pIsDefault=" + pOfferTypeModel.IsDefault +
                    "&pOfferTypeIsActive=" + pOfferTypeModel.OfferTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbOfferType.vSQLResult = vDrwResult[0].ToString();
                _dbOfferType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbOfferType.funGetOfferTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//OfferTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult OfferTypeReport()
        {

            return View();
        }
    }
}