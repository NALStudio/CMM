using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Language;

internal class Identifier : LangFeature
{
    public override string Name { get; }

    public Identifier(string name)
    {
        Name = name;
    }
}
