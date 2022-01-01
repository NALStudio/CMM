using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models;

internal class CMM_Program
{
    public bool AllowUnsafeCode { get; private set; } = false;
    public string FilePath { get; }

    private CMM_Program(string filepath)
    {
        FilePath = filepath;
    }

    public static CMM_Program Create(string[] args)
    {
        if (args.Length < 1)
            throw new ArgumentException("No filepath provided.");

        string filepath = args[^1];
        if (!File.Exists(filepath))
            throw new ArgumentException($"Invalid path: '{filepath}'");

        CMM_Program program = new(filepath);

        program.AllowUnsafeCode = args.Contains("-unsafe");

        return program;
    }
}
