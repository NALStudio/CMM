using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class Parser
{
    private ParsingContext Context { get; set; }

    public void Evaluate(IEnumerable<LexingToken> lexingTokens)
    {
        ModuleParser moduleParser = new();
        FunctionParser functionParser = new();

        ParsingContext context = new(lexingTokens);

        moduleParser.Evaluate(ref context);
        functionParser.Evaluate(ref context);
    }
}
