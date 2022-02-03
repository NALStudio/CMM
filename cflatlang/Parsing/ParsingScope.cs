using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingScope
{
    public Dictionary<string, ParsingFunction> Functions { get; }
    public Dictionary<string, string> Constants { get; }
    public Dictionary<string, string> Variables { get; }

    public ParsingScope()
    {
        Functions = new();
        Constants = new();
        Variables = new();
    }
}
