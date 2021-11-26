using CMM.Models.Exceptions;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMM.Core
{
    public static class Lexer
    {
        private static CMM_Operation? MatchEndToOperation(string s)
        {
            foreach (CMM_Operation op in Language.Operations.Values)
            {
                if (s.EndsWith(op.Name, StringComparison.Ordinal))
                    return op;
            }

            return null;
        }

        private static IEnumerable<Token> LexLine(string line, int lineNumber)
        {
            string token = string.Empty;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (!char.IsWhiteSpace(c))
                    token += c;

                if (token.Length < 1)
                    continue;

                CMM_Operation? matchedOperation = MatchEndToOperation(token);

                if (char.IsWhiteSpace(c) || matchedOperation is not null)
                {
                    string value = token;
                    token = string.Empty;

                    if (matchedOperation is not null)
                    {
                        string operationValue = value[^matchedOperation.Name.Length..];
                        value = value[..^matchedOperation.Name.Length];

                        string operationName = operationValue;
                        System.Diagnostics.Debug.Assert(string.Equals(operationName, matchedOperation.Name, StringComparison.Ordinal));
                        yield return new Token(TokenType.Operation, matchedOperation, operationName, (i - operationName.Length, lineNumber));
                    }

                    if (value.Length < 1)
                        continue;

                    (int column, int row) pos = (i - value.Length, lineNumber);
                    if (Language.Keywords.TryGetValue(value, out CMM_Keyword? keyword))
                        yield return new Token(TokenType.Keyword, keyword, value, pos);
                    else if (Language.IsNumber(value))
                        yield return new Token(TokenType.Number, null, value, pos);
                    else
                        throw new LexingException($"The name \'{value}\' does not exist in the current context.");
                }
            }
        }

        public static IEnumerable<Token> LexFile(string file)
        {
            int lineNmbr = 0;
            foreach (string line in File.ReadLines(file))
            {
                lineNmbr++; // Lines start from 1
                foreach (Token t in LexLine(line, lineNmbr))
                    yield return t;
            }
        }
    }
}
