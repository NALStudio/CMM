using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Operations;

public class Multiply : CMM_Operation
{
    public override string Name => "*";
    public override OperatorDirection Direction => OperatorDirection.LeftAndRight;

    public override int Precedence => 3;
    public override OperatorAssociativity Associativity => OperatorAssociativity.Left;
}
