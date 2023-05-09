namespace Aquaculture.Contracts.Dto;

public record AnomalyDto(
    List<Guid> DiseasesIds,
    int DeadFish);
