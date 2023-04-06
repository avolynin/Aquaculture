using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
        => Value = value;

    public static UserId CreateUnique()
        => new UserId(Guid.NewGuid());

    public static UserId Create(Guid value)
        => new UserId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
