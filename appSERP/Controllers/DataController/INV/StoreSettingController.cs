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
    public class StoreSettingController : Controller
    {
        private IclsAPI _clsAPI;

        public StoreSettingController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: StoreSetting
        public ActionResult Index()
        {
            return View();
        }
        // Store Setting GET
        public string StoreSettingGET(
            int? pStoreSettingId = null,
            string pStoreSettingCode = null,
            string pStoreSettingNameL1 = null,
            string pStoreSettingNameL2 = null,
            string pStoreSettingNotes = null,
            int? pStoreId = null,
            bool? pStoreSettingIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIStoreSetting;
            // Praremeter
            string vParameters =
                "?pStoreSettingId=" + pStoreSettingId +
                "&pStoreSettingCode=" + pStoreSettingCode +
                "&pStoreSettingNameL1=" + pStoreSettingNameL1 +
                "&pStoreSettingNameL2=" + pStoreSettingNameL2 +
                "&pStoreSettingNotes=" + pStoreSettingNotes +
                "&pStoreId=" + pStoreId +
                "&pStoreSettingIsActive=" + pStoreSettingIsActive +
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