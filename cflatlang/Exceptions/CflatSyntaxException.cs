using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Exceptions;

internal class CflatSyntaxException : CflatException
{
    public CflatSyntaxException() : base()
    {
    }

    public CflatSyntaxException(string? message) : base(message)
    {
    }

    public CflatSyntaxException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
