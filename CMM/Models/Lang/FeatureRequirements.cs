using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang
{
    [Flags]
    public enum FeatureRequirements
    {
        // Enum values are powers of two
        None = 0,
        Callable = 1,
        CodeBlock = 2
    }
}
