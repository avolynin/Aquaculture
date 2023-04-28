using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.SensorAggregate.Enumerations;
using Aquaculture.Domain.ControlWaterContext.SensorAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.SensorAggregate;

public class Sensor : AggregateRoot<SensorId>
{
    public FishTankId FishTankId { get; private set; }
    public string Name { get; private set; }
    public GeoCoordinate Location { get; private set; }
    public WaterParamId MeasurementParamId { get; private set; }
    public float? Depth { get; private set; }
    public SensorStatus Status { get; private set; }
    public SensorPlace Place { get; private set; }
    public int Charging { get; private set; }

    private Sensor(
        SensorId id,
        FishTankId fishTankId,
        string name,
        GeoCoordinate location,
        WaterParamId waterParamId,
        float depth,
        SensorPlace place)
        : base(id)
    {
        FishTankId = fishTankId;
        Name = name;
        Location = location;
        MeasurementParamId = waterParamId;
        Depth = depth;
        Place = place;
    }

    public static Sensor Create(
        FishTankId fishTankId,
        string name,
        GeoCoordinate location,
        WaterParamId waterParamId,
        float depth,
        SensorPlace place)
    {
        return new Sensor(
            SensorId.CreateUnique(),
            fishTankId,
            name,
            location,
            waterParamId,
            depth,
            place);
    }

#pragma warning restore CS8618
    private Sensor()
    {
    }
#pragma warning restore CS8618
}
