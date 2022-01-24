using CMM.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lexing;

internal static class Parsers
{
    public static bool TryMatchLiteralFromStart(string text, [MaybeNullWhen(false)] out LiteralType type, [MaybeNullWhen(false)] out string match)
    {
        if (text.StartsWith(ControlSequences.LiteralBooleanTrue))
        {
            type = LiteralType.Boolean;
            match = text[..ControlSequences.LiteralBooleanTrue.Length];
            return true;
        }
        else if (text.StartsWith(ControlSequences.LiteralBooleanFalse))
        {
            type = LiteralType.Boolean;
            match = text[..ControlSequences.LiteralBooleanFalse.Length];
            return true;
        }
        else if (TryMatchNumberFromStart(text, out bool isDecimal, out string? numberMatch))
        {
            type = isDecimal ? LiteralType.Decimal : LiteralType.Integer;
            match = numberMatch;
            return true;
        }
        else if (TryMatchStringFromStart(text, out string? stringMatch))
        {
            type = LiteralType.String;
            match = stringMatch;
            return true;
        }

        type = default;
        match = null;
        return false;
    }

    private static bool TryMatchNumberFromStart(string text, [MaybeNullWhen(false)] out bool isDecimal, [MaybeNullWhen(false)] out string match)
    {
        static bool IsCompilerValidDigit(char c)
        {
            const string validChars = "0123456789_";
            return validChars.Contains(c);
        }

        int i;
        for (i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c == Separators.NumberDecimalSeparator)
            {
                if (text[..i].Contains(Separators.NumberDecimalSeparator))
                    break;
            }
            else if (!IsCompilerValidDigit(c))
            {
                break;
            }
        }

        if (i < 1)
        {
            match = null;
            isDecimal = default;
            return false;
        }

        match = text[..i];
        isDecimal = match.Contains(Separators.NumberDecimalSeparator);
        return true;
    }

    private static bool TryMatchStringFromStart(string text, [MaybeNullWhen(false)] out string match)
    {
        if (!text.StartsWith(ControlSequences.LiteralStringStart))
        {
            match = null;
            return false;
        }

        int stringEnd = text.IndexOf(ControlSequences.LiteralStringEnd, 1);
        if (stringEnd == -1)
        {
            match = null;
            return false;
        }

        int stringTotalLength = stringEnd + 1;
        match = text[..stringTotalLength];
        return true;
    }
}
