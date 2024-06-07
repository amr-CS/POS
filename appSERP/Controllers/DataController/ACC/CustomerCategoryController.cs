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
    public class CustomerCategoryController : Controller
    {
        // GET: CustomerCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchCustomerCategory()
        {
            return View();
        }
    }
}