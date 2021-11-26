using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Exceptions
{
    public class LanguageException : Exception
    {
        public LanguageException() : base()
        {
        }

        public LanguageException(string? message) : base(message)
        {
        }

        public LanguageException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
