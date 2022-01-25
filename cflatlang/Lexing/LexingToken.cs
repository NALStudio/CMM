using cflatlang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Lexing;

internal class LexingToken
{
    public LexingToken(LexingType type, string value, TokenPosition position)
    {
        Type = type;
        Value = value;
        Position = position;
    }

    public LexingType Type { get; set; }
    public string Value { get; set; }
    public TokenPosition Position { get; set; }

    public override string ToString()
        => $"LexingToken({Type}: '{Value}' at {Position})";
}
