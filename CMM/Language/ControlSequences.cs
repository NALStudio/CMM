using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Language;

/// <summary>
/// Same as Separators, but need to be matched manually.
/// </summary>
internal static class ControlSequences
{
    public const string LineCommentStart = "//";
    public const string BlockCommentStart = "/*";
    public const string BlockCommentEnd = "*/";

    public const string LiteralBooleanTrue = "true";
    public const string LiteralBooleanFalse = "false";

    public const char LiteralStringStart = '"';
    public const char LiteralStringEnd = '"';

    public const char VariableDiscardRepeat = '_';
}
