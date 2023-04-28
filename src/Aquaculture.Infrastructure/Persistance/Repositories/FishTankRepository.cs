using System.Diagnostics.Metrics;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Persistence;

namespace Aquaculture.Infrastructure.Persistance.Repositories;

public class FishTankRepository : IFishTankRepository
{
    private readonly AquacultureDbContext _dbContext;

    public FishTankRepository(AquacultureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(FishTank fishTank)
    {
        _dbContext.Add(fishTank);
        _dbContext.SaveChanges();
    }

    public IEnumerable<FishTank> GetAll()
    {
        return _dbContext.FishTanks.ToList();
    }

    public FishTank? Get(FishTankId fishTankId)
    {
        return _dbContext.FishTanks.Find(fishTankId);
    }
}
