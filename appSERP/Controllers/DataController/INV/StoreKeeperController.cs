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
    public class StoreKeeperController : Controller
    {
        private IclsAPI _clsAPI;

        public StoreKeeperController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: StoreKeeper
        public ActionResult Index()
        {
            return View();
        }
        // Store Setting GET
        public string StoreKeeperGET(
            int? pStoreKeeperId = null,
            string pStoreKeeperCode = null,
            string pStoreKeeperNameL1 = null,
            string pStoreKeeperNameL2 = null,
            int? pStoreId = null,
            bool? pStoreKeeperIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIStoreKeeper;
            // Praremeter
            string vParameters =
                "?pStoreKeeperId=" + pStoreKeeperId +
                "&pStoreKeeperCode=" + pStoreKeeperCode +
                "&pStoreKeeperNameL1=" + pStoreKeeperNameL1 +
                "&pStoreKeeperNameL2=" + pStoreKeeperNameL2 +
                "&pStoreId=" + pStoreId +
                "&pStoreKeeperIsActive=" + pStoreKeeperIsActive +
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