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
{   ///  BELAL    22/1/2018 
    [NoDirectAccess]
    [Authorize]
    public class PaymentTypeController : Controller
    {
        private IdbPaymentType _dbPaymentType;
        private IclsAPI _clsAPI;
        public PaymentTypeController(IdbPaymentType dbPaymentType, IclsAPI clsAPI)
        {
            _dbPaymentType = dbPaymentType;
            _clsAPI = clsAPI;
        }

        // GET: PaymentType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIPaymentType;
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
            PaymentTypeModel vPaymentTypeModel = new PaymentTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIPaymentType;
                string vParameters = "?pPaymentTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vPaymentTypeModel.PaymentTypeId = Convert.ToInt32(vDtData.Rows[0]["PaymentTypeId"]);
                vPaymentTypeModel.PaymentTypeCode = vDtData.Rows[0]["PaymentTypeCode"].ToString();
                vPaymentTypeModel.PaymentTypeNameL1 = vDtData.Rows[0]["PaymentTypeNameL1"].ToString();
                vPaymentTypeModel.PaymentTypeNameL2 = vDtData.Rows[0]["PaymentTypeNameL2"].ToString();
                vPaymentTypeModel.PaymentTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["PaymentTypeIsActive"]);
                



            }

            // Return Result
            return View(vPaymentTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, PaymentTypeModel pPaymentTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIPaymentType;
                string vParameters =
                    "?pPaymentTypeId=" + id +
                     "&pPaymentTypeCode=" + pPaymentTypeModel.PaymentTypeCode +
                    "&pPaymentTypeNameL1=" + pPaymentTypeModel.PaymentTypeNameL1 +
                    "&pPaymentTypeNameL2=" + pPaymentTypeModel.PaymentTypeNameL2 +
                    "&pPaymentTypeIsActive=" + pPaymentTypeModel.PaymentTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbPaymentType.vSQLResult = vDrwResult[0].ToString();
                _dbPaymentType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
            DataTable DT = _dbPaymentType.funGetPaymentTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//PaymentTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult PaymentTypeReport()
        {

            return View();
        }
    }
}