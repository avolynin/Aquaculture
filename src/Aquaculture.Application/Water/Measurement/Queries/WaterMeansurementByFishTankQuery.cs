using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Queries;

public record WaterMeansurementByFishTankQuery(
    Guid FishTankId) : IRequest<ErrorOr<List<WaterMeasurement>>>;
