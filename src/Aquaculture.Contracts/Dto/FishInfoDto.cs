namespace Aquaculture.Contracts.Dto;

public record FishInfoDto(
    Guid FishInfoId,
    int NumberFish,
    float Biomass,
    Guid FishTypeId,
    AnomalyDto AnomalyDto,
    DateTime CommitedDate,
    DateTime CreatedDate);
