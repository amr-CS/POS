using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.SYSSETT.ViewHeader
{
    public class ViewHeaderController : Controller
    {
        // GET: ViewHeader
        public ActionResult Index(string pHeaderTitle, bool? pIsNew = true, bool? pIsNewPermission = false)
        {
            // View Header
            ViewBag.vbHeaderTitle = pHeaderTitle;
            // Is New [Create Button]
            ViewBag.vbIsNew = pIsNew;
            // Is New [Permission]
            ViewBag.vbIsNewPermission = pIsNewPermission;

            // Return View
            return View();
        }
    }
}