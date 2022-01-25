using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Language.Operators;

internal class CflatAssign : CflatOperator
{
    public override string Name => "=";

    public override int Precedence => 1;
    public override OperatorAssociativity Associativity => OperatorAssociativity.Right;
}
