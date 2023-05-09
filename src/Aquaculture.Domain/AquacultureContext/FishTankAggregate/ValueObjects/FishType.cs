using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;

public class FishType : ValueObject
{
    public float Weight { get; }

    private FishType(float weight)
    {
        Weight = weight;
    }

    public static FishType Create(float weight)
        => new FishType(weight);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Weight;
    }
}
