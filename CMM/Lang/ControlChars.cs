using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang;

public static class ControlChars
{
    public const char CallStart = '(';
    public const char CallEnd = ')';
    public const char InnerContextStart = '(';
    public const char InnerContextEnd = ')';

    public const char CodeblockStart = '{';
    public const char CodeblockEnd = '}';

    public const char StatementDelimiter = ';';
    public const char SetItemDelimiter = ',';

    private static char[]? _all;
    public static IReadOnlyList<char> All
    {
        get
        {
            if (_all is null)
            {
                FieldInfo[] fields = typeof(ControlChars).GetFields(BindingFlags.Static | BindingFlags.Public);
                _all = new char[fields.Length];
                for (int i = 0; i < fields.Length; i++)
                    _all[i] = (char)(fields[i].GetValue(null) ?? throw new Exception($"Could not get value of field: {fields[i].Name}"));
            }
            return _all;
        }
    }
}
