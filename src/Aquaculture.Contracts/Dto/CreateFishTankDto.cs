namespace Aquaculture.Contracts.Dto;

public record CreateFishTankDto(
    Guid WaterMeasurementId,
    Guid FishInfoId,
    string Name);
