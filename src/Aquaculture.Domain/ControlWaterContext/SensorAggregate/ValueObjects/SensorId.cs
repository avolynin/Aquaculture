using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.SensorAggregate.ValueObjects;

public class SensorId : ValueObject
{
    public Guid Value { get; }

    private SensorId(Guid value)
        => Value = value;

    public static SensorId CreateUnique()
        => new SensorId(Guid.NewGuid());

    public static SensorId Create(Guid value)
        => new SensorId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
