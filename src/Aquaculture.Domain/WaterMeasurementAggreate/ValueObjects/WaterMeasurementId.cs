using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

public class WaterMeasurementId : ValueObject
{
    public Guid Value { get; }

    private WaterMeasurementId(Guid value)
        => Value = value;

    public static WaterMeasurementId CreateUnique()
        => new WaterMeasurementId(Guid.NewGuid());

    public static WaterMeasurementId Create(Guid value)
        => new WaterMeasurementId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
