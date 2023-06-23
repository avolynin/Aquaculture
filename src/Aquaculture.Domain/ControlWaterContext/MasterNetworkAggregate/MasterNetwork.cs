using System.Device.Location;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Entities;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;

public class MasterNetwork : AggregateRoot<MasterNetworkId>
{
    private readonly List<Sensor> _sensors = new();

    public Uri Url { get; private set; }
    public GeoCoordinate Location { get; private set; }
    public FishTankId FishTankId { get; private set; }

    /// <summary>
    /// Возвращает установлена ли связь с мастером сети.
    /// </summary>
    public bool IsConntected { get; private set; }

    /// <summary>
    /// Возвращает время задержки между запросами в минутах.
    /// </summary>
    public int Duration { get; private set; }
    public IReadOnlyList<Sensor> Sensors => _sensors.AsReadOnly();

    private MasterNetwork(
        MasterNetworkId id,
        FishTankId fishTankId,
        Uri url,
        GeoCoordinate location,
        int duration)
        : base(id)
    {
        Url = url;
        FishTankId = fishTankId;
        Location = location;
        Duration = duration;
    }

    public static MasterNetwork Create(
        FishTankId fishTankId,
        Uri url,
        GeoCoordinate location,
        int duration)
    {
        return new MasterNetwork(
            MasterNetworkId.CreateUnique(),
            fishTankId,
            url,
            location,
            duration)
        {
            IsConntected = false
        };
    }

    public void Connect()
    {
        // request to url
        // if OK IsConntected = true
        // set sensors
        // else IsConnected = false
    }

#pragma warning restore CS8618
    private MasterNetwork()
    {
    }
#pragma warning restore CS8618
}
