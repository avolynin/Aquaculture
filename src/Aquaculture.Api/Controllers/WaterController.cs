using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Application.Water.Measurement.Queries;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.WaterMeasurementAggreate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquaculture.Api.Controllers;

[Route("api/water")]
[AllowAnonymous]
public class WaterController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public WaterController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("measurement")]
    public async Task<IActionResult> CreateMeasurement(CreateWaterMeasurementDto measurementDto)
    {
        var command = _mapper.Map<CreateMeasurementCommand>(measurementDto);
        var createMeasurementResult = await _sender.Send(command);

        return createMeasurementResult.Match(
            waterMeasurement => Ok(_mapper.Map<WaterMeasurementDto>(waterMeasurement)),
            errors => Problem(errors));
    }

    [HttpGet("measurement/{fishTankId}")]
    public async Task<IActionResult> GetMeasurement(Guid fishTankId)
    {
        var query = new WaterMeansurementByFishTankQuery(fishTankId);
        var queryMeasurementsResult = await _sender.Send(query);

        return queryMeasurementsResult.Match(
            measurementsResult =>
            {
                var waterMeasurementDtos = new List<WaterMeasurementDto>();
                foreach (var item in measurementsResult)
                {
                    waterMeasurementDtos.Add(_mapper.Map<WaterMeasurementDto>(item));
                }

                return Ok(waterMeasurementDtos);
            },
            errors => Problem(errors));
    }
}
