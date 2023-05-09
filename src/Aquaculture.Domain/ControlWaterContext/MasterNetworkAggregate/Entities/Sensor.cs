using System.Device.Location;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Enumerations;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Entities;

public class Sensor : AggregateRoot<SensorId>
{
    public FishTankId FishTankId { get; private set; }
    public GeoCoordinate Location { get; private set; }
    public WaterParamId WaterParamId { get; private set; }
    public float? Depth { get; private set; }
    public SensorStatus Status { get; private set; }
    public SensorPlace Place { get; private set; }
    public int Charging { get; private set; }

    private Sensor(
        SensorId id,
        FishTankId fishTankId,
        GeoCoordinate location,
        WaterParamId waterParamId,
        float depth,
        SensorPlace place)
        : base(id)
    {
        FishTankId = fishTankId;
        Location = location;
        WaterParamId = waterParamId;
        Depth = depth;
        Place = place;
    }

    public static Sensor Create(
        SensorId id,
        FishTankId fishTankId,
        GeoCoordinate location,
        WaterParamId waterParamId,
        float depth,
        SensorPlace place)
    {
        return new Sensor(
            id,
            fishTankId,
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
