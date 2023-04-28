using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Models;
using Aquaculture.Domain.SensorAggregate.ControlWaterContext.ValueObjects;

namespace Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;

public class WaterMeasurement : AggregateRoot<WaterMeasurementId>
{
    public FishTankId FishTankId { get; private set; }
    public SensorId? SensorId { get; private set; }
    public WaterParamId WaterParamId { get; private set; }
    public float Value { get; private set; }
    public float Depth { get; private set; }
    public GeoCoordinate Location { get; private set; }
    public DateTime TimeStamp { get; private set; }

    private WaterMeasurement(
        WaterMeasurementId id,
        FishTankId fishTankId,
        DateTime timeStamp,
        WaterParamId waterParamId,
        float value,
        float depth,
        GeoCoordinate location,
        SensorId? sensorId = null)
        : base(id)
    {
        FishTankId = fishTankId;
        TimeStamp = timeStamp;
        WaterParamId = waterParamId;
        Value = value;
        Depth = depth;
        Location = location;
        SensorId = sensorId;
    }

    public static WaterMeasurement Create(
        FishTankId fishTankId,
        DateTime timeStamp,
        WaterParamId waterParamId,
        float value,
        float depth,
        GeoCoordinate location)
    {
        return new WaterMeasurement(
            WaterMeasurementId.CreateUnique(),
            fishTankId,
            timeStamp,
            waterParamId,
            value,
            depth,
            location);
    }

    public static WaterMeasurement CreateFromSensor(
        FishTankId fishTankId,
        DateTime timeStamp,
        WaterParamId waterParamId,
        float value,
        float depth,
        GeoCoordinate location,
        SensorId sensorId)
    {
        return new WaterMeasurement(
            WaterMeasurementId.CreateUnique(),
            fishTankId,
            timeStamp,
            waterParamId,
            value,
            depth,
            location,
            sensorId: sensorId);
    }

#pragma warning restore CS8618
    private WaterMeasurement()
    {
    }
#pragma warning restore CS8618
}
