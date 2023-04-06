namespace Aquaculture.Contracts.Dto;

public record CreateWaterMeasurementDto(
    Guid FishTankId,
    DateTime TimeStamp,
    WaterParamsDto WaterParams);
