using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.FishTanks.Commands.Create;

public record CreateFishTankCommand(
    Guid WaterMeasurementId,
    Guid FishInfoId,
    string Name) : IRequest<ErrorOr<FishTank>>;
