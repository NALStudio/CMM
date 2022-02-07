using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Intermediate;

internal enum IntermediateInstruction
{
    /// <summary>
    /// Load a variable onto the stack.
    /// </summary>
    Load,

    /// <summary>
    /// Push a value onto the stack.
    /// </summary>
    Push,

    /// <summary>
    /// Pop a value from the stack into a variable.
    /// </summary>
    Store,

    // TODO: Rest and also investigate how these should be interpreted.
}
