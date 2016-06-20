using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise07
{
    public sealed partial class MyTaskScheduler : TaskScheduler, IDisposable
    {
        public Thread _thread;

        public MyTaskScheduler()
        {
            _thread = new Thread(() => ProcessMessageLoop());
            Initialize();

            _thread.Start();
        }

        public void Dispose()
        {
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;

                DisposeInternal();
            }
        }

        partial void Initialize();

        partial void ProcessMessageLoop();

        partial void DisposeInternal();
    }
}
