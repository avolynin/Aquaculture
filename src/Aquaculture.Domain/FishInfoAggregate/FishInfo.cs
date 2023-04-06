using Aquaculture.Domain.FishInfoAggregate.Entities;
using Aquaculture.Domain.FishInfoAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.FishInfoAggregate;

public class FishInfo : AggregateRoot<FishInfoId>
{
    public DateTime BornDate { get; private set; }
    public TimeSpan Age => DateTime.UtcNow.Subtract(BornDate);
    public float AvgWeight { get; private set; }
    public FishType FishType { get; private set; }

    private FishInfo(
        FishInfoId id,
        DateTime bornDate,
        float avgWeight,
        FishType fishType)
        : base(id)
    {
        BornDate = bornDate;
        AvgWeight = avgWeight;
        FishType = fishType;
    }

    public static FishInfo Create(
        DateTime bornDate,
        float avgWeight,
        FishType fishType)
    {
        return new FishInfo(
            FishInfoId.CreateUnique(),
            bornDate,
            avgWeight,
            fishType);
    }

#pragma warning restore CS8618
    private FishInfo()
    {
    }
#pragma warning restore CS8618
}
