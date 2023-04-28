using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;

public class PumpId : ValueObject
{
    public Guid Value { get; }

    private PumpId(Guid value)
        => Value = value;

    public static PumpId CreateUnique()
        => new PumpId(Guid.NewGuid());

    public static PumpId Create(Guid value)
        => new PumpId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
