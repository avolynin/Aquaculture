using Aquaculture.Domain.PersonalContext.UserAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Commands.Update;

public record UpdateUserCommand(
    Guid Id,
    string? FullName,
    string? Role,
    string? Email,
    string? Password) : IRequest<ErrorOr<User>>;
