using Aquaculture.Domain.FishInfoAggregate.ValueObjects;
using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Models;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

namespace Aquaculture.Domain.FishInfoAggregate.Entities;

public class FishType : Entity<FishTypeId>
{
    public string Name { get; private set; } = null!;
    public WaterParams ComfortParams { get; private set; }
    public WaterParams TolerantParams { get; private set; }
    public WaterParams CriticalParams { get; private set; }

    private FishType(
        FishTypeId id,
        string name,
        WaterParams comfortParams,
        WaterParams tolerantParams,
        WaterParams criticalParams)
        : base(id)
    {
        Name = name;
        ComfortParams = comfortParams;
        TolerantParams = tolerantParams;
        CriticalParams = criticalParams;
    }

    public static FishType Create(
        string name,
        WaterParams comfortParams,
        WaterParams tolerantParams,
        WaterParams criticalParams)
    {
        return new FishType(
            FishTypeId.CreateUnique(),
            name,
            comfortParams,
            tolerantParams,
            criticalParams);
    }

#pragma warning restore CS8618
    private FishType()
    {
    }
#pragma warning restore CS8618
}
