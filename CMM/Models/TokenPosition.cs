using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models;

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
}
