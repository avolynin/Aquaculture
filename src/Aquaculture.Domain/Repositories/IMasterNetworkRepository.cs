using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Entities;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IMasterNetworkRepository
{
    void Add(MasterNetwork master);
    MasterNetwork? Get(MasterNetworkId masterId);
}
