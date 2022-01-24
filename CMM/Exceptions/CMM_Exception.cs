using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Exceptions;

internal class CMM_Exception : Exception
{
    public CMM_Exception() : base()
    {
    }

    public CMM_Exception(string? message) : base(message)
    {
    }

    public CMM_Exception(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
