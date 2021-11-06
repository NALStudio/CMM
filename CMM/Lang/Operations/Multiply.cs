using CMM.Models.Lang;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Operations
{
    public class Multiply : Operation
    {
        public override string Name => "*";
        public override OperatorDirection Direction => OperatorDirection.LeftAndRight;
    }
}
