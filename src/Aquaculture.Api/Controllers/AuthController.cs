using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Application.Users.Commands.Register;
using Aquaculture.Application.Users.Queries.Login;
using Aquaculture.Contracts.Dto;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquaculture.Api.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var command = _mapper.Map<RegisterCommand>(registerDto);
        var registerResult = await _sender.Send(command);

        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationDto>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var query = _mapper.Map<LoginQuery>(loginDto);
        var loginResult = await _sender.Send(query);

        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationDto>(authResult)),
            errors => Problem(errors));
    }
}
