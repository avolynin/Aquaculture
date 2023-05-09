using System.Device.Location;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
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
        var waterParamId = WaterParamId.Create(command.WaterParamId);

        if (_measurementRepository.Get(fishTankId, command.TimeStamp) is not null)
        {
            return Errors.WaterMeasurement.DuplicateMeasurement;
        }

        WaterMeasurement measurement = WaterMeasurement.Create(
            fishTankId: fishTankId,
            timeStamp: command.TimeStamp,
            waterParamId: waterParamId,
            value: command.Value,
            depth: command.Depth,
            location: command.Location);

        _measurementRepository.Add(measurement);

        return measurement;
    }
}
