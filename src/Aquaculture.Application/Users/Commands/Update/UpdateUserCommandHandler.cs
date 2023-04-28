using Aquaculture.Application.Common;
using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.PersonalContext.UserAggregate;
using Aquaculture.Domain.PersonalContext.UserAggregate.ValueObjects;
using Aquaculture.Domain.Repositories;
using ErrorOr;
using MediatR;
using OneOf.Types;

namespace Aquaculture.Application.Users.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        UserId userId = UserId.Create(command.Id);

        if (_userRepository.Get(userId) is not User user)
        {
            return Errors.User.NotFoundUser;
        }

        user.Update(
            fullName: command.FullName,
            email: command.Email,
            role: command.Role,
            password: command.Password);

        _userRepository.Update(user);

        return user;
    }
}
