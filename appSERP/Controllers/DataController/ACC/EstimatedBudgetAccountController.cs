using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
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
    [NoDirectAccess]
    [Authorize]
    public class EstimatedBudgetAccountController : Controller
    {

        private IdbEstimatedBudgetAccount _dbEstimatedBudgetAccount;
        private IclsAPI _clsAPI;

        public EstimatedBudgetAccountController(IdbEstimatedBudgetAccount dbEstimatedBudgetAccount, IclsAPI clsAPI)
        {
            _dbEstimatedBudgetAccount = dbEstimatedBudgetAccount;
            _clsAPI = clsAPI;
        }

        // GET: EstimatedBudgetAccount
        public ActionResult Index(int? id = 0)
        {
            // API Path
            string vPath = appAPIDirectory.vAPIEstimatedBudgetAccount;
            DataTable vDtData;
            if (id > 0)
            {
                // Result
                string vParameters = "?pEstimatedBudgetAccountId=" + id;
                 vDtData = _clsAPI.funResultGet(vPath + vParameters);
            }
            else
            {
                vDtData = _clsAPI.funResultGet(vPath);
            }
            // Result
            //DataTable vDtData = clsAPI.funResultGet(vPath);
           
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
            EstimatedBudgetAccountModel vEstimatedBudgetAccountModel = new EstimatedBudgetAccountModel();
            if (id == 0 )
            {
                ViewBag.vbcAccountId = 0;
            }
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIEstimatedBudgetAccount;
                string vParameters = "?pEstimatedBudgetAccountId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcAccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"]);
                // Set Model Data
                vEstimatedBudgetAccountModel.EstimatedBudgetAccountId = Convert.ToInt32(vDtData.Rows[0]["EstimatedBudgetAccountId"]);
                vEstimatedBudgetAccountModel.AccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"]);
                vEstimatedBudgetAccountModel.EstimatedBudgetAccountValue = Convert.ToDecimal(vDtData.Rows[0]["EstimatedBudgetAccountValue"]);

            }

            // Return Result
            return View(vEstimatedBudgetAccountModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, EstimatedBudgetAccountModel pEstimatedBudgetAccountModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIEstimatedBudgetAccount;
                string vParameters =
                    "?pEstimatedBudgetAccountId=" + id +
                     "&pAccountId=" + pEstimatedBudgetAccountModel.AccountId +
                    "&pEstimatedBudgetAccountValue=" + pEstimatedBudgetAccountModel.EstimatedBudgetAccountValue +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbEstimatedBudgetAccount.vSQLResult = vDrwResult[0].ToString();
                _dbEstimatedBudgetAccount.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
    }
}