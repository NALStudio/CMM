using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Exceptions;

internal class CflatException : Exception
{
    public CflatException() : base()
    {
    }

    public CflatException(string? message) : base(message)
    {
    }

    public CflatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
