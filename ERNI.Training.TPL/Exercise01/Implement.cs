using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise01
{
    public class Implement
    {
        /// <summary>
        /// Creates a new task, that returns input after 300 miliseconds.
        /// </summary>
        /// <remarks>
        /// Try to use SpinWait.
        /// </remarks>
        public Task<int> CreateTask(int input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Blocks until the task is finished.
        /// </summary>
        public void WaitForTask(Task task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns result of task.
        /// </summary>
        public int GetTaskResult(Task<int> task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Store result of task into Storage.Value without blocking current thread.
        /// </summary>
        public void StoreResult(Task<int> task, Storage storage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stores sum of results of several tasks into Storage.Value without blocking current thread.
        /// </summary>
        public void StoreResultSum(List<Task<int>> tasks, Storage storage)
        {
            throw new NotImplementedException();
        }
    }
}
