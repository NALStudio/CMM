using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Language;

internal static class Separators
{
    public const char CallStart = '(';
    public const char CallEnd = ')';
    public const char InnerContextStart = '(';
    public const char InnerContextEnd = ')';

    public const char CodeblockStart = '{';
    public const char CodeblockEnd = '}';

    public const char StatementDelimiter = ';';
    public const char SetItemDelimiter = ',';

    public const char GenericDefinitionStart = '<';
    public const char GenericDefinitionEnd = '>';

    public const char NumberDecimalSeparator = '.';


    private static HashSet<char>? _all = null;
    public static IReadOnlySet<char> All
    {
        get
        {
            if (_all is null)
            {
                FieldInfo[] fields = typeof(Separators).GetFields(BindingFlags.Static | BindingFlags.Public);
                _all = new HashSet<char>();
                for (int i = 0; i < fields.Length; i++)
                    _ = _all.Add((char)(fields[i].GetValue(null) ?? throw new Exception($"Could not get value of field: {fields[i].Name}")));
            }
            return _all;
        }
    }
}
