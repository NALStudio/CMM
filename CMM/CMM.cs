using CMM.Core;
using CMM.Models;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CMM;

public static class CMM
{
    private static int Main(string[] args)
    {
        if (args.Length < 1 || args[0] == "help")
        {
            ConsoleUtility.WriteUsage();
            return 0;
        }

        #region Initialisations
        Language.Init();
        #endregion

        string command = args[0];
        Program program;
        try
        {
             program = Program.Create(args[1..]);
        }
        catch (Exception ex)
        {
            ConsoleUtility.WriteError(ex.Message);
            return 1;
        }

        try
        {
            switch (command)
            {
                // NOTE: Help is handled at the start of the application
                case "int":
                    Interpret(program);
                    break;
                case "com":
                    CompileToFile(program);
                    break;
                case "run":
                    Run(program);
                    break;
                case "check":
                    Compile(program);
                    break;
                default:
                    throw new Exception($"Invalid command: \'{command}\'");
            }
        }
        catch (Exception ex)
        {
            ConsoleUtility.WriteError(ex.Message);
        }

        return 0;
    }

    private static void Run(Program program)
    {
        string outputPath = CompileToFile(program);
        Process.Start(outputPath);
    }

    private static void Compile(Program program)
    {
        IEnumerable<Token> tokens = Lexer.LexFile(program.FilePath);
        foreach (Token token in tokens)
        {
            Console.WriteLine(token.Value);
            Console.WriteLine(token.Type);
            Console.WriteLine(token.Position);
            Console.WriteLine();
        }
    }

    private static string CompileToFile(Program program)
    {
        throw new NotImplementedException();
    }

    private static void Interpret(Program program)
    {
        throw new NotImplementedException();
    }
}
