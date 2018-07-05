using DTBLL.Controllers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DailyTool.MailSchedule
{
    public class MailToAdmin : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            new MailDTController().SendMailToAdmin();
            return Task.CompletedTask;
        }
    }
}
