using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Keywords;

public class Else : CMM_Keyword
{
    public override FeatureRequirements Requirements => FeatureRequirements.CodeBlock;
    public override string Name => "else";
}
