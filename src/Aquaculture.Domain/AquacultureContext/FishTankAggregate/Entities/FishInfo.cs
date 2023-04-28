using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;

public class FishInfo : Entity<FishInfoId>
{
    public int NumberFish { get; private set; }
    public float Biomass { get; private set; }
    public FishTypeId TypeId { get; private set; }
    public Anomaly? Anomaly { get; private set; } = null;
    public DateTime CommitedDate { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private FishInfo(
        FishInfoId id,
        int numberFish,
        FishTypeId typeId)
        : base(id)
    {
        NumberFish = numberFish;
        TypeId = typeId;
        Biomass = NumberFish * Type.Weight;
    }

    public static FishInfo Create(
        int numberFish,
        FishTypeId typeId)
    {
        return new FishInfo(
            FishInfoId.CreateUnique(),
            numberFish,
            typeId)
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
