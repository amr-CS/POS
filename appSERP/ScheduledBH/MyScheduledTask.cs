using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.Controllers.DataController.RES.POS;
using appSERP.Logger;
using appSERP.Models.RES;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace appSERP.ScheduledBH
{
    // by Quartz.NET Library
    public class MyScheduledTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            
            string message = "Beginning of task execution.";
            LogScheduled.LogException(message, "start");
            string today = DateTime.Now.AddDays(-1).ToShortDateString() + " 4:00:00";
            string tomorow = DateTime.Now.AddDays(1).ToShortDateString() + " 4:00:00";
            DateTime DateFrom = DateTime.Parse(today);
            DateTime DateTo = DateTime.Parse(tomorow);

            var _dbINVInvoice = UnityConfig.GetInstanceUC<IdbINVInvoice>();
            //var _dbINVInvoice = new dbINVInvoice(new appCode.SQL.ADO.clsADO(new Log()));
            DataTable vDT = _dbINVInvoice.funInvoiceOrderOrPOSDT(pDateFrom: DateFrom, pDateTo: DateTo, pQueryTypeId: 403);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Number of invoices not passed : " + vDT.Rows.Count.ToString());
            
            ICollection<UnsentInvoices> invoices = new List<UnsentInvoices>();
            
            foreach (DataRow item in vDT.Rows)
            {
                invoices.Add(new UnsentInvoices() {pInvId= Convert.ToInt32(item["InvId"].ToString())
                    ,pOrderId = item["OrderId"].ToString()=="0" ? (int?)null :Convert.ToInt32(item["OrderId"].ToString()) });
            }
            if (invoices.Count > 0)
            {
                var _POSController = UnityConfig.GetInstanceUC<POSController>();
                var result = _POSController.SendInvoices(invoices);
                sb.AppendLine(result);
            }
            sb.Append("= End of task execution : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            LogScheduled.LogException(sb.ToString(), "end");
            return Task.CompletedTask;
        }
    }
}