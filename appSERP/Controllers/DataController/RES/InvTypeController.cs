using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class InvTypeController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;
        public InvTypeController(ILog log, IclsAPI clsAPI)
        {
            _ILog = log;
            _clsAPI = clsAPI;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: InvType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchInvType()
        {
            return View();
        }
        public string GetInvTypeByCode(string id = "1", string pInvTypeCode = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvType/InvTypeGET?pInvTypeCode=" + pInvTypeCode + "&&pQueryTypeId=" + 401;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;


        }



    }
}