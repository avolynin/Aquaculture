using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Persistance.AquacultureContext;

namespace Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;

public class PumpRepository : IPumpRepository
{
    private readonly InfluenceWaterDbContext _dbContext;

    public PumpRepository(InfluenceWaterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Pump pump)
    {
        _dbContext.Pumps.Add(pump);
        _dbContext.SaveChanges();
    }

    public Pump? Get(PumpId pumpId)
        => _dbContext.Pumps.Find(pumpId);
}
