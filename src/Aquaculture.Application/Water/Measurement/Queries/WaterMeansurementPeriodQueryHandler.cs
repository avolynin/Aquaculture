using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Water.Measurement.Queries;

public class WaterMeansurementPeriodQueryHandler : IRequestHandler<WaterMeansurementPeriodQuery, ErrorOr<List<WaterMeasurement>>>
{
    private readonly IWaterMeasurementRepository _waterMeasurementRepository;

    public WaterMeansurementPeriodQueryHandler(IWaterMeasurementRepository waterMeasurementRepository)
    {
        _waterMeasurementRepository = waterMeasurementRepository;
    }

    public async Task<ErrorOr<List<WaterMeasurement>>> Handle(WaterMeansurementPeriodQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var fishTankId = FishTankId.Create(query.FishTankId);

        if (_waterMeasurementRepository.GetByPeriod(fishTankId, query.From, query.To) is not List<WaterMeasurement> waterMeasurements)
        {
            return Errors.WaterMeasurement.NotFoundMeasurement;
        }

        return waterMeasurements;
    }
}
