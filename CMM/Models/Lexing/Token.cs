
using CMM.Models.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lexing
{
    public class Token
    {
        public Token(TokenType type, LangFeature? feature, string value, (int column, int row) position)
        {
            Type = type;
            Feature = feature;
            Value = value;
            Position = position;
        }

        public TokenType Type { get; }
        public LangFeature? Feature { get; }
        public string Value { get; }
        public (int column, int row) Position { get; }
    }
}
