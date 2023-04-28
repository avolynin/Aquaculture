using Aquaculture.Application.FishTanks.Commands.Create;
using Aquaculture.Application.FishTanks.Quries.GetFishTanks;
using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Contracts.Dto;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquaculture.Api.Controllers;

[Route("api/fishTanks")]
[AllowAnonymous]
public class FishTankController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FishTankController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetFishTanksQuery();
        var queryResult = await _sender.Send(query);

        return queryResult.Match(
            measurementsResult =>
            {
                var fishtankDtos = new List<FishTankDto>();
                foreach (var item in measurementsResult)
                {
                    fishtankDtos.Add(_mapper.Map<FishTankDto>(item));
                }

                return Ok(fishtankDtos);
            },
            errors => Problem(errors));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateFishTank(CreateFishTankDto fishTankDto)
    {
        var command = _mapper.Map<CreateFishTankCommand>(fishTankDto);
        var createFishTankResult = await _sender.Send(command);

        return createFishTankResult.Match(
            fishTank => Ok(_mapper.Map<FishTankDto>(fishTank)),
            errors => Problem(errors));
    }
}
