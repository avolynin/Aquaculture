using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.FishTanks.Commands.Create;

public record CreateFishTankCommand(
    string Name,
    float Volume,
    GeoCoordinate Location) : IRequest<ErrorOr<FishTank>>;
