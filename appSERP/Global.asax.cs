using appSERP.appCode.Setting.GD;
using appSERP.appCode.Setting.User;
using appSERP.ScheduledBH;
using DevExpress.Security.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace appSERP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Obsolete]
        protected void Application_Start()
        {
    
            DevExtremeBundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            QuartzConfig.Configure().GetAwaiter().GetResult();
        }
        // Applciation Culture
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            
            // Applciation Culture [Culture]
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(clsUser.vUserCulture);
            // Applciation Culture [UI Culture]
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(clsUser.vUserCulture);

            if (Request.IsAuthenticated)
            {
                // Check Dev Company Setting
                //if (DevCompanySetting.DevCompanyNameL1 == string.Empty)
                //{
                    // Continue set data
                   // DevCompanySetting.SetDevCompanySetting();
                //}
            }
        }
        // Session Start
        protected void Session_Start()
        {
         //   clsUserType.funUserTypeGET();
        }
    }
}
