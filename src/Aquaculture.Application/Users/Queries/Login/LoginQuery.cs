using Aquaculture.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
