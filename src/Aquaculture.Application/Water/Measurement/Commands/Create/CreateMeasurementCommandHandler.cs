using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using Aquaculture.Domain.WaterMeasurementAggreate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Commands.Create;

public class CreateMeasurementCommandHandler :
    IRequestHandler<CreateMeasurementCommand, ErrorOr<WaterMeasurement>>
{
    private readonly IWaterMeasurementRepository _measurementRepository;

    public CreateMeasurementCommandHandler(
        IWaterMeasurementRepository measurementRepository)
    {
        _measurementRepository = measurementRepository;
    }

    public async Task<ErrorOr<WaterMeasurement>> Handle(CreateMeasurementCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var fishTankId = FishTankId.Create(command.FishTankId);
        var waterParams = command.WaterParams;

        if (_measurementRepository.Get(fishTankId, command.TimeStamp) is not null)
        {
            return Errors.WaterMeasurement.DuplicateMeasurement;
        }

        WaterMeasurement measurement = WaterMeasurement.Create(
            fishTankId,
            command.TimeStamp,
            WaterParams.Create(
                waterParams.Temperature,
                waterParams.DissolvedOxygen,
                waterParams.Acidity,
                waterParams.Alkalinity,
                waterParams.CarbonDioxide,
                waterParams.Temperature));

        _measurementRepository.Add(measurement);

        return measurement;
    }
}
