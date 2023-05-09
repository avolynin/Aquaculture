using Aquaculture.Domain.AquacultureContext;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.FishTanks.Quries.GetFishTanks;

public class GetFishTanksQueryHandler : IRequestHandler<GetFishTanksQuery, ErrorOr<List<FishTank>>>
{
    private readonly IFishTankRepository _fishTankRepository;

    public GetFishTanksQueryHandler(IFishTankRepository fishTankRepository)
    {
        _fishTankRepository = fishTankRepository;
    }

    public async Task<ErrorOr<List<FishTank>>> Handle(GetFishTanksQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_fishTankRepository.GetAll() is not List<FishTank> fishTanks)
        {
            return Errors.FishTank.NotFoundFishTanks;
        }

        return fishTanks;
    }
}
