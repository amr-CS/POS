using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.Encode;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Views.Shared.appResource.loginResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC.Login
{
    public class LoginModel
    {

        private IdbUser _dbUser;
        public LoginModel(IdbUser dbUser)
        {
            _dbUser = dbUser;
        }

        [Display(Name = "UserName", ResourceType = typeof(loginResource))]
        [Required(ErrorMessageResourceType = typeof(loginResource), ErrorMessageResourceName = "msgRequired")]
        public string UserName { get; set; }

        [Display(Name = "UserPassword", ResourceType = typeof(loginResource))]
        [Required(ErrorMessageResourceType = typeof(loginResource), ErrorMessageResourceName = "msgRequired")]
        public string UserPassword { get; set; }

        [Display(Name = "RememberMeOnThisPC", ResourceType = typeof(loginResource))]
        [Required(ErrorMessageResourceType = typeof(loginResource), ErrorMessageResourceName = "msgRequired")]
        public bool RememberMeOnThisPC { get; set; }

        public static System.Web.HttpCookie CookieUserId;
        public static System.Web.HttpCookie CookieUserName;
        public static System.Web.HttpCookie CookieSchoolId;
        public static DataTable vDtLogin;
        // Check Login Data
        public List<object> funIsValid(string pUsername, string pUserPassword)
        {
            // Result
            List<object> vlstResult = new List<object>();
            // Machine
            string vMachineName = Environment.MachineName + " / " + _dbUser.funGetLocalIPAddress();

            // Is User Lock
            string vUserLoginMsg = "";
            // Is User Multi School
            bool vUserIsMultiSchool = false;

            // Check Login Data
           // vDtLogin = dbUser.funUserLogin(pUsername, pUserPassword, vMachineName, true, false, clsQueryType.qSelectLogin);

            // Check If There is User and Password
            if (vDtLogin != null)
            {
                // Check if There is Rows in DT
                if (vDtLogin.Rows.Count == 1)
                {
                    bool vIsUserLock = Convert.ToBoolean(vDtLogin.Rows[0]["UserIsLock"]);

                    if (!vIsUserLock)
                    {
                        // Set User Id
                        clsUser.vUserId = Convert.ToInt32(vDtLogin.Rows[0]["UserId"]);
                        clsUser.vUserName = vDtLogin.Rows[0]["UserName"].ToString();
                        clsUser.vUserLanguageId = Convert.ToInt32(vDtLogin.Rows[0]["LanguageId"]);
                        clsUser.vUserPassowrd = clsEncode.funBase64Decode(vDtLogin.Rows[0]["UserPassword"].ToString());
                        clsCompany.vCompanyId = Convert.ToInt32(vDtLogin.Rows[0]["CompanyId"].ToString());

                        funCookie();

                    }

                }

            }

            // Get Result
            vlstResult.Add(vUserLoginMsg);
            vlstResult.Add(vUserIsMultiSchool);

            // Return Result
            return vlstResult;

        } // End of Is Valid Functions


        public static void funCookie()
        {


            //Cookies
            CookieUserId = new System.Web.HttpCookie("UserId", Convert.ToString(clsUser.vUserId));//Set this parameter cooky name and value 
            CookieUserName = new System.Web.HttpCookie("UserName", Convert.ToString(clsUser.vUserName));//Set this parameter cooky name and value 
            CookieSchoolId = new System.Web.HttpCookie("CompanyId", Convert.ToString(clsCompany.vCompanyId));//Set this parameter cooky name and value 

            CookieUserId.Expires = System.DateTime.Now.ToUniversalTime().AddDays(15);
            CookieUserName.Expires = System.DateTime.Now.ToUniversalTime().AddDays(15);
            CookieSchoolId.Expires = System.DateTime.Now.ToUniversalTime().AddDays(15);

            HttpContext.Current.Response.Cookies.Add(CookieUserId);
            HttpContext.Current.Response.Cookies.Add(CookieUserName);
            HttpContext.Current.Response.Cookies.Add(CookieSchoolId);

            string vUserId = HttpContext.Current.Request.Cookies["UserId"].Value.ToString();
            string vCompanyId = HttpContext.Current.Request.Cookies["CompanyId"].Value;
        }

    }
}