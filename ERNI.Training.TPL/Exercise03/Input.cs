using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise03
{
    public interface ICancelProvider : IDisposable
    {
        void Cancel();
    }

    public class Storage
    {
        private volatile int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    public struct TaskResponse
    {
        private readonly Task<int> _task;
        private readonly ICancelProvider _cancelProvider;

        public TaskResponse(Task<int> task, ICancelProvider cancelProvider)
        {
            _task = task;
            _cancelProvider = cancelProvider;
        }

        public Task<int> Task => _task;

        public ICancelProvider CancelProvider => _cancelProvider;
    }
}
