using ErrorOr;

namespace Aquaculture.Domain.Common.Errors;

public static partial class Errors
{
    public static class FishTank
    {
        public static Error NotFoundFishTanks => Error.NotFound(
            code: "FishTank.NotFoundFishTanks",
            description: "FishTanks not found!");
    }
}
