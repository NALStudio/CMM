using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Exceptions
{
    class LexingException : Exception
    {
        private LexingException() : base()
        {
        }

        public LexingException(string? message) : base(message)
        {
        }

        public LexingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
