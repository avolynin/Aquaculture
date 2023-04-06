using Aquaculture.Domain.UserAggregate;

namespace Aquaculture.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
