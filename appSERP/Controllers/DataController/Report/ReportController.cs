using appSERP.appCode.dbCode.ACC.Doc;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.Report
{
    [NoDirectAccess]
    [Authorize]
    public class ReportController : Controller
    {
        private IclsAPI _clsAPI;

        public ReportController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        public ActionResult Report()
        {
            return View();
        }

        // View - Report Journal
        public ActionResult GLVoucherReport(string id = "5")
         // public ActionResult GLVoucherReport(string id = null)
        {
            string vAPIPath = "/APIGLVoucher/GLVoucherGET?phGLVoucherId=" + id;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);


            DataTable DTDocDetail = new DataTable();
            DTDocDetail.Columns.Add("GLVoucherDtlId");
            DTDocDetail.Columns.Add("dGLVoucher");
            DTDocDetail.Columns.Add("dGLVoucherTypeId");
            DTDocDetail.Columns.Add("dFinancialYearId");
            DTDocDetail.Columns.Add("AccountId");
            DTDocDetail.Columns.Add("AccNo");
            DTDocDetail.Columns.Add("AccountNameL1");
            DTDocDetail.Columns.Add("AccountNameL2");
            //DTDocDetail.Columns.Add("IsCostCenter");
            DTDocDetail.Columns.Add("CurrencyFactorValue");
            DTDocDetail.Columns.Add("dCashDeskId");
            DTDocDetail.Columns.Add("CurrencyId");
            DTDocDetail.Columns.Add("GLVoucherDtlDebit");
            DTDocDetail.Columns.Add("GLVoucherDtlCredit");
            DTDocDetail.Columns.Add("CostCenterNameL1");
            DTDocDetail.Columns.Add("CostCenterNameL2");
            DTDocDetail.Columns.Add("GLVoucherDtlNote");
            DTDocDetail.Columns.Add("CurrencyNameL1");
            DTDocDetail.Columns.Add("CurrencyNameL2");

            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(vJSONResult);
            int rowindex = 0;
            foreach (var result in obj)
            {
                foreach (JObject config in result["DocDetail"])
                {
                    //string id2 = (string)config["GLVoucherDtlId"];
                    //string name = (string)config["dGLVoucher"];
                    //string gid = (string)config["dFinancialYearId"];
                    DTDocDetail.Rows.Add();
                    DTDocDetail.Rows[rowindex]["GLVoucherDtlId"] = (string)config["GLVoucherDtlId"];
                    DTDocDetail.Rows[rowindex]["dGLVoucher"] = (string)config["dGLVoucher"];
                    DTDocDetail.Rows[rowindex]["dGLVoucherTypeId"] = (string)config["dGLVoucherTypeId"];
                    DTDocDetail.Rows[rowindex]["dFinancialYearId"] = (string)config["dFinancialYearId"];
                    DTDocDetail.Rows[rowindex]["AccountId"] = (string)config["AccountId"];
                    DTDocDetail.Rows[rowindex]["AccNo"] = (string)config["AccNo"];
                    DTDocDetail.Rows[rowindex]["AccountNameL1"] = (string)config["AccountNameL1"];
                    DTDocDetail.Rows[rowindex]["AccountNameL2"] = (string)config["AccountNameL2"];
                    DTDocDetail.Rows[rowindex]["CurrencyFactorValue"] = (string)config["CurrencyFactorValue"];
                    DTDocDetail.Rows[rowindex]["CurrencyId"] = (string)config["CurrencyId"];
                    DTDocDetail.Rows[rowindex]["GLVoucherDtlDebit"] = (string)config["GLVoucherDtlDebit"];
                    DTDocDetail.Rows[rowindex]["GLVoucherDtlCredit"] = (string)config["GLVoucherDtlCredit"];
                    DTDocDetail.Rows[rowindex]["CostCenterNameL1"] = (string)config["CostCenterNameL1"];
                    DTDocDetail.Rows[rowindex]["CostCenterNameL2"] = (string)config["CostCenterNameL2"];
                    DTDocDetail.Rows[rowindex]["GLVoucherDtlNote"] = (string)config["GLVoucherDtlNote"];
                    DTDocDetail.Rows[rowindex]["CurrencyNameL1"] = (string)config["CurrencyNameL1"];
                    DTDocDetail.Rows[rowindex]["CurrencyNameL2"] = (string)config["CurrencyNameL2"];


                    rowindex ++;
                }
            }





            ViewBag.vbData = vDtData;


            // Detail
            //string vDetail = vDtData.Rows[0]["DocDetail"].ToString();
            //DataTable vDtDocDetail = JsonConvert.DeserializeObject<DataTable>(vDetail);
            //ViewBag.vbDataDetail = vDtDocDetail;
            ViewBag.vbDataDetail = DTDocDetail;

            return View();
        }
        public ActionResult CostCenterReport(string id = "1")
        {
            string vAPIPath = "/APICostCenter/CostCenterGET?pCostCenterId=" + id;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            string vAPIPathDtl = "/APICostCenter/CostCenterGET?pCostCenterId=" + id+ "&&pQueryTypeId=405";
            // Detail
            string vJSONResultDtl = _clsAPI.funResultGetJSON(vAPIPathDtl);
            DataTable vDtDataDtl = JsonConvert.DeserializeObject<DataTable>(vJSONResultDtl);
            ViewBag.vbData = vDtData;
            ViewBag.vbDataDetail = vDtDataDtl;
            return View();

        }
        public ActionResult AccountReport(string id = "1")
        {
            string vAPIPath = "/APIAccount/AccountGET?pAccountId=" + id;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            string vAPIPathDtl = "/APIAccount/AccountGET?pAccountId=" + id + "&&pQueryTypeId=408";
            // Detail
            string vJSONResultDtl = _clsAPI.funResultGetJSON(vAPIPathDtl);
            DataTable vDtDataDtl = JsonConvert.DeserializeObject<DataTable>(vJSONResultDtl);
            ViewBag.vbData = vDtData;
            ViewBag.vbDataDetail = vDtDataDtl;
            return View();

        }
        public ActionResult BankReport(string id = "1")
        {
            string vAPIPath = "/APIBank/BankGET?pBankId=" + id + "&&pIsAccountDetail=false" + "&&pQueryTypeId=400";

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            string vAPIPathDtl = "/APIBank/BankGET?pBankParentId=" + id + "&&pQueryTypeId=400" + "&&pIsAccountDetail=false";
            // Detail
            string vJSONResultDtl = _clsAPI.funResultGetJSON(vAPIPathDtl);
            DataTable vDtDataDtl = JsonConvert.DeserializeObject<DataTable>(vJSONResultDtl);
            ViewBag.vbData = vDtData;
            ViewBag.vbDataDetail = vDtDataDtl;
            return View();

        }

        // CS Movement Report
        public ActionResult CSMovementReport(string id = null, string pCSId = null, string pDateFrom = null, string pDateTo = null, string pAccountId = null, string pCostCenterId = null)
        {
            // Report Data
            DataTable vDtReportCSData = funCSMovementReportData(id, pCSId, pDateFrom, pDateTo, pAccountId, pCostCenterId);

            // Viewbag
            ViewBag.vbData = vDtReportCSData;

            // Return View
            return View();

        }
        // CS Report
        public ActionResult CSMovementPartialReport(string id = null, string pCSId = null, string pDateFrom = null, string pDateTo = null, string pAccountId = null, string pCostCenterId = null)
        {
            // Report Data
            DataTable vDtReportCSData = funCSMovementReportData(id, pCSId, pDateFrom, pDateTo, pAccountId, pCostCenterId);
            // Return View - Data
            return View(vDtReportCSData);
        }


        public DataTable funCSMovementReportData(string id = null, string pCSId = null, string pDateFrom = null, string pDateTo = null, string pAccountId = null, string pCostCenterId = null)
        {
            // API CS Movement
            string vAPIPath = "/APICSMovement/CSMovementGET";
            string vParameters = 
                "?pCSId=" + pCSId + 
                "&pDateFrom=" + pDateFrom + 
                "&pDateTo=" + pDateTo + 
                "&pAccountId=" + pAccountId + 
                "&pCostCenterId=" + pCostCenterId;

            // JSON Result
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath + vParameters);
            // Convert to DataTable
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            // Return Data
            return vDtData;
        }
        // EstimatedBudget Account Report
        public ActionResult EstimatedBudgetAccountReport(string id = null, string pEstimatedBudgetAccountId = null,string pAccountId = null, string pDateFrom = null, string pDateTo = null)
        {
            // Report Data
            DataTable vDtReportEstimatedBudgetAccountData = funEstimatedBudgetAccountData(id, pEstimatedBudgetAccountId, pAccountId, pDateFrom, pDateTo);

            // Viewbag
            ViewBag.vbData = vDtReportEstimatedBudgetAccountData;

            // Return View
            return View();

        }
        // CS Report
        public ActionResult EstimatedBudgetAccountPartialReport(string id = null, string pEstimatedBudgetAccountId = null, string pAccountId = null, string pDateFrom = null, string pDateTo = null)
        {
            // Report Data
            DataTable vDtReportEstimatedBudgetAccountData = funEstimatedBudgetAccountData(id, pEstimatedBudgetAccountId, pAccountId, pDateFrom, pDateTo);
            // Return View - Data
            return View(vDtReportEstimatedBudgetAccountData);
        }

        public DataTable funEstimatedBudgetAccountData(string id = null, string pEstimatedBudgetAccountId = null, string pAccountId = null, string pDateFrom = null, string pDateTo = null)
        {
            // API CS Movement
            string vAPIPath = "/APIEstimatedBudgetAccount/EstimatedBudgetAccountGET";
            string vParameters =
                "?pEstimatedBudgetAccountId=" + pEstimatedBudgetAccountId +
                "&pAccountId=" + pAccountId +
                "&pDateFrom=" + pDateFrom +
                "&pDateTo=" + pDateTo;


            // JSON Result
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath + vParameters);
            // Convert to DataTable
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            // Return Data
            return vDtData;
        }

        #region ReportParameters

        // Get Account
        public  string funGetAccount()
        {
            string vPath = appAPIDirectory.vAPIAccount;
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            return JsonConvert.SerializeObject(vDtData);
        }

        // Get CostCenter
        public string funGetCostCenter()
        {
            string vPath = appAPIDirectory.vAPICostCenter;
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            return JsonConvert.SerializeObject(vDtData);
        }

        // Get CS
        public string funGetCustomerSupplier()
        {
            string vPath = appAPIDirectory.vAPICustomerSupplier;
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            return JsonConvert.SerializeObject(vDtData);
        }

        #endregion ReportParameters






    }
}