using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.FishInfoAggregate.ValueObjects;

public class FishInfoId : ValueObject
{
    public Guid Value { get; }

    private FishInfoId(Guid value)
        => Value = value;

    public static FishInfoId CreateUnique()
        => new FishInfoId(Guid.NewGuid());

    public static FishInfoId Create(Guid value)
        => new FishInfoId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
