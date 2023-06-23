using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.FishTypeAggregate;

public class FishType : AggregateRoot<FishTypeId>
{
    public string Name { get; private set; } = null!;
    public float Weight { get; private set; }
    public FishAge Age { get; private set; }
    public List<WaterParamId> ComfortParams { get; private set; }
    public List<WaterParamId> TolerantParams { get; private set; }
    public List<WaterParamId> CriticalParams { get; private set; }

    private FishType(
        FishTypeId id,
        string name,
        float weight,
        FishAge fishAge,
        List<WaterParamId> сomfortParams,
        List<WaterParamId> tolerantParams,
        List<WaterParamId> criticalParams)
        : base(id)
    {
        Name = name;
        Weight = weight;
        Age = fishAge;
        ComfortParams = сomfortParams;
        TolerantParams = tolerantParams;
        CriticalParams = criticalParams;
    }

    public static FishType Create(
        string name,
        float weight,
        FishAge fishAge,
        List<WaterParamId> сomfortParams,
        List<WaterParamId> tolerantParams,
        List<WaterParamId> criticalParams)
    {
        return new FishType(
            FishTypeId.CreateUnique(),
            name,
            weight,
            fishAge,
            сomfortParams,
            tolerantParams,
            criticalParams);
    }

#pragma warning restore CS8618
    private FishType()
    {
    }
#pragma warning restore CS8618
}
