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
{   ///  AMR    22/1/2018
    [NoDirectAccess]
    [Authorize]
    public class TransactionTypeController : Controller
    {

        private IdbTransactionType _dbTransactionType;
        private IclsAPI _clsAPI;
        public TransactionTypeController(IdbTransactionType dbTransactionType)
        {
            _dbTransactionType = dbTransactionType;
        }

        // GET: TransactionType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPITransactionType;
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
            TransactionTypeModel vTransactionTypeModel = new TransactionTypeModel();
            if (id == 0)
            {
                ViewBag.vbcSystemId = 0;
            }
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPITransactionType;
                string vParameters = "?pTransactionTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcSystemId = Convert.ToInt32(vDtData.Rows[0]["SystemId"]);
                // Set Model Data
                vTransactionTypeModel.TransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["TransactionTypeId"]);
                vTransactionTypeModel.TransactionTypeCode = vDtData.Rows[0]["TransactionTypeCode"].ToString();
                vTransactionTypeModel.TransactionTypeNameL1 = vDtData.Rows[0]["TransactionTypeNameL1"].ToString();
                vTransactionTypeModel.TransactionTypeNameL2 = vDtData.Rows[0]["TransactionTypeNameL2"].ToString();
                vTransactionTypeModel.SystemId = Convert.ToInt32(vDtData.Rows[0]["SystemId"].ToString());
                vTransactionTypeModel.SystemTransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["SystemTransactionTypeId"].ToString());
                vTransactionTypeModel.TransactionTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["TransactionTypeIsActive"]);
            }

            // Return Result
            return View(vTransactionTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, TransactionTypeModel pTransactionTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPITransactionType;
                string vParameters =
                    "?pTransactionTypeId=" + id +
                    "&pTransactionTypeCode=" + pTransactionTypeModel.TransactionTypeCode +
                    "&pTransactionTypeNameL1=" + pTransactionTypeModel.TransactionTypeNameL1 +
                    "&pTransactionTypeNameL2= " + pTransactionTypeModel.TransactionTypeNameL2 +
                    "&pSystemId=" + pTransactionTypeModel.SystemId +
                    "&pSystemTransactionTypeId= " + pTransactionTypeModel.SystemTransactionTypeId +
                    "&pTransactionTypeIsActive=" + pTransactionTypeModel.TransactionTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbTransactionType.vSQLResult = vDrwResult[0].ToString();
                _dbTransactionType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        // TransactionType Search
        public ActionResult SearchTransactionType()
        {
            return View();
        }

        public void ShowSimple()
        {
            DataTable DT = _dbTransactionType.funGetTransactionTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//TransactionTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult TransactionTypeReport()
        {

            return View();
        }
    }
}