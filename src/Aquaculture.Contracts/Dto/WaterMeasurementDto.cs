using System.Device.Location;

namespace Aquaculture.Contracts.Dto;

public record WaterMeasurementDto(
    Guid Id,
    Guid FishTankId,
    DateTime TimeStamp,
    Guid WaterParamId,
    float Value,
    float? Depth,
    GeoCoordinate Location,
    Guid? SensorId);
