using appSERP.appCode.Setting;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Views.Shared.appResource.loginResource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class CashierController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public CashierController(ILog log, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Cashier
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        // Save
        public string funSaveCashier(
       int? pCashId = null,
       bool? pIsCashComp = null,
       string pNetAcc = null,
       int? Credit = null,
       int? pCostCenterId = null,
       string pNOTES = null,
       string pCashAcc = null,
       bool? pCashStatus = null,
       string pCashNameL2 = null,
       int? pEmpId = null,
       string pCashNameL1 = null,
       int? pCashCode = null,
       bool? pIsDeleted = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APICashier/CashierGET";
            // Paramter
            string vParameters =
                "?pIsCashComp="+ pIsCashComp+
                "&pNetAcc="+pNetAcc+
                "&Credit="+Credit +
                "&pCostCenterId="+ pCostCenterId+
                "&pNOTES="+ pNOTES+
                "&pCashAcc="+ pCashAcc+
                "&pCashStatus="+ pCashStatus+
                "&pCashNameL2="+ pCashNameL2+
                "&pEmpId="+ pEmpId+
                "&pCashNameL1="+ pCashNameL1+
                "&pCashId="+ pCashId+
                "&pCashCode="+ pCashCode+
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;

            // SQL Result
            string vResult =_clsAPI.funResultGetJSON(vPath + vParameters);

            return vResult;
        }


        // Permission View
        public ActionResult Permission()
        {
            return View();
        }

        [HttpPost]
        public string CheckLogin(string pUserName, string pUserPassword)
        {
            string vPath = "/APICashier/CashierGET";
            
            string vParameters =
          "?pUserName=" + pUserName +
          "&pCashPassword=" + pUserPassword +
          //"&pUserIsActive=" + true +
          //"&pIsDeleted=" + false +
          "&pQueryTypeId=" + 401;

            DataTable vDtCheckLogin = _clsAPI.funResultGet(vPath + vParameters);
            clsUser.vCashierId = Convert.ToInt32(vDtCheckLogin.Rows[0]["CashId"]);
            clsUser.vCashierFullName = vDtCheckLogin.Rows[0]["CashNameL1"].ToString();
           
            // List Object [Result]
            List<object> vlstResult = new List<object>() { };

            // Check If Login is Not Valid
            if (clsSystemSetting.funCheckDataTable(vDtCheckLogin))
            {

                int vUserTypeId = Convert.ToInt32(vDtCheckLogin.Rows[0]["UserTypeId"]);
                bool vIsUserLock = Convert.ToBoolean(vDtCheckLogin.Rows[0]["UserDeviceIsLock"]);
                // Get Machine Name
                string vMachineName = vDtCheckLogin.Rows[0]["UserDevice"].ToString();


                if (vIsUserLock)
                {
                    // User Is Lock
                    vlstResult.Add(clsUser.vLoginIsLocked);
                    vlstResult.Add(loginResource.msg1001UserLockedWorking + vMachineName);
                }
                else
                {
                    // Is Admin
                    if (vUserTypeId == 2)
                    {
                        // User Is Admin
                        vlstResult.Add(clsUser.vLoginIsAdmin);
                    }
                    // Valid Login
                    funSetUserData(vDtCheckLogin);
                    // Set Auth Cookie
                    FormsAuthentication.SetAuthCookie(pUserName, true);
                }
            }
            else
            {
                // Invalid Login Data
                vlstResult.Add(clsUser.vLoginIsInValid);
                vlstResult.Add(loginResource.msg1002InvalidLogin);
            }

           



            // Convert List Result to JSON
            string vResult = JsonConvert.SerializeObject(vlstResult);


       
            // Return Result
            return vResult;
        }


        // Set User Data
        public static void funSetUserData(DataTable pUserData)
        {
            if (pUserData.Columns.Contains("UserId"))
            {
                // Get UserId
                clsUser.vUserId = Convert.ToInt32(pUserData.Rows[0]["UserId"]);
                // Language - Culture
                clsUser.vUserLanguageId = Convert.ToInt32(pUserData.Rows[0]["LanguageId"]);
                if (clsUser.vUserLanguageId == 1)
                {
                    clsUser.vUserCulture = "ar-eg";
                    //clsUser.vNotificationCultureIndex = 0;
                }
                else
                {
                    clsUser.vUserCulture = "en-us";
                    //   clsUser.vNotificationCultureIndex = 1;
                }

                //// User Data
                //clsUser.vUserFullName = pUserData.Rows[0]["UserFullName"].ToString();
                //clsUser.vUserImage = pUserData.Rows[0]["UserImage"].ToString();
                //clsUser.vUserCompanyId = Convert.ToInt32(pUserData.Rows[0]["CompanyId"]);
                //clsUser.vUserBranchId = Convert.ToInt32(pUserData.Rows[0]["BranchId"]);



                //// Company
                //clsCompany.vCompanyId = Convert.ToInt32(pUserData.Rows[0]["CompanyId"]);
                //clsCompany.vCompanyName = pUserData.Rows[0]["CompanyNameL1"].ToString();
                //clsCompany.vCompanyLanguageId1 = Convert.ToInt32(pUserData.Rows[0]["Language1Id"]);
                //clsCompany.vCompanyLanguage1NameL1 = pUserData.Rows[0]["Language1NameL1"].ToString();
                //clsCompany.vCompanyLanguage1NameL2 = pUserData.Rows[0]["Language1NameL2"].ToString();
                //clsCompany.vCompanyLanguageId2 = Convert.ToInt32(pUserData.Rows[0]["Language2Id"]);
                //clsCompany.vCompanyLanguage2NameL1 = pUserData.Rows[0]["Language2NameL1"].ToString();
                //clsCompany.vCompanyLanguage2NameL2 = pUserData.Rows[0]["Language2NameL2"].ToString();
            }

        }


    }
}