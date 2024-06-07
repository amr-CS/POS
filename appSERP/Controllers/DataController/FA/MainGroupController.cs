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
    public class MainGroupController : Controller
    {// GET: MainGroup

        private IdbMainGroup _dbMainGroup;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public MainGroupController(IdbMainGroup dbMainGroup, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbMainGroup = dbMainGroup;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }


        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbMainGroup = _dbMainGroup;

            // API Path
            string vPath = appAPIDirectory.vAPIMainGroup;
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
            MainGroupModel vMainGroupModel = new MainGroupModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIMainGroup;
                string vParameters = "?pMainGroupId=" + id;

                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vMainGroupModel.MainGroupId = Convert.ToInt32(vDtData.Rows[0]["MainGroupId"]);
                vMainGroupModel.MainGroupNameL1 = vDtData.Rows[0]["MainGroupNameL1"].ToString();
                vMainGroupModel.MainGroupNameL2 = vDtData.Rows[0]["MainGroupNameL2"].ToString();
                vMainGroupModel.MainGroupIsActive = Convert.ToBoolean(vDtData.Rows[0]["MainGroupIsActive"]);
                vMainGroupModel.FixedAssetMethodId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetMethodId"]);
                vMainGroupModel.MainGroupPercent = Convert.ToInt32(vDtData.Rows[0]["MainGroupPercent"]);

                //vMainGroupModel.MainGroupDebitAccount = Convert.ToInt32(vDtData.Rows[0]["MainGroupDebitAccount"]);
                if (vDtData.Rows[0]["MainGroupDebitAccount"] is DBNull)
                {
                    vMainGroupModel.MainGroupDebitAccount = 0;
                }
                else if (vDtData.Rows[0]["MainGroupDebitAccount"] == null)
                {
                    vMainGroupModel.MainGroupDebitAccount = 0;
                }
                else
                {
                    vMainGroupModel.MainGroupDebitAccount = Convert.ToInt32(vDtData.Rows[0]["MainGroupDebitAccount"]);
                }
                if (vDtData.Rows[0]["MainGroupCreditAccount"] is DBNull)
                {
                    vMainGroupModel.MainGroupCreditAccount = 0;
                }
                else if (vDtData.Rows[0]["MainGroupCreditAccount"] == null)
                {
                    vMainGroupModel.MainGroupCreditAccount = 0;
                }
                else
                {
                    vMainGroupModel.MainGroupCreditAccount = Convert.ToInt32(vDtData.Rows[0]["MainGroupCreditAccount"]);
                }
                if (vDtData.Rows[0]["MainGroupPurchaseAccount"] is DBNull)
                {
                    vMainGroupModel.MainGroupPurchaseAccount = 0;
                }
                else if (vDtData.Rows[0]["MainGroupPurchaseAccount"] == null)
                {
                    vMainGroupModel.MainGroupPurchaseAccount = 0;
                }
                else
                {
                    vMainGroupModel.MainGroupPurchaseAccount = Convert.ToInt32(vDtData.Rows[0]["MainGroupPurchaseAccount"]);
                }
                if (vDtData.Rows[0]["MainGroupSalesAccount"] is DBNull)
                {
                    vMainGroupModel.MainGroupSalesAccount = 0;
                }
                else if (vDtData.Rows[0]["MainGroupSalesAccount"] == null)
                {
                    vMainGroupModel.MainGroupSalesAccount = 0;
                }
                else
                {
                    vMainGroupModel.MainGroupSalesAccount = Convert.ToInt32(vDtData.Rows[0]["MainGroupSalesAccount"]);
                }


             
            }

            // Return Result
            return View(vMainGroupModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, MainGroupModel pMainGroupModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIMainGroup;
                string vParameters =
                    "?pMainGroupId=" + id +
                    "&pMainGroupNameL1=" + pMainGroupModel.MainGroupNameL1 +
                    "&pMainGroupNameL2=" + pMainGroupModel.MainGroupNameL2 +
                    "&pMainGroupIsActive=" + pMainGroupModel.MainGroupIsActive +
                    "&pFixedAssetMethodId=" + pMainGroupModel.FixedAssetMethodId +
                    "&pMainGroupPercent=" + pMainGroupModel.MainGroupPercent +
                    "&pMainGroupDebitAccount=" + pMainGroupModel.MainGroupDebitAccount +
                    "&pMainGroupCreditAccount=" + pMainGroupModel.MainGroupCreditAccount +
                    "&pMainGroupPurchaseAccount=" + pMainGroupModel.MainGroupPurchaseAccount +
                    "&pMainGroupSalesAccount=" + pMainGroupModel.MainGroupSalesAccount +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbMainGroup.vSQLResult = vDrwResult[0].ToString();
                _dbMainGroup.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
          

            DataTable DT = _dbMainGroup.funGetMainGroupsReport();
            string vReportPath = Server.MapPath("~/Reports") + "//MainGroupReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult MainGroupReport()
        {
         
            return View();
        }
       
    }
}