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
    public Dictionary<string, List<LexingToken>> Functions = new();
    public Dictionary<string, string> Constants = new();
    public Dictionary<string, string> Variables = new();

    public ParsingScope Copy()
    {
        ParsingScope ps = new();

        foreach ((string name, List<LexingToken> tokens) in Functions)
            ps.Functions.Add(name, tokens);

        foreach ((string name, string value) in Constants)
            ps.Constants.Add(name, value);

        foreach ((string name, string value) in Variables)
            ps.Variables.Add(name, value);

        return ps;
    }
}
