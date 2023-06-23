namespace Aquaculture.Contracts.Dto;

public record WaterMeasurementsPeriodDto(
    Guid FishTankId,
    DateTime From,
    DateTime To);
