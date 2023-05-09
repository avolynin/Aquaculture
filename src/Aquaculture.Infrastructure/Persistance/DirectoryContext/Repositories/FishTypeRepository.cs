using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Repositories;

public class FishTypeRepository : IFishTypeRepository
{
    private readonly DirectoryDbContext _dbContext;

    public FishTypeRepository(DirectoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(FishType fishType)
    {
        _dbContext.FishTypes.Add(fishType);
        _dbContext.SaveChanges();
    }

    public void Delete(FishType fishType)
    {
        _dbContext.FishTypes.Remove(fishType);
        _dbContext.SaveChanges();
    }

    public FishType? Get(FishTypeId fishTypeId)
        => _dbContext.FishTypes.Find(fishTypeId);

    public void Update(FishType fishType)
    {
        _dbContext.FishTypes.Update(fishType);
        _dbContext.SaveChanges();
    }
}
