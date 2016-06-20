using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERNI.Training.TPL.Exercise03
{
    public class Test
    {
        [Fact]
        public void CreateTask_DontCancel_Runs400ms()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();

                TaskResponse result = implement.CreateTask(10);
                disposableToken = result.CancelProvider;

                Assert.NotEqual(TaskStatus.RanToCompletion, result.Task.Status);
                Thread.Sleep(400);
                Assert.NotEqual(TaskStatus.RanToCompletion, result.Task.Status);
                Thread.Sleep(400);
                Assert.Equal(TaskStatus.RanToCompletion, result.Task.Status);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void CreateTask_20_20()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();

                TaskResponse result = implement.CreateTask(20);
                disposableToken = result.CancelProvider;

                Assert.Equal(20, result.Task.Result);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void CreateTask_Cancel_Runs100ms()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();

                TaskResponse result = implement.CreateTask(30);
                disposableToken = result.CancelProvider;

                Assert.NotEqual(TaskStatus.RanToCompletion, result.Task.Status);
                Thread.Sleep(100);
                Assert.NotEqual(TaskStatus.RanToCompletion, result.Task.Status);

                result.CancelProvider.Cancel();

                Thread.Sleep(100);
                Assert.Equal(TaskStatus.Canceled, result.Task.Status);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void GetResult_40_40()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();

                TaskResponse response = implement.CreateTask(40);
                disposableToken = response.CancelProvider;
                int result = implement.GetTaskResult(response.Task);

                Assert.Equal(40, result);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void GetResult_Cancel_Negative1()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();

                TaskResponse response = implement.CreateTask(50);
                disposableToken = response.CancelProvider;

                Thread.Sleep(100);
                response.CancelProvider.Cancel();

                int result = implement.GetTaskResult(response.Task);

                Assert.Equal(-1, result);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void StoreResult_60_60IsStored()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();
                var storage = new Storage();

                TaskResponse response = implement.CreateTask(60);
                disposableToken = response.CancelProvider;
                implement.StoreResult(response.Task, storage);

                Assert.NotEqual(60, storage.Value);
                Thread.Sleep(400);
                Assert.NotEqual(60, storage.Value);
                Thread.Sleep(200);
                Assert.Equal(60, storage.Value);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }

        [Fact]
        public void StoreResult_Cancel_Negative1IsStored()
        {
            IDisposable disposableToken = null;
            try
            {
                var implement = new Implement();
                var storage = new Storage();

                TaskResponse response = implement.CreateTask(70);
                disposableToken = response.CancelProvider;
                implement.StoreResult(response.Task, storage);

                Thread.Sleep(100);
                response.CancelProvider.Cancel();

                Thread.Sleep(100);
                Assert.Equal(-1, storage.Value);
            }
            finally
            {
                if (disposableToken != null)
                {
                    disposableToken.Dispose();
                }
            }
        }
    }
}
