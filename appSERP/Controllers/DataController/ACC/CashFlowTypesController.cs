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
using System.Data;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{   ///  BELAL    22/1/2018 
    [NoDirectAccess]
    [Authorize]
    public class CashFlowTypesController : Controller
    {
        private IdbCashFlowType _dbCashFlowType;
        private IclsAPI _clsAPI;
        public CashFlowTypesController(IdbCashFlowType dbCashFlowType, IclsAPI clsAPI)
        {
            _dbCashFlowType = dbCashFlowType;
            _clsAPI = clsAPI;
        }

        // GET: CashFlowType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICashFlowType;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return Result
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            CashFlowTypeModel vCashFlowTypeModel = new CashFlowTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICashFlowType;
                string vParameters = "?pCashFlowTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCashFlowTypeModel.CashFlowTypeId = Convert.ToInt32(vDtData.Rows[0]["CashFlowTypeId"]);
                vCashFlowTypeModel.CashFlowTypeCode = vDtData.Rows[0]["CashFlowTypeCode"].ToString();
                vCashFlowTypeModel.CashFlowTypeNameL1 = vDtData.Rows[0]["CashFlowTypeNameL1"].ToString();
                vCashFlowTypeModel.CashFlowTypeNameL2 = vDtData.Rows[0]["CashFlowTypeNameL2"].ToString();
                vCashFlowTypeModel.CashFlowTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["CashFlowTypeIsActive"]);
            }

            // Return Result
            return View(vCashFlowTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CashFlowTypeModel pCashFlowTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICashFlowType;
                string vParameters =
                        "?pCashFlowTypeId=" + id +
                        "&pCashFlowTypeCode=" + pCashFlowTypeModel.CashFlowTypeCode +
                        "&pCashFlowTypeNameL1=" + pCashFlowTypeModel.CashFlowTypeNameL1 +
                        "&pCashFlowTypeNameL2=" + pCashFlowTypeModel.CashFlowTypeNameL2 +
                        "&pCashFlowTypeIsActive=" + pCashFlowTypeModel.CashFlowTypeIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCashFlowType.vSQLResult = vDrwResult[0].ToString();
                _dbCashFlowType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


            DataTable DT = _dbCashFlowType.funGetCashFlowTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//CashFlowTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult CashFlowTypeReport()
        {

            return View();
        }


    }
}