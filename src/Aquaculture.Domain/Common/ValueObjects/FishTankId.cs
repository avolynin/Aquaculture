using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.Common.ValueObjects;

public class FishTankId : ValueObject
{
    public Guid Value { get; }

    private FishTankId(Guid value)
        => Value = value;

    public static FishTankId CreateUnique()
        => new FishTankId(Guid.NewGuid());

    public static FishTankId Create(Guid value)
        => new FishTankId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
