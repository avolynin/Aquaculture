using Aquaculture.Domain.DirectoryContext.DiseaseAggregate;
using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Repositories;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly DirectoryDbContext _dbContext;

    public DiseaseRepository(DirectoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Disease disease)
    {
        _dbContext.Diseases.Add(disease);
        _dbContext.SaveChanges();
    }

    public void Delete(Disease disease)
    {
        _dbContext.Diseases.Remove(disease);
        _dbContext.SaveChanges();
    }

    public Disease? Get(DiseaseId diseaseId)
        => _dbContext.Diseases.Find(diseaseId);

    public void Update(Disease disease)
    {
        _dbContext.Diseases.Update(disease);
        _dbContext.SaveChanges();
    }
}
