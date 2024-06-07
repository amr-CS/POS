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
    public class TransactionSourceController : Controller
    {

        private IdbTransactionSource _dbTransactionSource;
        private IclsAPI _clsAPI;
        public TransactionSourceController(IdbTransactionSource dbTransactionSource, IclsAPI clsAPI)
        {
            _dbTransactionSource = dbTransactionSource;
            _clsAPI = clsAPI;
        }

        // GET: TransactionSource
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPITransactionSource;
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
            TransactionSourceModel vTransactionSourceModel = new TransactionSourceModel();
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPITransactionSource;
                string vParameters = "?pTransactionSourceId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vTransactionSourceModel.TransactionSourceId = Convert.ToInt32(vDtData.Rows[0]["TransactionSourceId"]);
                vTransactionSourceModel.TransactionSourceCode = vDtData.Rows[0]["TransactionSourceCode"].ToString();
                vTransactionSourceModel.TransactionSourceNameL1 = vDtData.Rows[0]["TransactionSourceNameL1"].ToString();
                vTransactionSourceModel.TransactionSourceNameL2 = vDtData.Rows[0]["TransactionSourceNameL2"].ToString();
                vTransactionSourceModel.TransactionSourceIsActive = Convert.ToBoolean(vDtData.Rows[0]["TransactionSourceIsActive"]);
            }

            // Return Result
            return View(vTransactionSourceModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, TransactionSourceModel pTransactionSourceModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPITransactionSource;
                string vParameters =
                    "?pTransactionSourceId=" + id +
                    "&pTransactionSourceCode=" + pTransactionSourceModel.TransactionSourceCode +
                    "&pTransactionSourceNameL1=" + pTransactionSourceModel.TransactionSourceNameL1 +
                    "&pTransactionSourceNameL2=" + pTransactionSourceModel.TransactionSourceNameL2 +
                    "&pTransactionSourceIsActive=" + pTransactionSourceModel.TransactionSourceIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbTransactionSource.vSQLResult = vDrwResult[0].ToString();
                _dbTransactionSource.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbTransactionSource.funGetTransactionSourceReport();
            string vReportPath = Server.MapPath("~/Reports") + "//TransactionSourceReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult TransactionSourceReport()
        {

            return View();
        }

    }
}