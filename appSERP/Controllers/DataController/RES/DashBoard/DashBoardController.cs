using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES.DashBoard
{
    [NoDirectAccess]
    [Authorize]
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}