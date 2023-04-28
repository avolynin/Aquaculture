using Aquaculture.Domain.PersonalContext.UserAggregate;

namespace Aquaculture.Application.Services.Users.Common;
public record AuthenticationResult(User User, string Token);
