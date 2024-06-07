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
    public class BuyGroupController : Controller
    {  // GET: BuyGroup

        private IdbBuyGroup _dbBuyGroup;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public BuyGroupController(IdbBuyGroup dbBuyGroup, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbBuyGroup = dbBuyGroup;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbBuyGroup = _dbBuyGroup;

            // API Path
            string vPath = appAPIDirectory.vAPIBuyGroup;
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
            BuyGroupModel vBuyGroupModel = new BuyGroupModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIBuyGroup;
                string vParameters = "?pBuyGroupId=" + id;

                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vBuyGroupModel.BuyGroupId = Convert.ToInt32(vDtData.Rows[0]["BuyGroupId"]);
                vBuyGroupModel.BuyGroupNameL1 = vDtData.Rows[0]["BuyGroupNameL1"].ToString();
                vBuyGroupModel.BuyGroupNameL2 = vDtData.Rows[0]["BuyGroupNameL2"].ToString();
                vBuyGroupModel.BuyGroupIsActive = Convert.ToBoolean(vDtData.Rows[0]["BuyGroupIsActive"]);
           
            }

            // Return Result
            return View(vBuyGroupModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, BuyGroupModel pBuyGroupModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIBuyGroup;
                string vParameters =
                    "?pBuyGroupId=" + id +
                    "&pBuyGroupNameL1=" + pBuyGroupModel.BuyGroupNameL1 +
                    "&pBuyGroupNameL2= " + pBuyGroupModel.BuyGroupNameL2 +
                    "&pBuyGroupIsActive=" + pBuyGroupModel.BuyGroupIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbBuyGroup.vSQLResult = vDrwResult[0].ToString();
                _dbBuyGroup.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbBuyGroup.funGetBuyGroupReport();
            string vReportPath = Server.MapPath("~/Reports") + "//BuyGroupReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult BuyGroupReport()
        {

            return View();

        }

    }
}