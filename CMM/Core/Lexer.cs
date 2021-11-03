using CMM.Models.Exceptions;
using CMM.Models.Lang;
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
        private static readonly Dictionary<string, Type> Keywords = new();
        private static readonly Dictionary<string, Type> Operations = new();

        private static void LoadLexerData()
        {
            #region Keywords
            Keywords.Clear();
            foreach ((string name, Type type) in GetLangFeaturesOfType<Keyword>())
            {
                if (Keywords.ContainsKey(name))
                    throw new LexingException($"Keywords already contain a definition for \'{name}\' by \'{type.Name}\'");
                Keywords.Add(name, type);
            }
            #endregion

            #region Operations
            Operations.Clear();
            foreach ((string name, Type type) in GetLangFeaturesOfType<Operation>())
            {
                if (Operations.ContainsKey(name))
                    throw new LexingException($"Operations already contain a definition for \'{name}\' by \'{type.Name}\'");
                Operations.Add(name, type);
            }
            #endregion
        }

        private static (TokenType type, LangFeature? featureType) GetFeature(string s)
        {
            if (Operations.TryGetValue(s, out Type? operationType))
                return (TokenType.Operation, (LangFeature)(Activator.CreateInstance(operationType) ?? throw new LexingException($"Internal Error. Could not construct object of type: {operationType}")));
            else if (Keywords.TryGetValue(s, out Type? keywordType))
                return (TokenType.Keyword, (LangFeature)(Activator.CreateInstance(keywordType) ?? throw new LexingException($"Internal Error. Could not construct object of type: {keywordType}")));
            else if (Regex.IsMatch(s, @"^\d+$"))
                return (TokenType.Number, null);
            throw new LexingException($"The name \'{s}\' does not exist in the current context.");
        }

        private static IEnumerable<Token> LexLine(string line, int lineNumber)
        {
            StringBuilder tokenBuilder = new();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (!char.IsWhiteSpace(c))
                {
                    tokenBuilder.Append(c);
                }
                else
                {
                    string value = tokenBuilder.ToString();
                    (TokenType type, LangFeature? featureType) = GetFeature(value);
                    tokenBuilder.Clear();
                    yield return new Token(type, featureType, value, (i - value.Length, lineNumber));
                }
            }
        }

        public static IEnumerable<Token> LexFile(string file)
        {
            LoadLexerData();

            int lineNmbr = 0;
            foreach (string line in File.ReadLines(file))
            {
                lineNmbr++; // Lines start from 1
                foreach (Token t in LexLine(line, lineNmbr))
                    yield return t;
            }
        }

        private static IEnumerable<(string name, Type type)> GetLangFeaturesOfType<T>() where T : LangFeature
        {
            Type type = typeof(T);

            Assembly? assembly = Assembly.GetAssembly(type);
            if (assembly == null)
                throw new ArgumentException($"Assembly of type: \'{type.Name}\' could not be found!");

            foreach (Type t in assembly.GetTypes().Where(_t => _t.IsClass && !_t.IsAbstract && _t.IsSubclassOf(type)))
            {
                FieldInfo? nameField = t.GetField(nameof(LangFeature.Name), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                T kw = (T)(Activator.CreateInstance(t) ?? throw new LexingException($"Internal Error. Could not construct object of type: {t.Name}"));
                yield return (kw.Name, t);
            }
        }
    }
}
