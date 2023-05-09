using Aquaculture.Domain.PersonalContext.UserAggregate;
using Aquaculture.Domain.PersonalContext.UserAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Persistance.AquacultureContext;

namespace Aquaculture.Infrastructure.Persistance.PersonalContext;

public class UserRepository : IUserRepository
{
    private readonly PersonalDbContext _dbContext;

    public UserRepository(PersonalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public User? GetByEmail(string email)
        => _dbContext.Users.SingleOrDefault(u => u.Email == email);

    public User? Get(UserId userId)
        => _dbContext.Users.Find(userId);
}
