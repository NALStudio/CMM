using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Core;

internal static class ConsoleUtility
{
    private static string GetUsageMessage()
    {
        StringBuilder sb = new();

        sb.AppendLine("Usage: cmm [COMMAND] [ARGS]"                                                          );
        sb.AppendLine("    COMMAND:"                                                                         );
        sb.AppendLine("        int <file>              Interpret the program"                                );
        sb.AppendLine("            ARGS:"                                                                    );
        sb.AppendLine("                -unsafe             Disable type-checking"                            );
        sb.AppendLine("        com <file>              Compile the program into an executable"               );
        sb.AppendLine("            ARGS:"                                                                    );
        sb.AppendLine("                -unsafe             Disable type-checking"                            );
        sb.AppendLine("        run <file>              Compile and run the program"                          );
        sb.AppendLine("        check <file>            Compile and type-check the program"                   );
        sb.AppendLine("            ARGS: "                                                                   );
        sb.AppendLine("                -unsafe             Disable type-checking"                            );
        sb.AppendLine("        flow <file>             Compile the program and generate a control flow graph");
        sb.AppendLine("            ARGS: "                                                                   );
        sb.AppendLine("                -unsafe             Disable type-checking"                            );
        sb.AppendLine("        help                    Print out this help message"                          );

        return sb.ToString();
    }

    public static void WriteError(string error)
    {
        Console.Error.WriteLine(GetUsageMessage());
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
        => Console.WriteLine(GetUsageMessage());
}
