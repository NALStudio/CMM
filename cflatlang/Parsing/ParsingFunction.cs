using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingFunction
{
    public ParsingContext ParentContext { get; }

    public string Name { get; }
    public ParsingScope InnerScope { get; }
    public IReadOnlyList<LexingToken> LexingTokens { get; private set; }


    public ParsingFunction(ParsingContext parent, string name, IEnumerable<LexingToken> tokens)
    {
        ParentContext = parent;

        Name = name;
        InnerScope = new();

        LexingTokens = new List<LexingToken>(tokens);
    }
}
