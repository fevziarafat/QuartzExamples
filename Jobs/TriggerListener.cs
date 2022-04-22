using Quartz;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class TriggerListener : ITriggerListener
    {
        public string Name { get; } = "Test trigger Listener";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(trigger.Key.Name);
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(trigger.Key.Name);
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(trigger.Key.Name);
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine(trigger.Key.Name);
            return false;
        }
    }
}
