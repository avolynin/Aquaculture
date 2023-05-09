using System.Device.Location;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Commands.Create;

public record CreateMeasurementCommand(
    Guid FishTankId,
    DateTime TimeStamp,
    Guid WaterParamId,
    float Value,
    float? Depth,
    GeoCoordinate Location) : IRequest<ErrorOr<WaterMeasurement>>;
