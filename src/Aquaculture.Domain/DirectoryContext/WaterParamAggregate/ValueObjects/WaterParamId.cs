using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;

public class WaterParamId : ValueObject
{
    public Guid Value { get; }

    private WaterParamId(Guid value)
        => Value = value;

    public static WaterParamId CreateUnique()
        => new WaterParamId(Guid.NewGuid());

    public static WaterParamId Create(Guid value)
        => new WaterParamId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}