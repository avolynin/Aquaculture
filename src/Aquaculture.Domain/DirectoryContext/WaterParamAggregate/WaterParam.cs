using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.WaterParamAggregate;

public class WaterParam : AggregateRoot<WaterParamId>
{
    public string Name { get; private set; } = null!;
    public string Unit { get; private set; } = null!;

    private WaterParam(
        WaterParamId id,
        string name,
        string unit)
        : base(id)
    {
        Name = name;
        Unit = unit;
    }

    public static WaterParam Create(
        string name,
        string unit)
    {
        return new WaterParam(
            WaterParamId.CreateUnique(),
            name,
            unit);
    }

#pragma warning restore CS8618
    private WaterParam()
    {
    }
#pragma warning restore CS8618
}
