using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Models;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

namespace Aquaculture.Domain.FishTankAggregate;

public class FishTank : AggregateRoot<FishTankId>
{
    public WaterMeasurementId WaterMeasurementId { get; private set; }

    private FishTank(FishTankId id, WaterMeasurementId waterMeasurementId)
        : base(id)
    {
        WaterMeasurementId = waterMeasurementId;
    }

    public static FishTank Create(WaterMeasurementId waterMeasurementId)
    {
        return new(FishTankId.CreateUnique(), waterMeasurementId);
    }
}
