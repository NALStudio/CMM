using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Exceptions;

public class ParsingException : CMM_Exception
{
    public ParsingException() : base()
    {
    }

    public ParsingException(string? message) : base(message)
    {
    }

    public ParsingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
