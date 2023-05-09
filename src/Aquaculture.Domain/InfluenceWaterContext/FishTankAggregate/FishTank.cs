using System.Device.Location;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.InfluenceWaterContext.FishTankAggregate;

public class FishTank : AggregateRoot<FishTankId>
{
    public string Name { get; private set; }
    public GeoCoordinate Location { get; private set; }
    public DateTime RelocatedDate { get; set; }

    public FishTank(
        FishTankId id,
        string name,
        GeoCoordinate location)
        : base(id)
    {
        Name = name;
        Location = location;
    }

    public void Relocate(GeoCoordinate newCoord)
    {
        Location = newCoord;
        RelocatedDate = DateTime.UtcNow;
    }

#pragma warning restore CS8618
    private FishTank()
    {
    }
#pragma warning restore CS8618
}
