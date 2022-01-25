using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Language.Operators;

internal class CflatAdd : CflatOperator
{
    public override string Name => "+";

    public override int Precedence => 12;
    public override OperatorAssociativity Associativity => OperatorAssociativity.Left;
}
