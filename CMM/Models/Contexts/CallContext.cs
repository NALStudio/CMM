using CMM.Models.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Contexts
{
    public class CallContext
    {
        public Argument[] Arguments { get; }

        public CallContext(IEnumerable<Argument> arguments)
        {
            Arguments = arguments.ToArray();
        }
    }
}
