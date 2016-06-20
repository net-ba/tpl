using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise07
{
    public class Test
    {
        [Fact]
        public void MyTaskScheduler_Run3Tasks_ExecuteOnSameThread()
        {
            var storage = new List<int>();
            using (var scheduler = new MyTaskScheduler())
            {
                var factory = new TaskFactory(scheduler);

                var task1 = factory.StartNew(() => DoWork(storage));
                var task2 = factory.StartNew(() => DoWork(storage));
                var task3 = factory.StartNew(() => DoWork(storage));

                Task.WaitAll(task1, task2, task3);
            }

            Assert.Equal(6, storage.Count);
            var threadId = storage[0];
            Assert.All(storage, i => Assert.Equal(threadId, i));
        }

        [Fact]
        public void MyTaskScheduler_Run2TasksWithPause_ExecuteOnSameThread()
        {
            var storage = new List<int>();
            using (var scheduler = new MyTaskScheduler())
            {
                var factory = new TaskFactory(scheduler);

                var task1 = factory.StartNew(() => DoWork(storage));
                Thread.Sleep(550);
                var task2 = factory.StartNew(() => DoWork(storage));

                Task.WaitAll(task1, task2);
            }

            Assert.Equal(4, storage.Count);
            var threadId = storage[0];
            Assert.All(storage, i => Assert.Equal(threadId, i));
        }

        private static void DoWork(List<int> storage)
        {
            storage.Add(Thread.CurrentThread.ManagedThreadId);
            SpinWait.SpinUntil(() => false, 300);
            storage.Add(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
