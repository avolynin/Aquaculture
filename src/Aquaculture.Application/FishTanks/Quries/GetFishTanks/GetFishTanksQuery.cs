using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.FishTanks.Quries.GetFishTanks;

public record GetFishTanksQuery()
    : IRequest<ErrorOr<List<FishTank>>>;
