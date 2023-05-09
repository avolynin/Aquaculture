using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;

public class SensorId : ValueObject
{
    public int Value { get; }

    private SensorId(int value)
        => Value = value;

    public static SensorId Create(int value)
        => new SensorId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
