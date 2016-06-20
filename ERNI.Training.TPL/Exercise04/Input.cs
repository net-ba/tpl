using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise04
{
    public class TimeStorage
    {
        private readonly ConcurrentBag<DateTime> _list = new ConcurrentBag<DateTime>();

        public void LogTime(DateTime time)
        {
            _list.Add(time);
        }

        public IEnumerable<DateTime> GetTimes()
        {
            return _list.ToArray();
        }
    }
}
