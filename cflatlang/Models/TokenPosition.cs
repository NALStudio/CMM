using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Models;

internal record TokenPosition
{
    public TokenPosition(int line, int column, int length)
    {
        Line = line;
        Column = column;
        Length = length;
    }

    public int Line { get; }
    public int Column { get; }
    public int Length { get; }

    public override string ToString()
        => $"{Line}:{Column}:{Length}";
}
