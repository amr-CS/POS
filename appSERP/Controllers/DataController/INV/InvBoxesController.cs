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
    public class InvBoxesController : Controller
    {
        // GET: InvBoxes
        private ILog _ILog;
        private IclsAPI _clsAPI;

        public InvBoxesController(ILog log, IclsAPI clsAPI)
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
        public ActionResult Index()
        {
            return View();
        }

        // Save Boxes
        public string funBoxes(
          int? pBoxId = null,
          string pBoxCode = null,
          int? pInvId = null,
          int? pInvType = null,
          int? pYear = null,
          int? pBoxDtlId = null,
          int? pAccountId = null,
          int? pCostCenterId = null,
          float? pBoxCredit = null,
          float? pBoxDebit = null,
          float? pCurValue = null,
          float? pBoxBaseCredit = null,
          float? pBoxBaseDebit = null,
          bool? pIsPosted = null,
          bool? pPosting = null,
          int? pStoreId = null,
          string pNotes = null,
          float? pTransSeq = null,
          bool? pIsDeleted = false,
          int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vPath = "/APIInvBoxes/BoxGET";
            string vParamters =
             "?pBoxId=" + pBoxId +
             "&pBoxCode=" + pBoxCode +
             "&pInvId=" + pInvId +
             "&pInvType=" + pInvType +
             "&pYear=" + pYear +
             "&pBoxDtlId=" + pBoxDtlId +
             "&pAccountId=" + pAccountId +
             "&pCostCenterId=" + pCostCenterId +
             "&pBoxCredit=" + pBoxCredit +
             "&pBoxDebit=" + pBoxDebit +
             "&pCurValue=" + pCurValue +
             "&pBoxBaseCredit=" + pBoxBaseCredit +
             "&pBoxBaseDebit=" + pBoxBaseDebit +
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