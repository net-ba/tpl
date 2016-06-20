using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise07
{
    /// <summary>
    /// Implement TaskScheduler that executes all tasks on single thread.
    /// </summary>
    /// <remarks>
    /// Do not forget to release all resources on Dispose.
    /// </remarks>
    partial class MyTaskScheduler : TaskScheduler
    {
        partial void ProcessMessageLoop()
        {
        }

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

        partial void DisposeInternal()
        {
        }
    }
}
