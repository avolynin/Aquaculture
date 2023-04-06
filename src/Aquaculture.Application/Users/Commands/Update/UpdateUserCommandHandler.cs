using Aquaculture.Application.Common;
using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.Repositories;
using Aquaculture.Domain.UserAggregate;
using Aquaculture.Domain.UserAggregate.ValueObjects;
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

        if (_userRepository.GetByEmail(command.Email) is not User user)
        {
            return Errors.User.NotFoundUser;
        }

        user = User.Create(
            userId,
            command.FullName ?? user.FullName,
            command.Email ?? user.Email,
            command.Role ?? user.Role,
            command.Password ?? user.Password);
        _userRepository.Update(user);

        return user;
    }
}
