using Aquaculture.Domain.UserAggregate;

namespace Aquaculture.Application.Services.Users.Common;
public record AuthenticationResult(User User, string Token);
