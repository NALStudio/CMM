using cflatlang.Core;
using cflatlang.Language;
using cflatlang.Lexing;
using cflatlang.Models;
using cflatlang.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace cflatlang;

public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length < 1 || args[0] == "help")
        {
            ConsoleUtility.WriteUsage();
            return 0;
        }

        string command = args[0];
        CflatProgram program;
        try
        {
            program = CflatProgram.Create(args[1..]);
        }
        catch (Exception ex)
        {
            ConsoleUtility.WriteError(ex.Message);
            return 1;
        }

        return command switch
        {
            "int" => Interpret(program),
            "com" => Compile(program).exitCode,
            "run" => Run(program),
            "check" => GenerateIR(program),
            "flow" => GenerateCFG(program),
            "byte" => GenerateAndSaveIR(program),
            _ => InvalidCommandError(command) // NOTE: help is handled above.
        };
    }

    private static int InvalidCommandError(string command)
    {
        ConsoleUtility.WriteError($"Invalid command: \"{command}\"");
        return 1;
    }


    private static int Run(CflatProgram program)
    {
        (string outputPath, int exitCode) = Compile(program);
        if (exitCode != 0)
            return exitCode;

        Process runProcess = Process.Start(outputPath);
        runProcess.WaitForExit();
        return runProcess.ExitCode;
    }

    private static int GenerateIR(CflatProgram program)
    {
        Lexer lexer = new();
        IEnumerable<LexingToken> tokens = lexer.EvaluateFile(program.FilePath);

        Parser parser = new();
        parser.Evaluate(tokens);

        throw new NotImplementedException();
    }

    private static int GenerateAndSaveIR(CflatProgram program)
    {
        throw new NotImplementedException();
    }

    private static int GenerateCFG(CflatProgram program)
    {
        throw new NotImplementedException();
    }

    private static (string path, int exitCode) Compile(CflatProgram program)
    {
        throw new NotImplementedException();
    }

    private static int Interpret(CflatProgram program)
    {
        // TODO: IR
        _ = GenerateIR(program);
        throw new NotImplementedException();
    }
}