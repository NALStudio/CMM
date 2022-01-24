using cflatlang.Exceptions;
using cflatlang.Language;
using cflatlang.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cflatlang.Lexing;

internal class Lexer
{
    private static bool TryMatchIdentifier(string lineRest, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out string match)
    {
        bool IsValidStartingCharacter(char c)
            => char.IsLetter(c) || c == '_';
        bool IsValidCharacter(char c)
            => char.IsLetterOrDigit(c) || c == '_';

        if (!IsValidStartingCharacter(lineRest[0]))
        {
            match = null;
            return false;
        }

        for (int i = 1; i < lineRest.Length; i++)
        {
            if (!IsValidCharacter(lineRest[i]))
            {
                match = lineRest[..i];
                return true;
            }
        }

        match = lineRest[..1];
        return true;
    }

    private static bool TryMatchLangFeatureFromEnumerable<T>(string lineRest, IEnumerable<T> enumerable, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out string match) where T : LangFeature
    {
        foreach (T keyword in enumerable)
        {
            if (lineRest.StartsWith(keyword.Name, StringComparison.Ordinal))
            {
                match = keyword.Name;
                return true;
            }
        }

        match = null;
        return false;
    }

    private static bool TryMatchSeparator(string lineRest, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out string match)
    {
        char c = lineRest[0];
        if (Separators.All.Contains(c))
        {
            match = c.ToString();
            return true;
        }

        match = null;
        return false;
    }

    private IEnumerable<LexingToken> EvaluateLine(string line, int lineNumber)
    {
        string lineRest = line;

        void ChopLineStart(int length)
            => lineRest = lineRest[length..];
        TokenPosition GetTokenPos(string match, string remaining)
        {
            int _line = lineNumber;
            int _column = line.Length - remaining.Length;
            int _length = match.Length;

            return new TokenPosition(_line, _column, _length);
        }

        while ((lineRest = lineRest.TrimStart()).Length > 0)
        {
            if (Parsers.TryMatchLiteralFromStart(lineRest, out LiteralType _, out string? mLit))
            {
                ChopLineStart(mLit.Length);
                yield return new LexingToken(LexingType.Literal, mLit, GetTokenPos(mLit, lineRest));
            }
            else if (TryMatchLangFeatureFromEnumerable(lineRest, LanguageData.Operators, out string? mOp))
            {
                ChopLineStart(mOp.Length);
                yield return new LexingToken(LexingType.Operator, mOp, GetTokenPos(mOp, lineRest));
            }
            else if (TryMatchSeparator(lineRest, out string? mSep))
            {
                ChopLineStart(mSep.Length);
                yield return new LexingToken(LexingType.Separator, mSep, GetTokenPos(mSep, lineRest));
            }
            else if (TryMatchLangFeatureFromEnumerable(lineRest, LanguageData.Keywords, out string? mKw))
            {
                ChopLineStart(mKw.Length);
                yield return new LexingToken(LexingType.Keyword, mKw, GetTokenPos(mKw, lineRest));
            }
            else if (TryMatchLangFeatureFromEnumerable(lineRest, LanguageData.Modifiers, out string? mMd))
            {
                ChopLineStart(mMd.Length);
                yield return new LexingToken(LexingType.Modifier, mMd, GetTokenPos(mMd, lineRest));
            }
            else if (TryMatchIdentifier(lineRest, out string? mId))
            {
                ChopLineStart(mId.Length);
                yield return new LexingToken(LexingType.Identifier, mId, GetTokenPos(mId, lineRest));
            }
            else
            {
                throw new Exception($"'{lineRest}' was not matched to anything.");
            }
        }
    }

    public IEnumerable<LexingToken> EvaluateFile(string filepath)
    {
        int lineNumber = 1;

        foreach (string line in File.ReadLines(filepath))
        {
            foreach (LexingToken token in EvaluateLine(line, lineNumber))
                yield return token;

            lineNumber++;
        }
    }
}
