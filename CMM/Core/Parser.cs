using CMM.Lang;
using CMM.Models.Exceptions;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using CMM.Models.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Core;

public class Parser
{
    public IEnumerable<Node> Parse(IEnumerable<Token> lexingTokens)
    {
        IEnumerable<AbstractNode> abstractNodes = AbstractParse(lexingTokens);
        ParsingContext context = ParseContext(abstractNodes);
        return ParseFinal(abstractNodes, context);
    }

    private IEnumerable<AbstractNode> AbstractParse(IEnumerable<Token> lexingTokens)
    {
        List<Token> tokens = new(lexingTokens);

        if (tokens.Count > 0)
            throw new ParsingException("No tokens provided!");

        if (tokens.Last().Feature is not CMM_ControlChar lastCC || lastCC.Name != ControlChars.StatementDelimiter.ToString())
            throw new ParsingException($"Expected '{ControlChars.StatementDelimiter}' at the end of statement.");


    }

    private ParsingContext ParseContext(IEnumerable<AbstractNode> nodes)
    {
        ParsingContext context = new();
    }

    private IEnumerable<Node> ParseFinal(IEnumerable<AbstractNode> nodes, ParsingContext context)
    {

    }
}
