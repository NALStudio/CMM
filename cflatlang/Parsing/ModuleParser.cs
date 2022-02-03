using cflatlang.Exceptions;
using cflatlang.Language;
using cflatlang.Lexing;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class ModuleParser
{

    public void Evaluate(ref ParsingContext context)
    {
        IEnumerator<LexingToken> enumerator = context.LexingTokens.GetEnumerator();

        while (enumerator.MoveNext())
        {
            List<CflatModifier> modifiers = new();

            LexingToken token;

            do
            {
                token = enumerator.Current;
                if (token.Type != LexingType.Modifier)
                    throw new CflatException($"Unexpected {token.Type.Humanize(LetterCasing.LowerCase)}: '{token.Value}'");

                CflatModifier[] modfrs = LanguageData.Modifiers.Where(m => m.Name == token.Value).ToArray();
                Trace.Assert(modfrs.Length == 1);

                CflatModifier modifier = modfrs[0];

                if (modifiers.Contains(modifier))
                    throw new CflatException($"Duplicate '{modifier.Name}' modifier");

                modifiers.Add(modifier);
            }
            while (enumerator.MoveNext() && enumerator.Current.Type == LexingType.Modifier);


            token = enumerator.Current;
            
            // TODO: Support other functions like properties etc.
            Language.Keywords.CflatFunction defaultFuncObject = new();

            if (modifiers.Count < 1
                || token.Type != LexingType.Keyword
                || token.Value != defaultFuncObject.Name
            )
            {
                throw new CflatException($"Unexpected {token.Type.Humanize(LetterCasing.LowerCase)}: '{token.Value}'");
            }

            if (!enumerator.MoveNext())
                throw new CflatException($"No name provided in {token.Value} declaration.");

            token = enumerator.Current;
            if (token.Type != LexingType.Identifier)
                throw new CflatException($"Unexpected {token.Type.Humanize(LetterCasing.LowerCase)}: '{token.Value}'");

            if (!enumerator.MoveNext() || enumerator.Current.Value != Separators.CallStart.ToString())
                throw new CflatException($"Missing '{Separators.CallStart}' parenthesis in {token.Value} declaration.");

            while (enumerator.MoveNext())
            {
                token = enumerator.Current;

                if (token.Value == Separators.CallEnd.ToString())
                    break;
            }

            if (!enumerator.MoveNext())
            {
                // Catch the case where the while-loop above runs out of tokens and move to codeblock token
                if (token.Value != Separators.CallEnd.ToString())
                    throw new CflatException($"Missing '{Separators.CallEnd}' parenthesis in {token.Value} declaration.");
                else
                    throw new CflatException($"Missing body in {token.Value} declaration.");
            }

            if (enumerator.Current.Value != Separators.CodeblockStart.ToString())
                throw new CflatException($"Missing body in {token.Value} declaration.");

            throw new NotImplementedException();
        }
    }
}
