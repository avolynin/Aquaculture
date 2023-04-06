namespace Aquaculture.Domain.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if(obj is null || obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((ValueObject)obj);
    }

    public static bool operator ==(ValueObject left, ValueObject right)
        => left.Equals(right);
    public static bool operator !=(ValueObject left, ValueObject right)
        => !left.Equals(right);

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        if (other is null || other.GetType() != this.GetType())
        {
            return false;
        }

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
}
