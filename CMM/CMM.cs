using CMM.Core;
using System;

namespace CMM
{
    public static class CMM
    {
        private static void CloseWithMessage(string message, int exitCode, ConsoleColor? color = null)
        {
            if (color.HasValue)
                Console.ForegroundColor = color.Value;
            Console.WriteLine(message);
            if (color.HasValue)
                Console.ResetColor();
            Environment.Exit(exitCode);
        }

        private static void Main(string[] args)
        {
            if (args.Length < 1 || args[0] == "help")
            {
                CloseWithMessage(Constants.HelpMessage("tmp_app_name"), 0);
                Environment.Exit(0);
            }

            string command = args[0];
            switch (command)
            {
                // NOTE: Help is handled at the start of the application
                case "intpr":
                    Interpret(args[1..]);
                    break;
                case "comp":
                    Compile(args[1..]);
                    break;
                case "run":
                    Run(args[1..]);
                    break;
                default:
                    CloseWithMessage($"Invalid command: \'{command}\'", 1, ConsoleColor.Red);
                    break;
            }
        }

        private static void Run(string[] args)
        {
            Compile(args);
            // TODO: run
            throw new NotImplementedException();
        }

        private static void Compile(string[] args)
        {
            throw new NotImplementedException();
        }

        private static void Interpret(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
