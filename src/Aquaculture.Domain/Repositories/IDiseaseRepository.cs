using Aquaculture.Domain.DirectoryContext.DiseaseAggregate;
using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IDiseaseRepository
{
    void Add(Disease disease);
    Disease? Get(DiseaseId diseaseId);
    void Update(Disease disease);
    void Delete(Disease disease);
}
