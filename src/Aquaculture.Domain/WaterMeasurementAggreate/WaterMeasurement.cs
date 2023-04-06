using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Models;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

namespace Aquaculture.Domain.WaterMeasurementAggreate;

public class WaterMeasurement : AggregateRoot<WaterMeasurementId>
{
    public FishTankId FishTankId { get; private set; }
    public DateTime TimeStamp { get; private set; }
    public WaterParams WaterParams { get; private set; }

    private WaterMeasurement(
        WaterMeasurementId id,
        FishTankId fishTankId,
        DateTime timeStamp,
        WaterParams waterParams)
        : base(id)
    {
        FishTankId = fishTankId;
        TimeStamp = timeStamp;
        WaterParams = waterParams;
    }

    public static WaterMeasurement Create(
        FishTankId fishTankId,
        DateTime timeStamp,
        WaterParams waterParam)
    {
        return new WaterMeasurement(
            WaterMeasurementId.CreateUnique(),
            fishTankId,
            timeStamp,
            waterParam);
    }

#pragma warning restore CS8618
    private WaterMeasurement()
    {
    }
#pragma warning restore CS8618
}
