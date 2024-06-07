using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.SEC

{
    [NoDirectAccess]
    [Authorize]
    public class UserCashierController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;

        public UserCashierController(ILog log, IclsAPI clsAPI)
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
        // GET: UserCashier
        public ActionResult Index()
        {
            return View();
        }

       // Save
       public string funSaveUserCashier(
       int? pUserCashierId = null,
       int? pUserId = null,
       int? pCashierId = null,
       bool? pModifyInvoice = null,
       bool? pCancelInvoice = null,
       bool? pRePrintInvoice = null,
       bool? pIsCashierDelivery = null,
       bool? pPcVerfiy = null,
       bool? pReturnInsurance = null,
       bool? pSearchInvoice = null,
       bool? pHoldInvoice = null,
       bool? Discount = null,
       int? pInsuranceLimit = null,
       int? ReportPeriod = null,
       bool? pIsDeleted = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APIUserCashier/UserCashierGET";
            // Paramter
            string vParameters =
                "?pUserCashierId=" + pUserCashierId +
                "&pUserId=" + pUserId +
                "&pCashierId=" + pCashierId +
                "&pModifyInvoice=" + pModifyInvoice +
                "&pCancelInvoice=" + pCancelInvoice +
                "&pRePrintInvoice=" + pRePrintInvoice +
                "&pIsCashierDelivery=" + pIsCashierDelivery +
                "&pPcVerfiy=" + pPcVerfiy +
                "&pReturnInsurance=" + pReturnInsurance +
                "&pSearchInvoice=" + pSearchInvoice +
                "&pHoldInvoice=" + pHoldInvoice +
                "&Discount=" + Discount +
                "&pInsuranceLimit=" + pInsuranceLimit +
                "&ReportPeriod=" + ReportPeriod +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vResult;
        }
        // Save
        public string funSaveUserGroup(
        int? pUserGroupId = null,
        int? pUserId = null,
        int? pGroupId = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APIUserGroup/UserGroupGET";
            // Paramter
            string vParameters =
                "?pUserGroupId=" + pUserGroupId +
                "&pUserId=" + pUserId +
                "&pGroupId=" + pGroupId +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;

            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vResult;
        }

        public ActionResult CashierSearch()
        {
            return View();
        }
        public ActionResult UserSearch()
        {
            return View();
        }
    }
}