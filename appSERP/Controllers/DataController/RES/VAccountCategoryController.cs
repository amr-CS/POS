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
    public class VAccountCategoryController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;

        public VAccountCategoryController(ILog log, IclsAPI clsAPI)
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
        // GET: VAccountCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchAccountCategory()
        {
            return View();
        }
        public string FilterAccountCategory(string id = "1", string pCodeId = null)
        {
            string vAPIPath;


            vAPIPath = "/APIVAccountCategory/VAccountCategoryGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 401;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;


        }
        public string SearchAccountCategoryByCode(string id = "1", string pCodeId = null)
        {
            string vAPIPath;


            vAPIPath = "/APIVAccountCategory/VAccountCategoryGET?pCodeId=" + pCodeId + "&&pQueryTypeId=" + 400;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;


        }
    }
}