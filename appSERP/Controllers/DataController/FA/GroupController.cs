using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.FA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    public class GroupController : Controller
    {

        private IdbGroup _dbGroup;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public GroupController(IdbGroup dbGroup, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbGroup = dbGroup;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: Group
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbGroup = _dbGroup;

            // API Path
            string vPath = appAPIDirectory.vAPIGroup;
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
            GroupModel vGroupModel = new GroupModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIGroup;
                string vParameters = "?pGroupId=" + id;

                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vGroupModel.GroupId = Convert.ToInt32(vDtData.Rows[0]["GroupId"]);
                vGroupModel.MainGroupId = Convert.ToInt32(vDtData.Rows[0]["MainGroupId"]);
                vGroupModel.GroupNameL1 = vDtData.Rows[0]["GroupNameL1"].ToString();
                vGroupModel.GroupNameL2 = vDtData.Rows[0]["GroupNameL2"].ToString();
                vGroupModel.GroupIsActive = Convert.ToBoolean(vDtData.Rows[0]["GroupIsActive"]);
                vGroupModel.FixedAssetMethodId = Convert.ToInt32(vDtData.Rows[0]["FixedAssetMethodId"]);
                vGroupModel.GroupPercent = Convert.ToInt32(vDtData.Rows[0]["GroupPercent"]);
                vGroupModel.GroupDebitAccount = Convert.ToInt32(vDtData.Rows[0]["GroupDebitAccount"]);
                vGroupModel.GroupCreditAccount = Convert.ToInt32(vDtData.Rows[0]["GroupCreditAccount"]);
                vGroupModel.GroupPurchaseAccount = Convert.ToInt32(vDtData.Rows[0]["GroupPurchaseAccount"]);
                vGroupModel.GroupSalesAccount = Convert.ToInt32(vDtData.Rows[0]["GroupSalesAccount"]);
            }

            // Return Result
            return View(vGroupModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, GroupModel pGroupModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIGroup;
                string vParameters =
                    "?pGroupId=" + id +
                    "&pMainGroupId=" + pGroupModel.MainGroupId +
                    "&pGroupNameL1=" + pGroupModel.GroupNameL1 +
                    "&pGroupNameL2= " + pGroupModel.GroupNameL2 +
                    "&pGroupIsActive=" + pGroupModel.GroupIsActive +
                    "&pFixedAssetMethodId=" + pGroupModel.FixedAssetMethodId +
                    "&pGroupPercent=" + pGroupModel.GroupPercent +
                    "&pGroupDebitAccount= " + pGroupModel.GroupDebitAccount +
                    "&pGroupCreditAccount=" + pGroupModel.GroupCreditAccount +
                    "&pGroupPurchaseAccount=" + pGroupModel.GroupPurchaseAccount +
                    "&pGroupSalesAccount= " + pGroupModel.GroupSalesAccount +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbGroup.vSQLResult = vDrwResult[0].ToString();
                _dbGroup.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbGroup.funGetGroupReport();
            string vReportPath = Server.MapPath("~/Reports") + "//GroupReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult GroupReport()
        {

            return View();
        }










    }
}