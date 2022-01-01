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
        private readonly List<AbstractNode> Children = new();
        public AbstractNode? Parent { get; private set; } = null;

        public AbstractNode(AbstractType type, LangFeature? feature, string value, (int column, int row) position, params AbstractNode[] children)
                            : base(type, feature, value, position)
        {
            foreach (AbstractNode child in children)
                Add(child);
        }

        public void Add(AbstractNode node)
        {
            Children.Add(node);
            node.Parent = this;
        }
    }
}
