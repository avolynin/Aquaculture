using Aquaculture.Domain.WaterMeasurementAggreate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Commands.Create;

public record CreateMeasurementCommand(
    Guid FishTankId,
    DateTime TimeStamp,
    WaterParams WaterParams) : IRequest<ErrorOr<WaterMeasurement>>;
