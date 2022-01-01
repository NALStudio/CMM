using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang.Features;

public abstract class CMM_Operation : LangFeature
{
    public abstract OperationDirection OperationDirection { get; }

    public virtual bool AllowImplementation => true;
    public virtual bool AllowAsStatement => false;

    public abstract int Precedence { get; }
    public abstract OperatorAssociativity Associativity { get; }
}
