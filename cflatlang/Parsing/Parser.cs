using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class Parser
{
    public void Evaluate()
    {
        ModuleParser moduleParser = new();
        FunctionParser functionParser = new();

        ParsingScope scope = new();

        moduleParser.Evaluate(ref scope);
        functionParser.Evaluate(ref scope);
    }
}
