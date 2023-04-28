using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.SensorAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate;

public class FishTank : AggregateRoot<FishTankId>
{
    private readonly List<FishInfo> _fishInfos = new();

    private readonly List<SensorId> _sensorIds = new();

    public string Name { get; private set; } = null!;
    public float Volume { get; private set; }
    public GeoCoordinate Location { get; set; }
    public IReadOnlyList<FishInfo> FishInfos => _fishInfos.AsReadOnly();
    public IReadOnlyList<SensorId> SensorIds => _sensorIds.AsReadOnly();

    private FishTank(
        FishTankId id,
        string name,
        float volume,
        GeoCoordinate location)
        : base(id)
    {
        Name = name;
        Volume = volume;
        Location = location;
    }

    public static FishTank Create(
        string name,
        float volume,
        GeoCoordinate location)
    {
        return new(
            FishTankId.CreateUnique(),
            name,
            volume,
            location);
    }

    public void CreateFishInfo(
        int numberFish,
        FishType type)
    {
        _fishInfos.Add(FishInfo.Create(numberFish, type));
    }

    public void AddFish(FishInfoId fishInfoId, int number)
    {
        var fishInfo = _fishInfos.Find(f => f.Id == fishInfoId);
        if (fishInfo is null) throw new Exception();

        fishInfo.AddFish(number);
    }

    public void CatchFish(FishInfoId fishInfoId, int number)
    {
        var fishInfo = _fishInfos.Find(f => f.Id == fishInfoId);
        if (fishInfo is null) throw new Exception();

        fishInfo.RemoveFish(number);
    }

    public float GetAvgWeight(List<FishInfoId>? fishInfoIds = null)
    {
        if (fishInfoIds == null)
        {
            return _fishInfos.Sum(s => s.Biomass);
        }
        else
        {
            return _fishInfos.IntersectBy(fishInfoIds, x => x.Id).Sum(s => s.Biomass);
        }
    }

#pragma warning restore CS8618
    private FishTank()
    {
    }
#pragma warning restore CS8618
}
