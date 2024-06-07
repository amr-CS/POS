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
{
    ///  AMR    21/1/2018
    [NoDirectAccess]
    [Authorize]
    public class AccountCostCenterController : Controller
    {

        private IdbAccountCostCenter _dbAccountCostCenter;
        private IclsAPI _clsAPI;
        public AccountCostCenterController(IdbAccountCostCenter dbAccountCostCenter, IclsAPI clsAPI)
        {
            _dbAccountCostCenter = dbAccountCostCenter;
            _clsAPI = clsAPI;
        }

        // GET: AccountCostCenter
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAccountCostCenter;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

   
        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            AccountCostCenterModel vAccountCostCenterModel = new AccountCostCenterModel();
            string vCostCenterPath = @"/APICostCenter/CostCenterGet";
            string vCostCenterParameters = "?pCostCenterIsActive=True";
            DataTable dtCostCenter = _clsAPI.funResultGet(vCostCenterPath + vCostCenterParameters);
            string vAccountPath = @"/APIAccount/AccountGet";
            string vAccountParameters = "?pAccountIsActive=True";
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath + vAccountParameters);

            if (id == 0)
            {
                ViewBag.vbCostCenterId = new SelectList(dtCostCenter.AsDataView(), "CostCenterId", "CostCenterNameL1");
                ViewBag.vbAccountId = new SelectList(dtAccount.AsDataView(), "AccountId", "AccountNameL1");
                ViewBag.vbcAccountId = 0;
                ViewBag.vbcCostCenterId = 0;

            }

            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPIAccountCostCenter;
                string vParameters = "?pAccountCostCenterId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcAccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"].ToString());
                ViewBag.vbcCostCenterId = Convert.ToInt32(vDtData.Rows[0]["CostCenterId"].ToString());
                ViewBag.vbCostCenterId = new SelectList(dtCostCenter.AsDataView(),
              "CostCenterId", "CostCenterName",
              vDtData.Rows[0]["CostCenterId"].ToString());
                ViewBag.vbAccountId = new SelectList(dtAccount.AsDataView(),
             "AccountId", "AccountName",
             vDtData.Rows[0]["AccountId"].ToString());
                // Set Model Data
                vAccountCostCenterModel.AccountCostCenterId = Convert.ToInt32(vDtData.Rows[0]["AccountCostCenterId"]);
                vAccountCostCenterModel.AccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"].ToString());
                vAccountCostCenterModel.CostCenterId = Convert.ToInt32(vDtData.Rows[0]["CostCenterId"].ToString());
             
            }

            // Return Result
            return View(vAccountCostCenterModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AccountCostCenterModel pAccountCostCenterModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAccountCostCenter;
                string vParameters =
                    "?pAccountCostCenterId=" + id +
                    "&pAccountId=" + pAccountCostCenterModel.AccountId +
                    "&pCostCenterId=" + pAccountCostCenterModel.CostCenterId +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAccountCostCenter.vSQLResult = vDrwResult[0].ToString();
                _dbAccountCostCenter.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
                if (Convert.ToBoolean(pIsDelete)){ return null; }
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


            DataTable DT = _dbAccountCostCenter.funGetAccountCostCenterReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AccountCostCenterReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult AccountCostCenterReport()
        {

            return View();
        }
    }
}