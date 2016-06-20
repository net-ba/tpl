using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise04
{
    /// <summary>
    /// Schedules tasks on time with no second fraction. For example task queued on 8:30:14.45 is executed on 8:30:15.
    /// </summary>
    /// <remarks>
    /// Hint: Use System.Threading.Timer.
    /// Optionally implement TryDequeueTask.
    /// </remarks>
    public sealed class SecondTaskScheduler : TaskScheduler
    {
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            throw new NotImplementedException();
        }

        protected override void QueueTask(Task task)
        {
            throw new NotImplementedException();
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }

        protected override bool TryDequeue(Task task)
        {
            return base.TryDequeue(task);
        }
    }
}
