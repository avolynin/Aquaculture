namespace Aquaculture.Contracts.Dto;

public record WaterMeasurementDto(
    Guid Id,
    Guid FishTankId,
    DateTime TimeStamp,
    WaterParamsDto WaterParams);
