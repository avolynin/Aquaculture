using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.FishInfoAggregate.ValueObjects;

public class FishTypeId : ValueObject
{
    public Guid Value { get; }

    private FishTypeId(Guid value)
        => Value = value;

    public static FishTypeId CreateUnique()
        => new FishTypeId(Guid.NewGuid());

    public static FishTypeId Create(Guid value)
        => new FishTypeId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
