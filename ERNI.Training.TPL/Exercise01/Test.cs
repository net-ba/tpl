using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise01
{
    public class Test
    {
        [Fact]
        public void CreateTask_10_ReturnsLongRunningTask()
        {
            var implement = new Implement();

            Task result = implement.CreateTask(10);

            Assert.NotEqual(TaskStatus.RanToCompletion, result.Status);
            Thread.Sleep(200);
            Assert.NotEqual(TaskStatus.RanToCompletion, result.Status);
            Thread.Sleep(200);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        [Fact]
        public void WaitForTask_TaskIsFinished()
        {
            var implement = new Implement();

            Task task = implement.CreateTask(10);
            implement.WaitForTask(task);

            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }

        [Fact]
        public void GetResult_20_20()
        {
            var implement = new Implement();

            Task<int> task = implement.CreateTask(20);
            int result = implement.GetTaskResult(task);

            Assert.Equal(20, result);
        }

        [Fact]
        public void StoreResult_30_30IsStored()
        {
            var implement = new Implement();
            var storage = new Storage();

            Task<int> task = implement.CreateTask(20);
            implement.StoreResult(task, storage);

            Assert.NotEqual(20, storage.Value);
            Thread.Sleep(200);
            Assert.NotEqual(20, storage.Value);
            Thread.Sleep(200);
            Assert.Equal(20, storage.Value);
        }

        [Fact]
        public void StoreResultSum_5Tasks_10IsStored()
        {
            var implement = new Implement();
            var storage = new Storage();

            var tasks = new List<Task<int>>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(implement.CreateTask(i));
            }

            implement.StoreResultSum(tasks, storage);

            Assert.NotEqual(10, storage.Value);
            Thread.Sleep(200);
            Assert.NotEqual(10, storage.Value);
            Thread.Sleep(500);
            Assert.Equal(10, storage.Value);
        }
    }
}
