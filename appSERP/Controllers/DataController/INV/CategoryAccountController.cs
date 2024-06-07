using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class CategoryAccountController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;
        public CategoryAccountController(ILog log, IclsAPI clsAPI)
        {
            _ILog = log;
            _clsAPI = clsAPI;

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
       
        // GET: CategoryAccount
        public ActionResult Index()
        {
            return View();
        }
        // Cash Desk GET
        public string CategoryAccountGET(
        int? pCategoryAccountId = null,
        string pCategoryAccountCode = null,
        string pCategoryAccountNameL1 = null,
        string pCategoryAccountNameL2 = null,
        int? pCurrencyId = null,
        int? pAccountId = null,
        int? pSalesAccountId = null,
        int? pReturnSalesAccountId = null,
        int? pDiscountReceivedId = null,
        int? pDiscountAllowedId = null,
        int? pTaxAccountId = null,
        int? pGroupAccountId = null,
        int? pReturnPurchasesAccountId = null,
        int? pSalesCostAccountId = null,
        int? pProductTypeId = null,
        bool? pCategoryAccountIsActive = null,
        bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICategoryAccount;
            // Praremeter
            string vParameters =
                "?pCategoryAccountId=" + pCategoryAccountId +
                "&pCategoryAccountCode=" + pCategoryAccountCode +
                "&pCategoryAccountNameL1=" + pCategoryAccountNameL1 +
                "&pCategoryAccountNameL2=" + pCategoryAccountNameL2 +
                "&pCurrencyId=" + pCurrencyId +
                "&pAccountId=" + pAccountId +
                "&pSalesAccountId=" + pSalesAccountId +
                "&pReturnSalesAccountId=" + pReturnSalesAccountId +
                "&pDiscountReceivedId=" + pDiscountReceivedId +
                "&pDiscountAllowedId=" + pDiscountAllowedId +
                "&pTaxAccountId=" + pTaxAccountId +
                "&pGroupAccountId=" + pGroupAccountId +
                "&pReturnPurchasesAccountId=" + pReturnPurchasesAccountId +
                "&pSalesCostAccountId=" + pSalesCostAccountId +
                "&pProductTypeId=" + pProductTypeId +
                "&pCategoryAccountIsActive=" + pCategoryAccountIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public string CategoryAccountByNameGET(
string pCategoryAccountCode = null,
bool? pCategoryAccountIsActive = null,
bool? pIsDeleted = false,
    int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICategoryAccount;
            // Praremeter
            string vParameters =
                "?pCategoryAccountCode=" + pCategoryAccountCode +
                "&pCategoryAccountIsActive=" + pCategoryAccountIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + 400;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }



        // Category Account Search
        public ActionResult SearchCategoryAccount()
        {
            return View();
        }
    }
}