using cflatlang.Language;
using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ParsingContext
{
    public string? Namespace { get; }

    public ParsingScope Scope { get; }
    public IReadOnlyList<LexingToken> LexingTokens { get; private set; }


    public ParsingContext(IEnumerable<LexingToken> tokens)
    {
        Scope = new();

        LexingTokens = new List<LexingToken>(tokens);
    }
}
