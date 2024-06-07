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

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class StoreTypeController : Controller
    {
        private IclsAPI _clsAPI;

        public StoreTypeController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: StoreType
        public ActionResult Index()
        {
            return View();
        }
        // Store Type GET
        public string StoreTypeGET(
            int? pStoreTypeId = null,
            string pStoreTypeCode = null,
            string pStoreTypeNameL1 = null,
            string pStoreTypeNameL2 = null,
            int? pStoreId = null,
            bool? pStoreTypeIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIStoreType;
            // Praremeter
            string vParameters =
                "?pStoreTypeId=" + pStoreTypeId +
                "&pStoreTypeCode=" + pStoreTypeCode +
                "&pStoreTypeNameL1=" + pStoreTypeNameL1 +
                "&pStoreTypeNameL2=" + pStoreTypeNameL2 +
                "&pStoreId=" + pStoreId +
                "&pStoreTypeIsActive=" + pStoreTypeIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public ActionResult SearchStoreType()
        {
            return View();
        }

    }
}