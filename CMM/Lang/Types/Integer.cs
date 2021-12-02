using CMM.Models.Contexts;
using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Types;

public class Integer : CMM_ValueType<int>
{
    public override InstantiationType Instantiation => InstantiationType.Number;

    public override string Name => "int";

    public override Dictionary<string, Func<CMM_Type<int>, CMM_Type<int>, CMM_Type<int>>> OperatorImplementations => new()
    {
        { "*", (x, y) => CreateNew(new Argument(((Integer)x).value * ((Integer)y).value)) }
    };

    public override CMM_Type<int> CreateNew(params Argument[] arguments)
        => new Integer(arguments[0].ReadAs<int>());

    private readonly int value;
    private Integer(int value)
    {
        this.value = value;
    }
}
