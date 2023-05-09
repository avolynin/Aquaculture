using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IPumpRepository
{
    void Add(Pump pump);
    Pump? Get(PumpId pumpId);
}
