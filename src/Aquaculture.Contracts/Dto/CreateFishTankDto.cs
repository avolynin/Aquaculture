using System.Device.Location;

namespace Aquaculture.Contracts.Dto;

public record CreateFishTankDto(
    string Name,
    float Volume,
    GeoCoordinate Location);
