using CMM.Models.Lang;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Parsing
{
    public class AbstractNode : Token
    {
        public AbstractNode(AbstractType type, LangFeature? feature, string value, (int column, int row) position) : base(type, feature, value, position)
        {
        }
    }
}
