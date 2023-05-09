using System.Diagnostics.Metrics;
using Aquaculture.Domain.AquacultureContext;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.Common.ValueObjects;

namespace Aquaculture.Infrastructure.Persistance.AquacultureContext;

public class FishTankRepository : IFishTankRepository
{
    private readonly AquacultureDbContext _dbContext;

    public FishTankRepository(AquacultureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(FishTank fishTank)
    {
        _dbContext.FishTanks.Add(fishTank);
        _dbContext.SaveChanges();
    }

    public IEnumerable<FishTank> GetAll()
        => _dbContext.FishTanks.ToList();

    public FishTank? Get(FishTankId fishTankId)
        => _dbContext.FishTanks.Find(fishTankId);
}
