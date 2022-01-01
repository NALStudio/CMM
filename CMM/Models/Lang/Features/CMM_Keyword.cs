using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang.Features;

public abstract class CMM_Keyword : LangFeature
{
    public abstract FeatureRequirements Requirements { get; }

    public virtual Dictionary<CMM_Keyword, ReferenceSearchBehaviour> AcquireKeywordReferences { get; } = new();
}
