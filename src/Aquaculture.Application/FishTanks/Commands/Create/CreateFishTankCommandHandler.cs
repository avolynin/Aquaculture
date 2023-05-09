using Aquaculture.Application.Common;
using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Application.Users.Commands.Register;
using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Domain.AquacultureContext;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.FishTanks.Commands.Create;

public class CreateFishTankCommandHandler :
    IRequestHandler<CreateFishTankCommand, ErrorOr<FishTank>>
{
    private readonly IFishTankRepository _fishTankRepository;

    public CreateFishTankCommandHandler(IFishTankRepository fishTankRepository)
    {
        _fishTankRepository = fishTankRepository;
    }

    public async Task<ErrorOr<FishTank>> Handle(CreateFishTankCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        FishTank fishTank = FishTank.Create(
            name: command.Name,
            volume: command.Volume,
            location: command.Location);

        _fishTankRepository.Add(fishTank);

        return fishTank;
    }
}
