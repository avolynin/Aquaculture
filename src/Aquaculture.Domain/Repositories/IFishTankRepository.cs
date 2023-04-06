using Aquaculture.Domain.FishTankAggregate;

namespace Aquaculture.Domain.Repositories;

public interface IFishTankRepository
{
    void Add(FishTank fishTank);
}
