using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class EPaymentTypeController : Controller
    {
        private IclsAPI _clsAPI;
        public EPaymentTypeController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }
        // GET: EPaymentType
        public ActionResult Index()
        {
            return View();
        }
        // EPayment Type GET
        public string EPaymentTypeGET(
            int? pEPaymentTypeId = null,
              int? pPaymentTypeId = null,
            string pEPaymentTypeCode = null,
            string pEPaymentTypeNameL1 = null,
            string pEPaymentTypeNameL2 = null,
            string pNotes = null,
            bool? pEPaymentTypeIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIEPaymentType;
            // Praremeter
            string vParameters =
                "?pEPaymentTypeId=" + pEPaymentTypeId +
                 "&pPaymentTypeId=" + pPaymentTypeId +
                "&pEPaymentTypeCode=" + pEPaymentTypeCode +
                "&pEPaymentTypeNameL1=" + pEPaymentTypeNameL1 +
                "&pEPaymentTypeNameL2=" + pEPaymentTypeNameL2 +
                "&pEPaymentTypeIsActive=" + pEPaymentTypeIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
    }
}