using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;

public class FishAge : ValueObject
{
    public string Name { get; }
    public string? Code { get; } = null;

    private FishAge(string name, string? code)
    {
        Name = name;
        Code = code;
    }

    public static FishAge Create(string name, string? code = null)
        => new FishAge(name, code);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        if (Code != null) yield return Code;
    }
}
