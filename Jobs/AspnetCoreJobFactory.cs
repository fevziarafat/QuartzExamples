using Quartz;
using Quartz.Simpl;
using Quartz.Spi;

using System;

namespace QuartzExamples.Jobs
{
    public class AspnetCoreJobFactory : SimpleJobFactory
    {
        IServiceProvider _serviceProvider;
        public AspnetCoreJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                //will inject dependencies that the job requires
                return (IJob)this._serviceProvider.GetService(bundle.JobDetail.JobType);
            }
            catch (Exception)
            {
                throw new SchedulerException(String.Format("Problem while ", bundle.JobDetail.Key));
            }
        }
    }
}
