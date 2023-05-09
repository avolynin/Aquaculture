using System.Device.Location;

namespace Aquaculture.Contracts.Dto;

public record FishTankDto(
    Guid Id,
    string Name,
    float Volume,
    GeoCoordinate Location,
    List<FishInfoDto> FishInfoDtos,
    List<Guid> SensorIds);
