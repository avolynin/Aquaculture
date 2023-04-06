using System.Diagnostics.Metrics;
using Aquaculture.Domain.FishTankAggregate;
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
}
