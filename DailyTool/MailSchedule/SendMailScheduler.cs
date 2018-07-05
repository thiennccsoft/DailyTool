using DTBLL.Controllers;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.MailSchedule
{
    public class SendMailScheduler
    {

        private StdSchedulerFactory factory;
        private IScheduler scheduler;

        public void Start()
        {

            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler().Result;
            scheduler.Start();

            IJobDetail jobToUser = JobBuilder.Create<MailToUser>().Build();
            scheduleJob(jobToUser, "MailToUser", 10, 28);
            IJobDetail jobToAdmin = JobBuilder.Create<MailToAdmin>().Build();
            scheduleJob(jobToAdmin, "MailToAdmin", 10, 29);
        }

        private void scheduleJob(IJobDetail job, String tgName, int hour, int minute)
        {
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(tgName)
                .WithDailyTimeIntervalSchedule
                (
                    a => a.WithIntervalInHours(24)
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute))
                )
                .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
