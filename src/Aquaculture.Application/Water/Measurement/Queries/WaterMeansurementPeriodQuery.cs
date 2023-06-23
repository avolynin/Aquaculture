using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Queries;

public record WaterMeansurementPeriodQuery(
    Guid FishTankId,
    DateTime From,
    DateTime To) : IRequest<ErrorOr<List<WaterMeasurement>>>;
