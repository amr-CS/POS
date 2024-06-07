using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class SellCostTypeController : Controller
    {
        // GET: SellCostType
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchSellCostType()
        {
            return View();
        }
    }
}