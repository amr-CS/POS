using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
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
    public class InvChecksController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;
        public InvChecksController(ILog log, IclsAPI clsAPI)
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
        // GET: InvChecks
        public ActionResult Index()
        {
            return View();
        }
        // Save Boxes
        public string funSaveCheck(
         int? pCheckId = null,
         string pCheckCode = null,
         int? pInvId = null,
         int? pInvType = null,
         int? pYear = null,
         int? pCheckDtlId = null,
         int? pAccountId = null,
         int? pBankId = null,
         int? pCheckNo = null,
         string pCheckPayDate = null,
         int? pCostCenterId = null,
         float? pCheckCredit = null,
         float? pCheckDebit = null,
         float? pCurValue = null,
         float? pCheckBaseCredit = null,
         float? pCheckBaseDebit = null,
         bool? pIsPosted = null,
         bool? pPosting = null,
         int? pStoreId = null,
         string pNotes = null,
         float? pTransSeq = null,
         bool? pIsDeleted = false,
         int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vPath = "/APIInvChecks/CheckGET";
            string vParamters =
             "?pCheckId=" + pCheckId +
             "&pCheckCode=" + pCheckCode +
             "&pInvId=" + pInvId +
             "&pInvType=" + pInvType +
             "&pYear=" + pYear +
             "&pCheckDtlId=" + pCheckDtlId +
             "&pAccountId=" + pAccountId +
             "&pBankId=" + pBankId +
             "&pCheckNo=" + pCheckNo+
             "&pCheckPayDate=" + pCheckPayDate+
             "&pCostCenterId=" + pCostCenterId +
             "&pCheckCredit=" + pCheckCredit +
             "&pCheckDebit=" + pCheckDebit +
             "&pCurValue=" + pCurValue +
             "&pCheckBaseCredit=" + pCheckBaseCredit +
             "&pCheckBaseDebit=" + pCheckBaseDebit +
             "&pIsPosted=" + pIsPosted +
             "&pPosting=" + pPosting +
             "&pStoreId=" + pStoreId +
             "&pNotes=" + pNotes +
             "&pTransSeq=" + pTransSeq +
             "&pIsDeleted=" + pIsDeleted +
             "&pQueryTypeId=" + pQueryTypeId;

            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParamters);

            // JSON
            string vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;

        }
    }
}