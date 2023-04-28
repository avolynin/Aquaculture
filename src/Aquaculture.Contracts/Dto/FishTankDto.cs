namespace Aquaculture.Contracts.Dto;

public record FishTankDto(
    Guid Id,
    Guid WaterMeasurementId,
    Guid FishInfoId,
    string Name);
