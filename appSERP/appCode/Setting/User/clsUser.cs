using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.User
{
    public static class clsUser
    {
        // User Data
        public static int vUserId { set; get; }
        
        public static string vUserCode = "123";
        public static string vUserFullName = "محمد عبد الرحمن";
        public static string vUserName = "a";
        public static string vUserPassowrd = "";
        public static string vUserImage = "";
        public static int vUserTypeId = 0;
        public static string vUserEmail = "";
        public static string vUserPhone = "";
        // Cashier User
        public static int vCashierId = 22;
        public static string vCashierFullName = "احمد محمود";
        public static string vCashierUserName = "";

        // User Language
        public static int vUserLanguageId = 1;
        public static string vUserCulture = "ar-eg";

        // User Type
        public static int vUsertTypeId = 1;

        // User Object
        public static int ObjectId;
        public static bool ObjectIsFav;

     


        //// User Login Cases
        // Is Admin
        public static int vLoginIsAdmin = 1000;
        // Is Locked
        public static int vLoginIsLocked = 1001;
        // Is InValid
        public static int vLoginIsInValid = 1002;



        //// No User Data
        // Language
        public static int vNoUserLanguageId = 1;
        public static string vNoUserCulture = "ar-eg";

        // Company And Branch
        public static int vUserCompanyId = 1;
        public static int vUserBranchId = 2;


    }
}