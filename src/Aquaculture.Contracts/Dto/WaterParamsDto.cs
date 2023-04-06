namespace Aquaculture.Contracts.Dto;

public record WaterParamsDto(
    float Temperature,
    float DissolvedOxygen,
    float Acidity,
    float Alkalinity,
    float CarbonDioxide,
    float Ammonia);
