using CMM.Lang;
using CMM.Models.Exceptions;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using CMM.Models.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMM.Core;

public class Lexer
{
    private CMM_Operation? MatchEndToOperation(string s)
    {
        foreach (CMM_Operation op in Language.Operations.Values)
        {
            if (s.EndsWith(op.Name, StringComparison.Ordinal))
                return op;
        }

        return null;
    }

    private IEnumerable<Token> LexLine(string line, int lineNumber)
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

            if (char.IsWhiteSpace(c) || matchedOperation is not null || i == line.Length - 1)
            {
                string value = token;
                token = string.Empty;

                string? operationValue = null;
                if (matchedOperation is not null)
                {
                    operationValue = value[^matchedOperation.Name.Length..];
                    value = value[..^matchedOperation.Name.Length];
                }

                if (value.Length > 0)
                {
                    (int column, int row) pos = (i - value.Length, lineNumber);
                    if (value.Length == 1 && ControlChars.All.Contains(value[0]))
                        yield return new Token(AbstractType.ControlChar, new CMM_ControlChar(value[0]), value, pos); // NOTE: value is exactly one character so no need to [0]
                    else if (Language.Keywords.TryGetValue(value, out CMM_Keyword? keyword))
                        yield return new Token(AbstractType.Keyword, keyword, value, pos);
                    else if (Language.Types.TryGetValue(value, out CMM_Type<object>? type))
                        yield return new Token(AbstractType.Type, type, value, pos);
                    else if (Language.IsNumber(value))
                        yield return new Token(AbstractType.Number, null, value, pos);
                    else
                        yield return new Token(AbstractType.Name, null, value, pos);
                }

                if (operationValue is not null)
                {
                    System.Diagnostics.Debug.Assert(matchedOperation is not null);
                    System.Diagnostics.Debug.Assert(string.Equals(operationValue, matchedOperation.Name, StringComparison.Ordinal));

                    yield return new Token(AbstractType.Operation, matchedOperation, operationValue, (i - operationValue.Length, lineNumber));
                }
            }
        }
    }

    public IEnumerable<Token> LexFile(string file)
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
