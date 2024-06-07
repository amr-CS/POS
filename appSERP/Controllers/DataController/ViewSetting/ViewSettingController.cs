using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.SYSSETT;
using appSERP.appCode.Setting.SYSSETT.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SYSSETT.ViewSetting
{
    // Tarek Khalifa
    // View Setting
    // 2019-01-22
    public class ViewSettingController : Controller
    {
        private IdbUserObjectAction _dbUserObjectAction;
        private ISYSSETTSetting _SYSSETTSetting;
        private IDevCompanySetting _DevCompanySetting;
        public ViewSettingController(IdbUserObjectAction dbUserObjectAction, ISYSSETTSetting SYSSETTSetting, IDevCompanySetting devCompanySetting)
        {
            _dbUserObjectAction = dbUserObjectAction;
            _SYSSETTSetting = SYSSETTSetting;
            _DevCompanySetting = devCompanySetting;
        }

        // GET: ViewHeader
        [HttpGet] 
        public ActionResult ViewSettingHeader(string pHeaderTitle, bool? pIsNew = true, bool? pIsCollapse = true)
        {
            // View Header
            ViewBag.vbHeaderTitle = pHeaderTitle;
            // Is New [Create Button]
            ViewBag.vbIsNew = pIsNew;
            // Is Collapse
            ViewBag.vbIsCollapse = pIsCollapse;

            // Return View
            return View();
        }

        // GET: Modal Header
        [HttpGet]
        public ActionResult ViewSettingModalHeader(string pModalHeaderTitle, int pId)
        {
            // Header Sub
            string vModalHeaderSub = "";
            if (pId == 0) { vModalHeaderSub = "جديد"; } else { vModalHeaderSub = "تعديل"; }


            ViewBag.vbModalHeaderTitle = pModalHeaderTitle;
            // Modal Header Title Sub
            ViewBag.vbModalHeaderTitleSub = vModalHeaderSub;

            // Return View
            return View();
        }

        // GET: ConfirmDelete
        [HttpGet]
        public ActionResult ViewSettingConfirmDelete(int id, string pName = null)
        {
            // View Bag
            ViewBag.vbId = id;
            ViewBag.vbName = pName;

            return View();
        }

        // Exist Customer
        [HttpGet]
        public ActionResult ViewSettingExistCustomer(int id, string pName = null)
        {
            // View Bag
            ViewBag.vbId = id;
            ViewBag.vbName = pName;

            return View();
        }
        // Company Header
        [HttpGet]
        public ActionResult ViewSettingCompanyHeader(string pHeaderTitle)
        {
            // View Header
            ViewBag.vbHeaderTitle = pHeaderTitle;

            // Return View
            return View();
        }
        // SideBar Content
        public ActionResult ViewSettingSideBar()
        {
            int UserId =0;
            if (Request.Cookies["UserId"] != null)
             UserId =Convert.ToInt32( Request.Cookies["UserId"].Value);

            // UserId =Convert.ToInt32( Request.Cookies["UserId"].Value);

            
            // Get Objects
            DataTable vDtObject = _dbUserObjectAction.funUserObjectGET(UserId);
            // Get Distinct Object Type
            DataTable vDtObjectType = _dbUserObjectAction.funUserObjectTypeGET(vDtObject);
            // Get Distinct System
            DataTable vDtSystem = _dbUserObjectAction.funUserSystemGET(vDtObjectType);
            // ViewBag
            ViewBag.vbObject = vDtObject;
            ViewBag.vbObjectType = vDtObjectType;
            ViewBag.vbSystem = vDtSystem;
            ViewBag.DevCompanySetting = _DevCompanySetting;

            // Return Result
            return View();
        }

        //ViewSettingUtilityBar
        public ActionResult ViewSettingUtilityBar()
        {
     

            return View();
        }
        public string First()
        {
            string vFirst = _SYSSETTSetting.funFirstGl();
            return vFirst;
        }

        public string Last()
        {
            string vLast = _SYSSETTSetting.funLastGL();

            return vLast;
        }

        public string Next()
        {
            string vNext = _SYSSETTSetting.funNextGL();
            return vNext;
        }

        public string Prev()
        {
            string vPrev = _SYSSETTSetting.funPrevGL();

            return vPrev;
        }
        // GET: ConfirmDelete
        [HttpGet]
        public ActionResult ViewSettingAlert(int id,string pName = null)
        {
            // View Bag
            ViewBag.vbId = id;
            ViewBag.vbName = pName;

            return View();
        }

    }
}