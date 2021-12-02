
using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using CMM.Models.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Keywords;

public class If : CMM_Keyword
{
    public override FeatureRequirements Requirements => FeatureRequirements.Callable | FeatureRequirements.CodeBlock;
    public override string Name => "if";
}
