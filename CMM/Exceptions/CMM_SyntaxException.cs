using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Exceptions;

internal class CMM_SyntaxException : CMM_Exception
{
    public CMM_SyntaxException() : base()
    {
    }

    public CMM_SyntaxException(string? message) : base(message)
    {
    }

    public CMM_SyntaxException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
