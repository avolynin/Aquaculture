using System.Device.Location;

namespace Aquaculture.Contracts.Dto;

public record CreateWaterMeasurementDto(
    Guid FishTankId,
    DateTime TimeStamp,
    Guid WaterParamId,
    float Value,
    float? Depth,
    GeoCoordinate Location);
