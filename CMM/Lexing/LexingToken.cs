using CMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lexing;

internal class LexingToken
{
    public LexingToken(LexingType token, string value, TokenPosition position)
    {
        Token = token;
        Value = value;
        Position = position;
    }

    public LexingType Token { get; set; }
    public string Value { get; set; }
    public TokenPosition Position { get; set; }
}
