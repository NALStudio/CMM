using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Language;

internal abstract class CflatOperator : LangFeature
{
    public abstract int Precedence { get; }
    public abstract OperatorAssociativity Associativity { get; }
}
