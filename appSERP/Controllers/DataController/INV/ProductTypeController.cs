using appSERP.appCode.Setting.APISetting.APIDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using appSERP.appCode.Setting.APISetting;
using Newtonsoft.Json;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.APISetting.Abstract;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class ProductTypeController : Controller
    {
        private IclsAPI _clsAPI;

        public ProductTypeController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: ProductType
        public ActionResult Index()
        {
            return View();
        }
        // Cash Desk GET
        public string ProductTypeGET(
            int? pProductTypeId = null,
            string pProductTypeCode = null,
            string pProductTypeNameL1 = null,
            string pProductTypeNameL2 = null,
            string pShortName = null, 
            string pProductTypeLevel = null,
            int? pProductTypeParentId = null,
            bool? pProductTypeIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIProductType;
            // Praremeter
            string vParameters =
                "?pProductTypeId=" + pProductTypeId +
                "&pProductTypeCode=" + pProductTypeCode +
                "&pProductTypeNameL1=" + pProductTypeNameL1 +
                "&pProductTypeNameL2=" + pProductTypeNameL2 +
                "&pShortName=" + pShortName+ 
                "&pProductTypeLevel=" +pProductTypeLevel+
                "&pProductTypeParentId=" + pProductTypeParentId +
                "&pProductTypeIsActive=" + pProductTypeIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }

        public ActionResult SearchProductType()
        {
            return View();
        }
    }
}