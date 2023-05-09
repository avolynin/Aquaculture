using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.Common.ValueObjects;

namespace Aquaculture.Domain.AquacultureContext;

public interface IFishTankRepository
{
    void Add(FishTank fishTank);
    IEnumerable<FishTank> GetAll();
    FishTank? Get(FishTankId fishTankId);
}
