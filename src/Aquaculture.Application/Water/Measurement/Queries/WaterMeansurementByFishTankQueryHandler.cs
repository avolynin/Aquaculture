using System.Collections.Generic;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Queries;

public class WaterMeansurementByFishTankQueryHandler : IRequestHandler<WaterMeansurementByFishTankQuery, ErrorOr<List<WaterMeasurement>>>
{
    private readonly IWaterMeasurementRepository _waterMeasurementRepository;

    public WaterMeansurementByFishTankQueryHandler(IWaterMeasurementRepository waterMeasurementRepository)
    {
        _waterMeasurementRepository = waterMeasurementRepository;
    }

    public async Task<ErrorOr<List<WaterMeasurement>>> Handle(WaterMeansurementByFishTankQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var fishTankId = FishTankId.Create(query.FishTankId);

        if (_waterMeasurementRepository.GetBy(fishTankId) is not List<WaterMeasurement> waterMeasurements)
        {
            return Errors.WaterMeasurement.NotFoundMeasurement;
        }

        return waterMeasurements;
    }
}
