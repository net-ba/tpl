using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise03
{
    public class Implement
    {
        /// <summary>
        /// Creates a new task, that returns input after 500 miliseconds. Task can be cancelled by returned provider.
        /// </summary>
        /// <remarks>
        /// Try to use SpinWait.
        /// </remarks>
        public TaskResponse CreateTask(int input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns result of task or -1, when task was cancelled.
        /// </summary>
        public int GetTaskResult(Task<int> task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Store result of task into Storage.Value without blocking current thread.
        /// Store -1, when task was cancelled.
        /// </summary>
        public void StoreResult(Task<int> task, Storage storage)
        {
            throw new NotImplementedException();
        }
    }
}
