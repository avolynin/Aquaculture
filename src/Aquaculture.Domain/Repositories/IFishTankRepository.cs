using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IFishTankRepository
{
    void Add(FishTank fishTank);
    IEnumerable<FishTank> GetAll();
    FishTank? Get(FishTankId fishTankId);
}
