using cflatlang.Language;
using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingScope
{
    public Dictionary<string, IEnumerable<LexingToken>> Functions = new();
    public Dictionary<string, string> Constants = new();
    public Dictionary<string, string> Variables = new();
}
