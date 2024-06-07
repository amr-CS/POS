using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.Models.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchStore()
        {
            return View();
        }




    }
}