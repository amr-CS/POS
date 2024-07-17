using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using DevExpress.Utils;
using Hangfire;
using Hangfire.SqlServer;
using appSERP.Controllers.DataController;

[assembly: OwinStartupAttribute(typeof(appSERP.Startup))]
namespace appSERP
{
    public class Startup
    {
 
        public void Configuration(IAppBuilder app)
        {
            JobStorage.Current = new SqlServerStorage("dbERPConnectionString");
            ZatcaAutoSendController zatcaAutoSendController = new ZatcaAutoSendController();
            RecurringJob.AddOrUpdate(new Guid().ToString(),() =>
   zatcaAutoSendController.AutoSendInvoice(), Cron.Hourly);
            app.UseHangfireServer();
         
            app.MapSignalR();
        }
        

    }
}