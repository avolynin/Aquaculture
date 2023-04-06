using Aquaculture.Domain.UserAggregate;
using Aquaculture.Domain.UserAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IUserRepository
{
    User? GetByEmail(string email);
    User? Get(UserId userId);
    void Add(User user);
    void Update(User user);
}
