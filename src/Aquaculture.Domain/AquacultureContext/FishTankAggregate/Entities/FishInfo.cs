using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.Models;
using Aquaculture.Domain.Repositories;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;

public class FishInfo : Entity<FishInfoId>
{
    public int NumberFish { get; private set; }
    public float Biomass { get; private set; }
    public FishTypeId TypeId { get; private set; }
    public FishType Type { get; init; }
    public Anomaly? Anomaly { get; private set; } = null;
    public DateTime CommitedDate { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private FishInfo(
        FishInfoId id,
        int numberFish,
        FishTypeId typeId,
        FishType type)
        : base(id)
    {
        NumberFish = numberFish;
        TypeId = typeId;
        Type = type;
        Biomass = NumberFish * Type.Weight;
    }

    public static FishInfo Create(
        int numberFish,
        FishTypeId typeId,
        FishType type)
    {
        return new FishInfo(
            FishInfoId.CreateUnique(),
            numberFish,
            typeId,
            type)
        {
            CommitedDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow
        };
    }

    public void AddFish(int number)
    {
        NumberFish += number;
        Biomass += number * Type.Weight;
        CommitedDate = DateTime.UtcNow;
    }

    public void RemoveFish(int number)
    {
        NumberFish -= number;
        Biomass -= number * Type.Weight;
        CommitedDate = DateTime.UtcNow;
    }

#pragma warning restore CS8618
    private FishInfo()
    {
    }
#pragma warning restore CS8618
}
