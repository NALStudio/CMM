using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Exceptions
{
    public class CMM_InternalException : CMM_Exception
    {
        public CMM_InternalException() : base()
        {
        }

        public CMM_InternalException(string? message) : base("[INTERNAL ERROR] " + message)
        {
        }

        public CMM_InternalException(string? message, Exception? innerException) : base("[INTERNAL ERROR] " + message, innerException)
        {
        }
    }
}
