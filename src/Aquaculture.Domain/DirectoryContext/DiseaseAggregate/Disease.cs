using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.DiseaseAggregate;

public class Disease : AggregateRoot<DiseaseId>
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }

    private Disease(
        DiseaseId id,
        string name,
        string? description = null)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public static Disease Create(
        string name,
        string? description = null)
    {
        return new Disease(
            DiseaseId.CreateUnique(),
            name,
            description);
    }

#pragma warning restore CS8618
    private Disease()
    {
    }
#pragma warning restore CS8618
}
