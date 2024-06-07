using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models.SEC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SEC
{    ///  AMR    21/1/2018   
    public class UserController : Controller
    {
        private ILog _ILog;
        private IdbUser _dbUser;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public UserController(ILog log, IdbUser dbUser, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbUser = dbUser;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: User
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbUser = _dbUser;
            // API Path
            string vPath = appAPIDirectory.vAPIUser;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }
        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            UserModel vUserModel = new UserModel();
            if (id == 0)
            {
                ViewBag.vbcSecurityGradeId = 0;
                ViewBag.vbcLanguageId = 0;
                ViewBag.vbcCountryId = 0;
                ViewBag.vbcFontSizeTypeId = 0;
                ViewBag.vbcUserTypeId = 0;
                @ViewBag.vbcTimeZoneId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUser;
                string vParameters = "?pUserId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                if (vDtData.Rows[0]["SecurityGradeId"].ToString() != ""
                   && vDtData.Rows[0]["LanguageId"].ToString() != ""
                   && vDtData.Rows[0]["CountryId"].ToString() != ""
                   && vDtData.Rows[0]["FontSizeTypeId"].ToString() != ""
                   && vDtData.Rows[0]["UserTypeId"].ToString() != ""
                   && vDtData.Rows[0]["UserTimeZoneId"].ToString() != ""
                    ) { 
                    ViewBag.vbcSecurityGradeId = Convert.ToInt32(vDtData.Rows[0]["SecurityGradeId"].ToString());
                ViewBag.vbcLanguageId = Convert.ToInt32(vDtData.Rows[0]["LanguageId"].ToString());
                ViewBag.vbcCountryId = Convert.ToInt32(vDtData.Rows[0]["CountryId"].ToString());
                ViewBag.vbcFontSizeTypeId = Convert.ToInt32(vDtData.Rows[0]["FontSizeTypeId"].ToString());
                ViewBag.vbcUserTypeId = Convert.ToInt32(vDtData.Rows[0]["UserTypeId"].ToString());
                ViewBag.vbcTimeZoneId = Convert.ToInt32(vDtData.Rows[0]["UserTimeZoneId"].ToString());
            }
            
                // Set Model Data
                vUserModel.UserId = Convert.ToInt32(vDtData.Rows[0]["UserId"]);
                vUserModel.UserCode = vDtData.Rows[0]["UserCode"].ToString();
                vUserModel.Printer = vDtData.Rows[0]["Printer"].ToString();
                vUserModel.UserName = vDtData.Rows[0]["UserName"].ToString();
                vUserModel.UserFullName = vDtData.Rows[0]["UserFullName"].ToString();
                vUserModel.UserPassword = vDtData.Rows[0]["UserPassword"].ToString();
                vUserModel.ConfirmPassword = vDtData.Rows[0]["UserPassword"].ToString();
                vUserModel.UserPhone = vDtData.Rows[0]["UserPhone"].ToString();
                vUserModel.UserEmail = vDtData.Rows[0]["UserEmail"].ToString();
               // vUserModel.IsUserLock = Convert.ToBoolean(vDtData.Rows[0]["IsUserLock"].ToString());
             //   vUserModel.UserImage = vDtData.Rows[0]["UserImage"].ToString();
               // vUserModel.UserIsActive = Convert.ToBoolean(vDtData.Rows[0]["UserIsActive"].ToString());
              //  vUserModel.SecurityGradeId = Convert.ToInt32(vDtData.Rows[0]["SecurityGradeId"]);
               // vUserModel.LanguageId = Convert.ToInt32(vDtData.Rows[0]["LanguageId"].ToString());
              //  vUserModel.CountryId = Convert.ToInt32(vDtData.Rows[0]["CountryId"]);
               // vUserModel.FontSizeTypeId = Convert.ToInt32(vDtData.Rows[0]["FontSizeTypeId"].ToString());
               // vUserModel.UserTypeId = Convert.ToInt32(vDtData.Rows[0]["UserTypeId"]);
                //vUserModel.UserTimeZoneId = Convert.ToInt32(vDtData.Rows[0]["UserTimeZoneId"].ToString());
               // vUserModel.UserTimeZoneIsDST = Convert.ToBoolean(vDtData.Rows[0]["UserTimeZoneIsDST"]);
            }
            // Return Result
            return View(vUserModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UserModel pUserModel = null, bool? pIsDelete = false, 
            HttpPostedFileBase pFile = null)
        {
            // User Image
            if (pFile != null)
            {
                pUserModel.UserImage = clsFileSave.funFileSave(pFile, "/Image/DataImage/SEC", pUserModel.UserImage);
            }
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPIUser;
                string vParameters =
                    "?pUserId=" + id +
                    "&pUserCode=" + pUserModel.UserCode +
                    "&Printer=" + pUserModel.Printer +
                    "&pUserFullName=" + pUserModel.UserFullName +
                    "&pUserAddress=" + pUserModel.UserAddress +
                    "&pUserPhone=" + pUserModel.UserPhone +
                    "&pUserEmail=" + pUserModel.UserEmail +
                    "&pUserName=" + pUserModel.UserName +
                    "&pUserPassword=" + funBase64Encode(pUserModel.UserPassword) +
                    "&pIsUserLock=" + pUserModel.IsUserLock +
                    "&pUserImage=" + pUserModel.UserImage +
                    "&pSecurityGradeId=" + pUserModel.SecurityGradeId +
                    "&pLanguageId=" + pUserModel.LanguageId +
                    "&pCountryId=" + pUserModel.CountryId +
                    "&pFontSizeTypeId=" + pUserModel.FontSizeTypeId +
                    "&pUserTypeId=" + pUserModel.UserTypeId +
                    "&pUserTimeZoneId=" + pUserModel.UserTimeZoneId +
                    "&pUserTimeZoneDST=" + pUserModel.UserTimeZoneIsDST +
                    "&pUserIsActive=" + pUserModel.UserIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUser.vSQLResult = vDrwResult[0].ToString();
                _dbUser.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                if (Convert.ToBoolean(pIsDelete)) { return null; }
                else
                { // Go To Index
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public static string funBase64Encode(string pTextToEncode)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(pTextToEncode);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        // Decode
        public static string funBase64Decode(string pTextToDecode)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(pTextToDecode);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public void ShowSimple()
        {
            DataTable DT = _dbUser.funGetUserReport();
            string vReportPath = Server.MapPath("~/Reports") + "//UserReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult UserReport()
        {

            return View();
        }
       public ActionResult ChangePassword()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult UserSearch()
        {

            return View();
        }
    }
}