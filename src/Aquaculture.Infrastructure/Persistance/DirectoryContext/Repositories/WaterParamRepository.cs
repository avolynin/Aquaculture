using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.PersonalContext.UserAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Persistance.AquacultureContext;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Repositories;

public class WaterParamRepository : IWaterParamRepository
{
    private readonly DirectoryDbContext _dbContext;

    public WaterParamRepository(DirectoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(WaterParam waterParam)
    {
        _dbContext.WaterParams.Add(waterParam);
        _dbContext.SaveChanges();
    }

    public void Delete(WaterParam waterParam)
    {
        _dbContext.WaterParams.Remove(waterParam);
        _dbContext.SaveChanges();
    }

    public WaterParam? Get(WaterParamId waterParamId)
        => _dbContext.WaterParams.Find(waterParamId);

    public void Update(WaterParam waterParam)
    {
        _dbContext.WaterParams.Update(waterParam);
        _dbContext.SaveChanges();
    }
}
