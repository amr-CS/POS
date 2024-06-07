using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.CaptchaImageResult;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.Encode;
using appSERP.appCode.Setting.Mail;
using appSERP.appCode.Setting.TimeSetting;
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


namespace appSERP.Controllers.DataControllers.SEC.Login
{
    public class LoginController : Controller
    {
        private ILog _ILog;
        private IdbUser _dbUser;
        private IdbUserSecurityLog _dbUserSecurityLog;
        private IclsAPI _clsAPI;
        public LoginController(ILog log, IdbUser dbUser, IdbUserSecurityLog dbUserSecurityLog, IclsAPI clsAPI)
        {
            _ILog = log;
            _dbUser = dbUser;
            _dbUserSecurityLog = dbUserSecurityLog;
            _clsAPI = clsAPI;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // Logout
        public ActionResult Logout()
        {
            // Logout
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();

            // User Log
            UserLog(pUserId: clsUser.vUserId, pUserSecurityTransactionTypeId: 3, pSecurityLogDevice: Environment.MachineName, pSecurityLogDeviceIsMobile: false);

            

            return RedirectToAction("Login", "Home");
        }
        

        [HttpPost]
        public string CheckLogin(string pUserName, string pUserPassword)        
        {
            // Check User
            #region CheckUser
            // Check User
            string vPath = appAPIDirectory.vAPIUserLogin;
            string vParameters =
         "?pUserName=" + pUserName +
         "&pUserPassword=" + pUserPassword +
         "&pDevice=" + Environment.MachineName +
         "&pUserIsActive=" + true +
         "&pIsDeleted=" + false +
         "&pQueryTypeId=" + clsQueryType.qSelectLogin;

            // SQL Result
            DataTable vDtCheckLogin = _clsAPI.funResultGet(vPath + vParameters);
            ViewBag.LoginData = vDtCheckLogin;
            #endregion CheckUser

            // List Object [Result]
            List<object> vlstResult = new List<object>() { };

            // Check If Login is Not Valid
            if (clsSystemSetting.funCheckDataTable(vDtCheckLogin))
            {
                // Return Result

                Session["vUserTypeId"] = Convert.ToInt32(vDtCheckLogin.Rows[0]["UserTypeId"]);
                int vUserTypeId = Convert.ToInt32(Session["vUserTypeId"]);

                // Check User Lock
                bool vIsUserLock = Convert.ToBoolean(vDtCheckLogin.Rows[0]["UserDeviceIsLock"]);
                // Get Machine Name
                string vMachineName = vDtCheckLogin.Rows[0]["UserDevice"].ToString();

                // Is User Lock
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

                    //Set Cookie id
                    Response.Cookies["UserId"].Value = vDtCheckLogin.Rows[0]["UserId"].ToString();
                    Response.Cookies["BranchId"].Value = vDtCheckLogin.Rows[0]["BranchId"].ToString();
                    Response.Cookies["Img"].Value = vDtCheckLogin.Rows[0]["LocationImgPath"].ToString();
                    Response.Cookies["UserName"].Value = vDtCheckLogin.Rows[0]["UserName"].ToString();
                    Response.Cookies["CompanyName"].Value = vDtCheckLogin.Rows[0]["CompanyNameL1"].ToString();
                    Response.Cookies["BranchName"].Value = vDtCheckLogin.Rows[0]["BranchDesc"].ToString();
                    Response.Cookies["BranchPhone"].Value = vDtCheckLogin.Rows[0]["BranchPhone"].ToString();
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(1);

                    // HttpCookie mycookie = HttpContext.Current.Request.Cookies["mycookie"];
                    if (vDtCheckLogin.Rows[0]["CashierId"].ToString() != "")
                    {
                        Response.Cookies["CashierId"].Value = vDtCheckLogin.Rows[0]["CashierId"].ToString();
                        Response.Cookies["CashierId"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["CashierName"].Value = vDtCheckLogin.Rows[0]["CashierName"].ToString();
                        Response.Cookies["CashierName"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["Printer"].Value = vDtCheckLogin.Rows[0]["Printer"].ToString();
                        Response.Cookies["Printer"].Expires = DateTime.Now.AddDays(1);

                        Response.Cookies["Credit"].Value = vDtCheckLogin.Rows[0]["Credit"].ToString();
                        Response.Cookies["Credit"].Expires = DateTime.Now.AddDays(1);
                    }
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

     
        public CaptchaImageResult ShowCaptchaImage()
        {

            return new CaptchaImageResult();
        }

        public string ShowCaptchaText()

        {
            string vImage = CaptchaImageResult.vCaptchaChar;
            return vImage;
        }


        // Set User Data
        public  void funSetUserData(DataTable pUserData)
        {
            if (pUserData.Columns.Contains("UserId"))
            {
                // Get UserId
                Session["UserId"] = Convert.ToInt32(pUserData.Rows[0]["UserId"]);
                Response.Cookies["UserId"].Value = pUserData.Rows[0]["UserId"].ToString();



                clsUser.vUserId = Convert.ToInt32(Session["UserId"]);
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

                //User  Data
                Session["UserFullName"] = pUserData.Rows[0]["UserFullName"].ToString();
                clsUser.vUserFullName = Session["UserFullName"].ToString();
                clsUser.vUserId = Convert.ToInt32(Session["UserId"]);
                clsUser.vUserImage = pUserData.Rows[0]["UserImage"].ToString();
                clsUser.vUserCompanyId = Convert.ToInt32(pUserData.Rows[0]["CompanyId"]);
                // clsUser.vUserBranchId = Convert.ToInt32(pUserData.Rows[0]["BranchId"]);
                // Branch 
                // Cashier
                //clsUser.vCashierId =Convert.ToInt32(pUserData.Rows[0]["CashierId"]);
                //if (pUserData.Rows[0]["CashierId"] != "")
                //{
                //    Session["CashierId"] = Convert.ToInt32(pUserData.Rows[0]["CashierId"]);

                //clsUser.vCashierFullName = pUserData.Rows[0]["CashierName"].ToString();
                //}

                // Company
                clsCompany.vCompanyId = Convert.ToInt32(pUserData.Rows[0]["CompanyId"]);
                clsCompany.vCompanyName= pUserData.Rows[0]["CompanyNameL1"].ToString();
                clsCompany.vCompanyLanguageId1 = Convert.ToInt32(pUserData.Rows[0]["Language1Id"]);
                clsCompany.vCompanyLanguage1NameL1 = pUserData.Rows[0]["BranchDesc"].ToString();
                clsCompany.vCompanyLanguage1NameL2 = pUserData.Rows[0]["BranchDescL"].ToString();
                clsCompany.vCompanyLanguageId2 = Convert.ToInt32(pUserData.Rows[0]["Language2Id"]);
                clsCompany.vCompanyLanguage2NameL1 = pUserData.Rows[0]["Language2NameL1"].ToString();
                clsCompany.vCompanyLanguage2NameL2 = pUserData.Rows[0]["Language2NameL2"].ToString();
                clsCompany.vCompanyPhone1= pUserData.Rows[0]["BranchPhone"].ToString();
            }

        }
     
        // FORGET PASSSWORD
        public ActionResult Email()
        {

            return View();
        }



        public ActionResult Code(string pCode)
        {
            if (pCode != clsUser.vUserCode)
            {

                ViewBag.ErrorMsg = "الكود الذي ادخلته غير صحيح";
            }

            return View();

        }
        public ActionResult NewPassword()
        {

            return View();
        }


        // Change Password
        public bool funChangePassword(string pEmail, string pPassword)
        {
            bool vIsPasswordChanged = false;

            if (!funCheckPasswordExist(pEmail, pPassword))
            {

                //Save Password 
                // API Path
                string vPath = appAPIDirectory.vAPIUser;
                string vParameters =
                    "?pUserEmail=" + pEmail +
                    "&pUserPassword=" + clsEncode.funBase64Encode(pPassword) +
                    "&pQueryTypeId=" + 409;
                // SQL Result
                DataRow DRClass = _clsAPI.funResultGet(vPath + vParameters).Rows[0];

                // Password Change Done
                vIsPasswordChanged = true;

                // Get UserId  
                int vUserId =Convert.ToInt32( _clsAPI.funResultGet(appAPIDirectory.vAPIUser + "?pUserEmail=" + pEmail).Rows[0]["UserId"].ToString());
               
                // User Log
                UserLog(pUserId: vUserId, pNewPassword: pPassword,pUserSecurityTransactionTypeId:1,pSecurityLogDevice: Environment.MachineName,pSecurityLogDeviceIsMobile:false);
            }
            else
            {
                // Password Change Done
                vIsPasswordChanged = false;
            }


            // Return Result
            return vIsPasswordChanged;
        }

        // Check Password Exists
        public bool funCheckPasswordExist(string pEmail, string pPassword)
        {

            //Save Password 
            // API Path
            string vPath = appAPIDirectory.vAPIUser;
            string vParameters =
                "?pUserEmail=" + pEmail +
                "&pUserPassword=" + clsEncode.funBase64Encode(pPassword) +
                "&pQueryTypeId=" + 410;
            // SQL Result
            DataRow DRClass = _clsAPI.funResultGet(vPath + vParameters).Rows[0];

            bool vIsFound = Convert.ToBoolean(DRClass["vIsPasswordFound"]);

            return vIsFound;
        }


        // Generate Random Code
        public string GenerateRandomCode()
        {
            // Generate Random Code
            Random vRandomGenerator = new Random();
            string vRandom = vRandomGenerator.Next(0, 999999).ToString("D6");

            // Return Result
            return vRandom;
        }

        // Send Code
        public string SendCode(string pMail, string pCode)
        {
            if (pMail != "")
            {
                try
                {
                    string vMsg = " كود التفعيل  لتغيير كلمة المرور أو اسم المستخدم " + pCode;
                    clsMail.funSendMail(loginResource.ForgotPassword, vMsg, pMail, null);
                
                    // Get UserName  
                   clsUser.vUserName = _clsAPI.funResultGet(appAPIDirectory.vAPIUser + "?pUserEmail=" + pMail).Rows[0]["UserName"].ToString();


                    // Get UserName
                    clsUser.vUserName = _clsAPI.funResultGet(appAPIDirectory.vAPIUser + "?pUserEmail=" + pMail).Rows[0]["UserName"].ToString();


                    return loginResource.msgSentSuccessfully;
                }
                catch (Exception ex)
                {
                    return loginResource.msgCannotSent;
                }
            }
            else
            {
                return loginResource.msgCannotSent;
            }

        }
        public ActionResult SetCookieBranch(int? BranchId, string BranchName, string BranchPhone )
        {
            Response.Cookies["BranchId"].Value = BranchId.ToString();
            Response.Cookies["BranchId"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["BranchName"].Value = BranchName;
            Response.Cookies["BranchName"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["BranchPhone"].Value = BranchPhone;
            Response.Cookies["BranchPhone"].Expires = DateTime.Now.AddDays(1);
            return RedirectToAction("Index", "Home");
        }
        // Check User Email
        public string CheckUserEmail(string pEmail)
        {
            // API Path4
            string vPath = appAPIDirectory.vAPIUser;
            string vParameters = "?pUserEmail=" + pEmail;

            // Get Data
            DataTable vDtUser = _clsAPI.funResultGet(vPath + vParameters);
            // Email
            bool vIsEmailValid = false;

            // Check Data
            if (vDtUser != null)
            {
                if (vDtUser.Rows.Count > 0)
                {
                    // Current Email From DB
                    string vUserEmail = vDtUser.Rows[0]["UserEmail"].ToString();
                    // Check Email
                    if (vUserEmail == pEmail)
                    {
                        vIsEmailValid = true;
                    }
                    else
                    {
                        vIsEmailValid = false;
                    }
                }
            }

            // Return Result
            return vIsEmailValid.ToString();
        }

        // User Log 
        public void UserLog(
        int? pSecurityLogId = null,
        string pSecurityLogLat = null,
        string pSecurityLogLng = null,
        string pSecurityLogLocation = null,
        string pSecurityLogDevice = null,
        bool? pSecurityLogDeviceIsMobile = null,
        DateTime? pSecurityLogDate = null,
        TimeSpan? pSecurityLogTime = null,
        string pOldPassword = null,
        string pNewPassword = null,
        int? pUserId = null,
        int? pUserSecurityTransactionTypeId = null)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserSecurityLog;
                string vParameters =
                    "?pSecurityLogId=" + pSecurityLogId +
                    "&pSecurityLogLat=" + pSecurityLogLat +
                    "&pSecurityLogLng=" + pSecurityLogLng +
                    "&pSecurityLogLocation=" + pSecurityLogLocation +
                    "&pSecurityLogDevice=" + pSecurityLogDevice +
                    "&pSecurityLogDeviceIsMobile=" + pSecurityLogDeviceIsMobile +
                    "&pSecurityLogDate=" + clsTimeSetting.funBranchTime().ToString("yyyy-MM-dd") +
                    "&pSecurityLogTime=" + clsTimeSetting.funBranchTime().ToString("hh:mm")+
                    "&pOldPassword=" + pOldPassword +
                    "&pNewPassword=" + pNewPassword +
                    "&pUserId=" + pUserId +
                    "&pUserSecurityTransactionTypeId=" + pUserSecurityTransactionTypeId +
                    "&pSecurityLogIsActive=" + true +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUserSecurityLog.vSQLResult = vDrwResult[0].ToString();
                _dbUser.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
          
            }
            catch (Exception ex)
            {
                
            }
        }
        

        





    }
}