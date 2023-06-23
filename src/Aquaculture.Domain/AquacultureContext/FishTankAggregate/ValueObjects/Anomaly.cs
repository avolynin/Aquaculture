using Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;
using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;

public class Anomaly : ValueObject
{
    private readonly List<DiseaseId> _diseaseIds = new();

    public int DeadFish { get; }
    public IReadOnlyList<DiseaseId> DiseaseIds => _diseaseIds.AsReadOnly();

    private Anomaly(List<DiseaseId> diseaseIds, int deadFish)
    {
        _diseaseIds = diseaseIds;
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
