using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.User
{
    public class GetUser
    {
        public int GetUserId()
        {
            HttpCookieCollection MyCookieCollection = HttpContext.Current.Request.Cookies;
            HttpCookie MyCookie = MyCookieCollection.Get("UserId");



            int user = 0;
            if (HttpContext.Current != null)
            {
              user= Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                return user;
            }
            else
            {
                return user;
            }

        }
    }
}