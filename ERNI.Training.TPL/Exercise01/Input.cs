using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise01
{
    public class Storage
    {
        private volatile int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
