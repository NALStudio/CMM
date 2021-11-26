using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Types
{
    internal class Integer : CMM_ValueType
    {
        public override InstantiationType Instantiation => InstantiationType.Number;

        public override string Name => "int";
    }
}
