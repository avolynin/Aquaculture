using Aquaculture.Application.Users.Commands.Update;
using Aquaculture.Contracts.Dto;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquaculture.Api.Controllers;

[Route("api/user")]
[AllowAnonymous]
public class UserController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UserController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UserDto userDto)
    {
        var command = _mapper.Map<UpdateUserCommand>(userDto);
        var updateResult = await _sender.Send(command);

        return updateResult.Match(
            user => Ok(_mapper.Map<UserDto>(user)),
            errors => Problem(errors));
    }
}
