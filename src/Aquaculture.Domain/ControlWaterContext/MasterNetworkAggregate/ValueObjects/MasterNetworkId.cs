using Aquaculture.Domain.ControlWaterContext.SensorAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;

public class MasterNetworkId : ValueObject
{
    public Guid Value { get; }

    private MasterNetworkId(Guid value)
        => Value = value;

    public static MasterNetworkId CreateUnique()
        => new MasterNetworkId(Guid.NewGuid());

    public static MasterNetworkId Create(Guid value)
        => new MasterNetworkId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
