using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class SalesMenController : Controller
    {
        private IclsAPI _clsAPI;
        public SalesMenController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: SalesMen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchSalesMen()
        {
            return View();
        }
        public string GetSales(string pCodeId = null)
        {
            string vAPIPath = "/APISalesMen/SalesMenGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + +clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

    }
}