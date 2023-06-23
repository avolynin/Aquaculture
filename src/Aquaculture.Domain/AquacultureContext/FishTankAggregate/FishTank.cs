using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate;

public class FishTank : AggregateRoot<FishTankId>
{
    private readonly List<FishInfo> _fishInfos = new();

    public string Name { get; private set; } = null!;
    public float Volume { get; private set; }
    public GeoCoordinate Location { get; set; }
    public MasterNetworkId MasterNetworkId { get; set; }
    public IReadOnlyList<FishInfo> FishInfos => _fishInfos.AsReadOnly();

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
            location)
        {
            MasterNetworkId = MasterNetworkId.Create(Guid.Empty)
        };
    }

    public void CreateFishInfo(
        int numberFish,
        FishTypeId typeId)
    {
        _fishInfos.Add(FishInfo.Create(numberFish, typeId));
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

    public void MountMasterNetwork(MasterNetworkId masterId)
    {
        MasterNetworkId = masterId;
    }

#pragma warning restore CS8618
    private FishTank()
    {
    }
#pragma warning restore CS8618
}
