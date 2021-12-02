using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang.Features;

public class CMM_ControlChar : LangFeature
{
    public CMM_ControlChar(char value)
    {
        Name = value.ToString();
    }

    public override string Name { get; }
}
