using CMM.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang
{
    public struct Argument
    {
        private object _value;

        public Argument(object value)
        {
            _value = value;
        }

        public T ReadAs<T>()
        {
            if (_value is T v)
                return v;

            throw new CMM_Exception($"Argument of type: '{_value.GetType()}' cannot be read as '{typeof(T)}'");
        }
    }
}
