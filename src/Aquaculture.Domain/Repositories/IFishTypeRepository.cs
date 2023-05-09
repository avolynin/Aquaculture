using Aquaculture.Domain.DirectoryContext.FishTypeAggregate;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IFishTypeRepository
{
    void Add(FishType fishType);
    FishType? Get(FishTypeId fishTypeId);
    void Update(FishType fishType);
    void Delete(FishType fishType);
}
