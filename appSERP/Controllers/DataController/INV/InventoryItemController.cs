using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class InventoryItemController : Controller
    {
        private ILog _ILog;
        private IDevCompanySetting _DevCompanySetting;
        public InventoryItemController(ILog log, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: InventoryItem
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
    }
}