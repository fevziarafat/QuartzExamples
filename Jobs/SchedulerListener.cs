using Quartz;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class SchedulerListener : ISchedulerListener
    {
        public async Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(jobDetail.Key.Name);
        }

        public async Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(jobKey.Name);
        }

        public async Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(jobKey.Name);
        }

        public async Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(jobKey.Name);
        }

        public async Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(jobKey.Name);
        }

        public async Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerStarted(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulerStarting(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
