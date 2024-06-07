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
    public class CSController : Controller
    {

        private IdbCustomerSupplier _dbCustomerSupplier;
        private IclsAPI _clsAPI;
        public CSController(IdbCustomerSupplier dbCustomerSupplier, IclsAPI clsAPI)
        {
            _dbCustomerSupplier = dbCustomerSupplier;
            _clsAPI = clsAPI;
        }

        // GET: CustomerSupplier
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICustomerSupplier;
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
            CustomerSupplierModel vCSModel = new CustomerSupplierModel();
            if (id == 0)
            {
                ViewBag.vbcAccountId = 0;
                ViewBag.vbcAreaId = 0;
                ViewBag.vbcCSGroupId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICustomerSupplier;
                string vParameters = "?pCSId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcAccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"]);
                ViewBag.vbcAreaId = Convert.ToInt32(vDtData.Rows[0]["AreaId"].ToString());
                ViewBag.vbcCSGroupId = Convert.ToInt32(vDtData.Rows[0]["CSGroupId"].ToString());

                // Set Model Data
                vCSModel.CSId = Convert.ToInt32(vDtData.Rows[0]["CSId"]);
                vCSModel.CSCode = vDtData.Rows[0]["CSCode"].ToString();
                vCSModel.CSNameL1 = vDtData.Rows[0]["CSNameL1"].ToString();
                vCSModel.CSNameL2 = vDtData.Rows[0]["CSNameL2"].ToString();
                vCSModel.CSAddress = vDtData.Rows[0]["CSAddress"].ToString();
                vCSModel.CSPhone1 = vDtData.Rows[0]["CSPhone1"].ToString();
                vCSModel.CSPhone2 = vDtData.Rows[0]["CSPhone2"].ToString();
                vCSModel.CSEmail = vDtData.Rows[0]["CSEmail"].ToString();
                vCSModel.CSContactPerson = vDtData.Rows[0]["CSContactPerson"].ToString();
                vCSModel.CSSalesPurchasePerson = vDtData.Rows[0]["CSSalesPurchasePerson"].ToString();
                vCSModel.CSTaxNumber = vDtData.Rows[0]["CSTaxNumber"].ToString();
                vCSModel.AreaId = Convert.ToInt32(vDtData.Rows[0]["AreaId"].ToString());
                vCSModel.CSCreditLimit = Convert.ToInt32(vDtData.Rows[0]["CSCreditLimit"]);
                vCSModel.CSGroupId = Convert.ToInt32(vDtData.Rows[0]["CSGroupId"].ToString());
                vCSModel.GracePeriod = Convert.ToInt32(vDtData.Rows[0]["GracePeriod"]);
                vCSModel.AccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"]);
                vCSModel.CSIsCustomer = Convert.ToBoolean(vDtData.Rows[0]["CSIsCustomer"].ToString());
                vCSModel.CSIsActive = Convert.ToBoolean(vDtData.Rows[0]["CSIsActive"]);
            }

            // Return Result
            return View(vCSModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CustomerSupplierModel pCSModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
            
                // API Path
                string vPath = appAPIDirectory.vAPICustomerSupplier;
                string vParameters =
                      "?pCSId=" + id +
                "&pCSCode=" + pCSModel.CSCode +
                "&pCSNameL1=" + pCSModel.CSNameL1 +
                "&pCSNameL2=" + pCSModel.CSNameL2 +
                "&pCSAddress=" + pCSModel.CSAddress +
                "&pCSPhone1=" + pCSModel.CSPhone1 +
                "&pCSPhone2=" + pCSModel.CSPhone2 +
                "&pCSEmail=" + pCSModel.CSEmail +
                "&pCSContactPerson=" + pCSModel.CSContactPerson +
                "&pCSSalesPurchasePerson=" + pCSModel.CSSalesPurchasePerson +
                "&pCSTaxNumber=" + pCSModel.CSTaxNumber +
                "&pAreaId=" + pCSModel.AreaId +
                "&pCSCreditLimit=" + pCSModel.CSCreditLimit +
                "&pCSGroupId=" + pCSModel.CSGroupId +
                "&pGracePeriod=" + pCSModel.GracePeriod +
                "&pAccountId=" + pCSModel.AccountId +
                "&pCSIsCustomer=" + pCSModel.CSIsCustomer +
                "&pCSIsActive=" + pCSModel.CSIsActive +
                "&pIsDeleted=" + pIsDelete +
                "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCustomerSupplier.vSQLResult = vDrwResult[0].ToString();
                _dbCustomerSupplier.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        // AREA Search
        public ActionResult SearchSupplier()
        {
            return View();
        }
        public ActionResult SearchCustomer()
        {
            return View();
        }
        public void ShowSimple()
        {


            DataTable DT = _dbCustomerSupplier.funGetCustomerSupplierReport();
            string vReportPath = Server.MapPath("~/Reports") + "//CustomerSupplierReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult CustomerSupplierReport()
        {

            return View();
        }


    }
}