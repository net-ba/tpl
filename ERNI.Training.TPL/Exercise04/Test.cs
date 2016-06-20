using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise04
{
    public class Test
    {
        [Fact]
        public void SecondTimeScheduler_1Task_ExecutedAtWholeSecond()
        {
            var timeStorage = new TimeStorage();
            var scheduler = new SecondTaskScheduler();
            var factory = new TaskFactory(scheduler);

            var task = factory.StartNew(() => timeStorage.LogTime(DateTime.UtcNow));
            task.Wait();

            VerifyTimes(timeStorage.GetTimes(), 1);
        }

        [Fact]
        public void SecondTimeScheduler_3Tasks_ExecutedAtWholeSecond()
        {
            var timeStorage = new TimeStorage();
            var scheduler = new SecondTaskScheduler();
            var factory = new TaskFactory(scheduler);
            var random = new Random();

            var task1 = factory.StartNew(() => timeStorage.LogTime(DateTime.UtcNow));
            Thread.Sleep(random.Next(2000));
            var task2 = factory.StartNew(() => timeStorage.LogTime(DateTime.UtcNow));
            Thread.Sleep(random.Next(2000));
            var task3 = factory.StartNew(() => timeStorage.LogTime(DateTime.UtcNow));

            Task.WaitAll(task1, task2, task3);

            VerifyTimes(timeStorage.GetTimes(), 3);
        }

        private static void VerifyTimes(IEnumerable<DateTime> times, int expectedCount)
        {
            Assert.Equal(expectedCount, times.Count());
            foreach (var time in times)
            {
                var ms = time.Millisecond;
                if (ms > 500)
                {
                    ms = 1000 - ms;
                }

                Assert.InRange(ms, 0, 100);
            }
        }
    }
}
