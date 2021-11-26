using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Core;

internal static class ConsoleUtility
{
    private static readonly string usage = @"
Usage: cmm [COMMAND] [ARGS]
    COMMAND:
        int <file>              Interpret the program
            ARGS:
                -unsafe             Disable type-checking
        com <file>              Compile the program
            ARGS:
                -unsafe             Disable type-checking
        run <file>              Compile and run the program
        check <file>            Compile and type-check the program without generating an output file
            ARGS: 
                -unsafe             Disable type-checking
        flow <file>             Compile the program and generate a 
            ARGS:               
                -unsafe             Disable type-checking
        help                    Print out this help message
".Trim();

    public static void WriteError(string error)
    {
        Console.Error.WriteLine(usage);
        Console.Error.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;

        // Indent all lines except the first line
        const string errorPrefix = "[ERROR] ";
        string[] errorLines = error.Split('\n');
        for (int i = 1; i < errorLines.Length; i++)
            errorLines[i] = errorLines[i].Insert(0, new string(' ', errorPrefix.Length));

        Console.Error.WriteLine(errorPrefix + string.Join('\n', errorLines));
        Console.ResetColor();
    }


    public static void WriteUsage()
        => Console.WriteLine(usage);
}
