using CMM.Models.Exceptions;
using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMM.Core;

public static class Language
{
    private static readonly Dictionary<string, CMM_Keyword> keywords = new();
    private static readonly Dictionary<string, CMM_Operation> operations = new();
    private static readonly Dictionary<string, CMM_Type> types = new();

    public static IReadOnlyDictionary<string, CMM_Keyword> Keywords => keywords;
    public static IReadOnlyDictionary<string, CMM_Operation> Operations => operations;
    public static IReadOnlyDictionary<string, CMM_Type> Types => types;


    private static Regex numberRegex = new(@"^\d+$");
    public static bool IsNumber(string s)
        => numberRegex.IsMatch(s);

    public static void Init()
    {
        #region Keywords
        keywords.Clear();
        foreach ((string name, Type type) in GetLangFeaturesOfType<CMM_Keyword>())
        {
            if (keywords.ContainsKey(name))
                throw new LexingException($"Keywords already contain a definition for \'{name}\' by \'{type.Name}\'");
            keywords.Add(name, (CMM_Keyword)(Activator.CreateInstance(type) ?? throw new LexingException($"Internal Error. Could not construct object of type: {type}")));
        }
        #endregion

        #region Operations
        operations.Clear();
        foreach ((string name, Type type) in GetLangFeaturesOfType<CMM_Operation>())
        {
            if (operations.ContainsKey(name))
                throw new LexingException($"Operations already contain a definition for \'{name}\' by \'{type.Name}\'");
            operations.Add(name, (CMM_Operation)(Activator.CreateInstance(type) ?? throw new LexingException($"Internal Error. Could not construct object of type: {type}")));
        }
        #endregion

        #region Types
        types.Clear();
        foreach ((string name, Type type) in GetLangFeaturesOfType<CMM_Type>())
        {
            if (types.ContainsKey(name))
                throw new LexingException($"Operations already contain a definition for \'{name}\' by \'{type.Name}\'");
            types.Add(name, (CMM_Type)(Activator.CreateInstance(type) ?? throw new LexingException($"Internal Error. Could not construct object of type: {type}")));
        }
        #endregion
    }

    private static IEnumerable<(string name, Type type)> GetLangFeaturesOfType<T>() where T : LangFeature
    {
        Type type = typeof(T);

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type t in assembly.GetTypes().Where(_t => _t.IsClass && !_t.IsAbstract && _t.IsSubclassOf(type)))
            {
                FieldInfo? nameField = t.GetField(nameof(LangFeature.Name), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                T kw = (T)(Activator.CreateInstance(t) ?? throw new LanguageException($"Internal Error. Could not construct object of type: {t.Name}"));
                yield return (kw.Name, t);
            }
        }
    }
}
