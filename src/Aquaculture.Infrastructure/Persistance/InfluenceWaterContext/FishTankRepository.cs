using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.InfluenceWaterContext.FishTankAggregate;
using Aquaculture.Domain.InfluenceWaterContext.Repositories;

namespace Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;

public class FishTankRepository : IFishTankRepository
{
    private readonly InfluenceWaterDbContext _dbContext;

    public FishTankRepository(InfluenceWaterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(FishTank fishTank)
    {
        _dbContext.FishTanks.Add(fishTank);
        _dbContext.SaveChanges();
    }

    public FishTank? Get(FishTankId fishTankId)
        => _dbContext.FishTanks.Find(fishTankId);
}
