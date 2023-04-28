using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;

public class DiseaseId : ValueObject
{
    public Guid Value { get; }

    private DiseaseId(Guid value)
        => Value = value;

    public static DiseaseId CreateUnique()
        => new DiseaseId(Guid.NewGuid());

    public static DiseaseId Create(Guid value)
        => new DiseaseId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
