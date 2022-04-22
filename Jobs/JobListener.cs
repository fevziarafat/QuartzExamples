using Quartz;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class JobListener : IJobListener
    {
        public string Name { get; } = "Test job listener";

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(context.JobDetail.Key.Name);
        }

        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(context.JobDetail.Key.Name);
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(context.JobDetail.Key.Name);
        }
    }
}
