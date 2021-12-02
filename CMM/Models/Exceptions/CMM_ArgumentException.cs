using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Exceptions;

internal class CMM_ArgumentException : CMM_Exception
{
    public CMM_ArgumentException() : base()
    {
    }

    public CMM_ArgumentException(string? message) : base(message)
    {
    }

    public CMM_ArgumentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
