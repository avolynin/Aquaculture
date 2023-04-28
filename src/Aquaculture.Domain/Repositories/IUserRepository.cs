using Aquaculture.Domain.PersonalContext.UserAggregate;
using Aquaculture.Domain.PersonalContext.UserAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IUserRepository
{
    User? GetByEmail(string email);
    User? Get(UserId userId);
    void Add(User user);
    void Update(User user);
}
