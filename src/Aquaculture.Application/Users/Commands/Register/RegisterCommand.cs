using Aquaculture.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Commands.Register;

public record RegisterCommand(
    string FullName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
