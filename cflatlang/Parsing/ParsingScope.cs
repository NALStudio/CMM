using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingScope
{
    public Dictionary<string, ParsingFunction> Functions = new();
    public Dictionary<string, string> Constants = new();
    public Dictionary<string, string> Variables = new();
}
