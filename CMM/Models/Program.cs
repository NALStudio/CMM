
using CMM.Core;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models
{
    public class Program
    {
        public bool AllowUnsafeCode = false;
        public string FilePath { get; }

        private Program(string filePath)
        {
            FilePath = filePath;
        }

        public static Program Create(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("No filepath provided.");

            string filepath = args[^1];
            if (!File.Exists(filepath))
                throw new ArgumentException($"Invalid path: '{filepath}'");

            Program program = new(filepath);

            for (int i = 0; i < args.Length - 1; i++)
            {
                switch (args[i])
                {
                    case "-unsafe":
                        program.AllowUnsafeCode = true;
                        break;
                }
            }

            return program;
        }
    }
}
