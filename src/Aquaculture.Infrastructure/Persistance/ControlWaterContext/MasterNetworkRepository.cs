using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;

namespace Aquaculture.Infrastructure.Persistance.ControlWaterContext;

public class MasterNetworkRepository : IMasterNetworkRepository
{
    private readonly WaterControlDbContext _dbContext;

    public MasterNetworkRepository(WaterControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(MasterNetwork master)
    {
        _dbContext.MasterNetworks.Add(master);
        _dbContext.SaveChanges();
    }

    public MasterNetwork? Get(MasterNetworkId masterId)
        => _dbContext.MasterNetworks.Find(masterId);
}
