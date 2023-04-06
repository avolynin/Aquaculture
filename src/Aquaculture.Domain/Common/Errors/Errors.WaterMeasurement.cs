using ErrorOr;

namespace Aquaculture.Domain.Common.Errors;

public static partial class Errors
{
    public static class WaterMeasurement
    {
        public static Error DuplicateMeasurement => Error.Conflict(
            code: "WaterMeasurement.DuplicateMeasurement",
            description: "Measurement already exist!");

        public static Error NotFoundMeasurement => Error.NotFound(
            code: "WaterMeasurement.NotFoundMeasurement",
            description: "Measurement not found!");
    }
}
