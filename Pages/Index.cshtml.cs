using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Quartz;

using QuartzExamples.Jobs;
using QuartzExamples.Models;

using System;

namespace QuartzExamples.Pages
{
    public class IndexModel : PageModel
    {
        IScheduler _scheduler;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IScheduler scheduler)
        {
            _logger = logger;
            _scheduler = scheduler;
        }

        public async void OnGet()
        {
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                //.UsingJobData("username", "softbae")
                //.UsingJobData("password", "softbae")
                .WithIdentity("simplejob", "quartz")
                .StoreDurably()
                .Build();

            job.JobDataMap.Add("username", new JobUserParameter { Username = "softbae", Password = "password" });

            //save the job
            await _scheduler.AddJob(job, true);
            //we can set multiple trigger on same job
            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerParam", "Simple trigger 1 parameter")
                .WithIdentity("testTrigger", "quartz")
                .StartNow()

                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever())

                //.WithDailyTimeIntervalSchedule(x => x.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(21, 12))
                //.EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(22, 0))
                //.OnDaysOfTheWeek(DayOfWeek.Monday,DayOfWeek.Tuesday)
                //.WithIntervalInMinutes(1))

                //.WithCalendarIntervalSchedule(x=>x.WithIntervalInDays(1).PreserveHourOfDayAcrossDaylightSavings(true)
                //.SkipDayIfHourDoesNotExist(true))
              
               // .WithCronSchedule("0/1 0 0 ? * * *")

                //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(10,0))

                .Build();

            await _scheduler.ScheduleJob(trigger);

            //ITrigger trigger2 = TriggerBuilder.Create()
            //    .ForJob(job)
            //    .UsingJobData("triggerParam", "Simple trigger 2 parameter")
            //    .WithIdentity("testTrigger2", "quartz")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5)
            //    .WithRepeatCount(5))
            //    .Build();

            //await _scheduler.ScheduleJob(trigger2);
        }
    }
}
