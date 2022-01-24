using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Models;

internal class CflatProgram
{
    public bool AllowUnsafeCode { get; private set; } = false;
    public string FilePath { get; }

    private CflatProgram(string filepath)
    {
        FilePath = filepath;
    }

    public static CflatProgram Create(string[] args)
    {
        if (args.Length < 1)
            throw new ArgumentException("No filepath provided.");

        string filepath = args[^1];
        if (!File.Exists(filepath))
            throw new ArgumentException($"Invalid path: '{filepath}'");

        CflatProgram program = new(filepath);

        program.AllowUnsafeCode = args.Contains("-unsafe");

        return program;
    }
}
