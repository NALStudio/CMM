using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingFunction
{
    public string Name { get; }
    public ParsingScope InnerScope { get; }
    public IReadOnlyList<LexingToken> LexingTokens { get; private set; }


    public ParsingFunction(string name, IEnumerable<LexingToken> tokens)
    {
        Name = name;
        InnerScope = new();

        LexingTokens = new List<LexingToken>(tokens);
    }
}
