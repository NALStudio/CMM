
using CMM.Core;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models
{
    public class Program
    {
        public bool AllowUnsafeCode = false;
        public string FilePath { get; }

        public Program(bool allowUnsafeCode, string filePath)
        {
            AllowUnsafeCode = allowUnsafeCode;
            FilePath = filePath;
        }

        public IEnumerable<Token> Lex()
            => Lexer.LexFile(FilePath);

    }
}
