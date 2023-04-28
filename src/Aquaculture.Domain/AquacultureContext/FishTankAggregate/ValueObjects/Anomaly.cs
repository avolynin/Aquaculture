using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;

public class Anomaly : ValueObject
{
    public List<DiseaseId> DiseaseIds { get; }
    public int DeadFish { get; }

    private Anomaly(List<DiseaseId> diseaseIds, int deadFish)
    {
        DiseaseIds = diseaseIds;
        DeadFish = deadFish;
    }

    public static Anomaly Create(List<DiseaseId> diseaseIds, int deadFish)
        => new Anomaly(diseaseIds, deadFish);

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var diseaseId in DiseaseIds)
            yield return diseaseId;
        yield return DeadFish;
    }
}
