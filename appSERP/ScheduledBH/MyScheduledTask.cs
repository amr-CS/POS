using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace appSERP.ScheduledBH
{
    // by Quartz.NET Library
    public class MyScheduledTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            string message = "تم تنفيذ المهمة الدورية";
            // هنا يمكن وضع الكود الخاص بتنفيذ المهمة
            Console.WriteLine("The periodic task has been carried out");
            LogBh.LogException(message);
            return Task.CompletedTask;
        }
    }
}