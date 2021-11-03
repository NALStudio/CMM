using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Core
{
    public static class Constants
    {
        #region Help
        public static string HelpMessage(string applicationName)
            => $@"
Usage: {applicationName} [COMMAND] [ARGS]
    COMMAND:
        intpr <file>            Interpret the program
            ARGS:
                
        comp <file>             Compile the program
            ARGS:
                -unsafe             Disable type checking
        run <file>              Compile and run the program
            ARGS: 
                -unsafe             Disable type checking
        help                    Print out this help message
".Trim();
        #endregion

    }
}
