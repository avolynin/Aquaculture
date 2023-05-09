using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.InfluenceWaterContext.FishTankAggregate;

namespace Aquaculture.Domain.InfluenceWaterContext.Repositories;

public interface IFishTankRepository
{
    void Add(FishTank fishTank);
    FishTank? Get(FishTankId fishTankId);
}
