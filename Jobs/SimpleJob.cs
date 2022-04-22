using Quartz;

using QuartzExamples.Models;
using QuartzExamples.Services;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class SimpleJob : IJob
    {
        IEmailService _emailService;
        public SimpleJob(IEmailService emailService)
        {
            _emailService=emailService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _emailService.Send("mail@mail.com", "DI", "Dependency injection in quartz jobs");

            //JobDataMap dataMap = context.MergedJobDataMap;
            //string username = dataMap.GetString("username");
            //string password = dataMap.GetString("password");
            //string triggerParam = dataMap.GetString("triggerParam");
            //JobUserParameter user = (JobUserParameter)dataMap.Get("username");
            //var message = $"Simple executed at {user.Username} and {user.Password} at time ${DateTime.Now.ToString()} with trigger param {triggerParam}";
            //Debug.WriteLine(message);
        }
    }
}
