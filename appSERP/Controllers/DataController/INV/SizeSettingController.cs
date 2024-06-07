using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
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
    public class SizeSettingController : Controller
    {
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SizeSettingController(IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // Index
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        // UNIT GET
        public string UnitGET(
            int? pUnitId = null,
            string pUnitCode = null,
            string pUnitNameL1 = null,
            string pUnitNameL2 = null,
            bool? pUnitIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIUnit;
           // string vPath = "/APIVUnit/VUnitGet";
            // Praremeter
            string vParameters =
                "?pUnitId=" + pUnitId +
                "&pUnitCode=" + pUnitCode +
                "&pUnitNameL1=" + pUnitNameL1 +
                "&pUnitNameL2=" + pUnitNameL2 +
                "&pUnitIsActive=" + pUnitIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;


            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        // Size GET
        public string SizeGET(
            int? pSizeId = null,
            string pSizeCode = null,
            string pSizeNameL1 = null,
            string pSizeNameL2 = null,
            int? pUnitId = null,
            bool? pSizeIsActive = null,
            bool? pIsDetail = null,
             bool? pIsUnitDetail = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPISize;
            // Praremeter
            string vParameters =
                "?pSizeId=" + pSizeId +
                "&pSizeCode=" + pSizeCode +
                "&pSizeNameL1=" + pSizeNameL1 +
                "&pSizeNameL2=" + pSizeNameL2 +
                "&pUnitId=" + pUnitId +
                "&pSizeIsActive=" + pSizeIsActive +
                "&pIsDetail=" + pIsDetail +
                "&pIsUnitDetail=" + pIsUnitDetail +
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
