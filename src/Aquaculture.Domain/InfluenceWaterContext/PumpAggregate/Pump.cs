using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;

public class Pump : AggregateRoot<PumpId>
{
    public bool IsEnable { get; private set; }
    public string Model { get; private set; }
    public float Efficiency { get; private set; }
    public DateTime OperatingTime { get; set; }

    public Pump(
        PumpId id,
        string model,
        float efficiency,
        DateTime operatingTimeBefore)
        : base(id)
    {
        Model = model;
        Efficiency = efficiency;
        OperatingTime = operatingTimeBefore;
    }

#pragma warning restore CS8618
    private Pump()
    {
    }
#pragma warning restore CS8618
}
