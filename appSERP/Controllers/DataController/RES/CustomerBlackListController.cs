using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class CustomerBlackListController : Controller
    {
        // GET: CustomerBlackList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerSearch()
        {
            return View();
        }
    }
}